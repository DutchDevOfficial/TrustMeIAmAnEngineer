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
    class Levens
    {
        private int _aantal;
        private int _startAantal;
        Rectangle levenRec;
        Texture2D levenTex;

        public int Aantal { get => _aantal; }

        public Levens(int beginlevens)
        {
            _startAantal = beginlevens;
            _aantal = beginlevens;
        }

        public void Load(ContentManager content)
        {
           levenTex = content.Load<Texture2D>("player/heart");
        }

        public bool Isdead()
        {
            if (_aantal <= 0)
            {
                _aantal = 0;

                return true;
            }
            return false;
        }

        public void Add(int aantal)
        {
            _aantal += aantal;
        }
        public void Hit(int aantal)
        {
            _aantal -= aantal;
        }

        public void ResetLevels()
        {
            _aantal = _startAantal;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            levenRec = new Rectangle(10, 10, levenTex.Width, levenTex.Height);

            for (int i = 0; i < Aantal; i++)
            {
                spriteBatch.Draw(levenTex, levenRec, Color.White);
                levenRec = new Rectangle(levenRec.X += 75, levenRec.Y, levenTex.Width, levenRec.Height);
            }
        }
    }
}
