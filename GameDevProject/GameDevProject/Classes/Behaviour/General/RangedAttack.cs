using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameDevProject.Interfaces;
using GameDevProject.Classes.Hero;
using System.Windows.Forms;
using GameDevProject.Classes.Enemies;

namespace GameDevProject.Classes.Behaviour.General
{
    internal class RangedAttack
    {
        IRangedAttacker _attacker;
        public RangedAttack(IRangedAttacker attacker)
        {
            _attacker = attacker;
        }
        public void Shoot(Texture2D texture)
        {
            if (_attacker is RangedEnemy)
            {
                (_attacker as RangedEnemy).Speed.X = 0;
                (_attacker as RangedEnemy)._currentAnimation = (_attacker as RangedEnemy).AttackingAnimation;
            }
            Projectile newProjectile = new Projectile(texture, 33, 27, _attacker.SpriteOrientation);//Content.Load<Texture2D>("Projectile"));
            if (_attacker.SpriteOrientation == SpriteEffects.None)
            {
                newProjectile.Speed = new Vector2(5, 0);
            }
            if (_attacker.SpriteOrientation == SpriteEffects.FlipHorizontally)
            {
                newProjectile.Speed = new Vector2(-5, 0);
            }
            if (_attacker is Classes.Hero.Hero)
            {
                newProjectile.Position = new Vector2((_attacker as Classes.Hero.Hero).Position.X + (_attacker as Classes.Hero.Hero).HitBox.Width, (_attacker as Classes.Hero.Hero).HitBox.Y + (_attacker as Classes.Hero.Hero).HitBox.Height / 6) + newProjectile.Speed * 5;
            }
            else if (_attacker is Enemies.RangedEnemy)
            {
                newProjectile.Position = new Vector2((_attacker as RangedEnemy).Position.X + (_attacker as RangedEnemy).HitBox.Width, (_attacker as RangedEnemy).HitBox.Y) + newProjectile.Speed * 5;
            }


            newProjectile.IsVisible = true;
            if (_attacker.Projectiles.Count < 1)
            {
                _attacker.Projectiles.Add(newProjectile);
                _attacker.isAttacking = true;
            }
        }
    }
}
