//Author: Valak770
//Description: The program's main form. Allows the user to add and remove items to track obtained items in game.
//Also allows connecting/hosting through tcp to sync items with other players. Contains a SettingsForm and PlayersForm object in its instance variables

using SuperSimpleTcp;
using System.Text;

namespace OOTMPTracker
{
    public partial class TrackerForm : Form
    {
        public static String name; //Player name
        public static String ip;
        public static String mode; //Host or client mode
        public static Dictionary<String, Item> items = new Dictionary<string, Item>(); //Dictionary of all items in order to access them (item name, item object)
        private bool multiplayer = false; //Multiplayer mode on/off, determines if server/client instructions are run
        private SettingsForm settingsForm;
        private PlayersForm playersForm;
        private SimpleTcpServer server; //Declares the server
        private SimpleTcpClient client; //Declare the client
        private bool fullSync = false; //Used for determing if an item sync was initiated

        //Declare all items
        private ProgressiveItem sticks;
        private ProgressiveItem nuts;
        private ProgressiveItem bombs;
        private ProgressiveItem bow;
        private Item fireArrows;
        private Item dins;
        private Item kokiriSword;
        private Item masterSword;
        private Item bigSword;

        private ProgressiveItem slingshot;
        private ProgressiveItem ocarina;
        private Item bombchus;
        private ProgressiveItem hookshot;
        private Item iceArrows;
        private Item farores;
        private Item dekuShield;
        private Item hylianShield;
        private Item mirrorShield;

        private Item boomerang;
        private Item lens;
        private ProgressiveItem beans;
        private Item hammer;
        private Item lightArrows;
        private Item nayrus;
        private Item kokiriTunic;
        private Item goronTunic;
        private Item zoraTunic;

        private ProgressiveItem wallet;
        private ProgressiveItem tokens;
        private ProgressiveItem bottles;
        private Item letter;
        private ProgressiveItem childTrade;
        private ProgressiveItem adultTrade;
        private Item kokiriBoots;
        private Item ironBoots;
        private Item hoverBoots;

        private ProgressiveItem scale;
        private ProgressiveItem magic;
        private ProgressiveItem strength;
        private Item gerudoToken;
        private Item agony;
        private ProgressiveItem heart;
        private ProgressiveItem heartPiece;
        private Item defense;

        private Item zelda;
        private Item epona;
        private Item saria;
        private Item sun;
        private Item time;
        private Item storm;
        private Item scarecrow;
        private ProgressiveItem triforce;

        private Item minuet;
        private Item bolero;
        private Item serenade;
        private Item requiem;
        private Item nocturne;
        private Item prelude;

        private Item emerald;
        private Item ruby;
        private Item sapphire;
        private Item light;
        private Item forest;
        private Item fire;
        private Item water;
        private Item shadow;
        private Item spirit;



        public TrackerForm()
        {
            InitializeComponent();
        }

