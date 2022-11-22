using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevProject.Classes
{
    internal class Projectile
    {
        public Texture2D Texture;
        public Vector2 Position;
        public Vector2 Speed;
        public Vector2 Origin;
        public Rectangle HitBox;
        public SpriteEffects SpriteDirection;

        public bool IsVisible;
        public Projectile(Texture2D texture, int hitboxX, int hitboxY, SpriteEffects spriteDirection)
        {
            Texture = texture;
            IsVisible = false;
            HitBox = new Rectangle((int)Position.X, (int)Position.Y, hitboxX, hitboxY);//Texture.Width, Texture.Height);
            SpriteDirection = spriteDirection;
        }
        public void Draw(SpriteBatch spriteBatch, float scaleModifier)
        {
            spriteBatch.Draw(Texture, Position, null, Color.White, 0, Origin, 1 * scaleModifier, SpriteDirection, 0);
        }
    }
}
