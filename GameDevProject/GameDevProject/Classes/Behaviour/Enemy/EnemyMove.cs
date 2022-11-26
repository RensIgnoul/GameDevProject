using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameDevProject.Classes.Enemies;

namespace GameDevProject.Classes.Behaviour.Enemy
{
    internal class EnemyMove
    {
        Enemies.Enemy _enemy;
        public EnemyMove(Enemies.Enemy enemy)
        {
            _enemy = enemy;
        }

        public void Move()
        {
            _enemy.Speed.X = 5 * _enemy.directionModifier;
            _enemy.Position += _enemy.Speed;
        }
    }
}
