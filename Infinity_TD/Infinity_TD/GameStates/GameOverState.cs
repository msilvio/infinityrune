using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Infinity_TD_Library;

namespace Infinity_TD
{
    public sealed class GameOverState : BaseGameState, IGameOverState
    {
        private Texture2D texture;
        SpriteFont font;

        protected override void LoadContent()
        {
            texture = Content.Load<Texture2D>(@"Graphics\Stuff\MenuFim");
            font = Content.Load<SpriteFont>(@"Fonts\menu_font");
            OurGame.soundManager.soundLoad("Intro");
            OurGame.soundManager.playSong();
            base.LoadContent();
        }

        public GameOverState(Game game)
            : base(game)
        {
            game.Services.AddService(typeof(IGameOverState), this);
        }

        public override void Update(GameTime gameTime)
        {
            if (Input.WasPressed(0, InputHandler.ButtonType.Back, Keys.Escape))
            {
                //GameManager.PushState(OurGame.StartMenuState.Value);
                OurGame.Exit();
            }
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            Vector2 pos = new Vector2(TitleSafeArea.Left, TitleSafeArea.Top);
            OurGame.SpriteBatch.Draw(texture, pos, Color.White);
            OurGame.SpriteBatch.DrawString(font, "GAME OVER", new Vector2(702, 382), Color.Black);
            OurGame.SpriteBatch.DrawString(font, "GAME OVER", new Vector2(700, 380), Color.Yellow);
            OurGame.SpriteBatch.DrawString(font, "Press Escape to Exit", new Vector2(652, 602), Color.Black);
            OurGame.SpriteBatch.DrawString(font, "Press Escape to Exit", new Vector2(650, 600), Color.Yellow);
            base.Draw(gameTime);
        }
    }
}