        private void TrackerForm_Load(object sender, EventArgs e)
        {
            syncToolStripMenuItem.Enabled = false; //Don't allow sync when not connected to another player
            playersToolStripMenuItem.Enabled = false; //Don't allow view of PlayersForm when not in multiplayer
            settingsForm = new SettingsForm(); //Instantiate SettingsForm object

            //Instantiate all items
            sticks = new ProgressiveItem("Deku Stick Upgrade", true, sticksImg, 10, 30, 10, stickCount);
            nuts = new ProgressiveItem("Deku Nut Upgrade", true, nutsImg, 20, 40, 10, nutCount);
            bombs = new ProgressiveItem("Bomb Bag", false, bombsImg, 20, 40, 10, bombCount);
            bow = new ProgressiveItem("Bow", false, bowImg, 30, 50, 10, arrowCount);
            fireArrows = new Item("Fire Arrows", false, fireArrowsImg);
            dins = new Item("Din's Fire", false, dinsImg);
            kokiriSword = new Item("Kokiri Sword", false, kokiriSwordImg);
            masterSword = new Item("Master Sword", false, masterSwordImg);
            bigSword = new Item("Biggoron Sword", false, bigSwordImg);

            slingshot = new ProgressiveItem("Slingshot", false, slingshotImg, 30, 50, 10, seedCount);
            ocarina = new ProgressiveItem("Ocarina", false, ocarinaImg, 1, 2, 1, null, 7);
            bombchus = new Item("Bombchus", false, bombchuImg);
            hookshot = new ProgressiveItem("Hookshot", false, hookshotImg, 1, 2, 1, shotCount, 10);
            iceArrows = new Item("Ice Arrows", false, iceArrowsImg);
            farores = new Item("Farore's Wind", false, faroresImg);
            dekuShield = new Item("Deku Shield", false, dekuShieldImg);
            hylianShield = new Item("Hylian Shield", false, hylianShieldImg);
            mirrorShield = new Item("Mirror Shield", false, mirrorShieldImg);

            boomerang = new Item("Boomberang", false, boomerangImg);
            lens = new Item("Lens of Truth", false, lensImg);
            beans = new ProgressiveItem("Magic Bean", false, beansImg, 1, 10, 1, beanCount);
            hammer = new Item("Megaton Hammer", false, hammerImg);
            lightArrows = new Item("Light Arrows", false, lightArrowsImg);
            nayrus = new Item("Nayru's Love", false, nayrusImg);
            kokiriTunic = new Item("Kokiri Tunic", true, kokiriTunicImg);
            goronTunic = new Item("Goron Tunic", false, goronTunicImg);
            zoraTunic = new Item("Zora Tunic", false, zoraTunicImg);

            wallet = new ProgressiveItem("Wallet Upgrade", true, walletImg, 99, 999, 0, walletCount);
            tokens = new ProgressiveItem("Gold Skulltula Token", false, tokensImg, 1, 100, 1, tokenCount);
            bottles = new ProgressiveItem("Bottle", false, bottlesImg, 1, 3, 1, bottleCount);
            letter = new Item("Ruto's Letter", false, letterImg);
            childTrade = new ProgressiveItem("Child Trade Item", false, childTradeImg, 1, 8, 1, null, 33);
            adultTrade = new ProgressiveItem("Adult Trade Item", false, adultTradeImg, 1, 11, 1, null, 45);
            kokiriBoots = new Item("Kokiri Boots", true, kokiriBootsImg);
            ironBoots = new Item("Iron Boots", false, ironBootsImg);
            hoverBoots = new Item("Hover Boots", false, hoverBootsImg);

            scale = new ProgressiveItem("Zora Scale", false, scaleImg, 1, 2, 1, null, 83);
            magic = new ProgressiveItem("Magic Upgrade", false, magicImg, 1, 2, 1, magicCount);
            strength = new ProgressiveItem("Strength Upgrade", false, strengthImg, 1, 3, 1, null, 80);
            gerudoToken = new Item("Gerudo Token", false, gerudoTokenImg);
            agony = new Item("Stone of Agony", false, agonyImg);
            heart = new ProgressiveItem("Heart Container", false, heartImg, 1, 99, 1, heartCount);
            heartPiece = new ProgressiveItem("Piece of Heart", false, heartPieceImg, 1, 99, 1, heartPieceCount);
            defense = new Item("Double Defense", false, defenseImg);

            zelda = new Item("Zelda's Lullaby", false, zeldaImg);
            epona = new Item("Epona's Song", false, eponaImg);
            saria = new Item("Saria's Song", false, sariaImg);
            sun = new Item("Sun's Song", false, sunImg);
            time = new Item("Song of Time", false, timeImg);
            storm = new Item("Song of Storms", false, stormsImg);
            scarecrow = new Item("Scarecrow's Song", false, scarecrowImg);
            triforce = new ProgressiveItem("Triforce Piece", false, triforceImg, 1, 999, 1, triforceCount);

            minuet = new Item("Minuet of the Forest", false, minuetImg);
            bolero = new Item("Bolero of Fire", false, boleroImg);
            serenade = new Item("Serenade of Water", false, serenadeImg);
            requiem = new Item("Requiem of Spirit", false, requiemImg);
            nocturne = new Item("Nocturne of Shadow", false, nocturneImg);
            prelude = new Item("Prelude of Light", false, preludeImg);

            emerald = new Item("Kokiri Emerald", false, emeraldImg);
            ruby = new Item("Goron Ruby", false, rubyImg);
            sapphire = new Item("Zora Sapphire", false, sapphireImg);
            light = new Item("Light Medallion", false, lightImg);
            forest = new Item("Forest Medallion", false, forestImg);
            fire = new Item("Fire Medallion", false, fireImg);
            water = new Item("Water Medallion", false, waterImg);
            shadow = new Item("Shadow Medallion", false, shadowImg);
            spirit = new Item("Spirit Medallion", false, spiritImg);
        }

