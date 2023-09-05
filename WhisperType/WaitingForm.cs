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
    public partial class WaitingForm : Form
    {
        public WaitingForm()
        {
            InitializeComponent();
        }

        public DialogResult ShowDialog(string message)
        {
            // You can display this message on a label in your form
            // so that you can customize the waiting message.
            // labelMessage.Text = message;
            return base.ShowDialog();
        }

    }
}
