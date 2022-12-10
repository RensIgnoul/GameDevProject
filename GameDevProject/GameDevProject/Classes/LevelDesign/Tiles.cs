using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevProject.Classes.LevelDesign
{
    /*internal class Tiles
    {
        public Texture2D texture;
        private Rectangle rectangle;
        public Rectangle Rectangle
        {
            get { return rectangle; }
            set { rectangle = value; }
        }

        private static ContentManager content;
        public static ContentManager Content
        {
            get { return content; }
            set { content = value; }
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture,Rectangle, Color.White);
        }
    }*/
    internal class Tiles
    {
        public Texture2D texture;
        private Rectangle rectangle;
        public Rectangle DestinationRectangle
        {
            get { return rectangle; }
            set { rectangle = value; }
        }
        public Rectangle SourceRectangle { get; set; }
        public Vector2 Position { get; set; }

        private static ContentManager content;
        public static ContentManager Content
        {
            get { return content; }
            set { content = value; }
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, DestinationRectangle, SourceRectangle,Color.White);//, Color.White, 0, new Vector2(0, 0), 6f, SpriteEffects.None, 0);
        }
    }
}
