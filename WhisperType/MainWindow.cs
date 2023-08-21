using System;
using System.Windows.Forms;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using NAudio.Wave;
using System.Diagnostics;
using System.Net.Http.Headers;

namespace WhisperType
{
    public partial class MainWindow : Form
    {
        private WaveInEvent waveIn;
        private byte[] rawDataArray;
        private int totalBytes;
        private string outputFile = "tempAudioTest.wav";
        private bool isRecording = false;
        static string whisperUrl = "https://api.openai.com/v1/audio/transcriptions";
        // static string whisperUrl = "https://catfact.ninja/fact";

        
        static string openaiApiKey = "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";

        public MainWindow()
        {
            InitializeComponent();
            waveIn = new WaveInEvent();
            waveIn.DataAvailable += waveIn_DataAvailable;
            waveIn.RecordingStopped += waveIn_RecordingStopped;
            waveIn.WaveFormat = new WaveFormat(16000, 1);
        }

        private void MainWindow_Load()
        {

        }
        private void btnRecord_Click(object sender, EventArgs e)
        {
            if (!this.isRecording)
            {
                totalBytes = 0;
                rawDataArray = new byte[0];
                waveIn.StartRecording();
                btnRecord.Text = "Stop Recording";
                Console.WriteLine("Recording...");
                this.isRecording = true;
            }
            else
            {
                waveIn.StopRecording();
                btnRecord.Text = "Record";
                this.isRecording = false;
            }
        }

        private void waveIn_DataAvailable(object sender, WaveInEventArgs e)
        {
            byte[] newArray = new byte[rawDataArray.Length + e.BytesRecorded];
            System.Buffer.BlockCopy(rawDataArray, 0, newArray, 0, rawDataArray.Length);
            System.Buffer.BlockCopy(e.Buffer, 0, newArray, rawDataArray.Length, e.BytesRecorded);
            rawDataArray = newArray;
            totalBytes += e.BytesRecorded;
        }

        private void waveIn_RecordingStopped(object sender, StoppedEventArgs e)
        {
            using (var writer = new WaveFileWriter(this.outputFile, waveIn.WaveFormat))
            {
                writer.Write(this.rawDataArray, 0, this.totalBytes);
                writer.Flush();
            }

            Console.WriteLine("Transcribing audio file...");
            TranscribeAudioAsync(this.outputFile).ContinueWith(t =>
            {
                if (t.IsFaulted)
                {
                    Debug.WriteLine($"Failed to transcribe: {t.Exception}");
                    //Debug.WriteLine(jsonResponse);

                }
                else
                {
                    Debug.WriteLine($"Transcription: {t.Result}");
                    txtOutput.Text = t.Result;
                    //Debug.WriteLine(jsonResponse);

                }
            });
        }

        private static async Task<string> TranscribeAudioAsync(string audioFilePath)
        {
            Debug.WriteLine("** Transcription");

            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + openaiApiKey);

            using (var content = new MultipartFormDataContent())
            {
                var fileBytes = await File.ReadAllBytesAsync(audioFilePath);
                var byteArrayContent = new ByteArrayContent(fileBytes);

                byteArrayContent.Headers.ContentType = MediaTypeHeaderValue.Parse("audio/wav");

                // Add audio file
                content.Add(byteArrayContent, "file", "audio.wav");

                // Add Model
                content.Add(new StringContent("whisper-1"), "model");

                // Set desired response_format
                content.Add(new StringContent("json"), "response_format");

                var response = await client.PostAsync(whisperUrl, content);  // Update with your OpenAI API endpoint

                var responseBody = await response.Content.ReadAsStringAsync();
                Debug.WriteLine(responseBody);
                var jsonResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<OpenAIResponse>(responseBody);

                return jsonResponse.choice.transcripts[0].text;
            }
        }


        private class OpenAIResponse
        {
            public Choice choice { get; set; }

            public class Choice
            {
                public Transcript[] transcripts { get; set; }

                public class Transcript
                {
                    public string text { get; set; }
                }
            }
        }
    }
}