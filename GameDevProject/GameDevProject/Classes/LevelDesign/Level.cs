using GameDevProject.Classes.Enemies;
using GameDevProject.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevProject.Classes.LevelDesign
{
    class Level : IGameObject
    {
        public Map Map { get; set; }
        public List<Enemy> enemies = new List<Enemy>();
        public Level(Map map, List<Enemy> enemyList)
        {
            Map = map;
            enemies = enemyList;
        }

        public void Update(GameTime gameTime)
        {
            throw new NotImplementedException();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Map.Draw(spriteBatch);
            foreach (var enemy in enemies)
            {
                enemy.Draw(spriteBatch);
                if (enemy.Health > 0)
                {
                    foreach (var projectile in enemy.Projectiles)
                    {
                        projectile.Draw(spriteBatch, 2f);//0.1f);
                    }
                }
            }
        }
    }
}
