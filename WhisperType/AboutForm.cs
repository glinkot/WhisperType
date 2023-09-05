using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WhisperType
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
            lnkOpenAI.Links.Add(0, lnkOpenAI.Text.Length, "https://openai.com/research/whisper");
            lnkOpenAI.LinkClicked += new LinkLabelLinkClickedEventHandler(LinkClicked);

            lnkHuggingFace.Links.Add(0, lnkHuggingFace.Text.Length, "https://huggingface.co/openai/whisper-large-v2");
            lnkHuggingFace.LinkClicked += new LinkLabelLinkClickedEventHandler(LinkClicked);

            lnkWhisperCpp.Links.Add(0, lnkWhisperCpp.Text.Length, "https://github.com/ggerganov/whisper.cpp");
            lnkWhisperCpp.LinkClicked += new LinkLabelLinkClickedEventHandler(LinkClicked);

            lnkWhisperNet.Links.Add(0, lnkWhisperNet.Text.Length, "https://github.com/sandrohanea/whisper.net");
            lnkWhisperNet.LinkClicked += new LinkLabelLinkClickedEventHandler(LinkClicked);

            lnkIcons8.Links.Add(0, lnkIcons8.Text.Length, "https://icons8.com/");
            lnkIcons8.LinkClicked += new LinkLabelLinkClickedEventHandler(LinkClicked);
        }

        private void LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Create a ProcessStartInfo with UseShellExecute set to true 
            var psi = new System.Diagnostics.ProcessStartInfo
            {
                FileName = e.Link.LinkData.ToString(),
                UseShellExecute = true
            };

            // Open the URL in the default browser
            System.Diagnostics.Process.Start(psi);
        }

    }
}
