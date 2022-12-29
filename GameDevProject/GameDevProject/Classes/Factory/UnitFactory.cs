using GameDevProject.Classes.Enemies;
using GameDevProject.Interfaces;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevProject.Classes.Factory
{
    internal class UnitFactory
    {
        public IUnit CreateUnit(string unitType, int x, int y, Texture2D texture)
        {
            if (unitType.ToUpper() == "TRAP")
            {
                return new TrapEnemy(texture, x, y);
            }
            if (unitType.ToUpper() == "CHARGER")
            {
                return new ChargerEnemy(texture, x, y);
            }
            return null;
        }
        public IUnit CreateUnit(string unitType, int x, int y, Texture2D texture, Texture2D projectileTexture)
        {
            if (unitType.ToUpper() == "RANGED")
            {
                return new RangedEnemy(texture, x, y, projectileTexture);
            }
            return null;
        }
    }
}
