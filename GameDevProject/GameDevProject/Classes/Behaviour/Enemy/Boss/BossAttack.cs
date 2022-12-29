using GameDevProject.Classes.Enemies;
using GameDevProject.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevProject.Classes.Behaviour.Enemy.Boss
{
    internal class BossAttack
    {
        Random rng = new Random();
        IRangedAttacker _attacker;
        public BossAttack(IRangedAttacker attacker)
        {
            _attacker = attacker;
        }
        public void Shoot(Texture2D texture)
        {
            int randomDirection = rng.Next(2);
            int randomAngle = rng.Next(11);
            (_attacker as BossEnemy)._currentAnimation = _attacker.AttackingAnimation;
            Projectile newProjectile = new Projectile(texture, 33, 27, _attacker.SpriteOrientation);//Content.Load<Texture2D>("Projectile"));
            if (randomDirection==1)
            {
                newProjectile.Speed = new Vector2(5, randomAngle);
            }
            else if(randomDirection==0)
            {
                newProjectile.Speed = new Vector2(-5, randomAngle);
            }


                newProjectile.Position = new Vector2((_attacker as BossEnemy).Position.X + (_attacker as BossEnemy).HitBox.Width, (_attacker as BossEnemy).HitBox.Y /*+ (HitBox.Height / 10)*/) + newProjectile.Speed * 5;



            newProjectile.IsVisible = true;
            if (_attacker.Projectiles.Count < 1)
            {
                _attacker.Projectiles.Add(newProjectile);
                (_attacker as BossEnemy).IsAttacking = true;

            }
        }
    }
}
