using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gameX.TileMap;
using Microsoft.Xna.Framework.Graphics;

namespace gameX
{
    /// <summary>
    /// deze klasse bepaald welk level getekend wordt + welke tiles collision met de speler moet worden gedaan
    /// </summary>
    class LevelSelector
    {
        public enum LevelState
        {
            Level1,
            Level2,
            Level3,
            Finished
        }

        public LevelState levelState = LevelState.Level1;
        public LevelState previousLevelState;

        Level1 Level1;
        Level2 Level2;
        Map map1;
        Map map2;
        Map map3;

        public void Init()
        {
            map1 = new Map();
            map2 = new Map();
            map3 = new Map();

            Level1 = new Level1();
            Level2 = new Level2();

            Level1.Init(map1);
            Level2.Init(map2);
        }

        public void Load()
        {
            Level1.Generate();
            Level2.Generate();
        }

        public void Update(Player player, Camera camera)
        {
            if (previousLevelState != levelState)
            {
                player.ResetPos();
            }

            if (levelState == LevelSelector.LevelState.Level1)
            {
                foreach (CollisionTiles tile in map1.CollisionTiles)
                {
                    player.Collision(tile.Rectangle, map1.Width, map1.Height);
                    camera.Update(player.Position, map1.Width, map1.Height);
                }
            }

            if (levelState == LevelSelector.LevelState.Level2)
            {
                foreach (CollisionTiles tile in map2.CollisionTiles)
                {
                    player.Collision(tile.Rectangle, map2.Width, map2.Height);
                    camera.Update(player.Position, map2.Width, map2.Height);
                }
            }
            previousLevelState = levelState;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (levelState == LevelSelector.LevelState.Level1)
            {
                Level1.Draw(spriteBatch);
            }

            if (levelState == LevelSelector.LevelState.Level2)
            {
                Level2.Draw(spriteBatch);
            }
        }
    }
}
