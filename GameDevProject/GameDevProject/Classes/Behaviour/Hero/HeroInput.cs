using GameDevProject.Classes.Behaviour.General;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevProject.Classes.Behaviour.Hero
{
    internal class HeroInput
    {
        Classes.Hero.Hero _hero;
        RangedAttack _attacker;
        public HeroInput(Classes.Hero.Hero hero, RangedAttack attacker)
        {
            _hero = hero;
            _attacker = attacker;
        }
        //De input methode is gebaseerd op de code van Oyyou (https://www.youtube.com/watch?v=l0WS5SvKdY4&t=867s&ab_channel=Oyyou), het schieten en blokken zijn volledig zelf geschreven;
        internal void Input(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                _hero.velocity.X = (float)gameTime.ElapsedGameTime.TotalMilliseconds / 3;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                _hero.velocity.X = -(float)gameTime.ElapsedGameTime.TotalMilliseconds / 3;
            }
            else _hero.velocity.X = 0f;
            if (Keyboard.GetState().IsKeyDown(Keys.Up) && _hero.hasJumped == false)
            {
                _hero.Position = new Vector2(_hero.Position.X, _hero.Position.Y - 5);
                _hero.velocity.Y = -8f;
                _hero.currentAnimation = _hero.jumpingAnimation;
                _hero.hasJumped = true;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Space) && _hero.CanAttack)
            {
                _attacker.Shoot(_hero.ProjectileSprite);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                _hero.Attackable = false;
                _hero.CanAttack = false;
                _hero.Color = Color.Purple;
            }
            else
            {
                _hero.Attackable = true;
                _hero.CanAttack = true;
                _hero.Color = Color.White;
            }

        }
    }
}
