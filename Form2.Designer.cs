namespace Password_generator
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            buttonDiscard = new Button();
            panel3 = new Panel();
            radTypeNumbers = new RadioButton();
            radTypeCharNormal = new RadioButton();
            radTypeCharEnabled = new RadioButton();
            radTypeCharSpecial = new RadioButton();
            panel2 = new Panel();
            label4 = new Label();
            numericUpDownresult = new NumericUpDown();
            panel1 = new Panel();
            radGenHybrid = new RadioButton();
            radGenCSPRNG = new RadioButton();
            radGenAtmospheric = new RadioButton();
            panel5 = new Panel();
            label3 = new Label();
            radioButtonDelayCustome = new RadioButton();
            radioButtonDelayDefault = new RadioButton();
            label2 = new Label();
            numericUpDownDelay = new NumericUpDown();
            labelDelayWarning = new Label();
            buttonSave = new Button();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownresult).BeginInit();
            panel1.SuspendLayout();
            panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownDelay).BeginInit();
            SuspendLayout();
            //
            // buttonDiscard
            // 
            buttonDiscard.BackColor = Color.FromArgb(80, 20, 20);
            buttonDiscard.FlatStyle = FlatStyle.Standard;
            buttonDiscard.Font = new Font("Georgia", 10F, FontStyle.Bold);
            buttonDiscard.Location = new Point(12, 475);
            buttonDiscard.Name = "buttonDiscard";
            buttonDiscard.Size = new Size(146, 45);
            buttonDiscard.TabIndex = 17;
            buttonDiscard.ForeColor = Color.LightCoral;
            buttonDiscard.Text = "Discard changes";
            buttonDiscard.UseVisualStyleBackColor = false;
            buttonDiscard.Click += buttonDiscard_Click;
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
            panel3.Location = new Point(15, 226);
            panel3.Name = "panel3";
            panel3.Size = new Size(346, 115);
            panel3.TabIndex = 31;
            // 
            // radTypeNumbers
            // 
            radTypeNumbers.AutoSize = true;
            radTypeNumbers.Location = new Point(3, 5);
            radTypeNumbers.Name = "radTypeNumbers";
            radTypeNumbers.Size = new Size(208, 20);
            radTypeNumbers.TabIndex = 7;
            radTypeNumbers.Text = "Web / OAuth safe";
            radTypeNumbers.UseVisualStyleBackColor = true;
            // 
            // radTypeCharNormal
            // 
            radTypeCharNormal.AutoSize = true;
            radTypeCharNormal.Location = new Point(3, 32);
            radTypeCharNormal.Name = "radTypeCharNormal";
            radTypeCharNormal.Size = new Size(228, 20);
            radTypeCharNormal.TabIndex = 8;
            radTypeCharNormal.Text = "*NIX / POSIX safe";
            radTypeCharNormal.UseVisualStyleBackColor = true;
            // 
            // radTypeCharEnabled
            // 
            radTypeCharEnabled.AutoSize = true;
            radTypeCharEnabled.Checked = true;
            radTypeCharEnabled.Location = new Point(3, 90);
            radTypeCharEnabled.Name = "radTypeCharEnabled";
            radTypeCharEnabled.Size = new Size(272, 20);
            radTypeCharEnabled.TabIndex = 10;
            radTypeCharEnabled.TabStop = true;
            radTypeCharEnabled.Text = "UTF-16LE BMP (full range)";
            radTypeCharEnabled.UseVisualStyleBackColor = true;
            // 
            // radTypeCharSpecial
            // 
            radTypeCharSpecial.AutoSize = true;
            radTypeCharSpecial.Location = new Point(3, 62);
            radTypeCharSpecial.Name = "radTypeCharSpecial";
            radTypeCharSpecial.Size = new Size(264, 20);
            radTypeCharSpecial.TabIndex = 9;
            radTypeCharSpecial.Text = "Azure AD / Kerberos (full ASCII)";
            radTypeCharSpecial.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(50, 20, 20);
            panel2.BorderStyle = BorderStyle.Fixed3D;
            panel2.ForeColor = Color.LightCoral;
            panel2.Controls.Add(label4);
            panel2.Controls.Add(numericUpDownresult);
            panel2.Location = new Point(15, 163);
            panel2.Name = "panel2";
            panel2.Size = new Size(346, 57);
            panel2.TabIndex = 30;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 6);
            label4.Name = "label4";
            label4.Size = new Size(121, 16);
            label4.TabIndex = 19;
            label4.Text = "Maximum length";
            // 
            // numericUpDownresult
            // 
            numericUpDownresult.Location = new Point(2, 26);
            numericUpDownresult.Minimum = new decimal(new int[] { 7, 0, 0, 0 });
            numericUpDownresult.Maximum = new decimal(new int[] { 128, 0, 0, 0 });
            numericUpDownresult.Name = "numericUpDownresult";
            numericUpDownresult.ValueChanged += numericUpDownresult_ValueChanged;
            numericUpDownresult.Size = new Size(336, 23);
            numericUpDownresult.TabIndex = 6;
            numericUpDownresult.Value = new decimal(new int[] { 16, 0, 0, 0 });
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(20, 45, 20);
            panel1.BorderStyle = BorderStyle.Fixed3D;
            panel1.ForeColor = Color.LightGreen;
            panel1.Controls.Add(radGenHybrid);
            panel1.Controls.Add(radGenCSPRNG);
            panel1.Controls.Add(radGenAtmospheric);
            panel1.Location = new Point(15, 347);
            panel1.Name = "panel1";
            // increase height slightly to avoid clipping under 150% DPI
            panel1.Size = new Size(346, 110);
            panel1.TabIndex = 29;
            // 
            // 
            // radGenHybrid
            // 
            radGenHybrid.AutoSize = true;
            radGenHybrid.Location = new Point(3, 6);
            radGenHybrid.Name = "radGenHybrid";
            radGenHybrid.Size = new Size(220, 20);
            radGenHybrid.TabIndex = 12;
            radGenHybrid.Text = "Hybrid (Random.org + CSPRNG)";
            radGenHybrid.UseVisualStyleBackColor = true;
            // 
            // radGenCSPRNG
            // 
            radGenCSPRNG.AutoSize = true;
            radGenCSPRNG.Location = new Point(3, 30);
            radGenCSPRNG.Name = "radGenCSPRNG";
            radGenCSPRNG.Size = new Size(150, 20);
            radGenCSPRNG.TabIndex = 13;
            radGenCSPRNG.Text = "Pure CSPRNG";
            radGenCSPRNG.UseVisualStyleBackColor = true;
            // 
            // radGenAtmospheric
            // 
            radGenAtmospheric.AutoSize = true;
            radGenAtmospheric.Location = new Point(3, 50);
            radGenAtmospheric.Name = "radGenAtmospheric";
            radGenAtmospheric.Size = new Size(190, 20);
            radGenAtmospheric.TabIndex = 14;
            radGenAtmospheric.Text = "Atmospheric (Random.org only)";
            radGenAtmospheric.UseVisualStyleBackColor = true;
            //
            // panel5
            // 
            panel5.BackColor = Color.FromArgb(20, 20, 55);
            panel5.BorderStyle = BorderStyle.Fixed3D;
            panel5.ForeColor = Color.LightBlue;
            panel5.Controls.Add(label3);
            panel5.Controls.Add(radioButtonDelayCustome);
            panel5.Controls.Add(radioButtonDelayDefault);
            panel5.Controls.Add(label2);
            panel5.Controls.Add(numericUpDownDelay);
            panel5.Controls.Add(labelDelayWarning);
            panel5.Location = new Point(15, 11);
            panel5.Name = "panel5";
            panel5.Size = new Size(346, 145);
            panel5.TabIndex = 34;
            //
            // label3
            //
            label3.AutoSize = true;
            label3.Font = new Font("Georgia", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label3.Location = new Point(306, 78);
            label3.Name = "label3";
            label3.Size = new Size(29, 16);
            label3.TabIndex = 22;
            label3.Text = "ms";
            //
            // radioButtonDelayCustome
            //
            radioButtonDelayCustome.AutoSize = true;
            radioButtonDelayCustome.Font = new Font("Georgia", 9F);
            radioButtonDelayCustome.Location = new Point(11, 51);
            radioButtonDelayCustome.Name = "radioButtonDelayCustome";
            radioButtonDelayCustome.Size = new Size(332, 18);
            radioButtonDelayCustome.TabIndex = 5;
            radioButtonDelayCustome.Text = "Custom (risk of API key ban if rate limits are violated)";
            radioButtonDelayCustome.UseVisualStyleBackColor = true;
            //
            // radioButtonDelayDefault
            //
            radioButtonDelayDefault.AutoSize = true;
            radioButtonDelayDefault.Checked = true;
            radioButtonDelayDefault.Font = new Font("Georgia", 9F);
            radioButtonDelayDefault.Location = new Point(11, 25);
            radioButtonDelayDefault.Name = "radioButtonDelayDefault";
            radioButtonDelayDefault.Size = new Size(327, 18);
            radioButtonDelayDefault.TabIndex = 4;
            radioButtonDelayDefault.TabStop = true;
            radioButtonDelayDefault.Text = "Default (recommended for free API plan)";
            radioButtonDelayDefault.UseVisualStyleBackColor = true;
            //
            // label2
            //
            label2.AutoSize = true;
            label2.Location = new Point(11, 6);
            label2.Name = "label2";
            label2.Size = new Size(167, 16);
            label2.TabIndex = 21;
            label2.Text = "Delay between requests";
            //
            // numericUpDownDelay
            //
            numericUpDownDelay.Location = new Point(3, 75);
            numericUpDownDelay.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numericUpDownDelay.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDownDelay.Name = "numericUpDownDelay";
            numericUpDownDelay.Size = new Size(301, 23);
            numericUpDownDelay.TabIndex = 20;
            numericUpDownDelay.Value = new decimal(new int[] { 100, 0, 0, 0 });
            numericUpDownDelay.ValueChanged += numericUpDownDelay_ValueChanged;
            //
            // labelDelayWarning
            //
            labelDelayWarning.AutoSize = false;
            labelDelayWarning.Font = new Font("Georgia", 8.25F, FontStyle.Bold);
            labelDelayWarning.ForeColor = Color.OrangeRed;
            labelDelayWarning.Location = new Point(3, 104);
            labelDelayWarning.Name = "labelDelayWarning";
            labelDelayWarning.Size = new Size(340, 36);
            labelDelayWarning.TabIndex = 23;
            labelDelayWarning.Text = "Warning: values below 100 ms risk rate-limit bans on the free API plan.";
            labelDelayWarning.Visible = false;
            // 
            // buttonSave
            // 
            buttonSave.BackColor = Color.FromArgb(25, 70, 25);
            buttonSave.FlatStyle = FlatStyle.Standard;
            buttonSave.Font = new Font("Georgia", 10F, FontStyle.Bold);
            buttonSave.Location = new Point(180, 475);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(181, 45);
            buttonSave.TabIndex = 16;
            buttonSave.ForeColor = Color.LightGreen;
            buttonSave.Text = "Save Settings";
            buttonSave.UseVisualStyleBackColor = false;
            buttonSave.Click += buttonSave_Click;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.FromArgb(0, 0, 64);
            DoubleBuffered = true;
            ClientSize = new Size(376, 531);
            Controls.Add(buttonSave);
            Controls.Add(panel5);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(buttonDiscard);
            Font = new Font("Georgia", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 238);
            Icon = (Icon)resources.GetObject("$this.Icon");
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "Form2";
            SizeGripStyle = SizeGripStyle.Hide;
            Text = "Settings";
            Load += Form2_Load;
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownresult).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownDelay).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button buttonDiscard;
        private Panel panel3;
        private RadioButton radTypeCharNormal;
        private RadioButton radTypeCharEnabled;
        private RadioButton radTypeCharSpecial;
        private Panel panel2;
        private Label label4;
        private NumericUpDown numericUpDownresult;
        private Panel panel1;
        private RadioButton radGenHybrid;
        private RadioButton radGenCSPRNG;
        private RadioButton radGenAtmospheric;
        private Panel panel5;
        private Button buttonSave;
        private RadioButton radioButtonDelayCustome;
        private RadioButton radioButtonDelayDefault;
        private Label label2;
        private NumericUpDown numericUpDownDelay;
        private RadioButton radTypeNumbers;
        private Label label3;
        private Label labelDelayWarning;
    }
}