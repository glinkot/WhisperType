namespace WhisperType
{
    partial class AboutForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutForm));
            pictureBox1 = new PictureBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label8 = new Label();
            label7 = new Label();
            label9 = new Label();
            lnkOpenAI = new LinkLabel();
            lnkHuggingFace = new LinkLabel();
            lnkWhisperCpp = new LinkLabel();
            lnkWhisperNet = new LinkLabel();
            lnkIcons8 = new LinkLabel();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.Logo641;
            pictureBox1.Location = new Point(13, 19);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(68, 66);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(94, 20);
            label1.Name = "label1";
            label1.Size = new Size(79, 15);
            label1.TabIndex = 1;
            label1.Text = "WhisperType";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(94, 45);
            label2.Name = "label2";
            label2.Size = new Size(118, 15);
            label2.TabIndex = 1;
            label2.Text = "Version 0.5 26/8/2023";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(94, 70);
            label3.Name = "label3";
            label3.Size = new Size(167, 15);
            label3.TabIndex = 1;
            label3.Text = "Copyright (C) 2023 Mark Foley";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(94, 431);
            label4.Name = "label4";
            label4.Size = new Size(160, 15);
            label4.TabIndex = 1;
            label4.Text = "Icons by Icons8 (icons8.com)";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label5.Location = new Point(94, 107);
            label5.MaximumSize = new Size(275, 0);
            label5.Name = "label5";
            label5.Size = new Size(257, 30);
            label5.TabIndex = 1;
            label5.Text = "WhisperType depends on the below amazing efforts:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(94, 156);
            label6.MaximumSize = new Size(260, 0);
            label6.Name = "label6";
            label6.Size = new Size(249, 45);
            label6.TabIndex = 1;
            label6.Text = "OpenAI Whisper - The algorithm that pushed open source speech recognition to where it is now";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(94, 223);
            label8.MaximumSize = new Size(260, 0);
            label8.Name = "label8";
            label8.Size = new Size(256, 30);
            label8.TabIndex = 1;
            label8.Text = "HuggingFace - Making these things practically possible";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(94, 279);
            label7.MaximumSize = new Size(260, 0);
            label7.Name = "label7";
            label7.Size = new Size(170, 15);
            label7.TabIndex = 1;
            label7.Text = "Whispercpp (Georgi Gerganov)";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(95, 337);
            label9.MaximumSize = new Size(260, 0);
            label9.Name = "label9";
            label9.Size = new Size(153, 15);
            label9.TabIndex = 1;
            label9.Text = "whisper.net (Sandro Hanea)";
            // 
            // lnkOpenAI
            // 
            lnkOpenAI.AutoSize = true;
            lnkOpenAI.Location = new Point(389, 156);
            lnkOpenAI.Name = "lnkOpenAI";
            lnkOpenAI.Size = new Size(72, 15);
            lnkOpenAI.TabIndex = 2;
            lnkOpenAI.TabStop = true;
            lnkOpenAI.Text = "Visit OpenAI";
            // 
            // lnkHuggingFace
            // 
            lnkHuggingFace.AutoSize = true;
            lnkHuggingFace.Location = new Point(389, 223);
            lnkHuggingFace.Name = "lnkHuggingFace";
            lnkHuggingFace.Size = new Size(101, 15);
            lnkHuggingFace.TabIndex = 2;
            lnkHuggingFace.TabStop = true;
            lnkHuggingFace.Text = "Visit Huggingface";
            // 
            // lnkWhisperCpp
            // 
            lnkWhisperCpp.AutoSize = true;
            lnkWhisperCpp.Location = new Point(389, 279);
            lnkWhisperCpp.Name = "lnkWhisperCpp";
            lnkWhisperCpp.Size = new Size(68, 15);
            lnkWhisperCpp.TabIndex = 2;
            lnkWhisperCpp.TabStop = true;
            lnkWhisperCpp.Text = "Visit Github";
            // 
            // lnkWhisperNet
            // 
            lnkWhisperNet.AutoSize = true;
            lnkWhisperNet.Location = new Point(389, 337);
            lnkWhisperNet.Name = "lnkWhisperNet";
            lnkWhisperNet.Size = new Size(68, 15);
            lnkWhisperNet.TabIndex = 2;
            lnkWhisperNet.TabStop = true;
            lnkWhisperNet.Text = "Visit Github";
            // 
            // lnkIcons8
            // 
            lnkIcons8.AutoSize = true;
            lnkIcons8.Location = new Point(389, 431);
            lnkIcons8.Name = "lnkIcons8";
            lnkIcons8.Size = new Size(66, 15);
            lnkIcons8.TabIndex = 2;
            lnkIcons8.TabStop = true;
            lnkIcons8.Text = "Visit Icons8";
            // 
            // AboutForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(565, 474);
            Controls.Add(lnkIcons8);
            Controls.Add(lnkWhisperNet);
            Controls.Add(lnkWhisperCpp);
            Controls.Add(lnkHuggingFace);
            Controls.Add(lnkOpenAI);
            Controls.Add(label3);
            Controls.Add(label5);
            Controls.Add(label9);
            Controls.Add(label7);
            Controls.Add(label8);
            Controls.Add(label6);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "AboutForm";
            Text = "About";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label8;
        private Label label7;
        private Label label9;
        private LinkLabel lnkOpenAI;
        private LinkLabel lnkHuggingFace;
        private LinkLabel lnkWhisperCpp;
        private LinkLabel lnkWhisperNet;
        private LinkLabel lnkIcons8;
    }
}