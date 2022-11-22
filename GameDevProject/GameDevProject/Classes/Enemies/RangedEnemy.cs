using GameDevProject.Classes.Animations;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevProject.Classes.Enemies
{
    internal class RangedEnemy : Enemy
    {
        public Texture2D ProjectileSprite;
        //public List<Projectile> Projectiles = new List<Projectile>();
        public bool IsPatrolling;

        float attackTimer = 0;
        Animation attackingAnimation;
        public RangedEnemy(Texture2D texture, int x, int y, Texture2D projectile) : base(texture, x, y)
        {
            ProjectileSprite = projectile;
            IsPatrolling = true;
            IsAttacking = false;
            HitBox = new Rectangle((int)Position.X, (int)Position.Y, 65, 65);
        }

        public override void Update(GameTime gameTime)
        {
            HitBox.X = (int)Position.X + 60;
            HitBox.Y = (int)Position.Y + 80;
            runningAnimation.Update(gameTime);

            attackingAnimation.Update(gameTime);
            if (IsAttacking)
            {
                attackTimer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
                if (attackTimer >= 700)
                {
                    IsAttacking = false;
                    attackTimer = 0;
                }
            }
            else
            {
                attackingAnimation.counter = 0;
            }
            UpdateProjectiles();
            Position += Speed;//*directionModifier;
            /*if (Speed.Y < 10)
            {
                Speed.Y += 0f;
            }
            if (IsPatrolling)
            {*/
            Speed.X = 5 * directionModifier;
            //}    
            _currentAnimation = runningAnimation;
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            if (Health > 0)
            {
                spriteBatch.Draw(texture, Position, _currentAnimation.CurrentFrame.SourceRectangle, Color.White, 0, new Vector2(0, 0), new Vector2(2, 2), spriteOrientation, 1);
            }
        }
        public override void Attack(GameTime gameTime)
        {
            Speed.X = 0;
            _currentAnimation = attackingAnimation;
            Projectile newProjectile = new Projectile(ProjectileSprite, 48, 10, spriteOrientation);
            if (spriteOrientation == SpriteEffects.None)
            {
                newProjectile.Speed = new Vector2(5, 0);
            }
            if (spriteOrientation == SpriteEffects.FlipHorizontally)
            {
                newProjectile.Speed = new Vector2(-5, 0);
            }
            newProjectile.Position = new Vector2(Position.X + HitBox.Width, HitBox.Y /*+ (HitBox.Height / 10)*/) + newProjectile.Speed * 5;


            newProjectile.IsVisible = true;
            if (Projectiles.Count < 1)
            {
                Projectiles.Add(newProjectile);
                IsAttacking = true;
            }
        }
        public void UpdateProjectiles()
        {
            foreach (var projectile in Projectiles)
            {
                projectile.Position += projectile.Speed;
                projectile.HitBox.X = (int)projectile.Position.X;
                projectile.HitBox.Y = (int)projectile.Position.Y;
                if (Vector2.Distance(projectile.Position, Position) > 500) // maakt kogel onzichtbaar na 500px
                {
                    projectile.IsVisible = false;
                }
            }
            for (int i = 0; i < Projectiles.Count; i++)
            {
                if (!Projectiles[i].IsVisible)
                {
                    Projectiles.RemoveAt(i);
                    i--;
                }
            }
        }

        public override void CreateAnimations()
        {
            List<Rectangle> runningFrames = new List<Rectangle>();
            List<Rectangle> idleFrames = new List<Rectangle>();
            List<Rectangle> jumpingFrames = new List<Rectangle>();
            List<Rectangle> attackingFrames = new List<Rectangle>();
            int frameWidth = 100;


            runningAnimation = new Animation();
            attackingAnimation = new Animation();


            for (int i = 0; i < 8 * frameWidth; i += frameWidth)
            {
                runningFrames.Add(new Rectangle(i, 100, frameWidth, 100));
            }
            for (int i = 0; i < 6 * frameWidth; i += frameWidth)
            {
                idleFrames.Add(new Rectangle(i, 192, frameWidth, 192));
            }
            for (int i = 0 * frameWidth; i < 2 * frameWidth; i += frameWidth)
            {
                jumpingFrames.Add(new Rectangle(i, 384, frameWidth, 192));
            }
            for (int i = 0 * frameWidth; i < 6 * frameWidth; i += frameWidth)
            {
                attackingFrames.Add(new Rectangle(i, 0, frameWidth, 100));
            }
            runningAnimation.AddFrameList(runningFrames);
            attackingAnimation.AddFrameList(attackingFrames);
        }
    }
}
