using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevProject.Classes.Behaviour.Enemy.Boss
{
    internal class BossAttackUpdate
    {
        Enemies.BossEnemy _boss;
        public BossAttackUpdate(Enemies.BossEnemy enemy)
        {
            _boss = enemy;
        }
        public void UpdateProjectiles()
        {
            foreach (var projectile in _boss.Projectiles)
            {
                projectile.Position += projectile.Speed;
                projectile.HitBox.X = (int)projectile.Position.X;
                projectile.HitBox.Y = (int)projectile.Position.Y;
                if (Vector2.Distance(projectile.Position, _boss.Position) > 500) // maakt kogel onzichtbaar na 500px
                {
                    projectile.IsVisible = false;
                }
            }
            for (int i = 0; i < _boss.Projectiles.Count; i++)
            {
                if (!_boss.Projectiles[i].IsVisible)
                {
                    _boss.Projectiles.RemoveAt(i);
                    i--;
                }
            }
        }
    }
}
