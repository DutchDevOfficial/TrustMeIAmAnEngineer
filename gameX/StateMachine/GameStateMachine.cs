using gameX.StateMachine;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gameX
{   /// <summary>
    /// Deze klasse beheert de hoofd states van de game
    /// </summary>
    class GameStateMachine
    {
        Game1 game;
        Dead dead;

        public enum GameStates
        {
            MainMenu,
            EnterName,
            PlayingLevel,
            Dead,
            Exit
        }

        public GameStates gameStates;

        public GameStateMachine(Game1 game1)
        {
            game = game1;
        }

        public void Init()
        {
            dead = new Dead();
        }

        public void Load(ContentManager content)
        {
            dead.Load(content);
        }

        public void Draw(SpriteBatch spritebatch)
        {
            if (gameStates == GameStates.Dead)
            {
                dead.Draw(spritebatch);
            }
        }

    }
}
