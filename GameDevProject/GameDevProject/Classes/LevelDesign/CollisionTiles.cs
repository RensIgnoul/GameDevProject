using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace GameDevProject.Classes.LevelDesign
{
    /*internal class CollisionTiles : Tiles
    {
        public CollisionTiles(int i, Rectangle newRectangle)
        {
            texture = Content.Load<Texture2D>("Tile" + i);
            DestinationRectangle = newRectangle;
        }
    }*/
    internal class CollisionTiles : Tiles
    {
        public CollisionTiles(int i, int x, int y, Rectangle newRectangle)
        {
            Position = new Vector2(x, y);
            texture = Content.Load<Texture2D>("TileSet/DungeonTileSet");
            DestinationRectangle = newRectangle;
            if (i == 1)// || i == 2)
            {
                SourceRectangle = new Rectangle(32, 32, 17, 17);
            }
            if (i == 2)
            {
                SourceRectangle = new Rectangle(144, 16, 17, 17);
            }
        }
    }
}