        //For player who obtains the item, calls obtain method on given item, sets alertText for who/what was obtained, then sends data to players/host if in multiplayer mode
        //Sending obtained data is in the format "playerName,itemName,obtained,progressive"
        public void update(Item item, String click)
        {
            if (click.Equals("Left")) //Add
            {
                item.obtain(true);
                if (multiplayer && item.progressive)
                {
                    alertText.Text = name + " found a " + item.name;
                    if (mode.Equals("host"))
                    {
                        foreach(String clientIp in playersForm.players.Keys) //Host send data to each client ip
                        {
                            server.Send(clientIp, name + "," + item.name + "," + "true" + "," + "true");
                        }
                    }
                    else
                    {
                        client.Send(name + "," + item.name + "," + "true" + "," + "true");
                    }
                }
                else if (multiplayer && !item.progressive)
                {
                    alertText.Text = name + " found the " + item.name;
                    if (mode.Equals("host"))
                    {
                        foreach (String clientIp in playersForm.players.Keys) //Host send data to each client ip
                        {
                            server.Send(clientIp, name + "," + item.name + "," + "true" + "," + "false");
                        }
                    }
                    else
                    {
                        client.Send(name + "," + item.name + "," + "true" + "," + "false");
                    }
                }

            }
            else if (click.Equals("Right")) //Remove
            {
                item.obtain(false);
                if (multiplayer && item.progressive)
                {
                    alertText.Text = name + " removed a " + item.name;
                    if (mode.Equals("host"))
                    {
                        foreach (String clientIp in playersForm.players.Keys)
                        {
                            server.Send(clientIp, name + "," + item.name + "," + "false" + "," + "true");
                        }
                    }
                    else
                    {
                        client.Send(name + "," + item.name + "," + "false" + "," + "true");
                    }
                }
                else if(multiplayer && !item.progressive)
                {
                    alertText.Text = name + " removed a " + item.name;
                    if (mode.Equals("host"))
                    {
                        foreach (String clientIp in playersForm.players.Keys)
                        {
                            server.Send(clientIp, name + "," + item.name + "," + "false" + "," + "false");
                        }
                    }
                    else
                    {
                        client.Send(name + "," + item.name + "," + "false" + "," + "false");
                    }
                }
            }
        }

        //For when the other players obtain and item, obtain whatever item it was, then update the alertText with what happened
        public void sync(String name, Item item, bool add)
        {
            if (add)
            {

                this.Invoke((MethodInvoker)delegate
                {
                    item.obtain(true);
                    if (item.progressive == true)
                    {
                        alertText.Text = name + " found a " + item.name;
                    }
                    else
                    {
                        alertText.Text = name + " found the " + item.name;
                    }
                });


            }
            else
            {
                this.Invoke((MethodInvoker)delegate
                {
                    item.obtain(false);
                    if (item.progressive == true)
                    {
                        alertText.Text = name + " removed a " + item.name;
                    }
                    else
                    {
                        alertText.Text = name + " removed the " + item.name;
                    }
                });

            }
        }

        //Event handlers for each item, calls update function with the item that was clicked and which mouse button
        private void sticksImg_MouseDown(object sender, MouseEventArgs e)
        {
            update(sticks, e.Button.ToString());
        }

