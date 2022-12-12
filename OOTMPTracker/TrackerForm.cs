using SuperSimpleTcp;
using System.Diagnostics;
using System.Text;

namespace OOTMPTracker
{
    public partial class TrackerForm : Form
    {
        public static String name;
        public static String ip;
        private String targetIp;
        public static String mode;
        public static Dictionary<String, Item> items = new Dictionary<string, Item>();
        private bool multiplayer = false;
        private SettingsForm settingsForm;
        private SimpleTcpServer server;
        private SimpleTcpClient client;
        private bool fullSync = false;

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
            syncToolStripMenuItem.Enabled = false;
            settingsForm = new SettingsForm();

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

        public void update(Item item, String click)
        {
            if (click.Equals("Left"))
            {
                item.obtain(true);
                if (multiplayer && item.progressive)
                {
                    alertText.Text = name + " found a " + item.name;
                    if (mode.Equals("host"))
                    {
                        server.Send(targetIp, name + "," + item.name + "," + "true" + "," + "true");
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
                        server.Send(targetIp, name + "," + item.name + "," + "true" + "," + "false");
                    }
                    else
                    {
                        client.Send(name + "," + item.name + "," + "true" + "," + "false");
                    }
                }

            }
            else if (click.Equals("Right"))
            {
                item.obtain(false);
                if (multiplayer && item.progressive)
                {
                    alertText.Text = name + " removed a " + item.name;
                    if (mode.Equals("host"))
                    {
                        server.Send(targetIp, name + "," + item.name + "," + "false" + "," + "true");
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
                        server.Send(targetIp, name + "," + item.name + "," + "false" + "," + "false");
                    }
                    else
                    {
                        client.Send(name + "," + item.name + "," + "false" + "," + "false");
                    }
                }
            }
        }

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

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            settingsForm.ShowDialog();
            try
            {
                name = settingsForm.name;
                ip = settingsForm.ip + ":" + settingsForm.port;
                if (settingsForm.mode.Equals("host") || settingsForm.mode.Equals("client"))
                {
                    mode = settingsForm.mode;
                    if (mode.Equals("host"))
                    {
                        server = new SimpleTcpServer(ip);
                        server.Events.ClientConnected += Events_ClientConnected;
                        server.Events.ClientDisconnected += Events_ClientDisconnected;
                        server.Events.DataReceived += Events_DataReceived;
                        server.Keepalive.EnableTcpKeepAlives = true;
                        server.Keepalive.TcpKeepAliveRetryCount = 5;
                        server.Settings.MaxConnections = 1;
                        try
                        {
                            server.Start();
                        }
                        catch (TimeoutException)
                        {
                            syncToolStripMenuItem.Enabled = false;
                            multiplayer = false;
                            MessageBox.Show("Other player disconnected");
                            alertText.Text = "";
                        }
                    }
                    else
                    {
                        client = new SimpleTcpClient(ip);
                        client.Events.DataReceived += Events_DataReceived;
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

        private void Events_ClientConnected(object sender, ConnectionEventArgs e)
        {
            targetIp = e.IpPort;
            MessageBox.Show("Client Connected");
            this.Invoke((MethodInvoker)delegate
            {
                syncToolStripMenuItem.Enabled = true;
            });
            multiplayer = true;
        }

        private void Events_Connected(object sender, ConnectionEventArgs e)
        {
            MessageBox.Show("Connected");
            syncToolStripMenuItem.Enabled = true;
            multiplayer = true;
        }

        private void Events_ClientDisconnected(object sender, ConnectionEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                syncToolStripMenuItem.Enabled = false;
                multiplayer = false;
                MessageBox.Show("Other player disconnected");
                alertText.Text = "";
            });
        }

        private void Events_Disconnected(object sender, ConnectionEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                syncToolStripMenuItem.Enabled = false;
                multiplayer = false;
                MessageBox.Show("Disconnected from other player");
                alertText.Text = "";
                client = null;
                mode = "";
            });
        }

        private void Events_DataReceived(object sender, SuperSimpleTcp.DataReceivedEventArgs e)
        {
            if (fullSync)
            {
                byte[] data = e.Data.ToArray();
                for (int i = 0; i < items.Count; i++)
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        Item item = items.ElementAt(i).Value;
                        item.set(item.name, Convert.ToBoolean(data[i]), Convert.ToInt16(data[i + items.Count]), Convert.ToInt16(data[i + (items.Count * 2)]));
                    });
                }
                fullSync = false;
            }
            else
            {
                String data = Encoding.UTF8.GetString(e.Data);

                if (data.Equals("SYNCING ALL ITEMS"))
                {
                    fullSync = true;
                }

                else
                {
                    String[] splitData = data.Split(",");
                    String username = splitData[0];
                    bool add = Convert.ToBoolean(splitData[2]);
                    bool progressive = Convert.ToBoolean(splitData[3]);
                    sync(username, items[splitData[1]], add);
                }
            }
        }

        private void syncToolStripMenuItem_Click(object sender, EventArgs e)
        {
            byte[] data = new byte[items.Count * 3];
            int i = 0;
            foreach (Item item in items.Values)
            {
                data[i] = Convert.ToByte(item.obtained);
                if (item.progressive)
                {
                    ProgressiveItem pItem = (ProgressiveItem)item;
                    data[i + items.Count] = Convert.ToByte(pItem.num);
                    data[i + (items.Count * 2)] = Convert.ToByte(pItem.loc);
                }
                else
                {
                    data[i + items.Count] = 0;
                    data[i + (items.Count * 2)] = 0;
                }
                i++;
            }
            if (mode.Equals("host"))
            {
                server.Send(targetIp, "SYNCING ALL ITEMS");
                System.Threading.Thread.Sleep(1000);
                server.Send(targetIp, data);
            }
            else
            {
                client.Send("SYNCING ALL ITEMS");
                System.Threading.Thread.Sleep(1000);
                client.Send(data);
            }
        }
    }
}