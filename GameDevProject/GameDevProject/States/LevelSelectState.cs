using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Button = GameDevProject.Controls.Button;
using GameDevProject.Classes.UI;

namespace GameDevProject.States
{
    public class LevelSelectState : State
    {
        private List<Component> _components;

        public LevelSelectState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
        {
            var buttonTexture = _content.Load<Texture2D>("Controls/Button");
            var buttonFont = _content.Load<SpriteFont>("Fonts/Font");

            var level1Button = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width / 2 - (buttonTexture.Width / 2), GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height / 2 - buttonTexture.Height),
                Text = "Level 1",
            };
            level1Button.Click += Level1Button_Click;
            var level2Button = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width / 2 - (buttonTexture.Width / 2), GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height / 2),
                Text = "Level 2",
            };
            level2Button.Click += Level2Button_Click;

            _components = new List<Component>()
            {
                level1Button,
                level2Button
            };
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            foreach (var component in _components)
                component.Draw(gameTime, spriteBatch);
        }

        public override void Update(GameTime gameTime)
        {
            foreach (var component in _components)
                component.Update(gameTime);
        }

        private void Level1Button_Click(object sender, EventArgs e)
        {
            _game.ChangeState(new LevelOneState(_game, _graphicsDevice, _content));
        }
        private void Level2Button_Click(object sender, EventArgs e)
        {
            _game.ChangeState(new LevelTwoState(_game, _graphicsDevice, _content));
        }
    }
}
