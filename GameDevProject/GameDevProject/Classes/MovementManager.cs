using GameDevProject.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevProject.Classes
{
    internal class MovementManager
    {

        public void Move(IMovable movable)
        {
            var direction = movable.InputReader.ReadInput();
            if (movable.InputReader.IsDestinationalInput)
            {
                direction -= movable.Position;
                direction.Normalize();
            }
            var afstand = direction * movable.Speed;
            movable.Position += afstand;
        }
    }
}
