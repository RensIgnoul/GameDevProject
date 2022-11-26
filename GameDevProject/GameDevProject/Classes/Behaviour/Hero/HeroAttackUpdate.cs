using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GameDevProject.Classes.Behaviour.Hero
{
    internal class HeroAttackUpdate
    {
        Classes.Hero.Hero _hero;
        public HeroAttackUpdate(Classes.Hero.Hero hero)
        {
            _hero = hero;
        }
        public void UpdateProjectiles()
        {
            foreach (var projectile in _hero.Projectiles)
            {
                projectile.Position += projectile.Speed;
                projectile.HitBox.X = (int)projectile.Position.X;
                projectile.HitBox.Y = (int)projectile.Position.Y;
                if (Vector2.Distance(projectile.Position, _hero.Position) > 500) // maakt kogel onzichtbaar na 500px
                {
                    projectile.IsVisible = false;
                }
            }
            for (int i = 0; i < _hero.Projectiles.Count; i++)
            {
                if (!_hero.Projectiles[i].IsVisible)
                {
                    _hero.Projectiles.RemoveAt(i);
                    i--;
                }
            }
        }
    }
}
