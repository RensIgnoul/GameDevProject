using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevProject.Classes.Behaviour.Enemy.Ranged
{
    internal class RangedAttackUpdate
    {
        Enemies.RangedEnemy _enemy;
        public RangedAttackUpdate(Enemies.RangedEnemy enemy)
        {
            _enemy = enemy;
        }
        public void UpdateProjectiles()
        {
            foreach (var projectile in _enemy.Projectiles)
            {
                projectile.Position += projectile.Speed;
                projectile.HitBox.X = (int)projectile.Position.X;
                projectile.HitBox.Y = (int)projectile.Position.Y;
                if (Vector2.Distance(projectile.Position, _enemy.Position) > 500) // maakt kogel onzichtbaar na 500px
                {
                    projectile.IsVisible = false;
                }
            }
            for (int i = 0; i < _enemy.Projectiles.Count; i++)
            {
                if (!_enemy.Projectiles[i].IsVisible)
                {
                    _enemy.Projectiles.RemoveAt(i);
                    i--;
                }
            }
        }
    }
}
