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
    /// <summary>
    /// Deze klasse is verantwoordelijk om paralex backgrounds te beheren, deze worden meerdere keren getekend op het scherm (overgang is niet zichtbaar)
    /// </summary>
    class Paralex
    {
        private string _assetNameParalex;

        Texture2D ParallexTexture;
        Rectangle ParallexRectangle;

        private int Yparallex = 0;
        private int Xparallex = 0;

        public Paralex(string assetName)
        {
            _assetNameParalex = assetName;
        }

        public void Load(ContentManager content)
        {
            ParallexTexture = content.Load<Texture2D>(_assetNameParalex);
            ParallexRectangle = new Rectangle(0, 0, ParallexTexture.Width, ParallexTexture.Height);
        }

        public void Draw(SpriteBatch spritebatch, int Xkeer, int Ykeer)
        {
            for (int i = 0; i < Xkeer; i++)
            {
                for (int q = 0; q < Ykeer; q++)
                {
                    ParallexRectangle = new Rectangle(0, 0, ParallexTexture.Width, ParallexTexture.Height);
                    spritebatch.Draw(ParallexTexture, new Vector2(Xparallex, Yparallex), ParallexRectangle, Color.White);

                    Yparallex += ParallexTexture.Height;
                }
                Xparallex += ParallexTexture.Width;
                Yparallex = 0;
            }
            Xparallex = 0;
        }
    }
}
