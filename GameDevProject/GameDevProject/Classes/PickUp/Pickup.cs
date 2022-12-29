using GameDevProject.Classes.Animations;
using GameDevProject.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevProject.Classes.PickUp
{
    internal class Pickup:IGameObject
    {
        public Texture2D texture;
        public Vector2 Position { get; set; }
        public Rectangle HitBox;

        internal Animation rotationAnimation;

        public Pickup(int x, int y, Texture2D texture)
        {
            rotationAnimation = new Animation();
            this.texture = texture;
            Position = new Vector2(x, y);
            HitBox = new Rectangle((int)Position.X, (int)Position.Y, 16, 16);
        }

        public void Update(GameTime gameTime)
        {
            rotationAnimation.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, Position,new Rectangle(352,0,16,16),Color.White,0,new Vector2(0,0),2,SpriteEffects.None,1);
        }
    }
}
