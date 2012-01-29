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
        Texture2D sidebar, scroll, crafting, runebag, border;
        Texture2D[] runes = new Texture2D[10];
        Combinator.Tower currentTower;
        public Rectangle[] rectangles = new Rectangle[10];
        public Combinator combinator = new Combinator();
        public Combinator.Runes[] combinatorRunes = new Combinator.Runes[3];
        public Texture2D[] combinatorRuneText = new Texture2D[3];
        int runeCount = 0;
        
        float positionX = 800;

        public void InitializeInterface(ContentManager content)
        {
            sidebar = content.Load<Texture2D>("Graphics/Stuff/hud_base");
            //scroll = content.Load<Texture2D>("");
            //crafting = content.Load<Texture2D>("");
            //runebag = content.Load<Texture2D>("");
            //border = content.Load<Texture2D>("");
            for (int i = 0; i < 9; i++)
            {
                runes[i] = content.Load<Texture2D>("Graphics/Stuff/Screen/Um");
            }
        }

        public void UpdateInterface(GameTime gameTime, Rectangle mouseRec, MouseState previousState)
        {

            for (int i = 0; i < 10; i++)
            {
                if (mouseRec.Intersects(rectangles[i]))
                {
                    if ((Mouse.GetState().LeftButton == ButtonState.Pressed) && (previousState.LeftButton == ButtonState.Released))
                    {
                        combinatorRunes[runeCount] = RuneManager.RuneList[i];
                        combinatorRuneText[runeCount] = runes[i];
                        runeCount++;

                        if( runeCount == 3)
                        {
                             runeCount = 0;
                             currentTower = (combinator.parseCombination(combinatorRunes[1], combinatorRunes[2], combinatorRunes[3]));

                        }
                    }
                }
            }

        }

        public void DrawInterface(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sidebar, new Vector2(positionX, 0), Color.White);

            for (int i = 0; i < 9; i++)
            {
                rectangles[i] = new Rectangle((int)positionX + 25 + (int)((i % 3) * 60), 50 + (int)((i / 3) * 70), 30, 30);
                spriteBatch.Draw(runes[i], new Vector2(positionX + 25 + (int)((i % 3) * 60), 50 + (int)((i / 3) * 70)), Color.White);
            }

            for (int i = 0; i < runeCount; i++)
            {
                spriteBatch.Draw(combinatorRuneText[i], new Vector2(625 + 70 * i, 260), Color.White);
            }

                 /*spriteBatch.Draw(runebag, new Vector2(positionX, 30), Color.White);
            for (int i = 1; i <= 9; i++)
            {
                spriteBatch.Draw(runes[i], new Vector2((i % 3) * 64, 0), Color.White);
            }
            spriteBatch.Draw(scroll, Vector2.Zero, Color.White);*/
            
        }

    }
}
