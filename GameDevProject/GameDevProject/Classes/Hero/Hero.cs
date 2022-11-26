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
    internal class Hero : IGameObject, IMovable, IRangedAttacker
    {
        public Texture2D texture;
        private IInputReader inputReader;
        private MovementManager movementManager;
        internal Vector2 velocity;
        public Rectangle HitBox;
        internal Color color;

        //public SpriteEffects SpriteOrientation = SpriteEffects.None;
        internal bool hasJumped = false;
        internal Vector2 position;
        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }
        public Vector2 KnockbackPosition { get; set; }

        //public List<Projectile> Projectiles = new List<Projectile>();
        KeyboardState pastKey;
        // public Vector2 Position { get; set; }
        public Vector2 Speed { get; set; }
        public IInputReader InputReader { get; set; }
        public int Health { get; set; }
        public List<Projectile> Projectiles { get; set; }
        public SpriteEffects SpriteOrientation {get; set; }
        public bool isAttacking { get; set; }

        //////////////////////////
        // Testing animations   //
        //////////////////////////
        internal Animation idleAnimation;
        internal Animation currentAnimation;
        internal Animation runningAnimation;
        internal Animation jumpingAnimation;
        public Animation AttackingAnimation { get; set; }
        //internal bool isAttacking;
        float attackTimer = 0;
        public Texture2D ProjectileSprite;
        public bool IsSpotted = false;
        RangedAttack _heroAttack;
        HeroMove _heroMove;
        HeroInput _heroInput;
        HeroAnimationCreator _heroAnimationCreator;
        HeroAnimationPicker _heroAnimationPicker;
        RangedAnimation _heroAnimationConfigurator;
        HeroAttackUpdate _heroAttackUpdate;
        // TODO REFACTOR ANIMATIONS? Dictionary misschien?

        /// <summary>
        /// TESTING INTERFACE RANGED ATTACK
        /// </summary>
        public Hero() { }
        public Hero(Texture2D texture, IInputReader inputReader, Texture2D projectile)
        {
            this.texture = texture;
            InputReader = inputReader;
            #region comment
            /*runningAnimation.AddFrame(new AnimationFrame(new Rectangle(0, 0, 231, 190)));
            runningAnimation.AddFrame(new AnimationFrame(new Rectangle(231, 0, 231, 190)));
            runningAnimation.AddFrame(new AnimationFrame(new Rectangle(462, 0, 231, 190)));
            runningAnimation.AddFrame(new AnimationFrame(new Rectangle(693, 0, 231, 190)));
            runningAnimation.AddFrame(new AnimationFrame(new Rectangle(924, 0, 231, 190)));
            runningAnimation.AddFrame(new AnimationFrame(new Rectangle(1155, 0, 231, 190)));
            runningAnimation.AddFrame(new AnimationFrame(new Rectangle(1386, 0, 231, 190)));
            runningAnimation.AddFrame(new AnimationFrame(new Rectangle(1617, 0, 231, 190)));*/


            /* idleAnimation.AddFrame(new AnimationFrame(new Rectangle(1848, 0, 231, 190)));
             idleAnimation.AddFrame(new AnimationFrame(new Rectangle(2079, 0, 231, 190)));
             idleAnimation.AddFrame(new AnimationFrame(new Rectangle(2310, 0, 231, 190)));
             idleAnimation.AddFrame(new AnimationFrame(new Rectangle(2541, 0, 231, 190)));
             idleAnimation.AddFrame(new AnimationFrame(new Rectangle(2772, 0, 231, 190)));
             idleAnimation.AddFrame(new AnimationFrame(new Rectangle(3003, 0, 231, 190)));


             jumpingAnimation.AddFrame(new AnimationFrame(new Rectangle(3234, 0, 231, 190)));
             jumpingAnimation.AddFrame(new AnimationFrame(new Rectangle(3465, 0, 231, 190)));*/
            //animation.GetFramesFromTextureProperties(texture.Width, texture.Height, 5, 2);
            //animation.GetFramesFromTextureProperties(texture.Width, texture.Height, 8, 1);
            #endregion
            currentAnimation = idleAnimation;
            Position = new Vector2(0, 0);
            KnockbackPosition = new Vector2(Position.X - 100, Position.Y);
            Speed = new Vector2(1, 1);
            movementManager = new MovementManager();
            color = Color.White;
            HitBox = new Rectangle((int)Position.X, (int)Position.Y, 76, 76);//150, 210);
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
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            _heroAnimationPicker.SetAnimation();

            spriteBatch.Draw(texture, Position, currentAnimation.CurrentFrame.SourceRectangle, color, 0, new Vector2(0, 0), new Vector2(1, 1), SpriteOrientation, 1);
        }

        /*private void SetAnimation()
        {
            if (isAttacking)
            {
                currentAnimation = attackingAnimation;
            }
            else if (hasJumped)
            {
                currentAnimation = jumpingAnimation;
            }
            else if (velocity.X != 0)
            {
                currentAnimation = runningAnimation;
            }
            else
            {
                currentAnimation = idleAnimation;
            }

            if (velocity.X < 0)
            {
                SpriteOrientation = SpriteEffects.FlipHorizontally;
            }
            else if (velocity.X > 0)
            {
                SpriteOrientation = SpriteEffects.None;
            }
        }*/

        public void Update(GameTime gameTime)
        {
            HitBox.X = (int)Position.X + 76;
            HitBox.Y = (int)Position.Y + 76;
            KnockbackPosition = new Vector2(Position.X - 100, Position.Y);
            var temp = Position;
            runningAnimation.Update(gameTime);
            idleAnimation.Update(gameTime);
            jumpingAnimation.Update(gameTime);
            AttackingAnimation.Update(gameTime);
            _heroAnimationConfigurator.AttackConfiguration(gameTime,800);


            //Move();
            _heroAttackUpdate.UpdateProjectiles();
            _heroInput.Input(gameTime);
            _heroMove.Move();
        }
        /*Position += velocity;
        if (velocity.Y < 10)
        {
            velocity.Y += 0.4f;
        }*/



        /*private void AttackConfiguration(GameTime gameTime)
        {
            if (isAttacking)
            {
                attackTimer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
                if (attackTimer >= 800)
                {
                    isAttacking = false;
                    attackTimer = 0;
                }
            }
            else
            {
                attackingAnimation.counter = 0; // dit houd de animation op de eerste frame, anders kan animition of random frame beginnen;
            }
        }*/

        private void Move()
        {
            movementManager.Move(this);
        }
        public void ChangeInput(IInputReader inputReader)
        {
            this.inputReader = inputReader;
        }
        /*private void Input(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                velocity.X = (float)gameTime.ElapsedGameTime.TotalMilliseconds / 3;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                velocity.X = -(float)gameTime.ElapsedGameTime.TotalMilliseconds / 3;
            }
            else velocity.X = 0f;
            if (Keyboard.GetState().IsKeyDown(Keys.Space) && hasJumped == false)
            {
                position.Y -= 50f;
                velocity.Y = -9f;
                currentAnimation = jumpingAnimation;
                hasJumped = true;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.U)/*&&pastKey.IsKeyUp(Keys.U))
            {
                heroAttack.Shoot(ProjectileSprite);//Content.Load<Texture2D>("Projectiles/energy_ball"));
            }
        }*/
        public void Collision(Rectangle newRectangle)
        {
            if (HitBox.TouchTopOf(newRectangle))
            {
                HitBox.Y = newRectangle.Y - HitBox.Height;
                velocity.Y = 0f;
                currentAnimation = idleAnimation;
                hasJumped = false;
            }
            if (HitBox.TouchLeftOf(newRectangle))
            {
                position.X = position.X - 15;//-newRectangle.Width;
            }
            if (HitBox.TouchRightOf(newRectangle))
            {
                position.X = position.X + 10;//+ newRectangle.Width;
            }
            if (HitBox.TouchBottomOf(newRectangle))
            {
                velocity.Y += 0.8f;
            }
        }

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
        }*/

        /*public void Shoot(Texture2D texture)
        {
            Projectile newProjectile = new Projectile(texture,33,27, SpriteOrientation);//Content.Load<Texture2D>("Projectile"));
            if (SpriteOrientation == SpriteEffects.None)
            {
                newProjectile.Speed = new Vector2(5, 0);
            }
            if (SpriteOrientation == SpriteEffects.FlipHorizontally)
            {
                newProjectile.Speed = new Vector2(-5, 0);
            }
            newProjectile.Position = new Vector2(Position.X + HitBox.Width, HitBox.Y + HitBox.Height / 6) + newProjectile.Speed * 5;


            newProjectile.IsVisible = true;
            if (Projectiles.Count < 1)
            {
                Projectiles.Add(newProjectile);
                isAttacking = true;
            }
            heroAttack = new HeroAttack(this);
        }*/
        public void TakeDamage()
        {
            Health--;
        }

        public void Attack()
        {
            throw new NotImplementedException();
        }

        public void UpdateAttacks()
        {
            throw new NotImplementedException();
        }

        /*public void CreateAnimations()
{
   List<Rectangle> runningFrames = new List<Rectangle>();
   List<Rectangle> idleFrames = new List<Rectangle>();
   List<Rectangle> jumpingFrames = new List<Rectangle>();
   List<Rectangle> attackingFrames = new List<Rectangle>();
   int frameWidth = 231;

   idleAnimation = new Animation();
   runningAnimation = new Animation();
   jumpingAnimation = new Animation();
   attackingAnimation = new Animation();


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
   idleAnimation.AddFrameList(idleFrames);
   jumpingAnimation.AddFrameList(jumpingFrames);
   attackingAnimation.AddFrameList(attackingFrames);
}*/
    }
}
