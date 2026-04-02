using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Password_generator
{
    public partial class Form2 : Form
    {
        public string? message { get; set; }

        public Form2()
        {
            InitializeComponent();
        }

        SaveSettings settings = new SaveSettings();
        private int _lastValidLength2 = 16;
        private bool _suppressLengthChange2 = false;

        private void numericUpDownDelay_ValueChanged(object sender, EventArgs e)
        {
            labelDelayWarning.Visible = (int)numericUpDownDelay.Value < 100;
        }

        private void numericUpDownresult_ValueChanged(object sender, EventArgs e)
        {
            if (_suppressLengthChange2) return;
            int v = (int)numericUpDownresult.Value;
            if (v >= 65 && v <= 127)
            {
                _suppressLengthChange2 = true;
                numericUpDownresult.Value = _lastValidLength2;
                _suppressLengthChange2 = false;
                return;
            }
            _lastValidLength2 = v;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            message += settings.LoadData(false) + "\n";
            radioButtonDelayDefault.Checked = !settings.requestMode;
            radioButtonDelayCustome.Checked = settings.requestMode;
            numericUpDownDelay.Value = settings.requestDelay;
            labelDelayWarning.Visible = settings.requestDelay < 100;
            int loadedLen = Math.Clamp(settings.length, 7, 64);
            if (settings.length == 128) loadedLen = 128;
            numericUpDownresult.Value = loadedLen;
            _lastValidLength2 = loadedLen;

            switch (settings.mode)
            {
                case 0: radTypeNumbers.Checked = true; break;
                case 1: radTypeCharNormal.Checked = true; break;
                case 2: radTypeCharSpecial.Checked = true; break;
                case 3: radTypeCharEnabled.Checked = true; break;
                default: radTypeNumbers.Checked = true; break;
            }

            // generation type: 0 - hybrid, 1 - pure local CSPRNG, 2 - atmospheric (remote only)
            switch (settings.generationType)
            {
                case 0: radGenHybrid.Checked = true; break;
                case 1: radGenCSPRNG.Checked = true; break;
                case 2: radGenAtmospheric.Checked = true; break;
                default: radGenHybrid.Checked = true; break;
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            settings.requestMode = radioButtonDelayCustome.Checked;
            settings.requestDelay = (int)numericUpDownDelay.Value;
            settings.length = (int)numericUpDownresult.Value;

            if (radTypeNumbers.Checked) settings.mode = 0;
            else if (radTypeCharNormal.Checked) settings.mode = 1;
            else if (radTypeCharSpecial.Checked) settings.mode = 2;
            else if (radTypeCharEnabled.Checked) settings.mode = 3;

            if (radGenHybrid.Checked) settings.generationType = 0;
            else if (radGenCSPRNG.Checked) settings.generationType = 1;
            else if (radGenAtmospheric.Checked) settings.generationType = 2;

            // keep usedApi for backward compatibility: true unless pure local selected
            settings.usedApi = (settings.generationType != 1);

            message += settings.WriteData() + "\n";
            this.Close();
        }

        private void buttonDiscard_Click(object sender, EventArgs e)
        {
            message += "Changes not saved, operation cancelled.";
            this.Close();
        }

    }
}
