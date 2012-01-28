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
    public sealed class OptionsMenuState : BaseGameState, IOptionsMenuState
    {
        Texture2D texture;

        protected override void LoadContent()
        {
            texture = Content.Load<Texture2D>(@"Graphics\Stuff\optionsMenu");

            base.LoadContent();
        }

        public OptionsMenuState(Game game)
            : base(game)
        {
            game.Services.AddService(typeof(IOptionsMenuState), this);
        }

        public override void Update(GameTime gameTime)
        {
            if ((Input.WasPressed(0, InputHandler.ButtonType.Back, Keys.Escape)) ||
                (Input.WasPressed(0, InputHandler.ButtonType.Start, Keys.Enter)))
                GameManager.PopState();

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            Vector2 pos = new Vector2(TitleSafeArea.Left, TitleSafeArea.Top);
            OurGame.SpriteBatch.Draw(texture, pos, Color.White);

            base.Draw(gameTime);
        }

    }
}
