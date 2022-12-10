using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevProject.Classes.LevelDesign
{
    /*internal class Map
    {
        private List<CollisionTiles> collisionTiles = new List<CollisionTiles>();
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

                    if (nr > 0)
                    {
                        collisionTiles.Add(new CollisionTiles(nr, new Rectangle(i * size, j * size, size, size)));
                    }
                    width = (i + 1) * size;
                    height = (j + 1) * size;
                }
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var tile in collisionTiles)
            {
                tile.Draw(spriteBatch);
            }
        }
    }*/
    internal class Map
    {
        private List<CollisionTiles> collisionTiles = new List<CollisionTiles>();
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
                    width = (i /*+ 1*/) * size;
                    height = (j /**+ 1*/) * size;
                    if (nr > 0)
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
        }
    }
}
