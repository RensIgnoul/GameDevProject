using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevProject.Classes.Behaviour.Hero
{
    internal class HeroAnimationConfiguration
    {
        Classes.Hero.Hero _hero;
        float attackTimer;
        public HeroAnimationConfiguration(Classes.Hero.Hero hero)
        {
            _hero = hero;
        }

        internal void AttackConfiguration(GameTime gameTime)
        {
            if (_hero.isAttacking)
            {
                attackTimer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
                if (attackTimer >= 800)
                {
                    _hero.isAttacking = false;
                    attackTimer = 0;
                }
            }
            else
            {
                _hero.attackingAnimation.counter = 0; // dit houd de animation op de eerste frame, anders kan animition of random frame beginnen;
            }
        }
    }
}
