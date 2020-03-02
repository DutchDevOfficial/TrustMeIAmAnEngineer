using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace gameX
{
    class Camera
    {
        public float Zoom { get; set; }
        public float Rotation { get; set; }

        private Matrix transform;
        //deze of methode
        public Matrix Transform
        {
            get { return transform; }
        }

        private Vector2 center;
        private readonly Viewport _viewport;

        public Camera(Viewport newViewport)
        {
            _viewport = newViewport;
            Zoom = 1;
        }


        public void Update(Vector2 position, int xOffset, int yOffset)
        {
            if (position.X < _viewport.Width / 2)
            {
                center.X = _viewport.Width / 2;
            }

            else if (position.X > xOffset - (_viewport.Width / 2))
            {
                center.X = xOffset - (_viewport.Width / 2);
            }
            else
            {
                center.X = position.X;
            }


            if (position.Y < _viewport.Height / 2)
            {
                center.Y = _viewport.Height / 2;
            }

            else if (position.Y > yOffset - (_viewport.Height / 2))
            {
                center.Y = yOffset - (_viewport.Height / 2);
            }
            else center.Y = position.Y;

        }


        //plattegrond
        public Vector2 ViewportCenter
        {
            get
            {
                return new Vector2(_viewport.Width * 0.5f, _viewport.Height * 0.5f);
            }
        }



        public Matrix GetViewMatrix()
        {
            transform = Matrix.CreateTranslation(new Vector3(-center.X + (_viewport.Width / 2),
                                                             -center.Y + (_viewport.Height / 2), 0));

            return transform;
        }


    }
}
