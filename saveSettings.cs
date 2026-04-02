using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Password_generator
{

    internal class SaveSettings
    {
        private static readonly string UserConfigPath =
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "RORG", "config.ini");

        public string? key { get; set; }
        public bool requestMode { get; set; } // false - default, true - custom
        public int requestDelay { get; set; } // 100ms
        public int length { get; set; } // 16 chars
        public int mode { get; set; } // 0 - numbers, 1 - normal chars only, 2 - with special chars, 3 - enabled chars, 4 - all
        public bool usedApi { get; set; } // false - local generation, true - online via random.org
        public int generationType { get; set; } // 0 - hybrid, 1 - pure CSPRNG, 2 - atmospheric (remote only)
        public bool clearPreviousResult { get; set; }
        public bool copyToClipboard { get; set; }

        public SaveSettings(string key, bool requestMode, int requestDelay, int length, int mode, int generationType, bool usedApi, bool clearPreviousResult, bool copyToClipboard)
        {
            this.key = key;
            this.length = length;
            this.mode = mode;
            this.generationType = generationType;
            this.usedApi = usedApi;
            this.clearPreviousResult = clearPreviousResult;
            this.copyToClipboard = copyToClipboard;
        }

        public SaveSettings() { }

        public override string ToString() { return $"{key}\n{requestMode}\n{requestDelay}\n{length}\n{mode}\n{generationType}\n{usedApi}\n{clearPreviousResult}\n{copyToClipboard}"; }

        public string WriteData()
        {
            try
            {
                string Description = File.ReadAllText(@"defaultDescription.ini", Encoding.UTF8);
                Directory.CreateDirectory(Path.GetDirectoryName(UserConfigPath)!);
                File.WriteAllText(UserConfigPath, this.ToString() + Description, Encoding.UTF8);
                return $"Configuration saved to {UserConfigPath}";
            }
            catch (Exception ex) { return ex.Message + " Unable to write configuration. Please check your system permissions."; }
        }

        public string LoadData(bool defaultPath)
        {
            try
            {
                string inifile = (!defaultPath) ? File.ReadAllText(UserConfigPath, Encoding.UTF8) : File.ReadAllText("defaultSettings.ini", Encoding.UTF8);
                string[] ini = inifile.Split("\n");

                string Get(int i) => ini.Length > i ? ini[i].Trim() : string.Empty;

                key = defaultPath ? string.Empty : Get(0);
                bool.TryParse(Get(1), out bool rm);   requestMode = rm;
                int.TryParse(Get(2), out int rd);     requestDelay = rd == 0 ? 100 : rd;
                int.TryParse(Get(3), out int ln);     length = ln == 0 ? 16 : ln;
                int.TryParse(Get(4), out int mo);     mode = mo;
                int.TryParse(Get(5), out int gt);     generationType = gt;
                bool.TryParse(Get(6), out bool ua);   usedApi = ua;
                bool.TryParse(Get(7), out bool cp);   clearPreviousResult = cp;
                bool.TryParse(Get(8), out bool cc);   copyToClipboard = cc;

                return "Settings loaded successfully.";
            }
            catch (Exception ex)
            {
                if (!defaultPath)
                    AppLog.Write("CONFIG_LOAD_FAILURE", ex.Message, "Falling back to default configuration");

                if (!defaultPath)
                {
                    SaveSettings DefaultSettings = new SaveSettings();
                    DefaultSettings.LoadData(true);

                    key = DefaultSettings.key;
                    requestMode = DefaultSettings.requestMode;
                    requestDelay = DefaultSettings.requestDelay;
                    length = DefaultSettings.length;
                    mode = DefaultSettings.mode;
                    generationType = DefaultSettings.generationType;
                    usedApi = DefaultSettings.usedApi;
                    clearPreviousResult = DefaultSettings.clearPreviousResult;
                    copyToClipboard = DefaultSettings.copyToClipboard;

                    return ex.Message + $"\nUsing default configuration.\nExpected config: {UserConfigPath}";
                }

                // Defaults themselves failed — use hardcoded fallback values
                requestMode = false;
                requestDelay = 100;
                length = 16;
                mode = 0;
                generationType = 0;
                usedApi = true;
                clearPreviousResult = true;
                copyToClipboard = false;
                return "Default configuration file unreadable. Using hardcoded defaults.";
            }
        }
    }
}
