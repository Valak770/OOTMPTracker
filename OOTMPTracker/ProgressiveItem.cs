using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOTMPTracker
{
    public class ProgressiveItem : Item
    {
        private int min;
        private int max;
        private int inc;
        private bool spriteChange;
        private Label count;
        public int num { get; set; } = 0;
        public int loc { get; set; } = 0;

        public ProgressiveItem(String name, bool starter, PictureBox picture, int min, int max, int inc, Label count) : base(name, starter, picture)
        {
            progressive = true;
            this.min = min;
            this.max = max;
            this.inc = inc;
            this.spriteChange = false;
            this.count = count;
            this.num = min;

            if (!starter && count != null)
            {
                count.Visible = false;
            }
        }

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

            if (!starter && count != null)
            {
                count.Visible = false;
            }
        }

        public override void obtain(bool add)
        {
            if (add)
            {
                if (spriteChange)
                {
                    if (!obtained)
                    {
                        base.obtain(true);
                        if (count != null)
                        {
                            count.Visible = true;
                        }
                    }
                    else
                    {
                        if (num != max)
                        {
                            num++;
                            loc++;
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
                                count.Text = "L";
                            }
                        }
                    }
                }
                else
                {
                    if (!obtained)
                    {
                        base.obtain(true);
                        count.Visible = true;
                    }
                    else
                    {
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
                        else if (Int32.Parse(count.Text.ToString()) != max)
                        {
                            num = Int32.Parse(count.Text.ToString()) + inc;
                            count.Text = num.ToString();
                        }
                    }
                }
            }
            
            //remove
            else
            {
                if (spriteChange)
                {
                    if (!starter && obtained && num == 1)
                    {
                        base.obtain(false);
                        if (count != null)
                        {
                            count.Visible = false;
                        }
                    }
                    else
                    {
                        if (num != min)
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
                else
                {
                    if (!starter && obtained && num == min)
                    {
                        base.obtain(false);
                        count.Visible = false;
                    }
                    else
                    {
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
                        else if (Int32.Parse(count.Text.ToString()) != min)
                        {
                            num = Int32.Parse(count.Text.ToString()) - inc;
                            count.Text = num.ToString();
                        }
                    }
                }
            }
        }

        public override void set(String itemName, bool obtained, int num, int loc)
        {
            if(count != null)
            {
                count.Visible = obtained;
            }
            this.obtained = obtained;
            this.num = num;
            this.loc = loc;
            if (spriteChange)
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
            switch (itemName)
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
            base.obtain(obtained);
        }

    }
}
