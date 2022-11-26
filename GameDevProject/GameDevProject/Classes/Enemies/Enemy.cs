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
    internal class Enemy : IGameObject, IAnimation
    {
        //Random rng = new Random();
        internal Texture2D texture;
        Animation animation;
        public int Health = 1;
        public Rectangle HitBox;
        public SpriteEffects SpriteOrientation { get; set; }
        public Vector2 Position;
        public Vector2 Speed;
        //float patrolTimer = 0;
        public int directionModifier = 1;
        public Animation runningAnimation;
        public Texture2D ProjectileSprite;
        //public List<Projectile> Projectiles = new List<Projectile>();
        public bool IsPatrolling;
        //public bool hasHitWall;
        //public bool hasHitRWall;
        //public int BaseSpeed;
        public bool IsAttacking;
        public Animation _currentAnimation;
        public Enemy(Texture2D texture, int x, int y)
        {
            this.texture = texture;
            CreateAnimations();
            animation = new Animation();
            //animation.GetFramesFromTextureProperties(texture.Width, texture.Height, 5, 2);
            Position = new Vector2(x, y);
            Speed = new Vector2(5, 0);
            SpriteOrientation = SpriteEffects.None;
            HitBox = new Rectangle((int)Position.X, (int)Position.Y, 76, 76);
            //ProjectileSprite = projectile;
            IsPatrolling = true;
            _currentAnimation = runningAnimation;
            //     BaseSpeed = 5;
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            /*if (Health > 0)
            {
                spriteBatch.Draw(texture, Position, runningAnimation.CurrentFrame.SourceRectangle, color, 0, new Vector2(0, 0), new Vector2(1, 1), spriteOrientation, 1);
            }*/
        }

        public virtual void Update(GameTime gameTime) { }
        /*HitBox.X = (int)Position.X + 76;
        HitBox.Y = (int)Position.Y + 76;
        runningAnimation.Update(gameTime);
        //UpdateProjectiles();



        //Patrol(gameTime);
        if (IsPatrolling)
        {
            Speed.X = 5 * directionModifier;
        }
        else
        {
            Speed.X = 0;
        }
        Position += Speed;//*directionModifier;
        if (Speed.Y < 10)
        {
            Speed.Y += 0.4f;
        }*/


        /*public void Patrol(GameTime gameTime)
        {
            if (IsPatrolling)
            {
                Speed.X = Speed.X * directionModifier;
                //Position.X += Speed.X * directionModifier;
            }

        }
        public void ResumePatrol()
        {
            IsPatrolling = true;

        }*/
        public void Collision(Rectangle newRectangle)
        {
            if (HitBox.TouchTopOf(newRectangle))
            {

                HitBox.Y = newRectangle.Y - (HitBox.Height + 1);
            }
            if (HitBox.TouchLeftOf(newRectangle))
            {
                //Position.X = Position.X - 5;
                directionModifier = -1;
                Position.X = Position.X - 15;
                //Speed.X = -5; // = new Vector2(-5, 0);
                SpriteOrientation = SpriteEffects.FlipHorizontally;

            }
            if (HitBox.TouchRightOf(newRectangle))
            {
                Position.X = Position.X + 10;//+ newRectangle.Width;
                directionModifier = 1;
                //Speed.X = 5;
                SpriteOrientation = SpriteEffects.None;
                //Position.X = Position.X + 15;
            }
            if (HitBox.TouchBottomOf(newRectangle))
            {
                Speed.Y = 1f;
            }
        }
        /*public void CreateAnimations()
        {
            List<Rectangle> runningFrames = new List<Rectangle>();
            List<Rectangle> idleFrames = new List<Rectangle>();
            List<Rectangle> jumpingFrames = new List<Rectangle>();
            List<Rectangle> attackingFrames = new List<Rectangle>();
            int frameWidth = 231;


            runningAnimation = new Animation();



            for (int i = 0; i < 8 * frameWidth; i += frameWidth)
            {
                runningFrames.Add(new Rectangle(i, 576, frameWidth, 192));
            }
            for (int i = 0; i < 6 * frameWidth; i += frameWidth)
            {
                idleFrames.Add(new Rectangle(i, 192, frameWidth, 192));
            }
            for (int i = 0 * frameWidth; i < 2 * frameWidth; i += frameWidth)
            {
                jumpingFrames.Add(new Rectangle(i, 384, frameWidth, 192));
            }
            for (int i = 0 * frameWidth; i < 8 * frameWidth; i += frameWidth)
            {
                attackingFrames.Add(new Rectangle(i, 0, frameWidth, 192));
            }
            runningAnimation.AddFrameList(runningFrames);
        }*/
        public virtual void Attack(GameTime gameTime) { }

        public virtual void CreateAnimations() { }
        /*public void UpdateProjectiles()
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

public void Shoot()//Texture2D texture)
{
   Projectile newProjectile = new Projectile(ProjectileSprite);//Content.Load<Texture2D>("Projectile"));
   if (spriteOrientation == SpriteEffects.None)
   {
       newProjectile.Speed = new Vector2(5, 0);
   }
   if (spriteOrientation == SpriteEffects.FlipHorizontally)
   {
       newProjectile.Speed = new Vector2(-5, 0);
   }
   newProjectile.Position = new Vector2(Position.X + HitBox.Width, HitBox.Y + (HitBox.Height / 6)) + newProjectile.Speed * 5;


   newProjectile.IsVisible = true;
   if (Projectiles.Count < 1)
   {
       Projectiles.Add(newProjectile);
   }
}*/
    }
}
