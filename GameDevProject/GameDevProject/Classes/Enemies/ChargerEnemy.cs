using GameDevProject.Classes.Animations;
using GameDevProject.Classes.Behaviour.Enemy;
using GameDevProject.Classes.Behaviour.Enemy.Charger;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.MediaFoundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevProject.Classes.Enemies
{
    internal class ChargerEnemy : Enemy
    {

        public bool isCharging;
        public float timer = 0;
        public ChargerAttack chargerAttack;
         EnemyMove _enemyMove;
        
        public ChargerEnemy(Texture2D texture, int x, int y) : base(texture, x, y)
        {
            isCharging = false;
            HitBox = new Rectangle((int)Position.X, (int)Position.Y, 70, 100);
            chargerAttack = new ChargerAttack(this);
            _enemyMove = new EnemyMove(this);
            
        }
        public override void Update(GameTime gameTime)
        {
            HitBox/*.X*/ = new Rectangle((int)Position.X + 110, (int)Position.Y + 100,HitBox.Width,HitBox.Height);
            //HitBox.Y = (int)Position.Y + 100;
            runningAnimation.Update(gameTime);
            //if (IsPatrolling)
            //{
            Speed.X = 5 * directionModifier;
            Speed.Y = 0;
            //}
            //else
            //{
            //    Speed.X = 0;
            //}
            //_enemyMove.Move();
            if (isCharging)
            {
                chargerAttack.Attack(gameTime);
            }
            Position += Speed;
            /*if (Speed.Y < 10)
            {
                Speed.Y += 0f;
            }*/

        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            if (Health > 0)
            {
                spriteBatch.Draw(texture, Position, runningAnimation.CurrentFrame.SourceRectangle, Color.White, 0, new Vector2(0, 0), new Vector2(2.5f, 2.5f), SpriteOrientation, 1);
            }
        }
        /*public override void Attack(GameTime gameTime)
        {
            isCharging = true;
            if (timer <= 10000) // timer aanpassen om duur charge te veranderen
            {
                Speed.X = Speed.X * 2;

            }
            if (timer >= 20000) // cooldown op charge. er word geen rekening gehoudn met de duur van de charge)
            {
                timer = 0;
                isCharging = false;
            }
            timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
        }*/
        public override void CreateAnimations()
        {
            // base.CreateAnimations();
            List<Rectangle> runningFrames = new List<Rectangle>();
            int frameWidth = 120;

            runningAnimation = new Animation();
            for (int i = 0; i < 10 * frameWidth; i += frameWidth)
            {
                runningFrames.Add(new Rectangle(i, 0, frameWidth, 80));
            }
            runningAnimation.AddFrameList(runningFrames);
        }
    }
}
