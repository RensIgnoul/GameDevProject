using GameDevProject.Classes.PickUp;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevProject.Classes.Factory
{
    internal class PickupFactory
    {
        public Pickup CreatePickUp(string type, int x,int y, Texture2D texture)
        {
            if (type.ToUpper()=="COIN")
            {
                return new Pickup(x, y, texture);
            }
            return null;
        }
    }
}
