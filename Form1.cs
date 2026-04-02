using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Password_generator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Random ran = new Random();
        private static readonly HttpClient client = new HttpClient();
        private readonly System.Windows.Forms.Timer _csprngRefreshTimer = new System.Windows.Forms.Timer { Interval = 60_000 };
        private readonly System.Windows.Forms.Timer _clockTimer = new System.Windows.Forms.Timer { Interval = 1_000 };
        private const string RANDOM_ORG_API_KEY = "cff4f1e6-9e8d-4446-a4b2-ae57ac5550da";

        // ── Integrated character sets (item 12) ──────────────────────────────
        // a) Web / OAuth safe — alphanumeric + URL-safe symbols
        private const string CS_WEB =
            "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789" +
            "!#$%&()*+-./:;=?@_~";

        // b) *NIX / POSIX safe (modern 2025+ systems)
        private const string CS_NIX =
            "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789" +
            "!#%+,-./:=@_~";

        // c) Azure AD / Cloud AD / Kerberos — full 95 printable ASCII (U+0020..U+007E)
        private static readonly string CS_AZURE =
            new string(Enumerable.Range(0x20, 95).Select(c => (char)c).ToArray());

        // d) UTF-16LE BMP (mode 3) — generated via BmpRangeGen; no charset string needed.
        // Valid range: U+0001..U+D7FF ∪ U+E000..U+FFFD  (excludes NUL, surrogates, U+FFFE/FFFF)
        // ─────────────────────────────────────────────────────────────────────

        int maxLength = 16;
        int _lastValidLength = 16;
        bool _suppressLengthChange = false;
        int mode = 0; // default: Web/OAuth safe
        int waitTime = 100;
        SaveSettings settings = new SaveSettings();

        private string GetCharset() => mode switch
        {
            0 => CS_WEB,
            1 => CS_NIX,
            2 => CS_AZURE,
            _ => CS_WEB
        };

        private string CharsetName() => mode switch
        {
            0 => "Web/OAuth",
            1 => "NIX/POSIX",
            2 => "Azure-AD/Kerberos",
            3 => "UTF-16LE-BMP",
            _ => "Unknown"
        };

        private void UpdateClock()
        {
            var now = DateTime.Now;
            var utc = DateTime.UtcNow;
            toolStripStatusLabelUTC.Text = $"UTC: {utc:HH:mm:ss}";
            toolStripStatusLabelLocal.Text = $"Local: {now:HH:mm:ss}";
        }

        private void ReseedRandom()
        {
            try
            {
                byte[] seedBytes = new byte[4];
                using (var rng = RandomNumberGenerator.Create())
                    rng.GetBytes(seedBytes);
                ran = new Random(BitConverter.ToInt32(seedBytes, 0));
            }
            catch { ran = new Random(); }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                ReseedRandom();
                _csprngRefreshTimer.Tick += (s, _) => ReseedRandom();
                _csprngRefreshTimer.Start();

                _clockTimer.Tick += (s, _) => UpdateClock();
                _clockTimer.Start();
                UpdateClock();

                string loadResult = settings.LoadData(false);
                foreach (var line in loadResult.Split('\n', StringSplitOptions.RemoveEmptyEntries))
                    ShowStatus(line.Trim());
                waitTime = (settings.requestMode) ? settings.requestDelay : 100;

                int loadedLen = Math.Clamp(settings.length, 7, 64);
                if (settings.length == 128) loadedLen = 128;
                numericUpDownLenght.Value = loadedLen;
                _lastValidLength = loadedLen;

                mode = settings.mode;
                switch (settings.mode)
                {
                    case 0: radTypeNumbers.Checked = true; break;
                    case 1: radTypeCharNormal.Checked = true; break;
                    case 2: radTypeCharSpecial.Checked = true; break;
                    case 3: radTypeCharEnabled.Checked = true; break;
                    default: radTypeNumbers.Checked = true; break;
                }

                switch (settings.generationType)
                {
                    case 1: radGenCSPRNG.Checked = true; break;
                    case 2: radGenAtmospheric.Checked = true; break;
                    default: radGenHybrid.Checked = true; break;
                }
            }
            catch (Exception ex) { ShowError("Load failed", ex.Message); }
        }

        private void numericUpDownLenght_ValueChanged(object sender, EventArgs e)
        {
            if (_suppressLengthChange) return;
            int v = (int)numericUpDownLenght.Value;
            if (v >= 65 && v <= 127)
            {
                // Invalid range — revert to last valid value
                _suppressLengthChange = true;
                numericUpDownLenght.Value = _lastValidLength;
                _suppressLengthChange = false;
                return;
            }
            maxLength = v;
            _lastValidLength = v;
        }

        private void charsetRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (radTypeNumbers.Checked) mode = 0;
            else if (radTypeCharNormal.Checked) mode = 1;
            else if (radTypeCharSpecial.Checked) mode = 2;
            else if (radTypeCharEnabled.Checked) mode = 3;
        }

        private void AppendLog(string line)
        {
            labelStatus.AppendText("\r\n" + line);
            labelStatus.SelectionStart = labelStatus.TextLength;
            labelStatus.ScrollToCaret();
        }

        private void ShowError(string message, string detail = "")
        {
            string ts = DateTime.Now.ToString("HH:mm:ss");
            AppendLog($"[{ts}] [ERR] {message}");
            if (!string.IsNullOrEmpty(detail)) AppendLog($"       {detail}");
            AppLog.Write("UI_ERROR", message, detail);
        }

        private void ShowStatus(string message)
        {
            string ts = DateTime.Now.ToString("HH:mm:ss");
            AppendLog($"[{ts}] {message}");
        }

        private void AppendResult(string pwd)
        {
            string timestamp = DateTime.Now.ToString("HH:mm:ss");
            string header = $"[{timestamp}] {CharsetName()}/{maxLength}:";
            string entry = textBoxResult.Text.Length > 0
                ? "\r\n" + header + "\r\n" + pwd
                : header + "\r\n" + pwd;
            textBoxResult.AppendText(entry);
        }

        private async void buttonGenerate_Click(object sender, EventArgs e)
        {
            try
            {
                int count = (int)numericUpDownCount.Value;
                button1.Enabled = false;
                ShowStatus(count > 1 ? $"Generating {count} passwords, please wait..." : "Please wait...");

                byte[]? remotePool = null;
                bool usedFallback = false;

                if (!radGenCSPRNG.Checked)
                {
                    int needed = Math.Min(Math.Max(64, count * maxLength * 4), 131072);
                    remotePool = await GetRemoteBytes(needed, RANDOM_ORG_API_KEY, waitTime);
                    if (remotePool == null || remotePool.Length == 0)
                    {
                        usedFallback = true;
                        AppLog.Write("GENERATION_FAILURE", "Remote API returned no bytes; falling back to CSPRNG",
                            $"count={count} mode={mode} length={maxLength}");
                        ShowStatus("Remote API unavailable — fell back to CSPRNG");
                    }
                }

                string requestedMethod = radGenCSPRNG.Checked ? "Pure CSPRNG (local)"
                    : radGenAtmospheric.Checked ? "Atmospheric (Random.org)"
                    : "Hybrid (Random.org + CSPRNG)";
                if (usedFallback) requestedMethod = "CSPRNG (fallback)";

                for (int i = 0; i < count; i++)
                {
                    string pwd;
                    if (radGenCSPRNG.Checked || usedFallback)
                    {
                        pwd = PureCSPRNGGen();
                    }
                    else if (radGenAtmospheric.Checked)
                    {
                        int sliceSize = remotePool!.Length / count;
                        int sliceStart = i * sliceSize;
                        byte[] slice = sliceSize > 0
                            ? remotePool.Skip(sliceStart).Take(sliceSize).ToArray()
                            : remotePool;
                        pwd = MapBytesToCharset(slice.Length > 0 ? slice : remotePool, mode, maxLength);
                    }
                    else // Hybrid — fresh local CSPRNG entropy per call
                    {
                        pwd = MixWithHKDFBytes(remotePool!, mode, maxLength);
                    }
                    AppendResult(pwd);
                }

                ShowStatus($"Generated {count} password{(count > 1 ? "s" : "")} OK");
                AppendLog($"       Count    : {count}");
                AppendLog($"       Length   : {maxLength} chars each");
                AppendLog($"       Charset  : {CharsetName()}");
                AppendLog($"       Method   : {requestedMethod}");
            }
            catch (Exception ex)
            {
                ShowError("Generation failed", ex.Message);
            }
            finally
            {
                button1.Enabled = true;
            }
        }

        // ── BMP-range generation (mode 3: UTF-16LE, rejection sampling) ──────
        private string BmpRangeGen(int len, byte[]? pool, ref int off)
        {
            var sb = new StringBuilder(len);
            using var rng = (pool == null) ? RandomNumberGenerator.Create() : null;
            byte[] buf = pool ?? new byte[Math.Max(64, len * 4)];
            if (rng != null) rng.GetBytes(buf);

            for (int i = 0; i < len; i++)
            {
                while (true)
                {
                    if (off + 2 > buf.Length)
                    {
                        if (rng != null)
                        {
                            buf = new byte[Math.Max(64, len * 4)];
                            rng.GetBytes(buf);
                        }
                        off = 0;
                    }
                    char c = (char)(buf[off] | (buf[off + 1] << 8));
                    off += 2;
                    if (c != '\0' && (c < '\uD800' || c > '\uDFFF') && c != '\uFFFE' && c != '\uFFFF')
                    {
                        sb.Append(c);
                        break;
                    }
                }
            }
            return sb.ToString();
        }

        private string PureCSPRNGGen()
        {
            if (mode == 3)
            {
                int off = 0;
                return BmpRangeGen(maxLength, null, ref off);
            }
            int needed = Math.Max(32, maxLength * 4);
            byte[] bytes = new byte[needed];
            using (var rng = RandomNumberGenerator.Create()) rng.GetBytes(bytes);
            return MapBytesToCharset(bytes, mode, maxLength);
        }

        private string MapBytesToCharset(byte[] bytes, int mode, int len)
        {
            if (bytes == null || bytes.Length == 0) return string.Empty;

            if (mode == 3)
            {
                int off = 0;
                return BmpRangeGen(len, bytes, ref off);
            }

            string charset = mode switch
            {
                0 => CS_WEB,
                1 => CS_NIX,
                2 => CS_AZURE,
                _ => CS_WEB
            };
            if (string.IsNullOrEmpty(charset)) return string.Empty;

            var sb = new StringBuilder(len);
            int off2 = 0;
            uint uintMax = uint.MaxValue;
            uint L = (uint)charset.Length;
            uint threshold = (L > 1) ? uintMax - (uintMax % L) : uintMax;

            for (int i = 0; i < len; i++)
            {
                if (off2 + 4 > bytes.Length) off2 = 0;
                uint val = (uint)(bytes[off2++] | (bytes[off2++] << 8) | (bytes[off2++] << 16) | (bytes[off2++] << 24));
                if (L == 1 || val < threshold)
                {
                    sb.Append(charset[(int)(L == 1 ? 0 : val % L)]);
                }
                else
                {
                    i--; // retry
                }
            }
            return sb.ToString();
        }

        // rorgGen: fetch raw bytes from remote and either mix (hybrid) or map directly.
        private async Task<string> rorgGen(bool hybrid = true)
        {
            int neededRemote = Math.Max(64, maxLength * 4);
            byte[]? remoteBytes = await GetRemoteBytes(neededRemote, RANDOM_ORG_API_KEY, waitTime);
            if (remoteBytes == null || remoteBytes.Length == 0)
            {
                AppLog.Write("GENERATION_FAILURE",
                    "Remote API returned no bytes; falling back to CSPRNG",
                    $"hybrid={hybrid} mode={mode} length={maxLength}");
                ShowStatus("Remote API unavailable — fell back to CSPRNG");
                return PureCSPRNGGen();
            }

            if (hybrid)
                return MixWithHKDFBytes(remoteBytes, mode, maxLength);
            else
                return MapBytesToCharset(remoteBytes, mode, maxLength);
        }

        private string MixWithHKDFBytes(byte[] remoteBytes, int mode, int len)
        {
            if (remoteBytes == null || remoteBytes.Length == 0) return string.Empty;

            // Domain separation: local || 0x01 || remote || 0x02
            byte[] local = new byte[64];
            using (var rng = RandomNumberGenerator.Create()) rng.GetBytes(local);

            byte[] ikm = new byte[local.Length + 1 + remoteBytes.Length + 1];
            Buffer.BlockCopy(local, 0, ikm, 0, local.Length);
            ikm[local.Length] = 0x01;
            Buffer.BlockCopy(remoteBytes, 0, ikm, local.Length + 1, remoteBytes.Length);
            ikm[ikm.Length - 1] = 0x02;

            byte[] info = Encoding.UTF8.GetBytes("hybrid-hkdf-v1");
            int neededBytes = len * 16;
            byte[] derived = HKDF_SHA256(ikm, null, info, neededBytes);

            if (mode == 3)
            {
                // UTF-16LE BMP range with HKDF-derived bytes; extend if needed
                var sb = new StringBuilder(len);
                int off = 0;
                for (int i = 0; i < len; i++)
                {
                    while (true)
                    {
                        if (off + 2 > derived.Length)
                        {
                            info = info.Concat(new byte[] { (byte)i }).ToArray();
                            derived = derived.Concat(HKDF_SHA256(ikm, null, info, neededBytes)).ToArray();
                        }
                        char c = (char)(derived[off] | (derived[off + 1] << 8));
                        off += 2;
                        if (c != '\0' && (c < '\uD800' || c > '\uDFFF') && c != '\uFFFE' && c != '\uFFFF')
                        {
                            sb.Append(c);
                            break;
                        }
                    }
                }
                return sb.ToString();
            }

            string charset = mode switch
            {
                0 => CS_WEB,
                1 => CS_NIX,
                2 => CS_AZURE,
                _ => CS_WEB
            };
            if (string.IsNullOrEmpty(charset)) return string.Empty;

            var sb2 = new StringBuilder(len);
            int off2 = 0;
            uint uintMax = uint.MaxValue;
            uint L = (uint)charset.Length;
            uint threshold = (L > 1) ? uintMax - (uintMax % L) : uintMax;

            for (int i = 0; i < len; i++)
            {
                uint val = 0;
                bool accepted = false;
                while (!accepted)
                {
                    if (off2 + 4 > derived.Length)
                    {
                        info = info.Concat(new byte[] { (byte)i }).ToArray();
                        derived = derived.Concat(HKDF_SHA256(ikm, null, info, neededBytes)).ToArray();
                    }
                    val = (uint)(derived[off2++] | (derived[off2++] << 8) | (derived[off2++] << 16) | (derived[off2++] << 24));
                    if (L == 1 || val < threshold) accepted = true;
                }
                sb2.Append(charset[(int)(L == 1 ? 0 : val % L)]);
            }
            return sb2.ToString();
        }

        private async Task<byte[]?> generatorBytes(int len, string apik, int wait)
        {
            try
            {
                var request = new
                {
                    jsonrpc = "2.0",
                    method = "generateBlobs",
                    @params = new
                    {
                        apiKey = apik,
                        n = 1,
                        size = len * 8,
                        format = "base64"
                    },
                    id = 1
                };
                var json = System.Text.Json.JsonSerializer.Serialize(request);
                var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                var response = await client.PostAsync("https://api.random.org/json-rpc/4/invoke", content);
                response.EnsureSuccessStatusCode();
                var responseString = await response.Content.ReadAsStringAsync();
                var doc = System.Text.Json.JsonDocument.Parse(responseString);
                var root = doc.RootElement;
                if (root.TryGetProperty("error", out _)) return null;
                var b64 = root.GetProperty("result").GetProperty("random").GetProperty("data")[0].GetString();
                if (b64 == null) return null;
                byte[] bytes = Convert.FromBase64String(b64);
                await Task.Delay(wait);
                return bytes;
            }
            catch
            {
                return null;
            }
        }

        private async Task<byte[]?> GetRemoteBytes(int targetLen, string apik, int wait)
        {
            int[] attempts = new int[] { targetLen, targetLen * 2, targetLen / 2 };
            foreach (var sz in attempts)
            {
                try
                {
                    var b = await generatorBytes(sz, apik, wait);
                    if (b != null && b.Length >= targetLen) return b.Take(targetLen).ToArray();
                    if (b != null && b.Length > 0) return b;
                }
                catch { }
            }

            try
            {
                List<byte> collected = new List<byte>();
                int chunk = 64;
                while (collected.Count < targetLen)
                {
                    var b = await generatorBytes(chunk, apik, wait);
                    if (b == null || b.Length == 0) break;
                    collected.AddRange(b);
                    if (collected.Count >= targetLen) break;
                }
                if (collected.Count > 0) return collected.Take(targetLen).ToArray();
            }
            catch { }

            return null;
        }

        private static byte[] HKDF_SHA256(byte[] ikm, byte[]? salt, byte[] info, int length)
        {
            return HKDF.DeriveKey(HashAlgorithmName.SHA256, ikm, length, salt, info);
        }

        private void buttonSettings_Click(object sender, EventArgs e)
        {
            Enabled = false;
            Form2 setForm = new Form2();
            setForm.ShowDialog();
            Enabled = true;
            if (!string.IsNullOrEmpty(setForm.message))
                foreach (var line in setForm.message.Split('\n', StringSplitOptions.RemoveEmptyEntries))
                    ShowStatus(line.Trim());
            settings.LoadData(false);
            waitTime = settings.requestMode ? settings.requestDelay : 100;

            int syncLen = Math.Clamp(settings.length, 7, 64);
            if (settings.length == 128) syncLen = 128;
            _suppressLengthChange = true;
            numericUpDownLenght.Value = syncLen;
            _suppressLengthChange = false;
            maxLength = syncLen;
            _lastValidLength = syncLen;

            mode = settings.mode;
            switch (settings.mode)
            {
                case 0: radTypeNumbers.Checked = true; break;
                case 1: radTypeCharNormal.Checked = true; break;
                case 2: radTypeCharSpecial.Checked = true; break;
                case 3: radTypeCharEnabled.Checked = true; break;
                default: radTypeNumbers.Checked = true; break;
            }

            switch (settings.generationType)
            {
                case 1: radGenCSPRNG.Checked = true; break;
                case 2: radGenAtmospheric.Checked = true; break;
                default: radGenHybrid.Checked = true; break;
            }
        }
    }
}
