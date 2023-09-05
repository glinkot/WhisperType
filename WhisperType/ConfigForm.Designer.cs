namespace WhisperType
{
    partial class ConfigForm
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigForm));
            cmbWhisperRecognitionStrategy = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            cmbLocalModel = new ComboBox();
            label5 = new Label();
            txtWhisperAPIKey = new TextBox();
            label7 = new Label();
            label8 = new Label();
            numFramesBeforeAutoStop = new NumericUpDown();
            chkAutoStopAfterSilence = new CheckBox();
            label10 = new Label();
            txtLogFilePath = new TextBox();
            label11 = new Label();
            chkLogHistoryText = new CheckBox();
            chkStoreVoiceSnippets = new CheckBox();
            txtVoiceSnippetPath = new TextBox();
            label12 = new Label();
            label13 = new Label();
            label17 = new Label();
            toolTips = new ToolTip(components);
            label19 = new Label();
            cmbNoiseOperatingModel = new ComboBox();
            label3 = new Label();
            chkTrailingSpaceAfterText = new CheckBox();
            label6 = new Label();
            numGracePeriodAtStartMilliseconds = new NumericUpDown();
            label14 = new Label();
            btnOk = new Button();
            btnCancel = new Button();
            btnShowAbout = new Button();
            label9 = new Label();
            label20 = new Label();
            txtLanguage = new TextBox();
            label4 = new Label();
            label16 = new Label();
            numericUpDown1 = new NumericUpDown();
            chkCapitaliseEachUtterance = new CheckBox();
            chkMegaConspicuousTrayIcons = new CheckBox();
            label15 = new Label();
            label18 = new Label();
            ((System.ComponentModel.ISupportInitialize)numFramesBeforeAutoStop).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numGracePeriodAtStartMilliseconds).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            SuspendLayout();
            // 
            // cmbWhisperRecognitionStrategy
            // 
            cmbWhisperRecognitionStrategy.FormattingEnabled = true;
            cmbWhisperRecognitionStrategy.Location = new Point(218, 12);
            cmbWhisperRecognitionStrategy.Name = "cmbWhisperRecognitionStrategy";
            cmbWhisperRecognitionStrategy.Size = new Size(172, 23);
            cmbWhisperRecognitionStrategy.TabIndex = 0;
            cmbWhisperRecognitionStrategy.SelectedIndexChanged += cmbWhisperRecognitionStrategy_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(26, 15);
            label1.Name = "label1";
            label1.Size = new Size(165, 15);
            label1.TabIndex = 1;
            label1.Text = "Whisper Recognition Strategy";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(59, 104);
            label2.Name = "label2";
            label2.Size = new Size(72, 15);
            label2.TabIndex = 2;
            label2.Text = "Local Model";
            // 
            // cmbLocalModel
            // 
            cmbLocalModel.FormattingEnabled = true;
            cmbLocalModel.Location = new Point(250, 101);
            cmbLocalModel.Name = "cmbLocalModel";
            cmbLocalModel.Size = new Size(354, 23);
            cmbLocalModel.TabIndex = 3;
            cmbLocalModel.SelectedIndexChanged += cmbLocalModel_SelectedIndexChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(60, 196);
            label5.Name = "label5";
            label5.Size = new Size(93, 15);
            label5.TabIndex = 6;
            label5.Text = "Whisper API Key";
            // 
            // txtWhisperAPIKey
            // 
            txtWhisperAPIKey.Location = new Point(250, 193);
            txtWhisperAPIKey.Name = "txtWhisperAPIKey";
            txtWhisperAPIKey.Size = new Size(354, 23);
            txtWhisperAPIKey.TabIndex = 7;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label7.Location = new Point(26, 226);
            label7.Name = "label7";
            label7.Size = new Size(134, 15);
            label7.TabIndex = 9;
            label7.Text = "Voice Activity Detection";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(59, 283);
            label8.Name = "label8";
            label8.Size = new Size(136, 15);
            label8.TabIndex = 10;
            label8.Text = "Silence before auto-stop";
            // 
            // numFramesBeforeAutoStop
            // 
            numFramesBeforeAutoStop.Location = new Point(250, 281);
            numFramesBeforeAutoStop.Maximum = new decimal(new int[] { 5000, 0, 0, 0 });
            numFramesBeforeAutoStop.Name = "numFramesBeforeAutoStop";
            numFramesBeforeAutoStop.Size = new Size(54, 23);
            numFramesBeforeAutoStop.TabIndex = 11;
            // 
            // chkAutoStopAfterSilence
            // 
            chkAutoStopAfterSilence.AutoSize = true;
            chkAutoStopAfterSilence.Checked = true;
            chkAutoStopAfterSilence.CheckState = CheckState.Checked;
            chkAutoStopAfterSilence.Location = new Point(43, 256);
            chkAutoStopAfterSilence.Margin = new Padding(2);
            chkAutoStopAfterSilence.Name = "chkAutoStopAfterSilence";
            chkAutoStopAfterSilence.Size = new Size(142, 19);
            chkAutoStopAfterSilence.TabIndex = 13;
            chkAutoStopAfterSilence.Text = "AutoStop after silence";
            chkAutoStopAfterSilence.UseVisualStyleBackColor = true;
            chkAutoStopAfterSilence.CheckedChanged += chkAutoStopAfterSilence_CheckedChanged;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label10.Location = new Point(26, 365);
            label10.Name = "label10";
            label10.Size = new Size(45, 15);
            label10.TabIndex = 14;
            label10.Text = "History";
            // 
            // txtLogFilePath
            // 
            txtLogFilePath.Location = new Point(250, 415);
            txtLogFilePath.Name = "txtLogFilePath";
            txtLogFilePath.Size = new Size(354, 23);
            txtLogFilePath.TabIndex = 16;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(60, 418);
            label11.Name = "label11";
            label11.Size = new Size(75, 15);
            label11.TabIndex = 15;
            label11.Text = "Log File Path";
            // 
            // chkLogHistoryText
            // 
            chkLogHistoryText.AutoSize = true;
            chkLogHistoryText.Checked = true;
            chkLogHistoryText.CheckState = CheckState.Checked;
            chkLogHistoryText.Location = new Point(43, 388);
            chkLogHistoryText.Margin = new Padding(2);
            chkLogHistoryText.Name = "chkLogHistoryText";
            chkLogHistoryText.Size = new Size(118, 19);
            chkLogHistoryText.TabIndex = 17;
            chkLogHistoryText.Text = "Log History (text)";
            chkLogHistoryText.UseVisualStyleBackColor = true;
            chkLogHistoryText.CheckedChanged += chkLogHistoryText_CheckedChanged;
            // 
            // chkStoreVoiceSnippets
            // 
            chkStoreVoiceSnippets.AutoSize = true;
            chkStoreVoiceSnippets.Checked = true;
            chkStoreVoiceSnippets.CheckState = CheckState.Checked;
            chkStoreVoiceSnippets.Location = new Point(43, 448);
            chkStoreVoiceSnippets.Margin = new Padding(2);
            chkStoreVoiceSnippets.Name = "chkStoreVoiceSnippets";
            chkStoreVoiceSnippets.Size = new Size(172, 19);
            chkStoreVoiceSnippets.TabIndex = 20;
            chkStoreVoiceSnippets.Text = "Store voice snippets as .wav";
            chkStoreVoiceSnippets.UseVisualStyleBackColor = true;
            chkStoreVoiceSnippets.CheckedChanged += chkStoreVoiceSnippets_CheckedChanged;
            // 
            // txtVoiceSnippetPath
            // 
            txtVoiceSnippetPath.Location = new Point(250, 470);
            txtVoiceSnippetPath.Name = "txtVoiceSnippetPath";
            txtVoiceSnippetPath.Size = new Size(354, 23);
            txtVoiceSnippetPath.TabIndex = 19;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(60, 473);
            label12.Name = "label12";
            label12.Size = new Size(104, 15);
            label12.TabIndex = 18;
            label12.Text = "Voice snippet path";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label13.Location = new Point(26, 169);
            label13.Name = "label13";
            label13.Size = new Size(115, 15);
            label13.TabIndex = 21;
            label13.Text = "Remote Recognition";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label17.Location = new Point(26, 78);
            label17.Name = "label17";
            label17.Size = new Size(102, 15);
            label17.TabIndex = 21;
            label17.Text = "Local Recognition";
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Location = new Point(58, 313);
            label19.Name = "label19";
            label19.Size = new Size(155, 15);
            label19.TabIndex = 2;
            label19.Text = "VAD noise handling method";
            // 
            // cmbNoiseOperatingModel
            // 
            cmbNoiseOperatingModel.FormattingEnabled = true;
            cmbNoiseOperatingModel.Location = new Point(250, 310);
            cmbNoiseOperatingModel.Name = "cmbNoiseOperatingModel";
            cmbNoiseOperatingModel.Size = new Size(355, 23);
            cmbNoiseOperatingModel.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(26, 514);
            label3.Name = "label3";
            label3.Size = new Size(82, 15);
            label3.TabIndex = 14;
            label3.Text = "Miscellaneous";
            // 
            // chkTrailingSpaceAfterText
            // 
            chkTrailingSpaceAfterText.AutoSize = true;
            chkTrailingSpaceAfterText.Checked = true;
            chkTrailingSpaceAfterText.CheckState = CheckState.Checked;
            chkTrailingSpaceAfterText.Location = new Point(43, 536);
            chkTrailingSpaceAfterText.Margin = new Padding(2);
            chkTrailingSpaceAfterText.Name = "chkTrailingSpaceAfterText";
            chkTrailingSpaceAfterText.Size = new Size(386, 19);
            chkTrailingSpaceAfterText.TabIndex = 17;
            chkTrailingSpaceAfterText.Text = "Put trailing space after text (useful for typing consecutive sentences)";
            chkTrailingSpaceAfterText.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(61, 344);
            label6.Name = "label6";
            label6.Size = new Size(113, 15);
            label6.TabIndex = 10;
            label6.Text = "Grace period at start";
            // 
            // numGracePeriodAtStartMilliseconds
            // 
            numGracePeriodAtStartMilliseconds.Location = new Point(250, 341);
            numGracePeriodAtStartMilliseconds.Maximum = new decimal(new int[] { 5000, 0, 0, 0 });
            numGracePeriodAtStartMilliseconds.Name = "numGracePeriodAtStartMilliseconds";
            numGracePeriodAtStartMilliseconds.Size = new Size(54, 23);
            numGracePeriodAtStartMilliseconds.TabIndex = 11;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(320, 343);
            label14.Name = "label14";
            label14.Size = new Size(81, 15);
            label14.TabIndex = 10;
            label14.Text = "(milliseconds)";
            // 
            // btnOk
            // 
            btnOk.Location = new Point(498, 654);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(75, 43);
            btnOk.TabIndex = 23;
            btnOk.Text = "OK";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(577, 654);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 43);
            btnCancel.TabIndex = 23;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnShowAbout
            // 
            btnShowAbout.Location = new Point(12, 654);
            btnShowAbout.Name = "btnShowAbout";
            btnShowAbout.Size = new Size(75, 42);
            btnShowAbout.TabIndex = 24;
            btnShowAbout.Text = "About";
            btnShowAbout.UseVisualStyleBackColor = true;
            btnShowAbout.Click += btnShowAbout_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(320, 283);
            label9.Name = "label9";
            label9.Size = new Size(81, 15);
            label9.TabIndex = 10;
            label9.Text = "(milliseconds)";
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Location = new Point(58, 50);
            label20.Name = "label20";
            label20.Size = new Size(178, 15);
            label20.TabIndex = 6;
            label20.Text = "Recognition language (or 'auto')";
            // 
            // txtLanguage
            // 
            txtLanguage.Location = new Point(250, 47);
            txtLanguage.Name = "txtLanguage";
            txtLanguage.Size = new Size(354, 23);
            txtLanguage.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(60, 137);
            label4.Name = "label4";
            label4.Size = new Size(83, 15);
            label4.TabIndex = 10;
            label4.Text = "Threads to use";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(320, 136);
            label16.Name = "label16";
            label16.Size = new Size(293, 15);
            label16.TabIndex = 10;
            label16.Text = "(0 = auto).  Don't exceed logical cores on your system.";
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(250, 134);
            numericUpDown1.Maximum = new decimal(new int[] { 5000, 0, 0, 0 });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(54, 23);
            numericUpDown1.TabIndex = 11;
            // 
            // chkCapitaliseEachUtterance
            // 
            chkCapitaliseEachUtterance.AutoSize = true;
            chkCapitaliseEachUtterance.Checked = true;
            chkCapitaliseEachUtterance.CheckState = CheckState.Checked;
            chkCapitaliseEachUtterance.Location = new Point(44, 560);
            chkCapitaliseEachUtterance.Margin = new Padding(2);
            chkCapitaliseEachUtterance.Name = "chkCapitaliseEachUtterance";
            chkCapitaliseEachUtterance.Size = new Size(245, 19);
            chkCapitaliseEachUtterance.TabIndex = 17;
            chkCapitaliseEachUtterance.Text = "Capitalise the first letter of each utterance";
            chkCapitaliseEachUtterance.UseVisualStyleBackColor = true;
            // 
            // chkMegaConspicuousTrayIcons
            // 
            chkMegaConspicuousTrayIcons.AutoSize = true;
            chkMegaConspicuousTrayIcons.Checked = true;
            chkMegaConspicuousTrayIcons.CheckState = CheckState.Checked;
            chkMegaConspicuousTrayIcons.Location = new Point(44, 583);
            chkMegaConspicuousTrayIcons.Margin = new Padding(2);
            chkMegaConspicuousTrayIcons.Name = "chkMegaConspicuousTrayIcons";
            chkMegaConspicuousTrayIcons.Size = new Size(444, 19);
            chkMegaConspicuousTrayIcons.TabIndex = 17;
            chkMegaConspicuousTrayIcons.Text = "Mega conspicuous tray icon indicators (Red = Recording, Green = Transcribing)";
            chkMegaConspicuousTrayIcons.UseVisualStyleBackColor = true;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label15.Location = new Point(26, 614);
            label15.Name = "label15";
            label15.Size = new Size(50, 15);
            label15.TabIndex = 14;
            label15.Text = "Hotkeys";
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label18.Location = new Point(61, 636);
            label18.Name = "label18";
            label18.Size = new Size(337, 15);
            label18.TabIndex = 14;
            label18.Text = "Ctrl-Alt-Space: Start Recording/ Stop Recording and Transcribe";
            // 
            // ConfigForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(664, 710);
            Controls.Add(btnShowAbout);
            Controls.Add(btnCancel);
            Controls.Add(btnOk);
            Controls.Add(label17);
            Controls.Add(label13);
            Controls.Add(chkStoreVoiceSnippets);
            Controls.Add(txtVoiceSnippetPath);
            Controls.Add(label12);
            Controls.Add(chkMegaConspicuousTrayIcons);
            Controls.Add(chkCapitaliseEachUtterance);
            Controls.Add(chkTrailingSpaceAfterText);
            Controls.Add(chkLogHistoryText);
            Controls.Add(txtLogFilePath);
            Controls.Add(label18);
            Controls.Add(label15);
            Controls.Add(label3);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(chkAutoStopAfterSilence);
            Controls.Add(numericUpDown1);
            Controls.Add(numGracePeriodAtStartMilliseconds);
            Controls.Add(numFramesBeforeAutoStop);
            Controls.Add(label9);
            Controls.Add(label16);
            Controls.Add(label4);
            Controls.Add(label14);
            Controls.Add(label6);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(txtLanguage);
            Controls.Add(label20);
            Controls.Add(txtWhisperAPIKey);
            Controls.Add(label5);
            Controls.Add(cmbNoiseOperatingModel);
            Controls.Add(label19);
            Controls.Add(cmbLocalModel);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(cmbWhisperRecognitionStrategy);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "ConfigForm";
            Text = "Configuration";
            Load += ConfigForm_Load;
            ((System.ComponentModel.ISupportInitialize)numFramesBeforeAutoStop).EndInit();
            ((System.ComponentModel.ISupportInitialize)numGracePeriodAtStartMilliseconds).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbWhisperRecognitionStrategy;
        private Label label1;
        private Label label2;
        private ComboBox cmbLocalModel;
        private Label label5;
        private TextBox txtWhisperAPIKey;
        private Label label7;
        private Label label8;
        private NumericUpDown numFramesBeforeAutoStop;
        private CheckBox chkAutoStopAfterSilence;
        private Label label10;
        private TextBox txtLogFilePath;
        private Label label11;
        private CheckBox chkLogHistoryText;
        private CheckBox chkStoreVoiceSnippets;
        private TextBox txtVoiceSnippetPath;
        private Label label12;
        private Label label13;
        private Label label4;
        private ComboBox cmbRecognitionHardware;
        private Label label16;
        private NumericUpDown numCpuCoresToUse;
        private Label label17;
        private Label label18;
        private ToolTip toolTips;
        private Label label19;
        private ComboBox cmbNoiseOperatingModel;
        private Label label3;
        private CheckBox chkTrailingSpaceAfterText;
        private Label label6;
        private NumericUpDown numGracePeriodAtStartMilliseconds;
        private Label label14;
        private Button btnOk;
        private Button btnCancel;
        private Button btnShowAbout;
        private Label label9;
        private Label label20;
        private TextBox txtLanguage;
        private NumericUpDown numericUpDown1;
        private CheckBox chkCapitaliseEachUtterance;
        private CheckBox chkMegaConspicuousTrayIcons;
        private Label label15;
    }
}