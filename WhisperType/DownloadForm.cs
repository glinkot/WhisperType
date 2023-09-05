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
    public partial class DownloadForm : Form
    {
        public bool Cancelled { get; private set; }

        public DownloadForm(string modelName)
        {
            InitializeComponent();
            lblProgress.Text = "Starting download...";
            lblTitle.Text = "Downloading model: " + modelName;
        }

        public void UpdateProgress(long bytesReceived, long totalBytesToReceive)
        {
            prgDownloadProgress.Invoke((Action)(() =>
            {
                var percentage = (double)bytesReceived / totalBytesToReceive;
                prgDownloadProgress.Value = (int)(percentage * 100);

                string strReceived = FormatBytes(bytesReceived);
                string strTotal = FormatBytes(totalBytesToReceive);
                int percent = (int)(percentage * 100);
                lblProgress.Text = $"{strReceived}/{strTotal} ({percent}%)";  // display "xxx/yyy (zz%)"
            }));
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            Cancelled = true;
            this.Close();
        }

        public void CloseForm()
        {
            // this.Invoke((Action)(() => this.Close()));
            this.Close();
        }

        private string FormatBytes(long bytes)
        {
            string[] suffixes = { "B", "KB", "MB", "GB" };
            int counter = 0;
            decimal number = bytes;
            while (Math.Round(number / 1024) >= 1)
            {
                number /= 1024;
                counter++;
            }
            return string.Format("{0:n2}{1}", number, suffixes[counter]);
        }
    }
}
