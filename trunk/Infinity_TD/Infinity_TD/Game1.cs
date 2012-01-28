using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Infinity_TD_Library;

namespace Infinity_TD
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        public SpriteBatch SpriteBatch { get; set; }
        public SoundManager soundManager;

        //Menu menu;
        //Interface interf = new Interface();
        //KeyboardState previousState;

        //List<Enemy> enemyList = new List<Enemy>();

        //MouseState previousMouseState;

        //public enum Screens { MENU, GAME, PAUSE }

        //public Screens currentScreen = Screens.GAME;

        Texture2D mouseCursor;

        //Estrutura de Menu
        private InputHandler input;
        private GameStateManager gameManager;

        public ITitleIntroState TitleIntroState; //Main State
        public IStartMenuState StartMenuState;
        public IOptionsMenuState OptionsMenuState;
        public IPlayingState PlayingState; //Main State
        public IPausedState PausedState;

        public Game1()
        {
           // menu = new Menu();
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = 1024;
            graphics.PreferredBackBufferHeight = 768;
            Window.Title = "Infinity TD";
            

            input = new InputHandler(this);
            Components.Add(input);

            IsMouseVisible = false;

            gameManager = new GameStateManager(this);
            Components.Add(gameManager);

            TitleIntroState = new TitleIntroState(this);
            StartMenuState = new StartMenuState(this);
            OptionsMenuState = new OptionsMenuState(this);
            PlayingState = new PlayingState(this);
            PausedState = new PausedState(this);
            soundManager = new SoundManager(this);
            gameManager.ChangeState(TitleIntroState.Value);
        }

        protected override void Initialize()
        {
            //interf.InitializeInterface(this.Content);
            base.Initialize();

        }

        protected override void LoadContent()
        {
            SpriteBatch = new SpriteBatch(GraphicsDevice);
            mouseCursor = Content.Load<Texture2D>("Graphics/Stuff/cursor1");
        }

        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {
            //if (Keyboard.GetState().IsKeyDown(Keys.Escape)) this.Exit();


            //switch (currentScreen)
            //{
            //    case Screens.GAME:
            //        interf.UpdateInterface(gameTime);
            //        break;
            //    case Screens.MENU:
            //        menu.updateMenu();
            //        break;
            //    case Screens.PAUSE:
            //        break;
            //}

            //previousMouseState = Mouse.GetState();
            //previousState = Keyboard.GetState();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            //spriteBatch.Begin();

            //switch (currentScreen)
            //{
            //    case Screens.GAME:
            //        //interf.DrawInterface(spriteBatch);
            //        break;
            //    case Screens.MENU:
            //        //Menu.drawMenu(spriteBatch, --SPRITEFONT HERE)
            //        break;
            //    case Screens.PAUSE:
            //        break;
            //}

            //spriteBatch.End();

            SpriteBatch.Begin();
            base.Draw(gameTime);

            SpriteBatch.Draw(mouseCursor, new Vector2(Mouse.GetState().X, Mouse.GetState().Y), Color.White);

            SpriteBatch.End();
        }
    }
}
