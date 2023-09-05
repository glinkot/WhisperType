using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebRtcVadSharp;
using Whisper.net.Ggml;


namespace WhisperType
{
    public partial class ConfigForm : Form
    {
        Config config;

        public ConfigForm()
        {
            InitializeComponent();

            config = Config.ExistingConfig;

            // Check if config file exists, if not, populate with defaults
            toolTips.SetToolTip(cmbWhisperRecognitionStrategy, "Local recognition downloads the model to your machine and all data remains local.  It's free, but may be slower than remote depending on your hardware.  Remote calls OpenAI's Whisper API, offloading the work to the cloud but incurring a per-use cost.");
            toolTips.SetToolTip(cmbLocalModel, "Which model to use.  Smaller models are typically faster but less accurate.  If the selected model isn't present in the provided model path, it is downloaded automatically from HuggingFace.");
            //toolTips.SetToolTip(cmbRecognitionHardware, "GPU recognition tends to be faster.  CUDA operates on NVidia GPU's, while OpenCL is intended to work on a broader range of GPUs.");
            //toolTips.SetToolTip(numCpuCoresToUse, "How many cores to use in CPU mode.  If you specify more than the cores you have, it will run less efficiently.");
            toolTips.SetToolTip(txtWhisperAPIKey, "To obtain a key, you'll need to register with OpenAI and generate a key in the 'API Keys' page. In the 'rates' page under the 'Audio' section you should see 'Whisper' listed; if not, you don't have access to the required API.");
            toolTips.SetToolTip(chkAutoStopAfterSilence, "A little while after you stop speaking, activate transcription without manually stopping recording.");
            toolTips.SetToolTip(numFramesBeforeAutoStop, "Takes brief slices of audio and applies voice detection to each.  If this many frames pass without any voice detected, recording stops.");
            toolTips.SetToolTip(chkTrailingSpaceAfterText, "Useful when chaining multiple sentences in the dictation window.");
            toolTips.SetToolTip(chkCapitaliseEachUtterance, "Whisper doesn't always start with a capital; if you're normally dictating sentence by sentence, this option is helpful.");
            toolTips.SetToolTip(chkMegaConspicuousTrayIcons, "Entire tray icon background changes to indicate recording and transcribing.  If false, a more subtle corner indicator is used.");



            // Populating WhisperRecognitionStrategy dropdown
            foreach (var option in Enum.GetValues(typeof(WhisperRecognitionStrategy)))
            {
                cmbWhisperRecognitionStrategy.Items.Add(option.ToString());
            }
            cmbWhisperRecognitionStrategy.SelectedItem = config.WhisperRecognitionStrategy.ToString();

            // Populating LocalModel dropdown
            foreach (var option in Enum.GetValues(typeof(GgmlType)))
            {
                cmbLocalModel.Items.Add(option.ToString());
            }
            cmbLocalModel.SelectedItem = config.LocalModel.ToString();

            // Populating Recognition Hardware dropdown
            //foreach (var option in Enum.GetValues(typeof(RecognitionHardware)))
            //{
            //    cmbRecognitionHardware.Items.Add(option.ToString());
            //}
            //cmbRecognitionHardware.SelectedItem = config.RecognitionHardware.ToString();

            //numCpuCoresToUse.Value = config.CpuCoresToUse;
            txtWhisperAPIKey.Text = config.WhisperAPIKey;
            chkAutoStopAfterSilence.Checked = config.AutoStopAfterSilence;
            numFramesBeforeAutoStop.Value = config.MsBeforeAutoStop;

            // Populating Noise handling
            foreach (var option in Enum.GetValues(typeof(OperatingMode)))
            {
                cmbNoiseOperatingModel.Items.Add(option.ToString());
            }
            cmbNoiseOperatingModel.SelectedItem = config.NoiseOperatingModel.ToString();

            numGracePeriodAtStartMilliseconds.Value = config.AutoStopGracePeriodAtStartMilliseconds;

            chkLogHistoryText.Checked = config.LogHistoryText;
            txtLogFilePath.Text = config.LogHistoryTextPath;
            chkStoreVoiceSnippets.Checked = config.LogHistoryWavs;
            txtVoiceSnippetPath.Text = config.LogHistoryWavsPath;
            chkTrailingSpaceAfterText.Checked = config.TrailingSpaceAfterText;
            chkCapitaliseEachUtterance.Checked = config.CapitaliseEachUtterance;
            chkMegaConspicuousTrayIcons.Checked = config.MegaConspiciousTrayIcons;

            AdjustControlStates();
        }

