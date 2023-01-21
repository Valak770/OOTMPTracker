//Author: Valak770
//Description: Form for the host to see all connected players. Also stores all players and their ips to be used later.
//Player ips are never displayed and are only used internally

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
        public Dictionary<String, String> players { get; set; } //Dictionary containing connected ips and their names. (ip, name)
        private int maxPlayers; //max players in the room (max connections + 1)
        public PlayersForm(String name, String ip, int maxConnections)
        {
            InitializeComponent();
            players = new Dictionary<String, String>();
            this.maxPlayers = maxConnections + 1;
            players.Add(ip, name); //Add the host to the list
        }

        //Updates the list of players
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

        //Hide the window instead of closing it so the data can be accessed
        private void PlayersForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }
    }
}
