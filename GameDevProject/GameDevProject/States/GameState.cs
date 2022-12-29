using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameDevProject.Classes.Hero;

namespace GameDevProject.States
{
    // Deze class is over genomen van Oyyou (https://www.youtube.com/watch?v=76Mz7ClJLoE&t=377s&ab_channel=Oyyou)
    internal class GameState : State
    {
        public GameState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content)
          : base(game, graphicsDevice, content)
        {
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {

        }

        public override void Update(GameTime gameTime)
        {

        }
    }
}
