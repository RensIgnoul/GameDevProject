using GameDevProject.Classes.Animations;
using GameDevProject.Classes.Behaviour.Hero;
using GameDevProject.Interfaces;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameDevProject.Classes.Behaviour.General;

namespace GameDevProject.Classes.Hero
{
    internal class Hero : IGameObject, IRangedAttacker, IUnit
    {
        public Texture2D texture { get; set; }
        internal Vector2 velocity;
        public Rectangle HitBox { get; set; }
        internal Color Color;

        internal bool hasJumped = false;
        private Vector2 position;
        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }
        public Vector2 SpawnPosition { get; set; }

        public int Health { get; set; }
        public List<Projectile> Projectiles { get; set; }
        public SpriteEffects SpriteOrientation { get; set; }
        public bool isAttacking { get; set; }

        internal Animation idleAnimation;
        internal Animation currentAnimation;
        internal Animation runningAnimation;
        internal Animation jumpingAnimation;
        public Animation AttackingAnimation { get; set; }

        public Texture2D ProjectileSprite { get; set; }
        RangedAttack _heroAttack;
        HeroMove _heroMove;
        HeroInput _heroInput;
        HeroAnimationCreator _heroAnimationCreator;
        HeroAnimationPicker _heroAnimationPicker;
        RangedAnimation _heroAnimationConfigurator;
        HeroAttackUpdate _heroAttackUpdate;

        public bool Attackable { get; set; }
        public bool CanAttack { get; set; }
        public int Score { get; set; }

        public Hero(Texture2D texture, Texture2D projectile)
        {
            this.texture = texture;
            currentAnimation = idleAnimation;
            Position = new Vector2(50, 50);
            SpawnPosition = position;
            Color = Color.White;
            HitBox = new Rectangle((int)Position.X, (int)Position.Y, 57, 57);
            Health = 3;
            isAttacking = false;
            ProjectileSprite = projectile;
            _heroAttack = new RangedAttack(this);
            _heroMove = new HeroMove(this);
            _heroInput = new HeroInput(this, _heroAttack);
            _heroAnimationCreator = new HeroAnimationCreator(this);
            _heroAnimationCreator.CreateAnimations();
            _heroAnimationPicker = new HeroAnimationPicker(this);
            _heroAnimationConfigurator = new RangedAnimation(this);
            _heroAttackUpdate = new HeroAttackUpdate(this);
            Projectiles = new List<Projectile>();
            Attackable = true;
            CanAttack = false;
            Score = 0;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            _heroAnimationPicker.SetAnimation();

            spriteBatch.Draw(texture, Position, currentAnimation.CurrentFrame.SourceRectangle, Color, 0, new Vector2(0, 0), new Vector2(0.75f, 0.75f), SpriteOrientation, 1);
        }

        public void Update(GameTime gameTime)
        {
            HitBox = new Rectangle((int)Position.X + 57, (int)Position.Y + 57, HitBox.Width, HitBox.Height);
            runningAnimation.Update(gameTime);
            idleAnimation.Update(gameTime);
            jumpingAnimation.Update(gameTime);
            AttackingAnimation.Update(gameTime);
            _heroAnimationConfigurator.AttackConfiguration(gameTime, 800);
            _heroAttackUpdate.UpdateProjectiles();
            _heroInput.Input(gameTime);
            _heroMove.Move();
        }
        public void Collision(Rectangle newRectangle)
        {
            if (HitBox.TouchTopOf(newRectangle))
            {
                HitBox/*.Y*/ = new Rectangle(HitBox.X, newRectangle.Y - HitBox.Height - 1, HitBox.Width, HitBox.Height);
                velocity.Y = 0f;
                currentAnimation = idleAnimation;
                hasJumped = false;
            }
            if (HitBox.TouchLeftOf(newRectangle))
            {
                position.X = position.X - 7;
            }
            if (HitBox.TouchRightOf(newRectangle))
            {
                position.X = position.X + 10;
            }
            if (HitBox.TouchBottomOf(newRectangle))
            {
                velocity.Y = 5;
            }
        }
        public void TakeDamage(GameTime gameTime)
        {
            Health--;
        }
        private void Attack()
        {
            _heroAttack.Shoot(ProjectileSprite);
        }

        private void UpdateAttacks()
        {
            _heroAttackUpdate.UpdateProjectiles();
        }
    }
}
