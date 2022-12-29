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
    public partial class PlayersForm : Form
    {
        public Dictionary<String, String> players { get; set; }
        private int maxPlayers;
        public PlayersForm(String name, String ip, int maxConnections)
        {
            InitializeComponent();
            players = new Dictionary<String, String>();
            this.maxPlayers = maxConnections + 1;
            players.Add(ip, name);
        }

        public void updateList()
        {
            var method = new MethodInvoker(delegate
            {
                maxPlayersText.Text = "Max Players: " + maxPlayers;
                playerListText.Clear();
                foreach (String name in players.Values)
                {
                    playerListText.Text += name + Environment.NewLine;
                }
            });
            if (InvokeRequired)
            {
                Invoke(method);
            }
            else
            {
                method();
            }
        }

        private void PlayersForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }
    }
}
