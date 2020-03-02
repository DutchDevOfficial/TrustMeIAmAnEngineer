using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;

namespace gameX
{
    class Timer
    {
        SpriteFont timefont;
        private float _timer = 0;
        private float _previousleveltime;

        public float Time { get => _timer; }
        public float PreviousLevelTime { get => _previousleveltime; }


        public void Load(ContentManager Content)
        {
            timefont = Content.Load<SpriteFont>("vent/File");
        }

        public void Update(GameTime gameTime)
        {
            _timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
        }

        public void Reset()
        {
            _timer = 0;
        }

        public void save()
        {
            _previousleveltime = _timer;
        }

        public bool notreset()
        {
            if (_timer > 1)
            {
                return true;
            }
            return false;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(timefont, "Your current time: " + _timer.ToString("0.00"), new Vector2(300, 20), Color.White);
            spriteBatch.DrawString(timefont, "Your previous level time: " + _previousleveltime.ToString("0.00"), new Vector2(300, 60), Color.Black);
        }
    }
}
