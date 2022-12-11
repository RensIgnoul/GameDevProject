using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using System.Diagnostics;

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
            texture = Content.Load<Texture2D>("TileSet/LevelOne/LevelOneTileSet");
            DestinationRectangle = newRectangle;
            switch (i)
            {
                case 1:
                    SourceRectangle = new Rectangle(130, 286, 18, 18);
                    break;
                case 2:
                    SourceRectangle = new Rectangle(148, 286, 18, 18);
                    break;
                case 3:
                    SourceRectangle = new Rectangle(166, 286, 18, 18);
                    break;
                case 4:
                    SourceRectangle = new Rectangle(183, 286, 18, 18);
                    break;
                case 5:
                    SourceRectangle = new Rectangle(201, 286, 18, 18);
                    break;
                case 6:
                    SourceRectangle = new Rectangle(219, 286, 18, 18);
                    break;
                case 7:
                    SourceRectangle = new Rectangle(306, 238, 19, 19);
                    break;
                case 8:
                    SourceRectangle = new Rectangle(324, 238, 19, 18);
                    break;
                case 9:
                    SourceRectangle = new Rectangle(343, 238, 25, 19);
                    break;
                case 10:
                    SourceRectangle = new Rectangle(285, 351, 18, 18);
                    break;
                case 11:
                    SourceRectangle = new Rectangle(267, 351, 18, 18);
                    break;
                case 12:
                    SourceRectangle = new Rectangle(242, 350, 18, 18);
                    break;
                case 13:
                    SourceRectangle = new Rectangle(259, 351, 18, 18);
                    break;
                case 14:
                    SourceRectangle = new Rectangle(277, 351, 18, 18);
                    break;
                case 15:
                    SourceRectangle = new Rectangle(241, 318, 19, 19);
                    break;
                case 16:
                    SourceRectangle = new Rectangle(127, 349, 17, 18);
                    break;
                case 17:
                    SourceRectangle = new Rectangle(126,336, 18, 19);
                    break;
                case 18:
                    SourceRectangle = new Rectangle(242, 336, 19, 19);
                    break;
                case 19:
                    SourceRectangle = new Rectangle(94,286, 18, 18);
                    break;
                case 20:
                    SourceRectangle = new Rectangle(18, 402, 18, 18);
                    break;
                case 21:
                    SourceRectangle = new Rectangle(628, 130, 32, 32);
                    break;
                case 22:
                    SourceRectangle = new Rectangle(835, 78 , 32, 37);
                    break;
                case 23:
                    SourceRectangle = new Rectangle(802, 130, 32, 32);
                    break;
                case 24:
                    SourceRectangle = new Rectangle(772, 78, 32, 37);
                    break;
                case 25:
                    SourceRectangle = new Rectangle(912,34,37,32);
                        break;
                case 26:
                    SourceRectangle = new Rectangle(913, 66, 35, 32);
                    break;
                case 27:
                    SourceRectangle = new Rectangle(912, 99, 39, 30);
                    break;
                case 28:
                    SourceRectangle = new Rectangle(628, 79, 33, 37);
                    break;
                case 29:
                    SourceRectangle = new Rectangle(662, 77, 28, 39);
                    break;
                case 30:
                    SourceRectangle = new Rectangle(704, 114, 38, 29);
                    break;
                case 31:
                    SourceRectangle = new Rectangle(804, 78, 37, 37);
                    break;

            }
            /*switch (i)
            {
                case 1:
                    SourceRectangle = new Rectangle(32, 32, 16, 16);
                    break;
                case 2:
                    SourceRectangle = new Rectangle(80, 32, 16, 16);
                    break;
                case 3:
                    SourceRectangle = new Rectangle(96, 32, 16, 16);
                    break;
                case 4:
                    SourceRectangle = new Rectangle(80, 48, 16, 16);
                    break;
                case 5:
                    SourceRectangle = new Rectangle(96, 48, 16, 16);
                    break;
                case 6:
                    SourceRectangle = new Rectangle(128, 16, 16, 16);
                    break;
                case 7:
                    SourceRectangle = new Rectangle(144, 16, 16, 16);
                    break;
                case 8:
                    SourceRectangle = new Rectangle(128, 32, 16, 16);
                    break;
                case 9:
                    SourceRectangle = new Rectangle(144, 32, 16, 16);
                    break;
                case 10:
                    SourceRectangle = new Rectangle(160, 80, 16, 16);
                    break;
                case 11:
                    SourceRectangle = new Rectangle(192, 16, 16, 16);
                    break;
                case 12:
                    SourceRectangle = new Rectangle(208, 16, 16, 16);
                    break;
                case 13:
                    SourceRectangle = new Rectangle(192, 32, 16, 16);
                    break;
                case 14:
                    SourceRectangle = new Rectangle(208, 32, 16, 16);
                    break;


            }*/
        }
    }
}
