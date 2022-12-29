using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevProject.Classes
{
    internal static class RectangleHelper
    {
        // Deze class is gebaseerd op de code van Oyyou (https://www.youtube.com/watch?v=PKlHcxFAEk0&t=67s&ab_channel=Oyyou)
        public static bool TouchTopOf(this Rectangle r1, Rectangle r2)
        {
            return (r1.Bottom >= r2.Top &&
                    r1.Bottom <= r2.Top + (r2.Height / 2) &&
                    r1.Right >= r2.Left + (r2.Width / 5) &&
                    r1.Left <= r2.Right - (r2.Width / 5));
        }
        public static bool TouchBottomOf(this Rectangle r1, Rectangle r2)
        {
            return (r1.Top <= r2.Bottom + (r2.Height / 5) &&
                    r1.Top >= r2.Bottom - 1 &&
                    r1.Right >= r2.Left + (r2.Width / 5) &&
                    r1.Left <= r2.Right - (r2.Width / 5));
        }
        public static bool TouchLeftOf(this Rectangle r1, Rectangle r2)
        {
            return (r1.Right <= r2.Right &&
                   r1.Right >= r2.Left - 5 &&
                   r1.Top <= r2.Bottom - (r2.Width / 4) &&
                   r1.Bottom >= r2.Top + (r2.Width / 4));
        }
        public static bool TouchRightOf(this Rectangle r1, Rectangle r2)
        {
            return (r1.Left >= r2.Left &&
                   r1.Left <= r2.Right + 5 &&
                   r1.Top <= r2.Bottom - (r2.Width / 4) &&
                   r1.Bottom >= r2.Top + (r2.Width / 4));
        }
    }
}