        private void nutsImg_MouseDown(object sender, MouseEventArgs e)
        {
            update(nuts, e.Button.ToString());
        }

        private void bombsImg_MouseDown(object sender, MouseEventArgs e)
        {
            update(bombs, e.Button.ToString());
        }

        private void bowImg_MouseDown(object sender, MouseEventArgs e)
        {
            update(bow, e.Button.ToString());
        }

        private void fireArrowsImg_MouseDown(object sender, MouseEventArgs e)
        {
            update(fireArrows, e.Button.ToString());
        }

        private void dinsImg_MouseDown(object sender, MouseEventArgs e)
        {
            update(dins, e.Button.ToString());
        }

        private void kokiriSwordImg_MouseDown(object sender, MouseEventArgs e)
        {
            update(kokiriSword, e.Button.ToString());
        }

        private void masterSwordImg_MouseDown(object sender, MouseEventArgs e)
        {
            update(masterSword, e.Button.ToString());
        }

        private void bigSwordImg_MouseDown(object sender, MouseEventArgs e)
        {
            update(bigSword, e.Button.ToString());
        }

        private void slingshotImg_MouseDown(object sender, MouseEventArgs e)
        {
            update(slingshot, e.Button.ToString());
        }

        private void ocarinaImg_MouseDown(object sender, MouseEventArgs e)
        {
            update(ocarina, e.Button.ToString());
        }

        private void bombchusImg_MouseDown(object sender, MouseEventArgs e)
        {
            update(bombchus, e.Button.ToString());
        }

        private void hookshotImg_MouseDown(object sender, MouseEventArgs e)
        {
            update(hookshot, e.Button.ToString());
        }

        private void iceArrowsImg_MouseDown(object sender, MouseEventArgs e)
        {
            update(iceArrows, e.Button.ToString());
        }

        private void faroresImg_MouseDown(object sender, MouseEventArgs e)
        {
            update(farores, e.Button.ToString());
        }

        private void dekuShieldImg_MouseDown(object sender, MouseEventArgs e)
        {
            update(dekuShield, e.Button.ToString());
        }

        private void hylianShieldImg_MouseDown(object sender, MouseEventArgs e)
        {
            update(hylianShield, e.Button.ToString());
        }

        private void mirrorShieldImg_MouseDown(object sender, MouseEventArgs e)
        {
            update(mirrorShield, e.Button.ToString());
        }

        private void boomerangImg_MouseDown(object sender, MouseEventArgs e)
        {
            update(boomerang, e.Button.ToString());
        }

        private void lensImg_MouseDown(object sender, MouseEventArgs e)
        {
            update(lens, e.Button.ToString());
        }

        private void beansImg_MouseDown(object sender, MouseEventArgs e)
        {
            update(beans, e.Button.ToString());
        }

        private void hammerImg_MouseDown(object sender, MouseEventArgs e)
        {
            update(hammer, e.Button.ToString());
        }

        private void lightArrowsImg_MouseDown(object sender, MouseEventArgs e)
        {
            update(lightArrows, e.Button.ToString());
        }

        private void nayrusImg_MouseDown(object sender, MouseEventArgs e)
        {
            update(nayrus, e.Button.ToString());
        }

        private void kokiriTunicImg_MouseDown(object sender, MouseEventArgs e)
        {
            update(kokiriTunic, e.Button.ToString());
        }

        private void goronTunicImg_MouseDown(object sender, MouseEventArgs e)
        {
            update(goronTunic, e.Button.ToString());
        }

        private void zoraTunicImg_MouseDown(object sender, MouseEventArgs e)
        {
            update(zoraTunic, e.Button.ToString());
        }

        private void walletImg_MouseDown(object sender, MouseEventArgs e)
        {
            update(wallet, e.Button.ToString());
        }

        private void tokensImg_MouseDown(object sender, MouseEventArgs e)
        {
            update(tokens, e.Button.ToString());
        }

