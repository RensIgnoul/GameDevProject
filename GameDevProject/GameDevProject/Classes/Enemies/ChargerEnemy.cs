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

        public ChargerEnemy(Texture2D texture, int x, int y) : base(texture, x, y)
        {
            isCharging = false;
            HitBox = new Rectangle((int)Position.X, (int)Position.Y, 50, 75);
            chargerAttack = new ChargerAttack(this);
        }
        public override void Update(GameTime gameTime)
        {
            HitBox = new Rectangle((int)Position.X + 75, (int)Position.Y + 75, HitBox.Width, HitBox.Height);

            runningAnimation.Update(gameTime);

            Speed.X = 5 * directionModifier;
            Speed.Y = 0;

            if (isCharging)
            {
                chargerAttack.Attack(gameTime);
            }
            Position += Speed;
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            if (Health > 0)
            {
                spriteBatch.Draw(texture, Position, runningAnimation.CurrentFrame.SourceRectangle, Color.White, 0, new Vector2(0, 0), new Vector2(1.8f, 1.8f), SpriteOrientation, 1);
            }
        }

        public override void CreateAnimations()
        {
            List<Rectangle> runningFrames = new List<Rectangle>();
            int frameWidth = 120;

            runningAnimation = new Animation();
            for (int i = 0; i < 10 * frameWidth; i += frameWidth)
            {
                runningFrames.Add(new Rectangle(i, 0, frameWidth, 80));
            }
            runningAnimation.AddFrameList(runningFrames);
        }
        public override void Attack(GameTime gameTime)
        {
            chargerAttack.Attack(gameTime);
        }
    }
}
