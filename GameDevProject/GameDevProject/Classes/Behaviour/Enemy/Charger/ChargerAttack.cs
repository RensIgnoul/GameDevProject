using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameDevProject.Classes.Enemies;
using Microsoft.Xna.Framework;

namespace GameDevProject.Classes.Behaviour.Enemy.Charger
{
    internal class ChargerAttack
    {
        ChargerEnemy _enemy;
        float timer;
        public ChargerAttack(ChargerEnemy enemy)
        {
            _enemy = enemy;
        }
        public void Attack(GameTime gameTime)
        {
            _enemy.isCharging = true;
            if (_enemy.timer <= 10000) // timer aanpassen om duur charge te veranderen
            {
                _enemy.Speed = new Vector2(_enemy.Speed.X * 2, _enemy.Speed.Y);//.X = _enemy.Speed.X * 2;

            }
            if (_enemy.timer >= 20000) // cooldown op charge. er word geen rekening gehoudn met de duur van de charge)
            {
                _enemy.timer = 0;
                _enemy.isCharging = false;
            }
            _enemy.timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
        }
    }
}
