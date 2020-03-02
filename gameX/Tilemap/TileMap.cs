using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gameX.Collectables;
using Microsoft.Xna.Framework.Content;

namespace gameX.TileMap
{
    /// <summary>
    /// Deze klasse is verantwoordelijk voor het omzetten van de tilemap in grafische draw + colission tiles
    /// </summary>
    class Map
    {
        private List<CollisionTiles> collisionTiles = new List<CollisionTiles>();

        public List<CollisionTiles> CollisionTiles
        {
            get { return collisionTiles; }
        }

        private int width, height;
        public int Width
        {
            get { return width; }
        }
        public int Height
        {
            get { return height; }
        }

        public void Generate (int[,] map, int size)
        {
          
            for (int x = 0; x < map.GetLength(1); x++)
            {
                for (int y = 0; y < map.GetLength(0); y++)
                {
                    int number = map[y, x];

                    if (number > 0)
                    {
                        collisionTiles.Add(new CollisionTiles(number, new Rectangle(x * size, y * size, size, size)));

                        width = (x + 1) * size;
                        height = (y + 1) * size;
                    }
                }
            }
        }

        public void Draw (SpriteBatch spriteBatch)
        {
            foreach (CollisionTiles tiles in collisionTiles)
            {
                tiles.Draw(spriteBatch);
            }
        }
    }
}
