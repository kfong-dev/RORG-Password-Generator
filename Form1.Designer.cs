namespace Password_generator
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            if (disposing)
            {
                _csprngRefreshTimer?.Dispose();
                _clockTimer?.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            statusStrip1 = new StatusStrip();
            toolStripStatusLabelUTC = new ToolStripStatusLabel();
            toolStripStatusLabelSpring = new ToolStripStatusLabel();
            toolStripStatusLabelLocal = new ToolStripStatusLabel();
            button1 = new Button();
            panelCount = new Panel();
            numericUpDownCount = new NumericUpDown();
            labelCountDesc = new Label();
            numericUpDownLenght = new NumericUpDown();
            radGenHybrid = new RadioButton();
            radGenCSPRNG = new RadioButton();
            radGenAtmospheric = new RadioButton();
            textBoxResult = new TextBox();
            labelStatus = new TextBox();
            radTypeCharSpecial = new RadioButton();
            radTypeCharEnabled = new RadioButton();
            panel1 = new Panel();
            label4 = new Label();
            radTypeCharNormal = new RadioButton();
            panel2 = new Panel();
            panel3 = new Panel();
            radTypeNumbers = new RadioButton();
            buttonSettings = new Button();
            statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownCount).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownLenght).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panelCount.SuspendLayout();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(30, 80, 30);
            button1.FlatStyle = FlatStyle.Standard;
            button1.Font = new Font("Georgia", 11F, FontStyle.Bold);
            button1.ForeColor = Color.LightGreen;
            button1.Location = new Point(12, 514);
            button1.Name = "button1";
            button1.Size = new Size(305, 45);
            button1.TabIndex = 0;
            button1.Text = "Generate!";
            button1.UseVisualStyleBackColor = false;
            button1.Click += buttonGenerate_Click;
            //
            // panelCount
            //
            panelCount.BackColor = Color.FromArgb(20, 20, 50);
            panelCount.BorderStyle = BorderStyle.Fixed3D;
            panelCount.ForeColor = Color.LightGray;
            panelCount.Controls.Add(labelCountDesc);
            panelCount.Controls.Add(numericUpDownCount);
            panelCount.Location = new Point(13, 352);
            panelCount.Name = "panelCount";
            panelCount.Size = new Size(303, 60);
            panelCount.TabIndex = 24;
            //
            // labelCountDesc
            //
            labelCountDesc.AutoSize = true;
            labelCountDesc.Font = new Font("Georgia", 9.75F);
            labelCountDesc.Location = new Point(5, 8);
            labelCountDesc.Name = "labelCountDesc";
            labelCountDesc.Text = "Number of passwords to generate:";
            //
            // numericUpDownCount
            //
            numericUpDownCount.Location = new Point(5, 30);
            numericUpDownCount.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDownCount.Maximum = new decimal(new int[] { 128, 0, 0, 0 });
            numericUpDownCount.Name = "numericUpDownCount";
            numericUpDownCount.Size = new Size(290, 23);
            numericUpDownCount.TabIndex = 1;
            numericUpDownCount.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // numericUpDownLenght
            // 
            numericUpDownLenght.Location = new Point(5, 37);
            numericUpDownLenght.Minimum = new decimal(new int[] { 7, 0, 0, 0 });
            numericUpDownLenght.Maximum = new decimal(new int[] { 128, 0, 0, 0 });
            numericUpDownLenght.Name = "numericUpDownLenght";
            numericUpDownLenght.Size = new Size(294, 23);
            numericUpDownLenght.TabIndex = 2;
            numericUpDownLenght.Value = new decimal(new int[] { 16, 0, 0, 0 });
            numericUpDownLenght.ValueChanged += numericUpDownLenght_ValueChanged;
            //
            // textBoxResult
            // 
            textBoxResult.BackColor = Color.FromArgb(20, 20, 35);
            textBoxResult.BorderStyle = BorderStyle.Fixed3D;
            textBoxResult.Font = new Font("Courier New", 10.5F, FontStyle.Bold);
            textBoxResult.ForeColor = Color.LightCyan;
            textBoxResult.Location = new Point(332, 15);
            textBoxResult.Multiline = true;
            textBoxResult.WordWrap = true;
            textBoxResult.Name = "textBoxResult";
            textBoxResult.PlaceholderText = "Result";
            textBoxResult.ScrollBars = ScrollBars.Vertical;
            textBoxResult.Size = new Size(361, 494);
            textBoxResult.TabIndex = 12;
            //
            // labelStatus
            // 
            labelStatus.BackColor = Color.FromArgb(18, 18, 30);
            labelStatus.BorderStyle = BorderStyle.Fixed3D;
            labelStatus.Font = new Font("Courier New", 8.25F, FontStyle.Regular);
            labelStatus.ForeColor = Color.LightGray;
            labelStatus.Location = new Point(13, 417);
            labelStatus.Multiline = true;
            labelStatus.Name = "labelStatus";
            labelStatus.ReadOnly = true;
            labelStatus.ScrollBars = ScrollBars.Vertical;
            labelStatus.Size = new Size(304, 92);
            labelStatus.TabIndex = 12;
            labelStatus.TabStop = false;
            // 
            // radTypeCharSpecial
            // 
            radTypeCharSpecial.AutoSize = true;
            radTypeCharSpecial.Location = new Point(3, 72);
            radTypeCharSpecial.Name = "radTypeCharSpecial";
            radTypeCharSpecial.Size = new Size(276, 21);
            radTypeCharSpecial.TabIndex = 5;
            radTypeCharSpecial.Text = "Azure AD / Kerberos (full ASCII)";
            radTypeCharSpecial.UseVisualStyleBackColor = true;
            radTypeCharSpecial.CheckedChanged += charsetRadio_CheckedChanged;
            //
            // radTypeCharEnabled
            // 
            radTypeCharEnabled.AutoSize = true;
            radTypeCharEnabled.Checked = true;
            radTypeCharEnabled.Location = new Point(3, 100);
            radTypeCharEnabled.Name = "radTypeCharEnabled";
            radTypeCharEnabled.Size = new Size(285, 21);
            radTypeCharEnabled.TabIndex = 6;
            radTypeCharEnabled.TabStop = true;
            radTypeCharEnabled.Text = "UTF-16LE BMP (full range)";
            radTypeCharEnabled.UseVisualStyleBackColor = true;
            radTypeCharEnabled.CheckedChanged += charsetRadio_CheckedChanged;
            //
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(20, 45, 20);
            panel1.BorderStyle = BorderStyle.Fixed3D;
            panel1.Controls.Add(radGenHybrid);
            panel1.Controls.Add(radGenCSPRNG);
            panel1.Controls.Add(radGenAtmospheric);
            panel1.Font = new Font("Georgia", 10F);
            panel1.ForeColor = Color.LightGreen;
            panel1.Location = new Point(13, 260);
            panel1.Name = "panel1";
            panel1.Size = new Size(303, 88);
            panel1.TabIndex = 16;
            //
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Georgia", 10F);
            label4.Location = new Point(5, 12);
            label4.Name = "label4";
            label4.Size = new Size(130, 17);
            label4.TabIndex = 19;
            label4.Text = "Maximum length";
            // 
            // radTypeCharNormal
            // 
            radTypeCharNormal.AutoSize = true;
            radTypeCharNormal.Location = new Point(3, 42);
            radTypeCharNormal.Name = "radTypeCharNormal";
            radTypeCharNormal.Size = new Size(252, 21);
            radTypeCharNormal.TabIndex = 4;
            radTypeCharNormal.Text = "*NIX / POSIX safe";
            radTypeCharNormal.UseVisualStyleBackColor = true;
            radTypeCharNormal.CheckedChanged += charsetRadio_CheckedChanged;
            //
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(50, 20, 20);
            panel2.BorderStyle = BorderStyle.Fixed3D;
            panel2.ForeColor = Color.LightCoral;
            panel2.Controls.Add(label4);
            panel2.Controls.Add(numericUpDownLenght);
            panel2.Location = new Point(12, 15);
            panel2.Name = "panel2";
            panel2.Size = new Size(304, 71);
            panel2.TabIndex = 22;
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(50, 38, 15);
            panel3.BorderStyle = BorderStyle.Fixed3D;
            panel3.ForeColor = Color.Khaki;
            panel3.Controls.Add(radTypeNumbers);
            panel3.Controls.Add(radTypeCharNormal);
            panel3.Controls.Add(radTypeCharEnabled);
            panel3.Controls.Add(radTypeCharSpecial);
            panel3.Font = new Font("Georgia", 10F);
            panel3.Location = new Point(13, 92);
            panel3.Name = "panel3";
            panel3.Size = new Size(303, 130);
            panel3.TabIndex = 23;
            // 
            // radTypeNumbers
            // 
            radTypeNumbers.AutoSize = true;
            radTypeNumbers.Location = new Point(3, 13);
            radTypeNumbers.Name = "radTypeNumbers";
            radTypeNumbers.Size = new Size(222, 21);
            radTypeNumbers.TabIndex = 3;
            radTypeNumbers.Text = "Web / OAuth safe";
            radTypeNumbers.UseVisualStyleBackColor = true;
            radTypeNumbers.CheckedChanged += charsetRadio_CheckedChanged;
            //
            // buttonSettings
            // 
            buttonSettings.BackColor = Color.FromArgb(15, 50, 55);
            buttonSettings.FlatStyle = FlatStyle.Standard;
            buttonSettings.Font = new Font("Georgia", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 238);
            buttonSettings.ForeColor = Color.LightCyan;
            buttonSettings.Location = new Point(616, 514);
            buttonSettings.Name = "buttonSettings";
            buttonSettings.Size = new Size(77, 45);
            buttonSettings.TabIndex = 15;
            buttonSettings.Text = "Settings";
            buttonSettings.UseVisualStyleBackColor = false;
            buttonSettings.Click += buttonSettings_Click;
            // 
            // radGenHybrid
            // 
            radGenHybrid.AutoSize = true;
            radGenHybrid.Location = new Point(3, 9);
            radGenHybrid.Name = "radGenHybrid";
            radGenHybrid.Size = new Size(220, 21);
            radGenHybrid.TabIndex = 17;
            radGenHybrid.Text = "Hybrid (Random.org + CSPRNG)";
            radGenHybrid.UseVisualStyleBackColor = true;
            // 
            // radGenCSPRNG
            // 
            radGenCSPRNG.AutoSize = true;
            radGenCSPRNG.Location = new Point(3, 34);
            radGenCSPRNG.Name = "radGenCSPRNG";
            radGenCSPRNG.Size = new Size(150, 21);
            radGenCSPRNG.TabIndex = 18;
            radGenCSPRNG.Text = "Pure CSPRNG";
            radGenCSPRNG.UseVisualStyleBackColor = true;
            // 
            // radGenAtmospheric
            // 
            radGenAtmospheric.AutoSize = true;
            radGenAtmospheric.Location = new Point(3, 59);
            radGenAtmospheric.Name = "radGenAtmospheric";
            radGenAtmospheric.Size = new Size(190, 21);
            radGenAtmospheric.TabIndex = 19;
            radGenAtmospheric.Text = "Atmospheric (Random.org only)";
            radGenAtmospheric.UseVisualStyleBackColor = true;
            //
            // statusStrip1
            //
            statusStrip1.BackColor = Color.FromArgb(0, 0, 48);
            statusStrip1.ForeColor = Color.LightCyan;
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabelUTC, toolStripStatusLabelSpring, toolStripStatusLabelLocal });
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(707, 22);
            statusStrip1.TabIndex = 25;
            //
            // toolStripStatusLabelUTC
            //
            toolStripStatusLabelUTC.Name = "toolStripStatusLabelUTC";
            toolStripStatusLabelUTC.Size = new Size(130, 17);
            toolStripStatusLabelUTC.Text = "UTC: --:--:--";
            //
            // toolStripStatusLabelSpring
            //
            toolStripStatusLabelSpring.Name = "toolStripStatusLabelSpring";
            toolStripStatusLabelSpring.Size = new Size(10, 17);
            toolStripStatusLabelSpring.Spring = true;
            toolStripStatusLabelSpring.Text = "";
            //
            // toolStripStatusLabelLocal
            //
            toolStripStatusLabelLocal.Name = "toolStripStatusLabelLocal";
            toolStripStatusLabelLocal.Size = new Size(130, 17);
            toolStripStatusLabelLocal.Text = "Local: --:--:--";
            //
            // Form1
            //
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.FromArgb(0, 0, 64);
            ClientSize = new Size(707, 593);
            Controls.Add(statusStrip1);
            Controls.Add(buttonSettings);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(labelStatus);
            Controls.Add(textBoxResult);
            Controls.Add(panelCount);
            Controls.Add(button1);
            DoubleBuffered = true;
            Font = new Font("Georgia", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 238);
            Icon = (Icon)resources.GetObject("$this.Icon");
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "Form1";
            Text = "Password Generator";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)numericUpDownCount).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownLenght).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panelCount.ResumeLayout(false);
            panelCount.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Panel panelCount;
        private NumericUpDown numericUpDownCount;
        private Label labelCountDesc;
        private NumericUpDown numericUpDownLenght;
        private RadioButton radGenHybrid;
        private RadioButton radGenCSPRNG;
        private RadioButton radGenAtmospheric;
        private TextBox textBoxResult;
        private TextBox labelStatus;
        private RadioButton radTypeCharSpecial;
        private RadioButton radTypeCharEnabled;
        private Panel panel1;
        private Label label4;
        private RadioButton radTypeCharNormal;
        private Panel panel2;
        private Panel panel3;
        private Button buttonSettings;
        private RadioButton radTypeNumbers;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabelUTC;
        private ToolStripStatusLabel toolStripStatusLabelSpring;
        private ToolStripStatusLabel toolStripStatusLabelLocal;
    }
}