        private void bottlesImg_MouseDown(object sender, MouseEventArgs e)
        {
            update(bottles, e.Button.ToString());
        }

        private void letterImg_MouseDown(object sender, MouseEventArgs e)
        {
            update(letter, e.Button.ToString());
        }

        private void childTradeImg_MouseDown(object sender, MouseEventArgs e)
        {
            update(childTrade, e.Button.ToString());
        }

        private void adultTradeImg_MouseDown(object sender, MouseEventArgs e)
        {
            update(adultTrade, e.Button.ToString());
        }

        private void kokiriBootsImg_MouseDown(object sender, MouseEventArgs e)
        {
            update(kokiriBoots, e.Button.ToString());
        }

        private void ironBootsImg_MouseDown(object sender, MouseEventArgs e)
        {
            update(ironBoots, e.Button.ToString());
        }

        private void hoverBootsImg_MouseDown(object sender, MouseEventArgs e)
        {
            update(hoverBoots, e.Button.ToString());
        }

        private void scaleImg_MouseDown(object sender, MouseEventArgs e)
        {
            update(scale, e.Button.ToString());
        }

        private void magicImg_MouseDown(object sender, MouseEventArgs e)
        {
            update(magic, e.Button.ToString());
        }

        private void strengthImg_MouseDown(object sender, MouseEventArgs e)
        {
            update(strength, e.Button.ToString());
        }

        private void gerudoTokenImg_MouseDown(object sender, MouseEventArgs e)
        {
            update(gerudoToken, e.Button.ToString());
        }

        private void agonyImg_MouseDown(object sender, MouseEventArgs e)
        {
            update(agony, e.Button.ToString());
        }

        private void heartPieceImg_MouseDown(object sender, MouseEventArgs e)
        {
            update(heartPiece, e.Button.ToString());
        }

        private void heartImg_MouseDown(object sender, MouseEventArgs e)
        {
            update(heart, e.Button.ToString());
        }

        private void defenseImg_MouseDown(object sender, MouseEventArgs e)
        {
            update(defense, e.Button.ToString());
        }

        private void zeldaImg_MouseDown(object sender, MouseEventArgs e)
        {
            update(zelda, e.Button.ToString());
        }

        private void eponaImg_MouseDown(object sender, MouseEventArgs e)
        {
            update(epona, e.Button.ToString());
        }

        private void sariaImg_MouseDown(object sender, MouseEventArgs e)
        {
            update(saria, e.Button.ToString());
        }

        private void sunImg_MouseDown(object sender, MouseEventArgs e)
        {
            update(sun, e.Button.ToString());
        }

        private void timeImg_MouseDown(object sender, MouseEventArgs e)
        {
            update(time, e.Button.ToString());
        }

        private void stormsImg_MouseDown(object sender, MouseEventArgs e)
        {
            update(storm, e.Button.ToString());
        }

        private void scarecrowImg_MouseDown(object sender, MouseEventArgs e)
        {
            update(scarecrow, e.Button.ToString());
        }

        private void minuetImg_MouseDown(object sender, MouseEventArgs e)
        {
            update(minuet, e.Button.ToString());
        }

        private void boleroImg_MouseDown(object sender, MouseEventArgs e)
        {
            update(bolero, e.Button.ToString());
        }

        private void serenadeImg_MouseDown(object sender, MouseEventArgs e)
        {
            update(serenade, e.Button.ToString());
        }

        private void requiemImg_MouseDown(object sender, MouseEventArgs e)
        {
            update(requiem, e.Button.ToString());
        }

        private void nocturneImg_MouseDown(object sender, MouseEventArgs e)
        {
            update(nocturne, e.Button.ToString());
        }

        private void preludeImg_MouseDown(object sender, MouseEventArgs e)
        {
            update(prelude, e.Button.ToString());
        }

        private void emeraldImg_MouseDown(object sender, MouseEventArgs e)
        {
            update(emerald, e.Button.ToString());
        }

        private void rubyImg_MouseDown(object sender, MouseEventArgs e)
        {
            update(ruby, e.Button.ToString());
        }

