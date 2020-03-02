using gameX.Collision;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gameX
{
    class Player : AnimatedSprite
    {
        private Texture2D Texture { get; }
        private Vector2 velocity;
        private Rectangle collisionRectangle;
        public Controles _controles { get;}
        private bool hasJumped = true;
        private int spriteW = 64;
        private int spriteH = 113;
        private SoundEffect jump;
        private Vector2 sStartPosition;
        public bool ready=false;

        bool finished;
        private Levens _levens;
        public Levens Levens { get => _levens; }

        //TESTING ONLY -> collision Rectangle visible
        Texture2D TESTtex;
        
        public Vector2 Position
        {
            get { return sPosition; }
        }

        public bool Finished { get => finished; set => finished = value; }
        public bool HasJumped { get => hasJumped; set => hasJumped = value; }

        public Player(Vector2 position) : base(position)
        {
            _controles = new ControlKeyboard();
            //_controles = new ControlNumPad();
            _levens = new Levens(3);

            FramesPerSecond = 10;

            sStartPosition = position;

            AddAnimation(9, 0, 0, "Idle", spriteW, spriteH, new Vector2(0, 0));
            AddAnimation(1, 113, 0, "JumpUp", spriteW, spriteH, new Vector2(0, 0));
            AddAnimation(1, 113, 1, "JumpDown", spriteW, spriteH, new Vector2(0, 0)); //xStartFrame is 1 -> wordt automatisch maal de width gedaan 
            AddAnimation(8, 225, 0, "Run", spriteW, spriteH, new Vector2(0, 0));
        }

        public void Load(ContentManager Content)
        {
            Levens.Load(Content);
            sTexture = Content.Load<Texture2D>("player/spritesheet");
            jump = Content.Load<SoundEffect>("audio/jumpEffect");

            //TESTING ONLY
            TESTtex = Content.Load<Texture2D>("Tile1");
        }
       
        public override void Update(GameTime gameTime)
        {
            sDirection = Vector2.Zero;
            Input(gameTime);

            if (_controles.Right == false && _controles.Left == false && _controles.Jump == false)
            {
                PlayAnimation("Idle");
            }

            if (velocity.Y < 0)
            {
                PlayAnimation("JumpUp");
            }
            if (velocity.Y > 0)
            {
                PlayAnimation("JumpDown");
            }
            if (velocity.X > 0 && velocity.Y == 0) //run right
            {
                PlayAnimation("Run");
            }

            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            base.Update(gameTime);

            sPosition += velocity;
            collisionRectangle = new Rectangle((int)sPosition.X, (int)sPosition.Y,  64, 112);

            if (velocity.Y < 10)
            {
                velocity.Y += 0.4f;
            }
        }


        private void Input(GameTime gameTime)
        {
            _controles.Update();

            if (_controles.Right)
            {
                velocity.X = (float)gameTime.ElapsedGameTime.TotalMilliseconds / 4;
                sDirection += new Vector2(1, 0);
            }
            else if (_controles.Left)
            {
                velocity.X = -(float)gameTime.ElapsedGameTime.TotalMilliseconds / 4;
                sDirection += new Vector2(-1, 0);
            }
            else
            {
                velocity.X = 0f;
            }

            if (_controles.Jump && HasJumped == false)
            {
                velocity.Y = -11f;
                HasJumped = true;

                sDirection += new Vector2(0, -1);
                jump.Play();
            }
        }


        public void Collision(Rectangle newRectangle, int xOffset, int yOffset)
        {
            if (collisionRectangle.TouchTopOf(newRectangle))
            {
                collisionRectangle.Y = newRectangle.Y - collisionRectangle.Height;
                velocity.Y = 0f;
                HasJumped = false;
            }

            if (collisionRectangle.TouchLeftOf(newRectangle))
            {
                sPosition.X = newRectangle.X - collisionRectangle.Width - 2;
            }

            if (collisionRectangle.TouchRightOf(newRectangle))
            {
                sPosition.X = newRectangle.X + newRectangle.Width + 2;
            }

            if (collisionRectangle.TouchBottomOf(newRectangle))
            {
                velocity.Y = 1f;
            }


            if (sPosition.X < 0)
            {
                sPosition.X = 0;
            }

            if (sPosition.X > xOffset - collisionRectangle.Width)
            {
                Finished = true;
            }

            if (sPosition.Y < 0)
            {
                velocity.Y = 1f;
            }

            if (sPosition.Y > yOffset - collisionRectangle.Height)
            {
                ResetPos();
                Levens.Hit(1);
                HasJumped = true;
            }
        }

        public void Finised()
        {
            ResetPos();
            Finished = false;
        }

        /// <summary>
        /// Deze klasse is enkel voor TESTING:
        /// Geeft de volledige collisionRectangle weer -> testen van collision
        /// </summary>
        /// <param name="spriteBatch"></param>
        public void DrawTest(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(TESTtex, collisionRectangle, Color.Red);
        }

        public void ResetPos()
        {
            sPosition = sStartPosition;
        }
    }
}
