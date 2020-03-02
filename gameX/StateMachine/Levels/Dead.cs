using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gameX.StateMachine
{
    class Dead
    {
        private Texture2D _youdied;

        public void Load(ContentManager content)
        {
            _youdied = content.Load<Texture2D>("State/youdied");
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_youdied, new Rectangle(0, 0, 1100, 480), Color.White);
        }
    }
}
