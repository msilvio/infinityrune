using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Infinity_TD_Library;

namespace Infinity_TD
{
    public sealed class PlayingState : BaseGameState, IPlayingState
    {
        SpriteFont font;
        Random rand;
        Color color;
        Interface hud = new Interface();
        CollisionHandler colHandler = new CollisionHandler();
        //Animacao _textureAnim1, _textureAnim2, _textureAnim3;
        //Texture2D texture1, texture2, texture3, texture4, texture5;
        Texture2D enemyTexture;
        Enemy testEnemy;

        TileMap tileMap;

        Texture2D stageTexture;

        public PlayingState(Game game)
            : base(game)
        {
            game.Services.AddService(typeof(IPlayingState), this);
            rand = new Random();
        }

        protected override void LoadContent()
        {
            enemyTexture = Content.Load<Texture2D>("Graphics/Enemy/_Robo1");
            testEnemy = new Enemy(new Vector2(0, 560), enemyTexture);
            testEnemy.speed.X = 2f;
            MapArrays.mapListInit();
            tileMap = new TileMap();
            tileMap.initializeMap();
            hud.InitializeInterface(this.Content);

            stageTexture = Content.Load<Texture2D>(@"Graphics\Scenes\cidade");
            font = Content.Load<SpriteFont>("Fonts/Arial");
            //texture1 = Content.Load<Texture2D>(@"Graphics\Enemy\_Robo1"); // retirar apos testes.
            //texture2 = Content.Load<Texture2D>(@"Graphics\Enemy\_Robo2"); // retirar apos testes.
            //texture3 = Content.Load<Texture2D>(@"Graphics\Tower\torre-raio"); // retirar apos testes.
            //_textureAnim1 = new Animacao(texture1, new Vector2(150, 150), 32, 32, 2, 90, 3.0f, true); // retirar apos testes.
            //_textureAnim2 = new Animacao(texture2, new Vector2(250, 150), 32, 32, 2, 90, 3.0f, true); // retirar apos testes.
            //_textureAnim3 = new Animacao(texture3, new Vector2(350, 150), 32, 32, 2, 90, 3.0f, true); // retirar apos testes.
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            testEnemy.Update(gameTime, tileMap);

            

            if (Input.WasPressed(0, InputHandler.ButtonType.Back, Keys.Escape))
                GameManager.PushState(OurGame.OptionsMenuState.Value);

            if (Input.WasPressed(0, InputHandler.ButtonType.Start, Keys.Enter))
                GameManager.PushState(OurGame.PausedState.Value); // push our paused state onto the stack

            if (Input.WasPressed(0, InputHandler.ButtonType.X, Keys.X))
            {
                OurGame.soundManager.playSound(1);
            }

            if (Input.WasPressed(0, InputHandler.ButtonType.Y, Keys.Z))
            {
                OurGame.soundManager.playSound(3);
            }
            //_textureAnim1.Update(gameTime); // retirar apos testes.
            //_textureAnim2.Update(gameTime); // retirar apos testes.
            //_textureAnim3.Update(gameTime); // retirar apos testes.
                base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            //_textureAnim1.Draw(OurGame.SpriteBatch); // retirar apos testes.
            //_textureAnim2.Draw(OurGame.SpriteBatch); // retirar apos testes.
            //_textureAnim3.Draw(OurGame.SpriteBatch); // retirar apos testes.

            
            
            OurGame.SpriteBatch.Draw(stageTexture, Vector2.Zero, Color.White);
            testEnemy.Draw(OurGame.SpriteBatch);
            hud.DrawInterface(OurGame.SpriteBatch);
            OurGame.SpriteBatch.DrawString(font, tileMap.WaypointList[6].position.ToString() + tileMap.WaypointList[6].DirectionList[0].ToString(), Vector2.Zero, Color.White);
            base.Draw(gameTime);
        }

        protected override void StateChanged(object sender, EventArgs e)
        {
            base.StateChanged(sender, e);

            if (GameManager.State != this.Value)
            {
                Visible = true;
                Enabled = false;
            }
        }


    }
}
