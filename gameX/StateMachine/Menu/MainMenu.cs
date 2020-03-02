using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gameX
{
    class MainMenu
    {
        Game1 game;
        GameStateMachine mainStateMachine;
        SoundEffect launch;
        List<GUIelements> main = new List<GUIelements>();

        private Song background;

        public MainMenu(Game1 thegame, GameStateMachine _mainStateMachine)
        {
            mainStateMachine = _mainStateMachine;

            game = thegame;
            //main.Add(new GUIelement("Menu/Leeg"));
            main.Add(new GUIelements("Menu/Start"));
            main.Add(new GUIelements("Menu/Save"));
            main.Add(new GUIelements("Menu/Quit"));
            main.Add(new GUIelements("Menu/Load"));
            main.Add(new GUIelements("Menu/resume"));
        }

        public void Load(ContentManager content)
        {
            foreach (GUIelements element in main)
            {
                element.Load(content);
                element.CenterElement(480, 1100);
                element.ClickEvent += OnClick;
            }
            //buttons zijn 50 y pixels
            //main.Find(x => x.AssetName == "Menu/Leeg").MoveElement(0, -50);

            main.Find(x => x.AssetName == "Menu/Start").MoveElement(0, -120);
            main.Find(x => x.AssetName == "Menu/Load").MoveElement(0, -60);
            main.Find(x => x.AssetName == "Menu/Quit").MoveElement(0, 60);

            main.Find(x => x.AssetName == "Menu/resume").MoveElement(0, -180);


            launch = content.Load<SoundEffect>("audio/specialEffect");
            background = content.Load<Song>("audio/menu");
            
            //UNCOMMENT voor achtergrond muziek
            MediaPlayer.Play(background);
            MediaPlayer.IsRepeating = true;

            //om elementen te verplaatsen:
            // 1. maak een property van de assetname
            // 2. doe dit
            // main.Find(x => x.AssetName == "Play").MoveElement(0,-100);
        }

        public void Update()
        {
            foreach (GUIelements element in main)
            {
                element.Update();
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (GUIelements elem in main)
            {
                elem.Draw(spriteBatch);
            }
        }

        public void OnClick(String element)
        {
            if (element == "Menu/Start" || element == "Menu/resume")
            {
                MediaPlayer.Volume = (float)0.1;
                launch.Play();
                mainStateMachine.gameStates = GameStateMachine.GameStates.PlayingLevel;
            }

            if (element == "nameBTN")
            {
                //enter name
                launch.Play();

                mainStateMachine.gameStates = GameStateMachine.GameStates.EnterName;
            }

            if (element == "done")
            {
                mainStateMachine.gameStates = GameStateMachine.GameStates.MainMenu;
            }

            if (element == "Menu/Quit")
            {
                mainStateMachine.gameStates = GameStateMachine.GameStates.Exit;
            }
        }
    }
}