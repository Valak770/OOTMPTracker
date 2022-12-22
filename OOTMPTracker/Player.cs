using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOTMPTracker
{
    public class Player
    {
        public String name { get; set; }
        public String ip { get; private set; }

        public Player(String name, String ip) {
            this.name = name;
            this.ip = ip;
        }

    }
}
