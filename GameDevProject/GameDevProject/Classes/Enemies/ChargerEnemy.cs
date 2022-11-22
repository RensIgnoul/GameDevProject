using GameDevProject.Classes.Animations;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevProject.Classes.Enemies
{
    internal class ChargerEnemy : Enemy
    {

        bool isCharging;
        float timer = 0;
        public ChargerEnemy(Texture2D texture, int x, int y) : base(texture, x, y)
        {
            isCharging = false;
            HitBox = new Rectangle((int)Position.X, (int)Position.Y, 70, 100);

        }
        public override void Update(GameTime gameTime)
        {
            HitBox.X = (int)Position.X + 110;
            HitBox.Y = (int)Position.Y + 100;
            runningAnimation.Update(gameTime);
            //if (IsPatrolling)
            //{
            Speed.X = 5 * directionModifier;
            //}
            //else
            //{
            //    Speed.X = 0;
            //}
            if (isCharging)
            {
                Attack(gameTime);
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
                spriteBatch.Draw(texture, Position, runningAnimation.CurrentFrame.SourceRectangle, Color.White, 0, new Vector2(0, 0), new Vector2(2.5f, 2.5f), spriteOrientation, 1);
            }
        }
        public override void Attack(GameTime gameTime)
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
        }
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
