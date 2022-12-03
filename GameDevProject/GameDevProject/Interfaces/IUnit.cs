using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevProject.Interfaces
{
    internal interface IUnit
    {
        public Vector2 Position { get; set; }
        public Rectangle HitBox { get; set; }
        public void Collision(Rectangle newRectangle);
        void Update(GameTime gameTime);
        void Draw(SpriteBatch sprite);
    }
}
