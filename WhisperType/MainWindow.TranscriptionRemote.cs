using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace WhisperType
{
    public partial class MainWindow
    {

        private async Task<string> TranscribeRemoteAsync(string audioFilePath)
        {
            try
            {
                Debug.WriteLine("Starting API based transcription");
                var client = new HttpClient();
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + config.WhisperAPIKey);

                using (var content = new MultipartFormDataContent())
                {
                    var fileBytes = await File.ReadAllBytesAsync(audioFilePath);
                    var byteArrayContent = new ByteArrayContent(fileBytes);

                    byteArrayContent.Headers.ContentType = MediaTypeHeaderValue.Parse("audio/wav");

                    content.Add(byteArrayContent, "file", "audio.wav");
                    content.Add(new StringContent("whisper-1"), "model");
                    content.Add(new StringContent("json"), "response_format");

                    var response = await client.PostAsync(whisperUrl, content);
                    var responseBody = await response.Content.ReadAsStringAsync();

                    Debug.WriteLine("remote response");
                    Debug.WriteLine(responseBody);

                    if (!response.IsSuccessStatusCode)
                    {
                        var errorResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<ErrorResponse>(responseBody);
                        ShowDialogForm("API Error", $"{errorResponse.error.message} Code: {errorResponse.error.code}");
                        return null;
                    }

                    var jsonResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<OpenAIResponse>(responseBody);

                    return jsonResponse.text;
                }
            }
            catch (Exception ex)
            {
                ShowDialogForm("Error", $"An unexpected error occurred: {ex.Message}");
                return null;
            }
        }

        //private async Task<string> TranscribeRemoteAsync(string audioFilePath)
        //{
        //    Debug.WriteLine("Starting API based transcription");
        //    var client = new HttpClient();
        //    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + config.WhisperAPIKey);

        //    using (var content = new MultipartFormDataContent())
        //    {
        //        var fileBytes = await File.ReadAllBytesAsync(audioFilePath);
        //        var byteArrayContent = new ByteArrayContent(fileBytes);

        //        byteArrayContent.Headers.ContentType = MediaTypeHeaderValue.Parse("audio/wav");

        //        content.Add(byteArrayContent, "file", "audio.wav");
        //        content.Add(new StringContent("whisper-1"), "model");
        //        content.Add(new StringContent("json"), "response_format");

        //        var response = await client.PostAsync(whisperUrl, content);
        //        var responseBody = await response.Content.ReadAsStringAsync();

        //        Debug.WriteLine("remote response");
        //        Debug.WriteLine(responseBody);

        //        var jsonResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<OpenAIResponse>(responseBody);

        //        return jsonResponse.text;
        //    }
        //}



        private void ShowDialogForm(string windowTitle, string bodyText)
        {
            // Remember to make this call from UI thread if your TranscribeRemoteAsync method is not called from UI thread
            var warningForm = new DialogForm(windowTitle, bodyText);
            warningForm.ShowDialog();
        }

    }


    public class ErrorResponse
    {
        public class Error
        {
            public string message { get; set; }
            public string type { get; set; }
            public string param { get; set; }
            public string code { get; set; }
        }

        public Error error { get; set; }
    }
}
