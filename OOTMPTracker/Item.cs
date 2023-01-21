//Author: Valak770
//Description: Representative of all items on tracker with one instance in game

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOTMPTracker
{
    public class Item
    {
        public String name { get; } //item name
        protected bool starter; //if player start with item
        protected PictureBox picture; //PictureBox object
        public bool obtained { get; protected set; } = true; //if the item has been obtained
        public bool progressive { get; protected set; } = false; //if the item is progressive (for sync purposes)

        public Item(string name, bool starter, PictureBox picture)
        {
            this.name = name;
            this.starter = starter;
            this.picture = picture;
            if (!starter) //If not started with, make it default not obtained
            {
                picture.Image = changeTransparency(picture.Image, 80);
                obtained = false;
            }
            TrackerForm.items.Add(this.name, this); //Add to Dictionary of all items
        }

        //Add or remove the item based on input
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

        //Helper function that changes item transparency to show obtained status
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

        //Set the item state for sync purposes (here for inheritance/polymorphism purposes)
        public virtual void set(String itemName, bool obtained, int num, int loc)
        {
            obtain(obtained);
        }
    }
}
