using GameDevProject.Classes.Animations;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameDevProject.Classes.Behaviour.Enemy;
using GameDevProject.Classes.Behaviour.Enemy.Ranged;
using GameDevProject.Classes.Behaviour.General;
using SharpDX.Direct3D9;
using RangedAttackUpdate = GameDevProject.Classes.Behaviour.Enemy.Ranged.RangedAttackUpdate;
using GameDevProject.Interfaces;

namespace GameDevProject.Classes.Enemies
{
    internal class RangedEnemy : Enemy, IRangedAttacker
    {
        public Texture2D ProjectileSprite;
        public Animation AttackingAnimation { get; set; }
        public RangedAttack enemyAttack;
        protected RangedAttackUpdate _enemyAttackUpdate;
        protected RangedAnimation _rangedAnimation;

        public List<Projectile> Projectiles { get; set; }
        public bool isAttacking { get; set; }

        public RangedEnemy(Texture2D texture, int x, int y, Texture2D projectile) : base(texture, x, y)
        {
            ProjectileSprite = projectile;
            IsAttacking = false;
            HitBox = new Rectangle((int)Position.X, (int)Position.Y, 65, 65);
            enemyAttack = new RangedAttack(this);
            _enemyAttackUpdate = new RangedAttackUpdate(this);
            _rangedAnimation = new RangedAnimation(this);
            Projectiles = new List<Projectile>();
        }

        public override void Update(GameTime gameTime)
        {
            HitBox = new Rectangle((int)Position.X + 60, (int)Position.Y + 80,HitBox.Width,HitBox.Height);

            runningAnimation.Update(gameTime);
            AttackingAnimation.Update(gameTime);
            _rangedAnimation.AttackConfiguration(gameTime,700);
            _enemyAttackUpdate.UpdateProjectiles();

            Position += Speed;
            Speed.X = 5 * directionModifier; 
            _currentAnimation = runningAnimation;
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            if (Health > 0)
            {
                spriteBatch.Draw(texture, Position, _currentAnimation.CurrentFrame.SourceRectangle, Color.White, 0, new Vector2(0, 0), new Vector2(2, 2), base.SpriteOrientation, 1);
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
            AttackingAnimation = new Animation();


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
            AttackingAnimation.AddFrameList(attackingFrames);
        }

        public void Attack()
        {
            enemyAttack.Shoot(ProjectileSprite);
        }
        public override void Attack(GameTime gameTime)
        {
            enemyAttack.Shoot(ProjectileSprite);
        }

        public void UpdateAttacks()
        {
            throw new NotImplementedException();
        }
    }
}
