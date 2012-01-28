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

        public PlayingState(Game game)
            : base(game)
        {
            game.Services.AddService(typeof(IPlayingState), this);
            rand = new Random();
        }

        public override void Update(GameTime gameTime)
        {
            if (Input.WasPressed(0, InputHandler.ButtonType.Back, Keys.Escape))
                GameManager.PushState(OurGame.OptionsMenuState.Value);

            if (Input.WasPressed(0, InputHandler.ButtonType.Start, Keys.Enter))
                GameManager.PushState(OurGame.PausedState.Value); // push our paused state onto the stack

            if (Input.WasPressed(0, InputHandler.ButtonType.X, Keys.X))
            {
                OurGame.soundManager.playSound(1);
            }

            if (Input.WasPressed(0, InputHandler.ButtonType.X, Keys.Z))
            {
                OurGame.soundManager.playSound(3);
            }

                base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {


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

        protected override void LoadContent()
        {


            base.LoadContent();
        }
    }
}
