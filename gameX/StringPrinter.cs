using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gameX
{
    class StringPrinter
    {
        SpriteFont font;

        public void Load(ContentManager Content)
        {
            font = Content.Load<SpriteFont>("vent/File");
        }

        public void Draw(SpriteBatch spriteBatch, string tekst, int x, int y, Color kleur )
        {
            spriteBatch.DrawString(font, tekst, new Vector2(x, y), kleur);

        }
    }
}
