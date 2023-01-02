using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevProject.Classes.Behaviour.Hero
{
    internal class HeroBlock
    {
       Classes.Hero.Hero _hero;

        public HeroBlock(Classes.Hero.Hero hero)
        {
            _hero = hero;
        }
        public void Block()
        {
            _hero.Attackable=false;
            _hero.CanAttack = false;
            _hero.Color = Color.Purple;
        }

        public void StopBlock()
        {
            _hero.Attackable = true;
            _hero.CanAttack = true;
            _hero.Color = Color.White;
        }
    }
}
