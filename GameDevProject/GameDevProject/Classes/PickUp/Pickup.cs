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
        Animation _currentAnimation;

        public Pickup(int x, int y, Texture2D texture)
        {
            this.texture = texture;
            CreateAnimation();
            Position = new Vector2(x, y);

            HitBox = new Rectangle((int)Position.X, (int)Position.Y, 16, 16);
            _currentAnimation = rotationAnimation;
        }

        public void Update(GameTime gameTime)
        {
            rotationAnimation.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //spriteBatch.Draw(texture, Position,new Rectangle(352,0,16,16),Color.White,0,new Vector2(0,0),2,SpriteEffects.None,1);
            spriteBatch.Draw(texture, Position, rotationAnimation.CurrentFrame.SourceRectangle, Color.White, 0, new Vector2(0, 0), 2, SpriteEffects.None, 1);
        }

        public void CreateAnimation()
        {
            List<Rectangle> rotationFrames = new List<Rectangle>();
            int frameWidth = 16;

            rotationAnimation = new Animation();
            for (int i = 21*frameWidth; i < 21*frameWidth+(9*frameWidth); i+=16)
            {
                rotationFrames.Add(new Rectangle(i, 0, 16, 16));
            }
            rotationAnimation.AddFrameList(rotationFrames);
        }
    }
}
