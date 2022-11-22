using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameDevProject.Classes;
using Button = GameDevProject.Controls.Button;
using Component = GameDevProject.Classes.Component;

namespace GameDevProject.States
{
    internal class MenuState : State
    {
        // TODO Centreer de knoppen
        private List<Component> _components;

        public MenuState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content)
          : base(game, graphicsDevice, content)
        {
            var buttonTexture = _content.Load<Texture2D>("Controls/Button");
            var buttonFont = _content.Load<SpriteFont>("Fonts/Font");

            var newGameButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width / 2 - (buttonTexture.Width / 2), GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height / 2 - buttonTexture.Height),
                Text = "New Game",
            };

            newGameButton.Click += NewGameButton_Click;

            var loadGameButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width / 2 - (buttonTexture.Width / 2), GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height / 2),
                Text = "Select",
            };

            loadGameButton.Click += LoadGameButton_Click;

            var quitGameButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width / 2 - (buttonTexture.Width / 2), GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height / 2 + buttonTexture.Height),
                Text = "Quit Game",
            };

            quitGameButton.Click += QuitGameButton_Click;

            _components = new List<Component>()
            {
                newGameButton,
                loadGameButton,
                quitGameButton,
            };
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {

            foreach (var component in _components)
                component.Draw(gameTime, spriteBatch);

        }

        private void LoadGameButton_Click(object sender, EventArgs e)
        {
            _game.ChangeState(new LevelSelectState(_game, _graphicsDevice, _content));
        }

        private void NewGameButton_Click(object sender, EventArgs e)
        {
            _game.ChangeState(new /*GameState*/LevelOneState(_game, _graphicsDevice, _content));
        }


        public override void Update(GameTime gameTime)
        {
            foreach (var component in _components)
                component.Update(gameTime);
        }

        private void QuitGameButton_Click(object sender, EventArgs e)
        {
            _game.Exit();
        }
    }
}
