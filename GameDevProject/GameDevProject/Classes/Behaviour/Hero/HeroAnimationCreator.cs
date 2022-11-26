using GameDevProject.Classes.Animations;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevProject.Classes.Behaviour.Hero
{
    internal class HeroAnimationCreator
    {
        Classes.Hero.Hero _hero;
        public HeroAnimationCreator(Classes.Hero.Hero hero)
        {
            _hero = hero;
        }
        public void CreateAnimations()
        {
            List<Rectangle> runningFrames = new List<Rectangle>();
            List<Rectangle> idleFrames = new List<Rectangle>();
            List<Rectangle> jumpingFrames = new List<Rectangle>();
            List<Rectangle> attackingFrames = new List<Rectangle>();
            int frameWidth = 231;

            _hero.idleAnimation = new Animation();
            _hero.runningAnimation = new Animation();
            _hero.jumpingAnimation = new Animation();
            _hero.AttackingAnimation = new Animation();


            for (int i = 0; i < 8 * frameWidth; i += frameWidth)
            {
                runningFrames.Add(new Rectangle(i, 576, frameWidth, 192));
            }
            for (int i = 0; i < 6 * frameWidth; i += frameWidth)
            {
                idleFrames.Add(new Rectangle(i, 192, frameWidth, 192));
            }
            for (int i = 0 * frameWidth; i < 2 * frameWidth; i += frameWidth)
            {
                jumpingFrames.Add(new Rectangle(i, 384, frameWidth, 192));
            }
            for (int i = 0 * frameWidth; i < 8 * frameWidth; i += frameWidth)
            {
                attackingFrames.Add(new Rectangle(i, 0, frameWidth, 192));
            }
            _hero.runningAnimation.AddFrameList(runningFrames);
            _hero.idleAnimation.AddFrameList(idleFrames);
            _hero.jumpingAnimation.AddFrameList(jumpingFrames);
            _hero.AttackingAnimation.AddFrameList(attackingFrames);
        }
    }
}
