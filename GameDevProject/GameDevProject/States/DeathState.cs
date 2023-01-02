using GameDevProject.Classes.UI;
using GameDevProject.Controls;
using Microsoft.VisualBasic.Devices;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Keyboard = Microsoft.Xna.Framework.Input.Keyboard;

namespace GameDevProject.States
{
    internal class DeathState : State
    {
        public DeathState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
        {

        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(_content.Load<SpriteFont>("Fonts/Font"), "You died D:", new Vector2((1920 / 2) - 70, 1080 / 2), Color.White);
            spriteBatch.DrawString(_content.Load<SpriteFont>("Fonts/Font"), "Press escape to quit", new Vector2((1920 / 2) - 100, (1080 / 2)+25), Color.White);
        }

        public override void Update(GameTime gameTime)
        {

        }
    }
}
