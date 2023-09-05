namespace WhisperType
{
    partial class DownloadForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DownloadForm));
            prgDownloadProgress = new ProgressBar();
            lblTitle = new Label();
            btnCancel = new Button();
            lblProgress = new Label();
            SuspendLayout();
            // 
            // prgDownloadProgress
            // 
            prgDownloadProgress.Location = new Point(12, 47);
            prgDownloadProgress.Name = "prgDownloadProgress";
            prgDownloadProgress.Size = new Size(344, 23);
            prgDownloadProgress.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitle.Location = new Point(15, 12);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(118, 15);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "Downloading model";
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(281, 84);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 2;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click_1;
            // 
            // lblProgress
            // 
            lblProgress.AutoSize = true;
            lblProgress.Location = new Point(13, 79);
            lblProgress.Margin = new Padding(2, 0, 2, 0);
            lblProgress.Name = "lblProgress";
            lblProgress.Size = new Size(10, 15);
            lblProgress.TabIndex = 3;
            lblProgress.Text = ".";
            // 
            // DownloadForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(366, 119);
            Controls.Add(lblProgress);
            Controls.Add(btnCancel);
            Controls.Add(lblTitle);
            Controls.Add(prgDownloadProgress);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "DownloadForm";
            Text = "Downloader";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ProgressBar prgDownloadProgress;
        private Label lblTitle;
        private Button btnCancel;
        private Label lblProgress;
    }
}