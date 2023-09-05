using Newtonsoft.Json;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using WebRtcVadSharp;
using Whisper.net.Ggml;

namespace WhisperType
{
    public class Config
    { 
        // Usage
        // var config = WhisperType.Config.ExistingConfig; //This will ensure singleton instance is retrieved
        // config.WhisperRecognitionStrategy = 123; // change a value
        // config.LocalModel = 3; // change another value
        // config.Save(); // save changes back to the file


        // Define a static variable to hold an instance of your Config
        private static Config existingConfig = null;

        // Create a static readonly object for thread safety lock while creating Singleton instance.
        private static readonly object lockObject = new object();

        //Properties
        public WhisperRecognitionStrategy WhisperRecognitionStrategy { get; set; }
        public string RecognitionLanguage { get; set; }
        public GgmlType LocalModel { get; set; }
        public int ThreadsToUse { get; set; }
        public string PathToModels { get; set; }
        //public RecognitionHardware RecognitionHardware { get; set; }
        //public int CpuCoresToUse { get; set; }
        public string WhisperAPIKey { get; set; }
        public bool AutoStopAfterSilence { get; set; }
        public int MsBeforeAutoStop { get; set; }
        public OperatingMode NoiseOperatingModel { get; set; }
        public int AutoStopGracePeriodAtStartMilliseconds { get; set; }
        public bool LogHistoryText { get; set; }
        public string LogHistoryTextPath { get; set; }
        public bool LogHistoryWavs { get; set; }
        public string LogHistoryWavsPath { get; set; }
        public bool TypeTextInActiveWindow { get; set; }
        public bool CopyToClipboard { get; set; }
        public bool TrailingSpaceAfterText { get; set; }
        public bool CapitaliseEachUtterance { get; set; }
        public bool MegaConspiciousTrayIcons { get; set; }
        public bool AlwaysOnTop { get; set; }

        public static Config ExistingConfig
        {
            get
            {
                lock (lockObject)
                {
                    if (existingConfig == null)
                    {
                        existingConfig = LoadOrCreate();
                    }
                    return existingConfig;
                }
            }
        }

        private Config() { } // Prevents usage of constructor from other classes

        //The path for storing the configuration file
        private static string ConfigFilePath => Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            "WhisperType",
            "config.json"
        );

        public void Save()
        {
            try
            {
                Directory.CreateDirectory(Path.GetDirectoryName(ConfigFilePath));
                string configJson = JsonConvert.SerializeObject(this, Formatting.Indented);
                File.WriteAllText(ConfigFilePath, configJson);
            }
            catch (UnauthorizedAccessException)
            {
                // handle if the user doesn't have the permission to write to this directory
            }
            catch (IOException)
            {
                // handle if there are any issues writing to the file
            }

            // Ensure model folder exists
            try
            {
                // NOTE: May need to check
                Directory.CreateDirectory(PathToModels);
            }
            catch (UnauthorizedAccessException)
            {
                // handle if the user doesn't have the permission to write to this directory
            }
            catch (IOException)
            {
                // handle if there are any issues writing to the file
            }

            // Ensure text log folder exists
            if (LogHistoryText)
            {
                try
                {
                    // NOTE: May need to check
                    Directory.CreateDirectory(LogHistoryTextPath);
                }
                catch (UnauthorizedAccessException)
                {
                    // handle if the user doesn't have the permission to write to this directory
                }
                catch (IOException)
                {
                    // handle if there are any issues writing to the file
                }
            }

            // Ensure wav history folder exists
            if (LogHistoryWavs)
            {
                try
                {
                    // NOTE: May need to check
                    Directory.CreateDirectory(LogHistoryWavsPath);
                }
                catch (UnauthorizedAccessException)
                {
                    // handle if the user doesn't have the permission to write to this directory
                }
                catch (IOException)
                {
                    // handle if there are any issues writing to the file
                }
            }
        }

        private static Config LoadOrCreate()
        {
            Config config;

            if (File.Exists(ConfigFilePath))
            {
                string configJson = File.ReadAllText(ConfigFilePath);

                try
                {
                    config = JsonConvert.DeserializeObject<Config>(configJson);
                }
                catch (JsonException)
                {
                    config = CreateNewAndSave();
                }
            }
            else
            {
                config = CreateNewAndSave();
            }

            return config;
        }

        private static Config CreateNewAndSave()
        {
            var config = new Config
            {
                // Set default values here
                WhisperRecognitionStrategy = WhisperRecognitionStrategy.API,
                RecognitionLanguage = "english",
                ThreadsToUse = 0,
                LocalModel = GgmlType.Medium,
                PathToModels = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                    "WhisperType",
                    "Models"),
                //RecognitionHardware = RecognitionHardware.CPU,
                //CpuCoresToUse = 1,
                WhisperAPIKey = "",
                AutoStopAfterSilence = true,
                MsBeforeAutoStop = 10,
                NoiseOperatingModel = OperatingMode.HighQuality,
                AutoStopGracePeriodAtStartMilliseconds = 1500,
                LogHistoryText = true,
                LogHistoryTextPath = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                    "WhisperType",
                    "TextHistory"),
                LogHistoryWavs = false,
                LogHistoryWavsPath = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                    "WhisperType",
                    "WavHistory"),
                TypeTextInActiveWindow = false,
                CopyToClipboard = false,
                TrailingSpaceAfterText = false,
                CapitaliseEachUtterance = true,
                MegaConspiciousTrayIcons = true,
                AlwaysOnTop = false
            };

            config.Save();
            return config;
        }
    }

    public enum WhisperRecognitionStrategy
    {
        Local,
        API
    };

    public enum RecognitionHardware
    {
        CPU,
        CUDA,
        OpenCL
    }

}
