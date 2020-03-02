using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gameX.Collision;

namespace gameX.Collectables
{
    class Coin : AnimatedSprite
    {/// <summary>
    /// NIET GEIMPLEMENTEERD
    /// </summary>

        private Texture2D Texture { get; }
        private Rectangle collisionRectangle;
        //private SoundEffect kickupSound;
        private int spriteW = 835;    // sprite width
        private int spriteH = 192;    // sprite height

        public Vector2 Position
        {
            get { return sPosition; }
        }

        public Coin(Vector2 position) : base(position)
        {
            FramesPerSecond = 10;

            AddAnimation(4, 0, 0, "Idle", spriteW, spriteH, new Vector2(0, 0));
        }

        public void Load(ContentManager content)
        {
            sTexture = content.Load<Texture2D>("Collectables/coin");
            //kickupSound = content.Load<SoundEffect>("audio/coinEffect");
        }

        public override void Update(GameTime gameTime)
        {
            PlayAnimation("Idle");

            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            base.Update(gameTime);
            collisionRectangle = new Rectangle((int)sPosition.X, (int)sPosition.Y, 96, 96);
        }


        public void Collision(Rectangle newRectangle, int xOffset, int yOffset)
        {
            if (collisionRectangle.TouchTopOf(newRectangle) ||
                collisionRectangle.TouchLeftOf(newRectangle)||
                collisionRectangle.TouchRightOf(newRectangle)||
                collisionRectangle.TouchBottomOf(newRectangle))
            {
                //kickedup = true;
                //kickupSound.Play();
            }
        }
    }
}
