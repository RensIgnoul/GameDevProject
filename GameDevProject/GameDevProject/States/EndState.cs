using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevProject.States
{
    internal class EndState : State
    {
        public EndState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
        {
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(_content.Load<SpriteFont>("Fonts/Font"), "You won! :D", new Vector2((1920 / 2)-25, 1080 / 2), Color.White);
            spriteBatch.DrawString(_content.Load<SpriteFont>("Fonts/Font"), "Congratulations", new Vector2((1920 / 2)-25, (1080 / 2)+50), Color.White);
        }

        public override void Update(GameTime gameTime)
        {
           
        }
    }
}
