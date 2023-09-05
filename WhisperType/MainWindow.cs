using System;
using System.Windows.Forms;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using NAudio.Wave;
using System.Diagnostics;
using System.Net.Http.Headers;
using WebRtcVadSharp;
using System.Runtime.InteropServices;
using NAudio.Utils;
using static System.Net.Mime.MediaTypeNames;
using System.Text.RegularExpressions;
using System.Text;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Whisper.net.Ggml;

namespace WhisperType
{   // icons from icon8.com
    public partial class MainWindow : Form
    {

        [DllImport("user32.dll")]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vlc);
        [DllImport("user32.dll")]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);


        private WaveInEvent waveIn;
        private byte[] rawDataArray;
        private int totalBytes;
        private string outputFile = "tempAudioTest.wav";
        private bool isRecording = false;
        static string whisperUrl = "https://api.openai.com/v1/audio/transcriptions";

        private WebRtcVad vad;
        private FrameLength frameLength = FrameLength.Is30ms;
        private int frameSize;

        private bool voiceDetected = false;
        private DateTime silenceGracePeriodInitialisationTime;

        private DateTime lastVoiceDetectedTimeStamp;

        // Metrics
        private Stopwatch stopwatch;
        private double lastSecondsToProcess = 0;
        private double lastWordsProcessed = 0;
        private double lastWordsPerSecond = 0;

        private string warningMessage;

        Config config;
        GgmlType previousLocalModel;

        private Stack<string> lastTranscriptionContent = new();

        public MainWindow()
        {
            InitializeComponent();
            SetupTrayIcon();
            //chkTopmost.Size = new Size(40, 40);  // Set desired size here

            config = Config.ExistingConfig; // This will ensure singleton instance is retrieved
            //config.WhisperRecognitionStrategy = 123; // change a value
            //config.LocalModel = 3; // change another value
            //config.Save(); // save changes back to the file

            // Metrics
            stopwatch = new Stopwatch();

            waveIn = new WaveInEvent();
            waveIn.DataAvailable += waveIn_DataAvailable;
            waveIn.RecordingStopped += waveIn_RecordingStopped;
            waveIn.WaveFormat = new WaveFormat(16000, 1);

            vad = new WebRtcVad()
            {
                OperatingMode = config.NoiseOperatingModel,
                FrameLength = frameLength,
                SampleRate = SampleRate.Is16kHz,
            };

            frameSize = (int)vad.SampleRate / 1000 * 2 * (int)frameLength;



            Debug.WriteLine(config.MsBeforeAutoStop.ToString());

            // Setting up the global 'record' hotkey (ctrl-alt-space)
            int MOD_CONTROL = 0x0002;
            int MOD_ALT = 0x0001;
            int VK_SPACE = 0x20;
            RegisterHotKey(this.Handle, 0, MOD_CONTROL | MOD_ALT, VK_SPACE);

            // Define the Ctrl-Backslash key
            int VK_BACKSLASH = 0xDC;
            // Register the hotkey
            RegisterHotKey(this.Handle, 1, MOD_CONTROL, VK_BACKSLASH);

            // Update UI selections with config
            // this.Invoke((Action)(() => chkAlwaysOnTop.Checked = config.AutoStopAfterSilence));
            this.Invoke((Action)(() => chkTypeText.Checked = config.TypeTextInActiveWindow));
            this.Invoke((Action)(() => chkCopyToClipboard.Checked = config.CopyToClipboard));
            AppState = AppState.Ready;

            toolTip1.SetToolTip(btnConfig, "Config");
            toolTip1.SetToolTip(chkTopmost, "Window always on top");
            toolTip1.SetToolTip(btnCopyText, "Copy text in text window to clipboard after each transcription");
            toolTip1.SetToolTip(chkTypeText, "After each transcription, type the most recent text into the active window");
            toolTip1.SetToolTip(btnUndoLast, "Undo");
            toolTip1.SetToolTip(btnClear, "Clear text window");
            toolTip1.SetToolTip(btnRecord, "Start/Stop recording");


            if (config.WhisperRecognitionStrategy == WhisperRecognitionStrategy.Local)
            {
                InitialiseLocalTranscription();
            }
            //waitingForm.ShowDialog("Loading, please wait..."));
            //if (config.WhisperRecognitionStrategy == WhisperRecognitionStrategy.Local)
            //{
            //    InitialiseLocalTranscriptionProvider();
            //}
            prgSilence.Maximum = config.MsBeforeAutoStop;

        }

        private void FormLoad(object sender, EventArgs e)
        {
            // Update UI selections with config
            // this.Invoke((Action)(() => chkAlwaysOnTop.Checked = config.AlwaysOnTop));
            this.Invoke((Action)(() => chkTypeText.Checked = config.TypeTextInActiveWindow));
            this.Invoke((Action)(() => chkCopyToClipboard.Checked = config.CopyToClipboard));
        }

        private void MainWindow_Load()
        {

        }
        private void btnRecord_Click(object sender, EventArgs e)
        {
            if (AppState == AppState.Recording)
            {
                waveIn.StopRecording();
                btnRecord.Text = "Record";
                AppState = AppState.Ready;
            }
            else if (AppState == AppState.Ready)
            {
                totalBytes = 0;
                rawDataArray = new byte[0];
                waveIn.StartRecording();
                btnRecord.Text = "Stop Recording";
                Console.WriteLine("Recording...");
                this.voiceDetected = false;
                this.silenceGracePeriodInitialisationTime = DateTime.Now.AddMilliseconds(config.AutoStopGracePeriodAtStartMilliseconds);
                this.Invoke((Action)(() => prgSilence.Value = 0));
                AppState = AppState.Recording;
            }

            // If appstate is transcribing, no action, otherwise we may try to write to the temp wav file before transcription has finished with it.
            // Currently same for other states, may want to adjust later.
            
        }

        private void waveIn_DataAvailable(object sender, WaveInEventArgs e)
        {
            AppState = AppState.Recording;

            // copying audio data to raw data array
            byte[] newArray = new byte[rawDataArray.Length + e.BytesRecorded];
            System.Buffer.BlockCopy(rawDataArray, 0, newArray, 0, rawDataArray.Length);
            System.Buffer.BlockCopy(e.Buffer, 0, newArray, rawDataArray.Length, e.BytesRecorded);
            rawDataArray = newArray;
            totalBytes += e.BytesRecorded;

            // checking for silence, but only after a grace period at the start
            // And only if function is on.
            if (DateTime.Now > silenceGracePeriodInitialisationTime)
            {
                var buffer = e.Buffer.Take(frameSize).ToArray();
                if (!vad.HasSpeech(buffer))
                {
                    if (isRecording && config.AutoStopAfterSilence)
                    {
                        // Set 'silence' progress bar
                        TimeSpan silentPeriod = DateTime.Now - lastVoiceDetectedTimeStamp;
                        double silentPeriodInMilliseconds = silentPeriod.TotalMilliseconds;
                        this.Invoke((Action)(() => prgSilence.Value = (int)silentPeriodInMilliseconds));

                        if (DateTime.Now > lastVoiceDetectedTimeStamp.AddMilliseconds(config.MsBeforeAutoStop))
                        {
                            waveIn.StopRecording();
                            this.Invoke((Action)(() => btnRecord.Text = "Record"));

                            AppState = AppState.Ready;
                            isRecording = false;

                            Debug.WriteLine("Silence detected, stopping recording");
                        }
                    }
                }
                else
                {
                    this.Invoke((Action)(() => stsStatus.Text = "Recording (voice)"));
                    voiceDetected = true;
                    lastVoiceDetectedTimeStamp = DateTime.Now;
                }
            }
        }

        private void waveIn_RecordingStopped(object sender, StoppedEventArgs e)
        {
            string fileNameDateTimePrefix = DateTime.Now.ToString("yyyy_MM_dd_HHmmss_fff");

            using (var writer = new WaveFileWriter(this.outputFile, waveIn.WaveFormat))
            {
                writer.Write(this.rawDataArray, 0, this.totalBytes);
                writer.Flush();
            }

            if (config.LogHistoryWavs)
            {
                string destFileName = Path.Combine(config.LogHistoryWavsPath, fileNameDateTimePrefix + ".wav");

                try
                {
                    using (var writer = new WaveFileWriter(destFileName, waveIn.WaveFormat))
                    {
                        writer.Write(this.rawDataArray, 0, this.totalBytes);
                        writer.Flush();
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Problem writing .wav to specified wav log folder.");
                }
            }


            // this was if (voicedetected) but that detection wasn't great for short utterances.
            if (true)
            {
                Debug.WriteLine("Transcribing audio file...");

                stopwatch.Reset();
                stopwatch.Start();

                Task<string> transcriptionTask;
                if (config.WhisperRecognitionStrategy == WhisperRecognitionStrategy.Local)
                {
                    // Local
                    Debug.WriteLine("Starting local transcription");
                    AppState = AppState.Transcribing;

                    transcriptionTask = TranscribeLocalAsync(this.outputFile);
                }
                else
                {
                    // Remote
                    AppState = AppState.Transcribing;

                    transcriptionTask = TranscribeRemoteAsync(this.outputFile);
                }

                transcriptionTask.ContinueWith(t =>
                {
                    if (t.IsFaulted)
                    {
                        Debug.WriteLine($"Failed to transcribe: {t.Exception}");
                        warningMessage = "Error using model, check file integrity.";
                        AppState = AppState.Warning;
                        return;
                    }
                    else
                    {

                        if (t.Result.Trim() == "[ERROR]")
                        {
                            return;
                        }

                        // Update metrics
                        stopwatch.Stop();

                        if (t.Result == null)
                        {
                            Debug.WriteLine("No text returned from transcriber");
                            warningMessage = "No text returned from transcriber";
                            AppState = AppState.Warning;
                            return;
                        }

                        string result = purifyOutput(t.Result);

                        lastSecondsToProcess = stopwatch.Elapsed.TotalSeconds;
                        lastWordsProcessed = result.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Length;
                        lastWordsPerSecond = lastWordsProcessed / lastSecondsToProcess;

                        // Log the error to console instead.

                        this.Invoke((Action)(() => stsLastProcessSummary.Text = $"Processed {lastWordsProcessed} words in {Math.Round(lastSecondsToProcess, 2)} seconds ({Math.Round(lastWordsPerSecond, 2)}w/s)"));

                        Debug.WriteLine($"Transcription: {result}");
                        this.Invoke((Action)(() => txtOutput.Text = txtOutput.Text + result));

                        if (chkCopyToClipboard.Checked)
                        {
                            try
                            {
                                this.Invoke((MethodInvoker)delegate
                                {
                                    // Set text.
                                    Clipboard.SetText(txtOutput.Text, TextDataFormat.Text);
                                });
                            }
                            catch
                            {
                                // we tried.
                            }
                        }

                        if (config.TypeTextInActiveWindow)
                        {
                            // KeyboardSimulator.DelayBetweenKeystrokesMS = 3;
                            this.Invoke((Action)(() => KeyboardSimulator.TypeText(result)));
                        }

                        if (config.LogHistoryText)
                        {
                            string destFileName = Path.Combine(config.LogHistoryTextPath, fileNameDateTimePrefix + ".txt");

                            try
                            {
                                File.WriteAllText(destFileName, result);
                            }
                            catch (Exception ex)
                            {
                                Debug.WriteLine("Problem writing .txt file to specified text log folder.");
                            }
                        }

                        lastTranscriptionContent.Push(result);
                    }
                    AppState = AppState.Ready;

                });
            }
            else
            {
                Debug.WriteLine("No voice detected during recording. Not transcribing.");
                AppState = AppState.Ready;
            }

        }


        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            // If the message is a hotkey press
            if (m.Msg == 0x0312)
            {
                // the ID for each hotkey was set during registration - act on that
                int id = m.WParam.ToInt32();
                switch (id)
                {
                    case 0:  // ctrl-alt-space
                        btnRecord_Click(this, new EventArgs());
                        break;
                    case 1:  // ctrl-backslash
                        // UndoPriorTyping();
                        break;
                    default:
                        break;
                }
            }
        }



        public class OpenAIResponse
        {
            public string text { get; set; }
        }

        private void chkTypeText_CheckedChanged(object sender, EventArgs e)
        {
            config.TypeTextInActiveWindow = chkTypeText.Checked;
            config.Save();
        }
        private void chkCopyToClipboard_CheckedChanged(object sender, EventArgs e)
        {
            config.CopyToClipboard = chkCopyToClipboard.Checked;
            config.Save();
        }

        private string purifyOutput(string input)
        {
            string result = input;

            // Remove bracketed sections such as [ EMPTY ] and ( SILENCE )
            result = Regex.Replace(result, @"\[.*?\]|\(.*?\)", string.Empty);

            // strip duplicated whitespace and any on the ends.

            result = result.Replace("[BLANK_AUDIO]", "");
            result = result.Replace("[MUSIC PLAYING]", "");

            result = result.Replace("  ", " ").Trim();
            result = result.Replace("  ", " ").Trim();

            if (config.CapitaliseEachUtterance) result = CapitalizeFirstLetter(result);
            if (config.TrailingSpaceAfterText) result = result + " ";

            return result;
        }

        public static string CapitalizeFirstLetter(string s)
        {
            if (string.IsNullOrEmpty(s))
                return string.Empty;

            char[] a = s.ToCharArray();
            a[0] = char.ToUpper(a[0]);
            return new string(a);
        }


        private void btnConfig_Click(object sender, EventArgs e)
        {
            // create an instance of the config form
            ConfigForm configForm = new();
            // Handle the FormClosed event
            configForm.FormClosed += ConfigForm_FormClosed;
            previousLocalModel = config.LocalModel;
            // show dialog
            configForm.ShowDialog();
        }
        private void ConfigForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // If model is different to last selected, clear prior one to trigger load/download of new one
            if (config.LocalModel != previousLocalModel)
            {
                whisperFactory = null;
            }
            if (config.WhisperRecognitionStrategy == WhisperRecognitionStrategy.Local)
            {
                InitialiseLocalTranscription();
            }
            UpdateUI();

            // Any other elements to adjust in line with config?
            prgSilence.Maximum = config.MsBeforeAutoStop;
        }

        private void UpdateUI()
        {
            StringBuilder modelSummary = new();
            modelSummary.Append(config.WhisperRecognitionStrategy.ToString());
            //if (!String.IsNullOrEmpty(config.WhisperRecognitionStrategy.ToString()) && config.WhisperRecognitionStrategy.ToString() == "Local")
            //{
            //    modelSummary.Append(" (" + config.LocalModel + ")");

            //    stsRecognitionHardware.Text = config.RecognitionHardware.ToString();

            //    if (config.RecognitionHardware.ToString() == "CPU") stsRecognitionHardware.ForeColor = Color.Red;
            //    switch (config.RecognitionHardware.ToString())
            //    {
            //        case "CPU":
            //            stsRecognitionHardware.ForeColor = Color.Red;
            //            break;
            //        case "CUDA":
            //            stsRecognitionHardware.ForeColor = Color.Green;
            //            break;
            //        case "OpenCL":
            //            stsRecognitionHardware.ForeColor = Color.Blue;
            //            break;
            //        default:
            //            stsRecognitionHardware.ForeColor = Color.Black;
            //            break;
            //    }
            //}
            //else
            //{
            //    // API
            //    stsRecognitionHardware.Text = "";
            //}

            // Only show auto stop progress bar if we're using the feature
            this.Invoke((Action)(() => prgSilence.Visible = config.AutoStopAfterSilence));


            stsModelSummary.Text = modelSummary.ToString();

            this.Invoke((Action)(() => stsStatus.Text = AppState.ToString()));
            this.Invoke((Action)(() => stsStatus.ForeColor = Color.Black));

            UpdateTrayIcon();

            if (AppState == AppState.Warning)
            {
                stsStatus.Text = "Warning";
                stsLastProcessSummary.Text = warningMessage;
                this.Invoke((Action)(() => stsStatus.ForeColor = Color.Red));

            }
        }

        private void chkTopmost_CheckedChanged(object sender, EventArgs e)
        {
            config.AlwaysOnTop = chkTopmost.Checked;
            this.TopMost = chkTopmost.Checked;

        }

        private void btnUndoLast_Click(object sender, EventArgs e)
        {
            if (lastTranscriptionContent.Count == 0) return;  //nothing to undo

            // txtOutput.Text = txtOutput.Text.Replace(lastTranscriptionContent.Pop(), "");
            if (txtOutput.Text.EndsWith(lastTranscriptionContent.Peek()))
            {
                txtOutput.Text = txtOutput.Text.Substring(0, txtOutput.Text.Length - lastTranscriptionContent.Pop().Length);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtOutput.Text = String.Empty;
        }

        private void btnCopyText_Click(object sender, EventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                // Set text.
                Clipboard.SetText(txtOutput.Text, TextDataFormat.Text);
            });
        }

    }
    public enum AppState
    {
        Initialising,
        Ready,
        Recording,
        Transcribing,
        Warning
    }
}