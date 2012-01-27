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

namespace Infinity_TD
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Menu menu;

        KeyboardState previousState;

        MouseState previousMouseState;

        Texture2D mouseCursor;

        public enum Screens { MENU, GAME, PAUSE }

        public Screens currentScreen = Screens.GAME;

        public Game1()
        {
            menu = new Menu();
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = 1024;
            graphics.PreferredBackBufferHeight = 768;
            Window.Title = "Infinity TD";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape)) this.Exit();


            switch (currentScreen)
            {
                case Screens.GAME:
                    break;
                case Screens.MENU:
                    menu.updateMenu();
                    break;
                case Screens.PAUSE:
                    break;
            }

            previousMouseState = Mouse.GetState();
            previousState = Keyboard.GetState();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            switch (currentScreen)
            {
                case Screens.GAME:
                    break;
                case Screens.MENU:
                    //Menu.drawMenu(spriteBatch, --SPRITEFONT HERE)
                    break;
                case Screens.PAUSE:
                    break;
            }



            spriteBatch.Draw(mouseCursor, new Vector2(Mouse.GetState().X, Mouse.GetState().Y), Color.White);

            base.Draw(gameTime);
        }
    }
}
