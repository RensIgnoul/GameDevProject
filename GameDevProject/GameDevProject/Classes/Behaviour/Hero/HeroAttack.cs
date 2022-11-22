﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevProject.Classes.Behaviour.Hero
{
    internal class HeroAttack
    {
        Classes.Hero.Hero _hero;
        public HeroAttack(Classes.Hero.Hero hero)
        {
            _hero = hero;
        }
        public void Shoot(Texture2D texture)
        {
            Projectile newProjectile = new Projectile(texture, 33, 27, _hero.SpriteOrientation);//Content.Load<Texture2D>("Projectile"));
            if (_hero.SpriteOrientation == SpriteEffects.None)
            {
                newProjectile.Speed = new Vector2(5, 0);
            }
            if (_hero.SpriteOrientation == SpriteEffects.FlipHorizontally)
            {
                newProjectile.Speed = new Vector2(-5, 0);
            }
            newProjectile.Position = new Vector2(_hero.Position.X + _hero.HitBox.Width, _hero.HitBox.Y + _hero.HitBox.Height / 6) + newProjectile.Speed * 5;


            newProjectile.IsVisible = true;
            if (_hero.Projectiles.Count < 1)
            {
                _hero.Projectiles.Add(newProjectile);
                _hero.isAttacking = true;
            }
        }
    }
}
