using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevProject.Classes.Enemies
{
    internal class TrapEnemy : Enemy
    {
        public TrapEnemy(Texture2D texture, int x, int y) : base(texture, x, y)
        {
            this.texture = texture;
            IsPatrolling = false;
            HitBox = new Rectangle((int)Position.X, (int)Position.Y+25, 70, 35);
            Speed = new Vector2(0, 0);
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, Position,new Rectangle(128,0,32,32), Color.White,0,new Vector2(0,0),2.2f,SpriteEffects.None,1);
        }
        public override void Update(GameTime gameTime)
        {
            Position = new Vector2(HitBox.X, HitBox.Y-10);
        }
    }
}
