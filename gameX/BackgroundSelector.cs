using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gameX
{
    class BackgroundSelector
    {
        List<Paralex> paralexList = new List<Paralex>();

        public BackgroundSelector()
        {
            paralexList.Add(new Paralex("paralax/realparalex"));
            paralexList.Add(new Paralex("paralax/otherparalex"));
            paralexList.Add(new Paralex("paralax/background"));
        }

        public void Load(ContentManager content)
        {
            foreach (Paralex item in paralexList)
            {
                item.Load(content);
            }
        }

        public void Draw(SpriteBatch spritebatch, int number, int Xkeer, int Ykeer)
        {
            paralexList[number].Draw(spritebatch, Xkeer, Ykeer);
        }
    }
}
