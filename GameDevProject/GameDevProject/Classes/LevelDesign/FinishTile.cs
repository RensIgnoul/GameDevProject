using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevProject.Classes.LevelDesign
{
    internal class FinishTile : CollisionTiles
    {
        public FinishTile(int i, int x, int y, Rectangle newRectangle) : base(i, x, y, newRectangle)
        {
        }
    }
}