        private void sapphireImg_MouseDown(object sender, MouseEventArgs e)
        {
            update(sapphire, e.Button.ToString());
        }

        private void lightImg_MouseDown(object sender, MouseEventArgs e)
        {
            update(light, e.Button.ToString());
        }

        private void forestImg_MouseDown(object sender, MouseEventArgs e)
        {
            update(forest, e.Button.ToString());
        }

        private void fireImg_MouseDown(object sender, MouseEventArgs e)
        {
            update(fire, e.Button.ToString());
        }

        private void waterImg_MouseDown(object sender, MouseEventArgs e)
        {
            update(water, e.Button.ToString());
        }

        private void shadowImg_MouseDown(object sender, MouseEventArgs e)
        {
            update(shadow, e.Button.ToString());
        }

        private void spiritImg_MouseDown(object sender, MouseEventArgs e)
        {
            update(spirit, e.Button.ToString());
        }

        private void triforceImg_MouseDown(object sender, MouseEventArgs e)
        {
            update(triforce, e.Button.ToString());
        }

        //Event handler for when "Options" on the menu bar is clicked
        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            settingsForm.ShowDialog(); //Show the SettingsForm
            try
            {
                //On close, save input data into TrackerForm variables
                name = settingsForm.name;
                ip = settingsForm.ip + ":" + settingsForm.port;
                if (settingsForm.mode.Equals("host") || settingsForm.mode.Equals("client")) //If the form was close with the host or join button
                {
                    mode = settingsForm.mode; //Set mode
                    if (mode.Equals("host")) //Server setup
                    {
                        server = new SimpleTcpServer(ip);
                        server.Events.ClientConnected += Events_ClientConnected;
                        server.Events.ClientDisconnected += Events_ClientDisconnected;
                        server.Events.DataReceived += Events_HostDataReceived;
                        server.Keepalive.EnableTcpKeepAlives = true;
                        server.Keepalive.TcpKeepAliveRetryCount = 5;
                        try
                        {
                            server.Settings.MaxConnections = Int16.Parse(settingsForm.connections);
                            playersForm = new PlayersForm(name, ip, server.Settings.MaxConnections); //Instantiate the PlayersForm
                            playersToolStripMenuItem.Enabled = true; //Enable viewing the PlayersForm
                            server.Start();
                        }
                        catch (ArgumentException)
                        {
                            syncToolStripMenuItem.Enabled = false;
                            playersToolStripMenuItem.Enabled = false;
                            multiplayer = false;
                            MessageBox.Show("Player number invalid");
                            alertText.Text = "";
                        }
                        catch (FormatException)
                        {
                            syncToolStripMenuItem.Enabled = false;
                            playersToolStripMenuItem.Enabled = false;
                            multiplayer = false;
                            MessageBox.Show("Player number invalid");
                            alertText.Text = "";
                        }
                        catch (OverflowException)
                        {
                            syncToolStripMenuItem.Enabled = false;
                            playersToolStripMenuItem.Enabled = false;
                            multiplayer = false;
                            MessageBox.Show("Player number invalid");
                            alertText.Text = "";
                        }
                        catch (TimeoutException)
                        {
                            syncToolStripMenuItem.Enabled = false;
                            playersToolStripMenuItem.Enabled = false;
                            multiplayer = false;
                            MessageBox.Show("Other player disconnected");
                            alertText.Text = "";
                        }
                    }
                    else //Client setup
                    {
                        client = new SimpleTcpClient(ip);
                        client.Events.DataReceived += Events_ClientDataReceived;
                        client.Events.Disconnected += Events_Disconnected;
                        client.Events.Connected += Events_Connected;
                        try
                        {
                            client.Connect();
                        }
                        catch (TimeoutException)
                        {
                            syncToolStripMenuItem.Enabled = false;
                            multiplayer = false;
                            MessageBox.Show("Disconnected from other player");
                            alertText.Text = "";
                            client = null;
                            mode = "";
                        }
                    }
                }
            }
            catch (FormatException)
            {
                multiplayer = false;
                MessageBox.Show("A field was filled out incorrectly");
                server = null;
                client = null;
                mode = "";
            }
            catch (System.Net.Sockets.SocketException)
            {
                multiplayer = false;
                MessageBox.Show("Something went wrong with the connection.");
                server = null;
                client = null;
                mode = "";
            }
        }

