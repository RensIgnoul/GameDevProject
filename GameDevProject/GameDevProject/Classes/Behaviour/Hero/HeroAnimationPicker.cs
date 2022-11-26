using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevProject.Classes.Behaviour.Hero
{
    internal class HeroAnimationPicker
    {
        Classes.Hero.Hero _hero;
        public HeroAnimationPicker(Classes.Hero.Hero hero)
        {
            _hero = hero;
        }
        public void SetAnimation()
        {
            if (_hero.isAttacking)
            {
                _hero.currentAnimation = _hero.AttackingAnimation;
            }
            else if (_hero.hasJumped)
            {
                _hero.currentAnimation = _hero.jumpingAnimation;
            }
            else if (_hero.velocity.X != 0)
            {
                _hero.currentAnimation = _hero.runningAnimation;
            }
            else
            {
                _hero.currentAnimation = _hero.idleAnimation;
            }

            if (_hero.velocity.X < 0)
            {
                _hero.SpriteOrientation = SpriteEffects.FlipHorizontally;
            }
            else if (_hero.velocity.X > 0)
            {
                _hero.SpriteOrientation = SpriteEffects.None;
            }
        }
    }
}
