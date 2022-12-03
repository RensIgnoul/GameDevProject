using GameDevProject.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevProject.Classes.NeutralUnits
{
    internal class NeutralUnit : IGameObject,IAnimation,IUnit
    {
        public Vector2 Position { get; set; }
        public Rectangle HitBox { get; set; }

        Texture2D texture;
        public NeutralUnit(Texture2D texture, int x, int y)
        {
            Position = new Vector2(x, y);
            this.texture = texture;

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            throw new NotImplementedException();
        }

        public void Update(GameTime gameTime)
        {
            throw new NotImplementedException();
        }
        public void Collision(Rectangle newRectangle)
        {
            throw new NotImplementedException();
        }

        public void CreateAnimations()
        {
            throw new NotImplementedException();
        }
    }
}
