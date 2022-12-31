using GameDevProject.Classes.Animations;
using GameDevProject.Interfaces;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevProject.Classes.Enemies
{
    internal abstract class Enemy : IGameObject, IAnimation, IUnit
    {
        internal Texture2D texture;
        public int Health = 1;
        public Rectangle HitBox { get; set; }
        public SpriteEffects SpriteOrientation { get; set; }
        public Vector2 Position { get; set; }
        public Vector2 Speed;
        public int directionModifier = 1;
        public Animation runningAnimation;
        public bool IsAttacking;
        public Animation _currentAnimation;
        public Enemy(Texture2D texture, int x, int y)
        {
            this.texture = texture;
            CreateAnimations();
            Position = new Vector2(x, y);
            Speed = new Vector2(5, 0);
            SpriteOrientation = SpriteEffects.None;
            HitBox = new Rectangle((int)Position.X, (int)Position.Y, 76, 76);
            _currentAnimation = runningAnimation;
        }

        public virtual void Draw(SpriteBatch spriteBatch) { }
        public virtual void Update(GameTime gameTime) { }
        public void Collision(Rectangle newRectangle)
        {
            if (HitBox.TouchTopOf(newRectangle))
            {
                HitBox/*.Y*/ = new Rectangle(HitBox.X,newRectangle.Y - (HitBox.Height + 1),HitBox.Width,HitBox.Height);
            }
            if (HitBox.TouchLeftOf(newRectangle))
            {
                directionModifier = -1;
                Position/*.X*/ = new Vector2(Position.X - 15,Position.Y);
                SpriteOrientation = SpriteEffects.FlipHorizontally;
            }
            if (HitBox.TouchRightOf(newRectangle))
            {
                Position/*.X*/ = new Vector2(Position.X + 10,Position.Y);
                directionModifier = 1;

                SpriteOrientation = SpriteEffects.None;
            }
            if (HitBox.TouchBottomOf(newRectangle))
            {
                Speed.Y = 1f;
            }
        }
        public virtual void Attack(GameTime gameTime) { }

        public virtual void CreateAnimations() { }
    }
}
