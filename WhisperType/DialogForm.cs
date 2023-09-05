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
    public partial class DialogForm : Form
    {
        public DialogForm(string windowTitle, string bodyText)
        {
            InitializeComponent();
            this.Text = windowTitle; // Set window title
            this.lblBodyText.Text = bodyText; // Set label text
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Close(); // Close the form when 'Ok' button is clicked

        }
    }
}
