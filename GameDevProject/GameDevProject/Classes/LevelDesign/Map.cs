using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevProject.Classes.LevelDesign
{
    //Deze class is overgenomen van Oyyou (https://www.youtube.com/watch?v=PKlHcxFAEk0&t=67s&ab_channel=Oyyou)
    internal class Map
    {
        private List<CollisionTiles> collisionTiles = new List<CollisionTiles>();
        private List<FinishTile> finishTiles = new List<FinishTile>();
        public List<FinishTile> FinishTiles { get { return finishTiles; } }
        public List<CollisionTiles> CollisionTiles { get { return collisionTiles; } }


        private int width, height;

        public int Width
        {
            get { return width; }
        }
        public int Height
        {
            get { return height; }
        }

        public Map() { }

        public void Generate(int[,] map, int size)
        {
            for (int i = 0; i < map.GetLength(1); i++)
            {
                for (int j = 0; j < map.GetLength(0); j++)
                {
                    int nr = map[j, i];
                    width = (i) * size;
                    height = (j) * size;
                    if (nr == 50)
                    {
                        finishTiles.Add(new FinishTile(nr, width, height, new Rectangle(i * size, j * size, size, size)));
                    }
                    if (nr > 0 && nr<50)
                    {
                        collisionTiles.Add(new CollisionTiles(nr, width, height, new Rectangle(i * size, j * size, size, size)));
                    }

                }
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var tile in collisionTiles)
            {
                tile.Draw(spriteBatch);
            }
            foreach (var tile in finishTiles)
            {
                tile.Draw(spriteBatch);
            }
        }
    }
}
