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
    public sealed class PausedState : BaseGameState, IPausedState
    {
        SpriteFont font;
        RuneManager runeManager;
        String coisa;
        int i = 0;

        public PausedState(Game game)
            : base(game)
        {
            game.Services.AddService(typeof(IPausedState), this);

        }

        protected override void LoadContent()
        {
            font = Content.Load<SpriteFont>(@"Fonts\Arial");
            runeManager = new RuneManager();
            runeManager.RecipeLoad();

            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            if (Input.WasPressed(0, InputHandler.ButtonType.Start, Keys.Enter))
            {
                GameManager.PopState(); //I am no longer paused ... 
            }
            
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            OurGame.SpriteBatch.DrawString(font, "PAUSED", new Vector2(50, 20), Color.Yellow);

            for (i = 0; i < runeManager.CheckRecipe.Length; i++)
            {
                if (runeManager.CheckRecipe[i] == true)
                {
                    OurGame.SpriteBatch.DrawString(font, runeManager.RecipeBag[i], new Vector2(100, 40 + i * 10), Color.Yellow);
                }
            }
            base.Draw(gameTime);
        }


    }
}
