using GameDevProject.Interfaces;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevProject.Classes.Behaviour.General
{
    internal class RangedAnimation
    {
        IRangedAttacker _attacker;
        float attackTimer;
        public RangedAnimation(IRangedAttacker attacker)
        {
            _attacker = attacker;
        }

        internal void AttackConfiguration(GameTime gameTime,int animationDuration)
        {
            if (_attacker.isAttacking)
            {
                attackTimer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
                if (attackTimer >= animationDuration)
                {
                    _attacker.isAttacking = false;
                    attackTimer = 0;
                }
            }
            else
            {
                _attacker.AttackingAnimation.counter = 0; // dit houd de animation op de eerste frame, anders kan animition of random frame beginnen;
            }
        }
    }
}
