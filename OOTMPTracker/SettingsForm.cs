using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOTMPTracker
{
    public partial class SettingsForm : Form
    {
        public String mode { get; private set; } = "";
        public String name { get; private set; }
        public String ip { get; private set; }
        public String port { get; private set; }
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void hostButton_Click(object sender, EventArgs e)
        {
            mode = "host";
            name = nameInput.Text;
            ip = ipInput.Text;
            port = portInput.Text;
            this.Hide();
        }

        private void joinButton_Click(object sender, EventArgs e)
        {
            mode = "client";
            name = nameInput.Text;
            ip = ipInput.Text;
            port = portInput.Text;
            this.Hide();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            mode = "";
            this.Hide();
        }

        private void SettingsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            mode = "";
        }
    }
}
