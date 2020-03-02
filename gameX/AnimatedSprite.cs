using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gameX
{
    /// <summary>
    /// klasse die als parent dient voor alle elementen die een spritesheet animatie gebruiken 
    /// </summary>
    abstract class AnimatedSprite
    {
        protected Texture2D sTexture;
        protected Vector2 sPosition;
        private int frameIndex;

        private double timeElapsed;
        private double timeToUpdate;

        protected Vector2 sDirection = Vector2.Zero;
        private string currentAnimation = "Idle";

        private Dictionary<string, Rectangle[]> sAnimations = new Dictionary<string, Rectangle[]>();

        public int FramesPerSecond
        {
            set { timeToUpdate = (1f / value);  }
        }
        
        public AnimatedSprite(Vector2 position)
        {
            sPosition = position;
        }

        public void AddAnimation(int frames, int yPos, int xStartFrame, string name, int width, int height, Vector2 offset) //hoeveel frames zijn er -> sprite instukken knippen
        {
            Rectangle[] Rectangles = new Rectangle[frames];

            for (int i = 0; i < frames; i++)
            {
                Rectangles[i] = new Rectangle((i + xStartFrame) * width, yPos, width, height);
            }
            sAnimations.Add(name, Rectangles);
        }

        public virtual void Update(GameTime gameTime) //virtual -> nu overridebaar
        {
            timeElapsed += gameTime.ElapsedGameTime.TotalSeconds;

            if (timeElapsed > timeToUpdate)
            {
                timeElapsed -= timeToUpdate; // voor framerate juist te maken/compenseren

                if (frameIndex < sAnimations[currentAnimation].Length -1)
                {
                    frameIndex++;
                }
                else
                {
                    frameIndex = 0;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {                                                    //frameindex van currenanimation van sanimation
            spriteBatch.Draw(sTexture, sPosition, sAnimations[currentAnimation][frameIndex], Color.White);
            //spriteBatch.Draw(sTexture, new Rectangle(100, 200, sTexture.Width, sTexture.Height), Color.White);
        }

        public void PlayAnimation(string name)
        {
            if (currentAnimation != name)
            {
                currentAnimation = name;
                frameIndex = 0;     //frameindex reset voor error te voorkomen
            }
        }


    }
}