        //Event Handler for the host when client connects
        private void Events_ClientConnected(object sender, ConnectionEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                syncToolStripMenuItem.Enabled = true;
            });
            multiplayer = true; //enable multiplayer mode
        }

        //Event Handler for the client when connecting to server
        private void Events_Connected(object sender, ConnectionEventArgs e)
        {
            syncToolStripMenuItem.Enabled = true;
            multiplayer = true;
            client.Send(name);
            MessageBox.Show("Connected to host");
        }

        //Event Handler for the server when a client disconnects
        private void Events_ClientDisconnected(object sender, ConnectionEventArgs e)
        {
            String tempName = "";
            this.Invoke((MethodInvoker)delegate
            {
                syncToolStripMenuItem.Enabled = false;
                if(playersForm.players.Count <= 1)
                {
                    multiplayer = false; //put it back into single player mode
                }
                alertText.Text = "";
                //get player that disconnected, remove them from the list, and notify the host
                tempName = playersForm.players[e.IpPort];
                playersForm.players.Remove(e.IpPort);
                playersForm.updateList();
            });
            MessageBox.Show(tempName + " disconnected");
        }

        //Event Handler for client when disconnecting from server
        private void Events_Disconnected(object sender, ConnectionEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                syncToolStripMenuItem.Enabled = false;
                multiplayer = false;
                alertText.Text = "";
                client = null;
                mode = "";
            });
            MessageBox.Show("Disconnected from host");
        }
        //Event Handler for when host recieves data, passes off that data to other clients as well
        private void Events_HostDataReceived(object sender, SuperSimpleTcp.DataReceivedEventArgs e)
        {
            List<String> tempIps = new List<String>();
            //Generate list of clients who did not send the data and are not this player. This is so client data goes to other clients
            foreach (String s in playersForm.players.Keys)
            {
                if (!s.Equals(ip) && !s.Equals(e.IpPort)){
                    tempIps.Add(s);
                }
            }

            if (fullSync) //For when expecting the next data to be fullSync data
            {
                byte[] data = e.Data.ToArray();
                for (int i = 0; i < items.Count; i++) //Go through recieved byte array and update all item states
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        Item item = items.ElementAt(i).Value;
                        item.set(item.name, Convert.ToBoolean(data[i]), Convert.ToInt16(data[i + items.Count]), Convert.ToInt16(data[i + (items.Count * 2)]));
                    });
                }
                fullSync = false; //End fullSync listen
                foreach (String s in tempIps)
                {
                    server.Send(s, "SYNCING ALL ITEMS");
                }
                System.Threading.Thread.Sleep(1000);
                foreach (String s in tempIps)
                {
                    server.Send(s, data);
                }
            }
            else
            {
                String data = Encoding.UTF8.GetString(e.Data);

                if (data.Equals("SYNCING ALL ITEMS")) //If this string is recieved, expect the next data to be an array with data for all items in byte form
                {
                    fullSync = true; //Enable fullSync listening
                }
                else if (data.Split(",").Length == 1) //If a player name is sent, it means a player joined, so add them to the list and notify the host
                {
                    playersForm.players.Add(e.IpPort, data);
                    playersForm.updateList();
                    MessageBox.Show(data + " connected");
                }
                else //Otherwise, the data is for one item being obtained or removed, so parse the data, then call function to update it on the tracker
                {
                    String[] splitData = data.Split(",");
                    String username = splitData[0];
                    bool add = Convert.ToBoolean(splitData[2]);
                    bool progressive = Convert.ToBoolean(splitData[3]);
                    sync(username, items[splitData[1]], add);
                    foreach(String s in tempIps){
                        server.Send(s, data);
                    }
                }
            }
        }

        //Event Handler for when client recieves data
        private void Events_ClientDataReceived(object sender, SuperSimpleTcp.DataReceivedEventArgs e)
        {
            if (fullSync) //For when expecting the next data to be fullSync data
            {
                byte[] data = e.Data.ToArray();
                for (int i = 0; i < items.Count; i++) //Go through recieved byte array and update all item states
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        Item item = items.ElementAt(i).Value;
                        item.set(item.name, Convert.ToBoolean(data[i]), Convert.ToInt16(data[i + items.Count]), Convert.ToInt16(data[i + (items.Count * 2)]));
                    });
                }
                fullSync = false; //End fullSync listen
            }
            else
            {
                String data = Encoding.UTF8.GetString(e.Data);

                if (data.Equals("SYNCING ALL ITEMS")) //If this string is recieved, expect the next data to be an array with data for all items in byte form
                {
                    fullSync = true; //Enable fullSync listening
                }
                else //Otherwise, the data is for one item being obtained or removed, so parse the data, then call function to update it on the tracker
                {
                    String[] splitData = data.Split(",");
                    String username = splitData[0];
                    bool add = Convert.ToBoolean(splitData[2]);
                    bool progressive = Convert.ToBoolean(splitData[3]);
                    sync(username, items[splitData[1]], add);
                }
            }
        }

        //Event Handler for when sync button is pressed on the menu bar
        private void syncToolStripMenuItem_Click(object sender, EventArgs e) 
        {
            //Array is formated where index i is obtained, index i + the amount of items is num, and index i + two of the amount of items is the loc.
            //This comes out to be {obtained, (all the other obtains), num, (all the other nums), loc, (all the other loc)} in the array for the first item.
            //Since items in the dictionary are the same for each player, the item it relates to is implied by the location in the array
            byte[] data = new byte[items.Count * 3];
            int i = 0;
            foreach (Item item in items.Values)
            {
                data[i] = Convert.ToByte(item.obtained); //add obtained into array
                if (item.progressive && !item.name.Equals("Wallet Upgrade")) //Progressive item case
                {
                    ProgressiveItem pItem = (ProgressiveItem)item; //Cast to progressive item to get other data
                    data[i + items.Count] = Convert.ToByte(pItem.num); //add num to array
                    data[i + (items.Count * 2)] = Convert.ToByte(pItem.loc); //add loc to array
                }
                else if(item.name.Equals("Wallet Upgrade")) //Special case for wallet num since it is bigger than a byte so must be converted to a smaller number
                {
                    ProgressiveItem pItem = (ProgressiveItem)item;
                    int num = 1;
                    switch (pItem.num)
                    {
                        case 99:
                            num = 1;
                            break;

                        case 200:
                            num = 2;
                            break;

                        case 500:
                            num = 3;
                            break;

                        case 999:
                            num = 4;
                            break;
                    }
                    data[i + items.Count] = Convert.ToByte(num);
                    data[i + (items.Count * 2)] = Convert.ToByte(pItem.loc);
                }
                else //If regular item, add 0 for num and loc to keep the spacing
                {
                    data[i + items.Count] = 0;
                    data[i + (items.Count * 2)] = 0;
                }
                i++;
            }
            //Send syncing message, wait a second to make sure the other player for sure recieved it, then send all the data
            if (mode.Equals("host")) 
            {
                foreach (String clientIp in playersForm.players.Keys)
                {
                    server.Send(clientIp, "SYNCING ALL ITEMS");
                }
                System.Threading.Thread.Sleep(1000);
                foreach (String clientIp in playersForm.players.Keys)
                {
                    server.Send(clientIp, data);
                }
            }
            else
            {
                client.Send("SYNCING ALL ITEMS");
                System.Threading.Thread.Sleep(1000);
                client.Send(data);
            }
        }

        //Event handler to open PlayersForm when players button on menu bar is pressed
        private void playersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            playersForm.updateList();
            playersForm.Show();
        }
    }
}