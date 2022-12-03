using GameDevProject.Classes.UI;
using GameDevProject.Controls;
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
    internal class DeathState : State
    {
        private List<Component> _components;
        public DeathState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
        {
            Texture2D deathButtonTexture = _content.Load<Texture2D>("Controls/Button"); 
            SpriteFont buttonFont = _content.Load<SpriteFont>("Fonts/Font");

            Button deathButton = new Button(deathButtonTexture, buttonFont)
            {
                Position = new Vector2(GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width / 2 - (deathButtonTexture.Width / 2), GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height / 2),
                Text = "You died, press escape to exit",
            };

            deathButton.Click += DeathButton_Click;

            _components = new List<Component>()
            {
                deathButton
            };
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            foreach (var component in _components)
            {
                component.Draw(gameTime, spriteBatch);
            }
        }

        public override void Update(GameTime gameTime)
        {
            foreach (var component in _components)
            {
                component.Update(gameTime);
            }
        }
        private void DeathButton_Click(object sender, EventArgs e)
        {
            _game.Exit();
        }
    }
}
