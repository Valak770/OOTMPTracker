//Author: Valak770
//Description: Menu for user to start multiplayer functions with inputed options. Stores the inputs
//to be utilized on close by TrackerForm

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
        public String mode { get; private set; } = ""; //Host or Client
        public String name { get; private set; } //Player name
        public String ip { get; private set; }
        public String port { get; private set; }
        public String connections { get; private set; } //Max connections
        public SettingsForm()
        {
            InitializeComponent();
        }

        //Set the mode to host mode, update all stored values, then hide the window
        private void hostButton_Click(object sender, EventArgs e)
        {
            mode = "host";
            name = nameInput.Text;
            ip = ipInput.Text;
            port = portInput.Text;
            connections = connectionsInput.Text;
            this.Hide();
        }

        //Set the mode to client mode, update all stored values, then hide the window
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
            mode = ""; //Sets the stored mode to nothing to avoid reopening server/client on close from TrackerForm
            this.Hide();
        }

        private void SettingsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            mode = ""; //Sets the stored mode to nothing to avoid reopening server/client on close from TrackerForm
        }
    }
}
