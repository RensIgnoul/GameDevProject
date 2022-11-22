using GameDevProject.Interfaces;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameDevProject.Interfaces;
using Microsoft.Xna.Framework;

namespace GameDevProject.Classes
{
    internal class KeyboardReader : IInputReader
    {
        public bool IsDestinationalInput => false;

        public Vector2 ReadInput()
        {
            KeyboardState state = Keyboard.GetState();
            Vector2 direction = Vector2.Zero;
            if (state.IsKeyDown(Keys.Left))
            {
                direction.X -= 5;
            }
            if (state.IsKeyDown(Keys.Right))
            {
                direction.X += 5;
            }
            if (state.IsKeyDown(Keys.Up))
            {
                direction.Y -= 5;
            }
            if (state.IsKeyDown(Keys.Down))
            {
                direction.Y += 5;
            }
            return direction;
        }
    }
}
