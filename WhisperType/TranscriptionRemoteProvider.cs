//using System;
//using System.Net.Http;
//using System.Net.Http.Headers;
//using System.Threading.Tasks;
//using System.IO;
//using Whisper;

//namespace WhisperType
//{
//    public class TranscriptionRemoteProvider
//    {
//        private bool useLocalModel;
//        private Whisper.iModel localModel;
//        private Whisper.Context context;

//        public TranscriptionRemoteProvider(bool useLocalModel, string localModelPath = null)
//        {
//            this.useLocalModel = useLocalModel;

//            if (useLocalModel && !string.IsNullOrEmpty(localModelPath))
//            {
//                // Load the local Whisper model
//                localModel = Whisper.Library.loadModel(localModelPath);
//                context = localModel.createContext();
//            }
//        }

//        public async Task<string> TranscribeAsync(byte[] audioData, string apiKey, string outputFile)
//        {
//            if (useLocalModel)
//            {
//                float[] buffer = ConvertByteToFloat(audioData);
//                var audioBuffer = Whisper.Library.createAudioBuffer(buffer, buffer.Length, 16000);
//                // assuming the sample rate of 16000, replace it with the actual sample rate if different

//                // Transcribe using local Whisper model
//                return TranscribeLocal(audioBuffer);
//            }
//            else
//            {
//                // Transcribe using OpenAI Whisper API
//                return await TranscribeOpenAiAsync(audioData, apiKey, outputFile);
//            }
//        }

//        // Transcribe using local Whisper model
//        private string TranscribeLocal(Whisper.iAudioBuffer audioBuffer)
//        {
//            // Implementation of transcription using local model

//        }

//        // Transcribe using OpenAI Whisper API
//        private async Task<string> TranscribeOpenAiAsync(byte[] audioData, string apiKey, string outputFile)
//        {
//            var client = new HttpClient();
//            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");

//            using (var content = new MultipartFormDataContent())
//            {
//                var byteArrayContent = new ByteArrayContent(audioData);
//                byteArrayContent.Headers.ContentType = MediaTypeHeaderValue.Parse("audio/wav");

//                content.Add(byteArrayContent, "file", "audio.wav");
//                content.Add(new StringContent("whisper-1"), "model");
//                content.Add(new StringContent("json"), "response_format");

//                var response = await client.PostAsync("https://api.openai.com/v1/audio/transcriptions", content);
//                var responseBody = await response.Content.ReadAsStringAsync();

//                var jsonResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<OpenAIResponse>(responseBody);
//                return jsonResponse.text;
//            }
//        }

//        // Dummy OpenAI response class
//        private class OpenAIResponse
//        {
//            public string text { get; set; }
//        }

//        private float[] ConvertByteToFloat(byte[] byteArray)
//        {
//            // Convert byte array to float array - for use with local Whisper model
//            // Ensure consistency with byte ordering (endianness)
//            // Replace with the actual implementation

//            return new float[] { }; // Dummy return 
//        }
//    }
//}
