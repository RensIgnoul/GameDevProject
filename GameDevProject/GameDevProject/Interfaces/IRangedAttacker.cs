using GameDevProject.Classes;
using GameDevProject.Classes.Animations;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevProject.Interfaces
{
    internal interface IRangedAttacker
    {
        public List<Projectile> Projectiles { get; set; }
        public SpriteEffects SpriteOrientation { get; set; }
        public Animation AttackingAnimation { get; set; }
        public bool isAttacking { get; set; }
        private void Attack() { }
        private void UpdateAttacks() { }
    }
}
