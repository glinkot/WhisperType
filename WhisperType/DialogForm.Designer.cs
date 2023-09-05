namespace WhisperType
{
    partial class DialogForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DialogForm));
            lblBodyText = new Label();
            btnOk = new Button();
            SuspendLayout();
            // 
            // lblBodyText
            // 
            lblBodyText.AutoSize = true;
            lblBodyText.Location = new Point(16, 16);
            lblBodyText.MaximumSize = new Size(350, 0);
            lblBodyText.Name = "lblBodyText";
            lblBodyText.Size = new Size(339, 30);
            lblBodyText.TabIndex = 0;
            lblBodyText.Text = "this is a label which I'll test the maximum width of things with, it's quite good to do son";
            // 
            // btnOk
            // 
            btnOk.Location = new Point(302, 78);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(75, 23);
            btnOk.TabIndex = 1;
            btnOk.Text = "OK";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click;
            // 
            // DialogForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(389, 113);
            Controls.Add(btnOk);
            Controls.Add(lblBodyText);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "DialogForm";
            Text = "DialogForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblBodyText;
        private Button btnOk;
    }
}