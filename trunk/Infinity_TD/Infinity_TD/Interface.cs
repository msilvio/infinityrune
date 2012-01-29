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
        KeyboardState previousKeyboard;
        public Texture2D altMouseTex;
        SpriteFont interfaceFont;
        string currentDrawString;
        public Combinator.Tower currentTower;
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
                recipes[i] = content.Load<Texture2D>("Graphics/Tower/torre-raio");

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
                        combinatorRuneText[runeCount] = runes[i];
                        runeCount++;

                        if( runeCount == 3)
                        {
                             runeCount = 0;
                             currentTower = (combinator.parseCombination(combinatorRunes[0], combinatorRunes[1], combinatorRunes[2]));
                             if (currentTower != Combinator.Tower.INVALID) altMouseTex = recipes[i];

                        }
                    }
                }
            }

            #region KeyboardInput

            if ((Keyboard.GetState().IsKeyDown(Keys.Q)) && (previousKeyboard.IsKeyUp(Keys.Q)))
            {
                combinatorRunes[runeCount] = RuneManager.RuneList[0];
                combinatorRuneText[runeCount] = runes[0];
                runeCount++;

                if (runeCount == 3)
                {
                    runeCount = 0;
                    currentTower = (combinator.parseCombination(combinatorRunes[0], combinatorRunes[1], combinatorRunes[2]));
                    if (currentTower != Combinator.Tower.INVALID) altMouseTex = recipes[0];

                }


            }

            if ((Keyboard.GetState().IsKeyDown(Keys.W)) && (previousKeyboard.IsKeyUp(Keys.W)))
            {
                combinatorRunes[runeCount] = RuneManager.RuneList[1];
                combinatorRuneText[runeCount] = runes[1];
                runeCount++;

                if (runeCount == 3)
                {
                    runeCount = 0;
                    currentTower = (combinator.parseCombination(combinatorRunes[0], combinatorRunes[1], combinatorRunes[2]));
                    if (currentTower != Combinator.Tower.INVALID) altMouseTex = recipes[1];

                }


            }

            if ((Keyboard.GetState().IsKeyDown(Keys.E)) && (previousKeyboard.IsKeyUp(Keys.E)))
            {
                combinatorRunes[runeCount] = RuneManager.RuneList[2];
                combinatorRuneText[runeCount] = runes[2];
                runeCount++;

                if (runeCount == 3)
                {
                    runeCount = 0;
                    currentTower = (combinator.parseCombination(combinatorRunes[0], combinatorRunes[1], combinatorRunes[2]));
                    if (currentTower != Combinator.Tower.INVALID) altMouseTex = recipes[2];

                }


            }


            if ((Keyboard.GetState().IsKeyDown(Keys.A)) && (previousKeyboard.IsKeyUp(Keys.A)))
            {
                combinatorRunes[runeCount] = RuneManager.RuneList[3];
                combinatorRuneText[runeCount] = runes[3];
                runeCount++;

                if (runeCount == 3)
                {
                    runeCount = 0;
                    currentTower = (combinator.parseCombination(combinatorRunes[0], combinatorRunes[1], combinatorRunes[2]));
                    if (currentTower != Combinator.Tower.INVALID) altMouseTex = recipes[3];

                }


            }


            if ((Keyboard.GetState().IsKeyDown(Keys.S)) && (previousKeyboard.IsKeyUp(Keys.S)))
            {
                combinatorRunes[runeCount] = RuneManager.RuneList[4];
                combinatorRuneText[runeCount] = runes[4];
                runeCount++;

                if (runeCount == 3)
                {
                    runeCount = 0;
                    currentTower = (combinator.parseCombination(combinatorRunes[0], combinatorRunes[1], combinatorRunes[2]));
                    if (currentTower != Combinator.Tower.INVALID) altMouseTex = recipes[4];

                }


            }


            if ((Keyboard.GetState().IsKeyDown(Keys.D)) && (previousKeyboard.IsKeyUp(Keys.D)))
            {
                combinatorRunes[runeCount] = RuneManager.RuneList[5];
                combinatorRuneText[runeCount] = runes[5];
                runeCount++;

                if (runeCount == 3)
                {
                    runeCount = 0;
                    currentTower = (combinator.parseCombination(combinatorRunes[0], combinatorRunes[1], combinatorRunes[2]));
                    if (currentTower != Combinator.Tower.INVALID) altMouseTex = recipes[5];

                }


            }


            if ((Keyboard.GetState().IsKeyDown(Keys.Z)) && (previousKeyboard.IsKeyUp(Keys.Z)))
            {
                combinatorRunes[runeCount] = RuneManager.RuneList[6];
                combinatorRuneText[runeCount] = runes[6];
                runeCount++;

                if (runeCount == 3)
                {
                    runeCount = 0;
                    currentTower = (combinator.parseCombination(combinatorRunes[0], combinatorRunes[1], combinatorRunes[2]));
                    if (currentTower != Combinator.Tower.INVALID) altMouseTex = recipes[6];

                }


            }


            if ((Keyboard.GetState().IsKeyDown(Keys.X)) && (previousKeyboard.IsKeyUp(Keys.X)))
            {
                combinatorRunes[runeCount] = RuneManager.RuneList[7];
                combinatorRuneText[runeCount] = runes[7];
                runeCount++;

                if (runeCount == 3)
                {
                    runeCount = 0;
                    currentTower = (combinator.parseCombination(combinatorRunes[0], combinatorRunes[1], combinatorRunes[2]));
                    if (currentTower != Combinator.Tower.INVALID) altMouseTex = recipes[7];

                }


            }


            if ((Keyboard.GetState().IsKeyDown(Keys.C)) && (previousKeyboard.IsKeyUp(Keys.C)))
            {
                combinatorRunes[runeCount] = RuneManager.RuneList[8];
                combinatorRuneText[runeCount] = runes[8];
                runeCount++;

                if (runeCount == 3)
                {
                    runeCount = 0;
                    currentTower = (combinator.parseCombination(combinatorRunes[0], combinatorRunes[1], combinatorRunes[2]));
                    if (currentTower != Combinator.Tower.INVALID) altMouseTex = recipes[8];

                }


            }

            #endregion

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

            previousKeyboard = Keyboard.GetState();
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
                    spriteBatch.Draw(recipes[i], new Rectangle((int)positionX + 35 + (int)((i % 3) * 60), 420 + (int)((i / 3) * 70), 32, 32), new Rectangle(0,0,32,32), Color.White);
                }
            }

            if (currentDrawString != null)
            {
                spriteBatch.DrawString(interfaceFont, currentDrawString, new Vector2(822, 687), Color.Black);
                spriteBatch.DrawString(interfaceFont, currentDrawString, new Vector2(820, 685), Color.Yellow);

            }

            if (altMouseTex != null)
            {
                spriteBatch.Draw(altMouseTex, new Rectangle(Mouse.GetState().X, Mouse.GetState().Y,32,32), new Rectangle(0, 0, 32, 32), Color.White);
            }
            
        }

    }
}
