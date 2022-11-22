using GameDevProject.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevProject.Classes
{
    internal class MouseReader : IInputReader
    {
        public bool IsDestinationalInput => true;

        public Vector2 ReadInput()
        {
            MouseState state = Mouse.GetState();
            Vector2 directionMouse = new Vector2(state.X, state.Y);
            /*if (directionMouse != Vector2.Zero)
            {
                directionMouse.Normalize();
            }*/
            return directionMouse;
        }
    }
}
