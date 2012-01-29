using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

namespace Infinity_TD
{
    class Interface
    {
        Texture2D sidebar, border;
        Texture2D[] runes = new Texture2D[10];
        Texture2D[] recipes = new Texture2D[12];
        SpriteFont interfaceFont;
        string currentDrawString;
        Combinator.Tower currentTower;
        public Rectangle[] runeRectangles = new Rectangle[10];
        public Rectangle[] recipeRectangles = new Rectangle[12];
        public Combinator combinator = new Combinator();
        public Combinator.Runes[] combinatorRunes = new Combinator.Runes[3];
        public Texture2D[] combinatorRuneText = new Texture2D[3];
        int runeCount = 0;
        
        float positionX = 800;

        public void InitializeInterface(ContentManager content)
        {
            combinator.InitializeRecipes();
            sidebar = content.Load<Texture2D>("Graphics/Stuff/hud_base");
            interfaceFont = content.Load<SpriteFont>("Fonts/hud_font");
            //border = content.Load<Texture2D>("");
            for (int i = 0; i < 9; i++)
            {
                runes[i] = content.Load<Texture2D>("Graphics/Stuff/Screen/Um");
            }

            for (int i = 0; i < 9; i++)
            {
                runeRectangles[i] = new Rectangle((int)positionX + 35 + (int)((i % 3) * 60), 50 + (int)((i / 3) * 70), 30, 30);
            }

            for (int i = 0; i < 12; i++)
            {
                recipeRectangles[i] = new Rectangle((int)positionX + 35 + (int)((i % 3) * 60), 420 + (int)((i / 3) * 70), 30, 30);
            }

            for (int i = 0; i < 12; i++)
            {
                recipes[i] = content.Load<Texture2D>("Graphics/Stuff/Screen/Um");

            }

        }

        public void UpdateInterface(GameTime gameTime, Rectangle mouseRec, MouseState previousState)
        {
            #region UpdateMainRunes
            for (int i = 0; i < 10; i++)
            {
                if (mouseRec.Intersects(runeRectangles[i]))
                {
                    if ((Mouse.GetState().LeftButton == ButtonState.Pressed) && (previousState.LeftButton == ButtonState.Released))
                    {
                        combinatorRunes[runeCount] = RuneManager.RuneList[i];
                        Console.WriteLine(combinatorRunes[runeCount].ToString());//
                        combinatorRuneText[runeCount] = runes[i];
                        runeCount++;

                        if( runeCount == 3)
                        {
                             runeCount = 0;
                             currentTower = (combinator.parseCombination(combinatorRunes[0], combinatorRunes[1], combinatorRunes[2]));

                        }
                    }
                }
            }
            #endregion

            #region UpdateRecipes

            for (int i = 0; i < 12; i++)
            {
                if ((RuneManager.CheckRecipe[i] == true) && (mouseRec.Intersects(recipeRectangles[i])))
                {
                    currentDrawString = RuneManager.RecipeBag[i];
                    break;
                }

                currentDrawString = null;
            }

            #endregion

        }

        public void DrawInterface(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sidebar, new Vector2(positionX, 0), Color.White);

            for (int i = 0; i < 9; i++)
            {
                spriteBatch.Draw(runes[i], new Vector2(positionX + 35 + (int)((i % 3) * 60), 50 + (int)((i / 3) * 70)), Color.White);
            }

            for (int i = 0; i < runeCount; i++)
            {
                spriteBatch.Draw(combinatorRuneText[i], new Vector2(830 + 64 * i, 300), Color.White);
            }

            for (int i = 0; i < 12; i++)
            {
                if (RuneManager.CheckRecipe[i] == true)
                {
                    spriteBatch.Draw(recipes[i], new Vector2((int)positionX + 35 + (int)((i % 3) * 60), 420 + (int)((i / 3) * 70)), Color.White);
                }
            }

            if (currentDrawString != null)
            {
                spriteBatch.DrawString(interfaceFont, currentDrawString, new Vector2(822, 687), Color.Black);
                spriteBatch.DrawString(interfaceFont, currentDrawString, new Vector2(820, 685), Color.Yellow);

            }
            
        }

    }
}
