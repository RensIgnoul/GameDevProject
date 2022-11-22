using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevProject.Classes.Behaviour.Hero
{
    internal class HeroMove
    {
        private Classes.Hero.Hero _hero;
        public HeroMove(Classes.Hero.Hero hero)
        {
            _hero = hero;
        }
        public void Move()
        {
            _hero.Position += _hero.velocity;
            if (_hero.velocity.Y < 10)
            {
                _hero.velocity.Y += 0.4f;
            }
        }
    }
}
