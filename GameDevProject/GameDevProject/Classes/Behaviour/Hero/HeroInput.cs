﻿using GameDevProject.Classes.Behaviour.General;
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
                _hero.Position = new Vector2(_hero.Position.X, _hero.Position.Y - 5);//.Y -= 50f;
                _hero.velocity.Y = -9f;
                _hero.currentAnimation = _hero.jumpingAnimation;
                _hero.hasJumped = true;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Space) && _hero.CanAttack)//&&pastKey.IsKeyUp(Keys.U/)
            {
                _attacker.Shoot(_hero.ProjectileSprite);//Content.Load<Texture2D>("Projectiles/energy_ball"));
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
