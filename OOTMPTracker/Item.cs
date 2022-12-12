using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOTMPTracker
{
    public class Item
    {
        public String name { get; }
        protected bool starter;
        protected PictureBox picture;
        public bool obtained { get; protected set; } = true;
        public bool progressive { get; protected set; } = false;

        public Item(string name, bool starter, PictureBox picture)
        {
            this.name = name;
            this.starter = starter;
            this.picture = picture;
            if (!starter)
            {
                picture.Image = changeTransparency(picture.Image, 80);
                obtained = false;
            }
            TrackerForm.items.Add(this.name, this);
        }

        public virtual void obtain(bool add)
        {
            if (add)
            {
                obtained = true;
                picture.Image = changeTransparency(picture.Image, 255);
            }
            else
            {
                if (!starter)
                {
                    obtained = false;
                    picture.Image = changeTransparency(picture.Image, 80);
                }
            }
        }

        protected Bitmap changeTransparency(Image image, int alpha)
        {
            Bitmap original = new Bitmap(image);
            Bitmap newImage = new Bitmap(image.Width, image.Height);
            for (int i = 0; i < image.Width; i++)
            {
                for (int j = 0; j < image.Height; j++)
                {
                    Color pixelColor = original.GetPixel(i, j);
                    Color c = Color.FromArgb(alpha, pixelColor.R, pixelColor.G, pixelColor.B);
                    newImage.SetPixel(i, j, c);
                }
            }
            return newImage;
        }

        public virtual void set(String itemName, bool obtained, int num, int loc)
        {
            obtain(obtained);
        }
    }
}
