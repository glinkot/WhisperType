namespace WhisperType
{
    partial class MainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            btnRecord = new Button();
            txtOutput = new TextBox();
            chkTypeText = new CheckBox();
            statusStrip1 = new StatusStrip();
            stsStatus = new ToolStripStatusLabel();
            stsModelSummary = new ToolStripStatusLabel();
            stsRecognitionHardware = new ToolStripStatusLabel();
            stsLastProcessSummary = new ToolStripStatusLabel();
            chkCopyToClipboard = new CheckBox();
            btnConfig = new Button();
            chkTopmost = new CheckBox();
            btnCopyText = new Button();
            toolTip1 = new ToolTip(components);
            prgSilence = new ProgressBar();
            btnUndoLast = new Button();
            btnClear = new Button();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // btnRecord
            // 
            btnRecord.Location = new Point(12, 11);
            btnRecord.Margin = new Padding(2);
            btnRecord.Name = "btnRecord";
            btnRecord.Size = new Size(78, 45);
            btnRecord.TabIndex = 0;
            btnRecord.Text = "Record";
            btnRecord.UseVisualStyleBackColor = true;
            btnRecord.Click += btnRecord_Click;
            // 
            // txtOutput
            // 
            txtOutput.Location = new Point(12, 78);
            txtOutput.Multiline = true;
            txtOutput.Name = "txtOutput";
            txtOutput.Size = new Size(487, 194);
            txtOutput.TabIndex = 1;
            // 
            // chkTypeText
            // 
            chkTypeText.AutoSize = true;
            chkTypeText.Checked = true;
            chkTypeText.CheckState = CheckState.Checked;
            chkTypeText.Location = new Point(95, 12);
            chkTypeText.Name = "chkTypeText";
            chkTypeText.Size = new Size(165, 19);
            chkTypeText.TabIndex = 3;
            chkTypeText.Text = "Type text in active window";
            chkTypeText.UseVisualStyleBackColor = true;
            chkTypeText.CheckedChanged += chkTypeText_CheckedChanged;
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(24, 24);
            statusStrip1.Items.AddRange(new ToolStripItem[] { stsStatus, stsModelSummary, stsRecognitionHardware, stsLastProcessSummary });
            statusStrip1.Location = new Point(0, 275);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(557, 22);
            statusStrip1.TabIndex = 4;
            statusStrip1.Text = "statusStrip1";
            // 
            // stsStatus
            // 
            stsStatus.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            stsStatus.Name = "stsStatus";
            stsStatus.Size = new Size(42, 17);
            stsStatus.Text = "Status";
            // 
            // stsModelSummary
            // 
            stsModelSummary.Name = "stsModelSummary";
            stsModelSummary.Size = new Size(13, 17);
            stsModelSummary.Text = "  ";
            // 
            // stsRecognitionHardware
            // 
            stsRecognitionHardware.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            stsRecognitionHardware.Name = "stsRecognitionHardware";
            stsRecognitionHardware.Size = new Size(13, 17);
            stsRecognitionHardware.Text = "  ";
            // 
            // stsLastProcessSummary
            // 
            stsLastProcessSummary.Name = "stsLastProcessSummary";
            stsLastProcessSummary.Size = new Size(474, 17);
            stsLastProcessSummary.Spring = true;
            stsLastProcessSummary.Text = ".";
            stsLastProcessSummary.TextAlign = ContentAlignment.MiddleRight;
            // 
            // chkCopyToClipboard
            // 
            chkCopyToClipboard.AutoSize = true;
            chkCopyToClipboard.Checked = true;
            chkCopyToClipboard.CheckState = CheckState.Checked;
            chkCopyToClipboard.Location = new Point(95, 37);
            chkCopyToClipboard.Name = "chkCopyToClipboard";
            chkCopyToClipboard.Size = new Size(171, 19);
            chkCopyToClipboard.TabIndex = 5;
            chkCopyToClipboard.Text = "Auto copy text to clipboard";
            chkCopyToClipboard.UseVisualStyleBackColor = true;
            chkCopyToClipboard.CheckedChanged += chkCopyToClipboard_CheckedChanged;
            // 
            // btnConfig
            // 
            btnConfig.Image = Properties.Resources.settings_32;
            btnConfig.Location = new Point(505, 11);
            btnConfig.Name = "btnConfig";
            btnConfig.Size = new Size(42, 42);
            btnConfig.TabIndex = 6;
            btnConfig.UseVisualStyleBackColor = true;
            btnConfig.Click += btnConfig_Click;
            // 
            // chkTopmost
            // 
            chkTopmost.Appearance = Appearance.Button;
            chkTopmost.AutoSize = true;
            chkTopmost.Image = Properties.Resources.upload_32;
            chkTopmost.Location = new Point(457, 11);
            chkTopmost.MaximumSize = new Size(42, 42);
            chkTopmost.MinimumSize = new Size(42, 42);
            chkTopmost.Name = "chkTopmost";
            chkTopmost.Size = new Size(42, 42);
            chkTopmost.TabIndex = 8;
            chkTopmost.UseVisualStyleBackColor = true;
            chkTopmost.CheckedChanged += chkTopmost_CheckedChanged;
            // 
            // btnCopyText
            // 
            btnCopyText.Image = Properties.Resources.copy_32;
            btnCopyText.Location = new Point(505, 134);
            btnCopyText.Name = "btnCopyText";
            btnCopyText.Size = new Size(42, 42);
            btnCopyText.TabIndex = 9;
            btnCopyText.UseVisualStyleBackColor = true;
            btnCopyText.Click += btnCopyText_Click;
            // 
            // prgSilence
            // 
            prgSilence.ForeColor = Color.FromArgb(255, 192, 128);
            prgSilence.Location = new Point(12, 62);
            prgSilence.Name = "prgSilence";
            prgSilence.Size = new Size(78, 10);
            prgSilence.TabIndex = 10;
            // 
            // btnUndoLast
            // 
            btnUndoLast.Image = Properties.Resources.icons8_undo_32;
            btnUndoLast.Location = new Point(505, 182);
            btnUndoLast.Name = "btnUndoLast";
            btnUndoLast.Size = new Size(42, 42);
            btnUndoLast.TabIndex = 11;
            btnUndoLast.UseVisualStyleBackColor = true;
            btnUndoLast.Click += btnUndoLast_Click;
            // 
            // btnClear
            // 
            btnClear.Image = Properties.Resources.icons8_bin_32;
            btnClear.Location = new Point(505, 230);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(42, 42);
            btnClear.TabIndex = 12;
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(557, 297);
            Controls.Add(btnClear);
            Controls.Add(btnUndoLast);
            Controls.Add(prgSilence);
            Controls.Add(btnCopyText);
            Controls.Add(chkTopmost);
            Controls.Add(btnConfig);
            Controls.Add(chkCopyToClipboard);
            Controls.Add(statusStrip1);
            Controls.Add(chkTypeText);
            Controls.Add(txtOutput);
            Controls.Add(btnRecord);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(2);
            MaximizeBox = false;
            Name = "MainWindow";
            Text = "WhisperType";
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnRecord;
        private TextBox txtOutput;
        private CheckBox chkTypeText;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel stsStatus;
        private ToolStripStatusLabel stsModelSummary;
        private ToolStripStatusLabel stsRecognitionHardware;
        private CheckBox chkCopyToClipboard;
        private Button btnConfig;
        private ToolStripStatusLabel stsLastProcessSummary;
        private CheckBox chkTopmost;
        private Button btnCopyText;
        private ToolTip toolTip1;
        private ProgressBar prgSilence;
        private Button btnUndoLast;
        private Button btnClear;
    }
}