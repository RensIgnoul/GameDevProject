using GameDevProject.Classes.Animations;
using GameDevProject.Classes.Behaviour.Enemy.Boss;
using GameDevProject.Classes.Behaviour.General;
using GameDevProject.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevProject.Classes.Enemies
{
    internal class BossEnemy : RangedEnemy,IBoss
    {
        public BossAttack _attack;
        public override void Update(GameTime gameTime)
        {
            Speed = new Vector2(0, 0);
            base.Update(gameTime);
            Speed = new Vector2(0, 0);
        }
        /*public BossAttack bossAttack;
        private BossAttackUpdate _update;
        private Animation idleAnimation;
        private float attackTimer = 0;
        /*Random rng = new Random();

        

        public Texture2D ProjectileSprite;
        public List<Projectile> Projectiles { get; set; }
        public Animation AttackingAnimation { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool isAttacking { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        BossAttack _attack;
        BossAttackUpdate _update;
        public BossEnemy(Texture2D texture, int x, int y, Texture2D projectile) : base(texture, x, y)
        {
            ProjectileSprite = projectile;
            HitBox = new Rectangle((int)Position.X, (int)Position.Y, 65, 65);
            Projectiles = new List<Projectile>();
            _attack = new BossAttack(this);
            _update = new BossAttackUpdate(this);
        }


        public override void Update(GameTime gameTime)
        {
            //Speed = new Vector2(1, 1);
            //Position += Speed;
            if (Keyboard.GetState().IsKeyDown(Keys.R))
            {
                _attack.Shoot(ProjectileSprite);
            }

            _update.UpdateProjectiles();

        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, Position, Color.White);
            /*if (Health > 0)
            {
                spriteBatch.Draw(texture, Position, _currentAnimation.CurrentFrame.SourceRectangle, Color.White, 0, new Vector2(0, 0), new Vector2(2, 2), base.SpriteOrientation, 1);
            }*//*
        /*}
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
        public void Attack()
        {
            Projectile newProjectile = new Projectile(ProjectileSprite, 33, 27, SpriteOrientation);
            if (rng.Next(2) == 1)
            {
                newProjectile.Speed = new Vector2(5, 2);
            }
            if (rng.Next(2) == 0)
            {
                newProjectile.Speed = new Vector2(-5, 2);
            }
            newProjectile.Position = new Vector2(Position.X + HitBox.Width / 2, Position.Y + HitBox.Height / 2) + newProjectile.Speed * 5;

            newProjectile.IsVisible = true;
            if (Projectiles.Count < 1)
            {
                Projectiles.Add(newProjectile);
            }
        }*//*
        public BossEnemy(Texture2D texture, int x, int y, Texture2D projectile) : base(texture, x, y, projectile)
        {
            HitBox = new Rectangle((int)Position.X, (int)Position.Y, 100, 110);
            bossAttack = new BossAttack(this);
            _rangedAnimation = new RangedAnimation(this);
            CreateAnimations();
            _update = new BossAttackUpdate(this);
            Health = 5;
        }
        public override void Update(GameTime gameTime)
        {
            HitBox/*.X*/ //= new Rectangle((int)Position.X + 200, (int)Position.Y + 230, HitBox.Width, HitBox.Height);
                         //HitBox.Y = (int)Position.Y + 80;



        //idleAnimation.Update(gameTime);
        /*AttackingAnimation.Update(gameTime);
        _rangedAnimation.AttackConfiguration(gameTime, 100);
        #region 
        /*if (IsAttacking)
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
            AttackingAnimation.counter = 0;
        }*/
        //#endregion
        //_update.UpdateProjectiles();
        #region
        //_enemyAttackUpdate.UpdateProjectiles();
        //_enemyMove.Move();
        //*directionModifier;
        /*if (Speed.Y < 10)
        {
            Speed.Y += 0f;
        }
        if (IsPatrolling)
        {*/
        #endregion
        /*if (Health<3)
        {
            Position = new Vector2(50, 50);
        }

        //}    
        _currentAnimation = runningAnimation;
    }*/
        /*public override void CreateAnimations()
        {
            List<Rectangle> attackFrames = new List<Rectangle>();
            List<Rectangle> idleFrames = new List<Rectangle>();

            idleAnimation = new Animation();
            AttackingAnimation = new Animation();

            int frameWidth = 250;

            for (int i = 0; i <  8 * frameWidth; i += frameWidth)
            {
                attackFrames.Add(new Rectangle(i, 0, frameWidth, 252));
            }
            for (int i = 0; i < 8 * frameWidth; i += frameWidth)
            {
                idleFrames.Add(new Rectangle(i, 504, frameWidth, 252));
            }

            AttackingAnimation.AddFrameList(attackFrames);
            idleAnimation.AddFrameList(idleFrames);
        }*/
        public BossEnemy(Texture2D texture, int x, int y, Texture2D projectile) : base(texture, x, y, projectile)
        {
            _attack = new BossAttack(this);
        }
    }
}
