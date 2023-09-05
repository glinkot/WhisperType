using NAudio.Wave.SampleProviders;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Whisper.net;
using Whisper.net.Ggml;
using System.Reflection;
using System.Diagnostics;
using System.IO;

namespace WhisperType
{
    partial class MainWindow : Form
    {
        // MAKE IT REFER TO WHOLE PATH AND VARY BY CONFIG.  THEN RETEST DL
        private static string GgmlModelFileName;


        private WhisperFactory whisperFactory;
        private readonly HttpClient httpClient = new HttpClient();

        private WhisperProcessor whisperProcessor;

        public async Task<string> TranscribeLocalAsync(string audioFilePath)
        {
            stopwatch.Stop();
            await InitialiseLocalTranscription();
            AppState = AppState.Transcribing;
            stopwatch.Start();

            if (whisperFactory == null)
            {
                Debug.WriteLine("Failed to initialise local transcription");
                warningMessage = "Failed to initialise local transcription.";
                AppState = AppState.Warning;
                return "[ERROR]";
            }

            // The voice could be passed in-memory, but this part only takes a handful of milliseconds, so fine as is.

            Debug.WriteLine("TranscribeLocalAsync running");
            using var fileStream = File.OpenRead(audioFilePath);
            using var wavStream = new MemoryStream();

            using var reader = new WaveFileReader(fileStream);
            var resampler = new WdlResamplingSampleProvider(reader.ToSampleProvider(), 16000);
            WaveFileWriter.WriteWavFileToStream(wavStream, resampler.ToWaveProvider16());

            wavStream.Seek(0, SeekOrigin.Begin);

            var textResult = "";

            Debug.WriteLine("current stopwatch before factory create: " + stopwatch.ElapsedMilliseconds);

            
            // using var processor = whisperFactory.CreateBuilder().WithLanguage(config.RecognitionLanguage).Build();

            Debug.WriteLine("current stopwatch after factory create: " + stopwatch.ElapsedMilliseconds);

            // TODO: Expose these customisations.
            // using var processor = whisperFactory.CreateBuilder().WithThreads(16).WithSpeedUp2x().WithLanguage("auto").Build();

            // Asynchronously process the audio file and concatenate the results in text format
            // Currently doesn't stream it.
            await foreach (var result in whisperProcessor.ProcessAsync(wavStream))
            {
                textResult += result.Text + " ";
            }

            AppState = AppState.Ready;
            return textResult;
        }

        private async Task InitialiseLocalTranscription()
        {
            // ******************
            // TODO: Make sure loaded model matches the now selected one.
            // If it does, don't redo any work, if it doesn't, do the check/dl/create whisper engine
            AppState = AppState.Initialising;

            Debug.WriteLine("InitialiseLocalTranscriptionProvider running");

            GgmlModelFileName = Path.Combine(config.PathToModels, WhisperGgmlDownloader.GetModelName(config.LocalModel) + ".bin");
            Debug.WriteLine("Ggml full path: " + GgmlModelFileName);

            // Delete any small scrap files from failed downloads for example
            // Make sure the file exists before getting its length
            FileInfo fInfo = new FileInfo(GgmlModelFileName);
            if (fInfo.Exists)
            {
                long lengthInBytes = fInfo.Length;

                // None of the models are <65mb to my knowledge so it's broken if that small.
                if (lengthInBytes < 65000000)
                {
                    File.Delete(GgmlModelFileName);
                }
            }

            if (!File.Exists(GgmlModelFileName))
            {
                // Make sure the file exists before getting its length
                if (fInfo.Exists)
                {
                    long lengthInBytes = fInfo.Length;

                    if (lengthInBytes < 100000)
                    {
                        File.Delete(GgmlModelFileName);
                    }
                }

                Debug.WriteLine("Existing model not found at: " + GgmlModelFileName + ", downloading.");

                var downloadForm = new DownloadForm(config.LocalModel.ToString());
                CancellationTokenSource cts = new CancellationTokenSource();

                var downloadTask = DownloadModel(GgmlModelFileName, downloadForm, cts.Token);

                downloadForm.ShowDialog();

                await downloadTask.ContinueWith(
                    task =>
                    {
                        // Check if the operation was canceled to avoid exception when closing
                        if (!task.IsCanceled && task.IsFaulted)
                        {
                            // handle possible download errors, e.g. incorrect URL
                        }

                        downloadForm.CloseForm();
                    });

                if (downloadForm.Cancelled)
                {
                    Debug.WriteLine("Cancellation detected...  Ensure incomplete file at was deleted:");
                    cts.Cancel();

                    Debug.WriteLine(GgmlModelFileName);
                    try
                    {
                        File.Delete(GgmlModelFileName);
                        Debug.Write("incomplete file deleted at " + GgmlModelFileName);
                    }
                    catch
                    {
                        Debug.Write("unable to delete incomplete file at " + GgmlModelFileName);
                    }

                    warningMessage = "Model download cancelled, choose another model in config.";
                    AppState = AppState.Warning;
                    return;
                }


                if (cts.IsCancellationRequested)
                {
                    // Handle if the download was canceled, like deleting the incomplete file
                    Debug.WriteLine("Cancellation request detected.  Ensure incomplete file at was deleted:");

                    return;
                }
            }
            else
            {
                Debug.WriteLine("Existing model found at:" + GgmlModelFileName);
            }

            if (whisperFactory == null)
            {
                Debug.WriteLine("Creating whisper factory for transcription");

                try
                {
                    string appPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                    string dllPath = System.IO.Path.Combine(appPath, "Native", "x64", "cpu", "whisper.dll");
                    Debug.WriteLine("Attempting to load dll at " + dllPath);
                    whisperFactory = WhisperFactory.FromPath(GgmlModelFileName, libraryPath: dllPath);

                    // whisperFactory = WhisperFactory.FromPath(GgmlModelFileName);
                    warningMessage = "";
                    AppState = AppState.Ready;
                }
                catch (Exception ex) 
                {
                    Debug.WriteLine("Error creating WhisperFactory transcriber - please ensure the model is in the right location and not corrupt or incomplete.");
                    Debug.WriteLine("Model location: " + GgmlModelFileName);

                    Debug.WriteLine(ex.Message);
                    // Debug.WriteLine(ex?.InnerException.Message);

                        warningMessage = "Check model for issues.";
                    AppState = AppState.Warning;
                    return;
                }
            }

            if (config.ThreadsToUse > 0)
            {
                whisperProcessor = whisperFactory.CreateBuilder().WithThreads(config.ThreadsToUse).WithLanguage(config.RecognitionLanguage).Build();
            }
            else
            {
                whisperProcessor = whisperFactory.CreateBuilder().WithLanguage(config.RecognitionLanguage).Build();
            }




        }

        public async Task DownloadModel(string fileName, DownloadForm downloadForm, CancellationToken cancellationToken)
        {

            var (modelStream, totalBytesToReceive) = await WhisperGgmlDownloader.GetGgmlModelAsync(config.LocalModel, QuantizationType.NoQuantization, cancellationToken);

            using var fileStream = File.OpenWrite(fileName);

            byte[] buffer = new byte[8192]; // Or other buffer size
            int bytesRead;
            long totalBytesRead = 0;

            while ((bytesRead = await modelStream.ReadAsync(buffer, cancellationToken)) > 0)
            {
                await fileStream.WriteAsync(buffer, 0, bytesRead, cancellationToken);
                totalBytesRead += bytesRead;
                downloadForm.UpdateProgress(totalBytesRead, totalBytesToReceive); // Display progress
            }

            downloadForm.CloseForm();
        }

    }
}