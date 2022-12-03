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
        public List<IUnit> Units = new List<IUnit>();
        public Level(Map map, List<IUnit> unitList)
        {
            Map = map;
            Units = unitList;
        }

        public void Update(GameTime gameTime)
        {
            throw new NotImplementedException();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Map.Draw(spriteBatch);
            foreach (var unit in Units)
            {
                unit.Draw(spriteBatch);
                if (unit is Enemy)
                {
                    Enemy enemy = unit as Enemy;
                    if (enemy.Health > 0)
                    {
                        if (unit is RangedEnemy)
                        {
                            foreach (var projectile in (unit as RangedEnemy).Projectiles)
                            {
                                projectile.Draw(spriteBatch, 2f);//0.1f);
                            }
                        }
                    }
                }
                
            }
        }
    }
}
