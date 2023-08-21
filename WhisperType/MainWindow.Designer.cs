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
            btnRecord = new Button();
            txtOutput = new TextBox();
            SuspendLayout();
            // 
            // btnRecord
            // 
            btnRecord.Location = new Point(27, 26);
            btnRecord.Margin = new Padding(2, 2, 2, 2);
            btnRecord.Name = "btnRecord";
            btnRecord.Size = new Size(78, 20);
            btnRecord.TabIndex = 0;
            btnRecord.Text = "Record";
            btnRecord.UseVisualStyleBackColor = true;
            btnRecord.Click += btnRecord_Click;
            // 
            // txtOutput
            // 
            txtOutput.Location = new Point(28, 70);
            txtOutput.Multiline = true;
            txtOutput.Name = "txtOutput";
            txtOutput.Size = new Size(507, 175);
            txtOutput.TabIndex = 1;
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(560, 270);
            Controls.Add(txtOutput);
            Controls.Add(btnRecord);
            Margin = new Padding(2, 2, 2, 2);
            Name = "MainWindow";
            Text = "MainWindow";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnRecord;
        private TextBox txtOutput;
    }
}