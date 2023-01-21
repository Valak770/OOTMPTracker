//Author: Valak770
//Description: Representative of all items on tracker with multiple instances or upgrades in game

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOTMPTracker
{
    public class ProgressiveItem : Item
    {
        private int min; //Minimum amount of the item
        private int max; //Maximum amount of the item
        private int inc; //Amount to increment the amount by on add or remove
        private bool spriteChange; //If the item changes sprites when incremented. Sprite change items use increments of 1
        private Label count; //Label that visually displays the item's amount (not how many obtained, ex. max arrows)
        public int num { get; set; } = 0; //Amount the item has (not how many obtained, ex. max arrows)
        public int loc { get; set; } = 0; //Sprite number of the item (for sprite change items)

        //Constructor for non sprite change items
        public ProgressiveItem(String name, bool starter, PictureBox picture, int min, int max, int inc, Label count) : base(name, starter, picture)
        {
            progressive = true;
            this.min = min;
            this.max = max;
            this.inc = inc;
            this.spriteChange = false;
            this.count = count;
            this.num = min;

            if (!starter && count != null) //Hide count label if it exists and the item is not a starting item
            {
                count.Visible = false;
            }
        }

        //Constructor for sprite change items
        public ProgressiveItem(String name, bool starter, PictureBox picture, int min, int max, int inc, Label count, int loc) : base(name, starter, picture)
        {
            progressive=true;
            this.min = min;
            this.max = max;
            this.inc = inc;
            this.spriteChange = true;
            this.count = count;
            this.loc = loc;
            this.num = min;

            if (!starter && count != null) //Hide count label if it exists and the item is not a starting item
            {
                count.Visible = false;
            }
        }

        //Add or remove the item based on input
        public override void obtain(bool add)
        {
            if (add)
            {
                //Add
                if (spriteChange) //For Sprite changes
                {
                    if (!obtained) //First obtained, change to not transparent and show count
                    {
                        base.obtain(true);
                        if (count != null)
                        {
                            count.Visible = true;
                        }
                    }
                    else //Second+ obtained
                    {
                        if (num != max) //Only if item can be obtained again
                        {
                            num++;
                            loc++;
                            //set image
                            if (loc < 10)
                            {
                                picture.Image = (Image)OOTMPTracker.Properties.Resources.ResourceManager.GetObject("tile00" + loc);
                            }
                            else
                            {
                                picture.Image = (Image)OOTMPTracker.Properties.Resources.ResourceManager.GetObject("tile0" + loc);
                            }
                            if (count != null) //Special case for Hookshot since it's the only one with a count, change to "L" for longshot
                            {
                                count.Text = "L";
                            }
                        }
                    }
                }
                else //For non sprite change
                {
                    if (!obtained) //First obtained, change to not transparent and show count
                    {
                        base.obtain(true);
                        count.Visible = true;
                    }
                    else //Second+ obtained
                    {
                        //Special case for wallet upgrades, has uneven increments
                        if (Int32.Parse(count.Text.ToString()) != max && name.Equals("Wallet Upgrade"))
                        {
                            if (inc == 0)
                            {
                                inc = 101;
                                num = Int32.Parse(count.Text.ToString()) + inc;
                                count.Text = num.ToString();
                            }
                            else if (inc == 101)
                            {
                                inc = 300;
                                num = Int32.Parse(count.Text.ToString()) + inc;
                                count.Text = num.ToString();
                            }
                            else if (inc == 300)
                            {
                                inc = 499;
                                num = Int32.Parse(count.Text.ToString()) + inc;
                                count.Text = num.ToString();
                            }
                        }
                        //If not max, increment and display it
                        else if (Int32.Parse(count.Text.ToString()) != max)
                        {
                            num = Int32.Parse(count.Text.ToString()) + inc;
                            count.Text = num.ToString();
                        }
                    }
                }
            }
            
            //Remove
            else
            {
                if (spriteChange) //For sprite change
                {
                    if (!starter && obtained && num == 1) //Unobtain item if only one, hide count
                    {
                        base.obtain(false);
                        if (count != null)
                        {
                            count.Visible = false;
                        }
                    }
                    else
                    {
                        if (num != min) //Deincrement and change image to reflect it
                        {
                            num--;
                            loc--;
                            if (loc < 10)
                            {
                                picture.Image = (Image)OOTMPTracker.Properties.Resources.ResourceManager.GetObject("tile00" + loc);
                            }
                            else
                            {
                                picture.Image = (Image)OOTMPTracker.Properties.Resources.ResourceManager.GetObject("tile0" + loc);
                            }
                            if (count != null)
                            {
                                count.Text = "H";
                            }
                        }
                    }
                }
                else //For non sprite change
                {
                    if (!starter && obtained && num == min) //Unobtain item, hide count if only one obtained
                    {
                        base.obtain(false);
                        count.Visible = false;
                    }
                    else
                    {
                        //Special case for wallet, deals with the uneven increments
                        if (Int32.Parse(count.Text.ToString()) != min && name.Equals("Wallet Upgrade"))
                        {
                            if (inc == 499)
                            {
                                num = Int32.Parse(count.Text.ToString()) - inc;
                                count.Text = num.ToString();
                                inc = 300;
                            }
                            else if (inc == 300)
                            {
                                num = Int32.Parse(count.Text.ToString()) - inc;
                                count.Text = num.ToString();
                                inc = 101;
                            }
                            else if (inc == 101)
                            {
                                num = Int32.Parse(count.Text.ToString()) - inc;
                                count.Text = num.ToString();
                                inc = 0;
                            }
                        }
                        else if (Int32.Parse(count.Text.ToString()) != min) //If possible, deincrement and set text
                        {
                            num = Int32.Parse(count.Text.ToString()) - inc;
                            count.Text = num.ToString();
                        }
                    }
                }
            }
        }

        //Set the item state for sync purposes. Updates all data and visuals based on given parameters
        public override void set(String itemName, bool obtained, int num, int loc)
        {
            if(count != null) //show the count label if obtained
            {
                count.Visible = obtained;
            }
            this.obtained = obtained;
            this.num = num;
            this.loc = loc;
            if (spriteChange) //Set image
            {
                if (loc < 10)
                {
                    picture.Image = (Image)OOTMPTracker.Properties.Resources.ResourceManager.GetObject("tile00" + loc);
                }
                else
                {
                    picture.Image = (Image)OOTMPTracker.Properties.Resources.ResourceManager.GetObject("tile0" + loc);
                }
            }
            else
            {
                count.Text = num.ToString();
            }
            switch (itemName) //Special cases for Hookshot and Wallet. Hookshot is the only sprite change with a count, which are letters, and wallet has uneven increments
            {
                case "Hookshot":
                    if(num == 1)
                    {
                        count.Text = "H";
                    }
                    else
                    {
                        count.Text = "L";
                    }
                    break;

                case "Wallet Upgrade":
                    switch (num)
                    {
                        case 2:
                            this.num = 200;
                            inc = 101;
                            count.Text = this.num.ToString();
                            break;

                        case 3:
                            this.num = 500;
                            inc = 300;
                            count.Text = this.num.ToString();
                            break;

                        case 4:
                            this.num = 999;
                            inc = 499;
                            count.Text = this.num.ToString();
                            break;

                        default:
                            this.num = 99;
                            inc = 0;
                            count.Text = this.num.ToString();
                            break;
                    }
                    break;
            }
            base.obtain(obtained); //Sync obtained status
        }

    }
}
