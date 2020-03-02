using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gameX
{
        public abstract class Controles
        {
        protected bool left;
        protected bool right;
        protected bool jump;
        

        public bool Left
        {
            get { return left; }
        }

        public bool Right
        {
            get { return right; }
        }

        public bool Jump
        {
            get { return jump; }
        }

        public abstract void Update();
        }

        public class ControlPijltjes : Controles
        {
            public override void Update()
            {
                KeyboardState stateKey = Keyboard.GetState();

                if (stateKey.IsKeyDown(Keys.Left))
                {
                    left = true;
                }
                if (stateKey.IsKeyUp(Keys.Left))
                {
                    left = false;
                }

                if (stateKey.IsKeyDown(Keys.Right))
                {
                    right = true;
                }
                if (stateKey.IsKeyUp(Keys.Right))
                {
                    right = false;
                }

                if (stateKey.IsKeyDown(Keys.Up))
                {
                    jump = true;
                }
                if (stateKey.IsKeyUp(Keys.Up))
                {
                    jump = false;
                }
            }
        }

        public class ControlKeyboard : Controles
        {
            public override void Update()
            {
                KeyboardState stateKey = Keyboard.GetState();

                if (stateKey.IsKeyDown(Keys.A))
                {
                    left = true;
                }
                if (stateKey.IsKeyUp(Keys.A))
                {
                    left = false;
                }

                if (stateKey.IsKeyDown(Keys.D))
                {
                    right = true;
                }
                if (stateKey.IsKeyUp(Keys.D))
                {
                    right = false;
                }

                if (stateKey.IsKeyDown(Keys.Space))
                {
                    jump = true;
                }
                if (stateKey.IsKeyUp(Keys.Space))
                {
                    jump = false;
                }
        }
        }


        public class ControlNumPad : Controles
        {
            public override void Update()
            {
                KeyboardState stateKey = Keyboard.GetState();

                if (stateKey.IsKeyDown(Keys.NumPad4))
                {
                    left = true;
                }
                if (stateKey.IsKeyUp(Keys.NumPad4))
                {
                    left = false;
                }

                if (stateKey.IsKeyDown(Keys.NumPad6))
                {
                    right = true;
                }
                if (stateKey.IsKeyUp(Keys.NumPad6))
                {
                    right = false;
                }

                if (stateKey.IsKeyDown(Keys.NumPad8))
                {
                    jump = true;
                }
                if (stateKey.IsKeyUp(Keys.NumPad8))
                {
                    jump = false;
                }
            }
        }
 }