        private void ConfigForm_Load(object sender, EventArgs e)
        {

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.SaveAndClose();
        }

        private void SaveAndClose()
        {
            // Store the new values in the config class
            config.WhisperRecognitionStrategy = (WhisperRecognitionStrategy)Enum.Parse(typeof(WhisperRecognitionStrategy), cmbWhisperRecognitionStrategy.SelectedItem.ToString());
            config.LocalModel = (GgmlType)Enum.Parse(typeof(GgmlType), cmbLocalModel.SelectedItem.ToString());
            //config.RecognitionHardware = (RecognitionHardware)Enum.Parse(typeof(RecognitionHardware), cmbRecognitionHardware.SelectedItem.ToString());
            //config.CpuCoresToUse = (int)numCpuCoresToUse.Value;
            config.WhisperAPIKey = txtWhisperAPIKey.Text;
            config.AutoStopAfterSilence = chkAutoStopAfterSilence.Checked;
            config.MsBeforeAutoStop = (int)numFramesBeforeAutoStop.Value;
            config.NoiseOperatingModel = (OperatingMode)Enum.Parse(typeof(OperatingMode), cmbNoiseOperatingModel.SelectedItem.ToString());
            config.AutoStopGracePeriodAtStartMilliseconds = (int)numGracePeriodAtStartMilliseconds.Value;
            config.LogHistoryText = chkLogHistoryText.Checked;
            config.LogHistoryTextPath = txtLogFilePath.Text;
            config.LogHistoryWavs = chkStoreVoiceSnippets.Checked;
            config.LogHistoryWavsPath = txtVoiceSnippetPath.Text;
            config.TrailingSpaceAfterText = chkTrailingSpaceAfterText.Checked;
            config.CapitaliseEachUtterance = chkCapitaliseEachUtterance.Checked;
            config.MegaConspiciousTrayIcons = chkMegaConspicuousTrayIcons.Checked;

            // Save the modified config
            config.Save();

            // Close the form, or reset controls, or whatever you want to do next
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AdjustControlStates()
        {
            // Refresh active state of controls based on others.

            // Recognition Strategy dependent fields
            bool isLocal = cmbWhisperRecognitionStrategy.SelectedItem.ToString().Equals(WhisperRecognitionStrategy.Local.ToString());
            txtWhisperAPIKey.Enabled = !isLocal;

            cmbLocalModel.Enabled = isLocal;
            //cmbRecognitionHardware.Enabled = isLocal;
            //numCpuCoresToUse.Enabled = isLocal;

            // AutoStopAfterSilence dependent fields
            bool autoStop = chkAutoStopAfterSilence.Checked;
            numFramesBeforeAutoStop.Enabled = autoStop;
            cmbNoiseOperatingModel.Enabled = autoStop;
            numGracePeriodAtStartMilliseconds.Enabled = autoStop;

            // LogHistoryText dependent field
            bool logHistoryText = chkLogHistoryText.Checked;
            txtLogFilePath.Enabled = logHistoryText;

            // LogHistoryWavs dependent field
            bool storeVoiceSnippets = chkStoreVoiceSnippets.Checked;
            txtVoiceSnippetPath.Enabled = storeVoiceSnippets;
        }

        private void cmbWhisperRecognitionStrategy_SelectedIndexChanged(object sender, EventArgs e)
        {
            AdjustControlStates();
        }

        private void cmbLocalModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            AdjustControlStates();
        }

        private void cmbRecognitionHardware_SelectedIndexChanged(object sender, EventArgs e)
        {
            AdjustControlStates();
        }

        private void chkAutoStopAfterSilence_CheckedChanged(object sender, EventArgs e)
        {
            AdjustControlStates();
        }

        private void chkLogHistoryText_CheckedChanged(object sender, EventArgs e)
        {
            AdjustControlStates();
        }

        private void chkStoreVoiceSnippets_CheckedChanged(object sender, EventArgs e)
        {
            AdjustControlStates();
        }

        private void btnShowAbout_Click(object sender, EventArgs e)
        {
            // create an instance of the config form
            AboutForm aboutForm = new();
            // Handle the FormClosed event
            aboutForm.FormClosed += AboutForm_FormClosed;
            // show dialog
            aboutForm.ShowDialog();
        }

        private void AboutForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // No current action
        }
    }
}
