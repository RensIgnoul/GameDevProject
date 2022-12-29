using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevProject.Classes.Animations
{
    internal class Animation
    {
        public AnimationFrame CurrentFrame { get; set; }
        private List<AnimationFrame> frames;
        public int counter;
        private double secondCounter = 0;

        public Animation()
        {
            frames = new List<AnimationFrame>();
        }

        public void AddFrame(AnimationFrame frame)
        {
            frames.Add(frame);
            CurrentFrame = frames[0];
        }

        public void AddFrameList(List<Rectangle> frameList)
        {
            foreach (var frame in frameList)
            {
                frames.Add(new AnimationFrame(frame));
            }
        }
        public void Update(GameTime gameTime)
        {
            CurrentFrame = frames[counter];
            
            secondCounter += gameTime.ElapsedGameTime.TotalSeconds;
            int fps = 10;

            if (secondCounter >= 1d / fps)
            {
                counter++;
                secondCounter = 0;
            }
            if (counter >= frames.Count)
            {
                counter = 0;
            }
        }

        public void GetFramesFromTextureProperties(int width, int height, int numberOfWidthSprites, int numberOfHeightSprites)
        {
            int widthOfFrame = width / numberOfWidthSprites;
            int heighOfFrame = height / numberOfHeightSprites;

            for (int y = 0; y <= height - heighOfFrame; y += heighOfFrame)
            {
                for (int x = 0; x <= width - widthOfFrame; x += widthOfFrame)
                {
                    frames.Add(new AnimationFrame(new Rectangle(x, y, widthOfFrame, heighOfFrame)));
                }
            }
        }
    }
}
