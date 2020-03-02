using gameX.TileMap;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;

namespace gameX
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Player player;
        Camera camera;

        MainMenu main;
        BackgroundSelector backgroundSelector;
        GameStateMachine gameStateMachine;
        LevelSelector levelSelector;
        StringPrinter stringPrinter;

        SoundEffect youdied;
        Timer timer;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            player = new Player(new Vector2(66,100));

            graphics.PreferredBackBufferWidth = 1100; //width
            graphics.PreferredBackBufferHeight = 480; //height
            graphics.ApplyChanges();

            Window.Title = "Trust me i am an engineer";

            // TESTING -> kijken op resolutie goed is, spel lengte
            Window.AllowUserResizing = true;

            backgroundSelector = new BackgroundSelector();
            gameStateMachine = new GameStateMachine(this);
            gameStateMachine.Init();
            levelSelector = new LevelSelector();
            levelSelector.Init();
            timer = new Timer();
            stringPrinter = new StringPrinter();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            //Contentmanager doorgeven naar Tiles
            Tiles.Content = Content;

            player.Load(Content);

            camera = new Camera(GraphicsDevice.Viewport);

            //this is om game1 mee tegeven -> om af te sluiten
            main = new MainMenu(this, gameStateMachine);
            main.Load(Content);

            levelSelector.Load();
            backgroundSelector.Load(Content);
            gameStateMachine.Load(Content);
            timer.Load(Content);
            stringPrinter.Load(Content);

            youdied = Content.Load<SoundEffect>("audio/youdied");
        }

        protected override void UnloadContent()
        {

        }
  
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                gameStateMachine.gameStates = GameStateMachine.GameStates.MainMenu;
            }

            switch (gameStateMachine.gameStates)
            {
                case GameStateMachine.GameStates.MainMenu:
                    this.IsMouseVisible = true;
                    main.Update();
                    break;
                case GameStateMachine.GameStates.EnterName:
                    break;
                case GameStateMachine.GameStates.PlayingLevel:
                    this.IsMouseVisible = false;

                    if (player.Finished == true)
                    {
                        player.Finised();

                        if (timer.notreset())
                        {
                            timer.save();
                        }
                        levelSelector.levelState = LevelSelector.LevelState.Level2;
                        timer.Reset();
                    }

                    if (player.Levens.Isdead())
                    {
                        youdied.Play();
                        timer.Reset();
                        gameStateMachine.gameStates = GameStateMachine.GameStates.Dead;
                    }

                    levelSelector.Update(player, camera);
                    player.Update(gameTime);

                    timer.Update(gameTime);

                    break;
                case GameStateMachine.GameStates.Dead:
                    player._controles.Update();

                    if (player._controles.Jump)
                    {
                        levelSelector.levelState = LevelSelector.LevelState.Level1;
                        gameStateMachine.gameStates = GameStateMachine.GameStates.MainMenu;
                        player.Levens.ResetLevels();
                        player.ResetPos();
                    }
                    break;
                case GameStateMachine.GameStates.Exit:
                    Exit();
                    break;
                default:
                    break;
            }


            base.Update(gameTime);
        }

   
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            switch (gameStateMachine.gameStates)
            {
                case GameStateMachine.GameStates.MainMenu:
                    spriteBatch.Begin();

                    backgroundSelector.Draw(spriteBatch, 1, 10, 4);
                    main.Draw(spriteBatch);

                    spriteBatch.End();
                    break;
                case GameStateMachine.GameStates.EnterName:
                    break;
                case GameStateMachine.GameStates.PlayingLevel:
                    spriteBatch.Begin();
                    backgroundSelector.Draw(spriteBatch, 0, 25, 4);
                    spriteBatch.End();

                    spriteBatch.Begin(SpriteSortMode.Deferred,
                      BlendState.AlphaBlend,
                      null, null, null, null,
                      camera.GetViewMatrix());

                    backgroundSelector.Draw(spriteBatch, 2, 25, 4);
                    levelSelector.Draw(spriteBatch);
                    player.Draw(spriteBatch);

                    //TESTING ONLY -> collisionrectangle zichtbaar
                    //player.DrawTest(spriteBatch);

                    spriteBatch.End();

                    spriteBatch.Begin();
                    player.Levens.Draw(spriteBatch);
                    timer.Draw(spriteBatch);
                    spriteBatch.End();
                    break;
                case GameStateMachine.GameStates.Dead:
                    spriteBatch.Begin();
                    gameStateMachine.Draw(spriteBatch);
                    stringPrinter.Draw(spriteBatch, "Press space to continue", 400, 400, Color.DarkGray);
                    spriteBatch.End();
                    break;
                case GameStateMachine.GameStates.Exit:
                    break;
                default:
                    break;
            }

            base.Draw(gameTime);
        }

    }
}
