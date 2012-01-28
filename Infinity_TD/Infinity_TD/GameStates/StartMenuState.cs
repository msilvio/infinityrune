using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Infinity_TD_Library;

namespace Infinity_TD
{
    public sealed class StartMenuState : BaseGameState, IStartMenuState
    {
        private Texture2D texture, arrowTexture;

        SpriteFont font;
        private string[] strings = new string[3];
        int menuStartY = 300;
        int arrowSelectionIndex;
        Vector2 arrowPosition;

        public StartMenuState(Game game)
            : base(game)
        {
            game.Services.AddService(typeof(IStartMenuState), this);
        }

        public override void Update(GameTime gameTime)
        {
            if (Input.WasPressed(0, InputHandler.ButtonType.A, Keys.Enter))
            {
                switch (arrowSelectionIndex)
                {
                    case 0:
                        if (GameManager.ContainsState(OurGame.PlayingState.Value))
                        {
                            GameManager.PopState(); //got here from our playing state, just pop myself off the stack
                            //OurGame.soundManager.stopSong();
                        }
                        else
                            GameManager.ChangeState(OurGame.PlayingState.Value); 
                        break;
                    case 1:
                        
                        break;
                    case 2:
                        OurGame.Exit();
                        break;
                }
            }

            if (Input.WasPressed(0, InputHandler.ButtonType.A, Keys.Down))
            {
                if (arrowSelectionIndex != strings.Length - 1)
                    arrowSelectionIndex++;
                else arrowSelectionIndex = 0;
            }
            if (Input.WasPressed(0, InputHandler.ButtonType.B, Keys.Up))
            {
                if (arrowSelectionIndex != 0)
                    arrowSelectionIndex--;
                else arrowSelectionIndex = strings.Length - 1;
            }
            arrowPosition = new Vector2(200, menuStartY + (32 * arrowSelectionIndex));

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            for (int i = 0; i < strings.Length; i++)
            {
                OurGame.SpriteBatch.DrawString(font, strings[i], new Vector2(240, menuStartY + (i * 32)), Color.White);
            }

            OurGame.SpriteBatch.Draw(arrowTexture, arrowPosition, Color.White);

            base.Draw(gameTime);
        }

        protected override void StateChanged(object sender, EventArgs e)
        {
            base.StateChanged(sender, e);

            if (GameManager.State != this.Value)
                Visible = true;
        }

        protected override void LoadContent()
        {
            texture = Content.Load<Texture2D>(@"Graphics\Stuff\startMenu");
            OurGame.soundManager.soundLoad("Menu");
            OurGame.soundManager.playSong();

            font = Content.Load<SpriteFont>(@"Fonts\Arial");
            arrowTexture = Content.Load<Texture2D>(@"Graphics\Stuff\arrow");

            //START
            strings[0] = "INICIAR JOGO";

            //OPTIONS
            strings[1] = "INSTRUCOES";

            //EXIT
            strings[2] = "SAIR";

            base.LoadContent();
        }
    }
}
