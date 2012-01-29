using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Infinity_TD
{
    class Interface
    {
        Texture2D sidebar, scroll, crafting, runebag, border;
        Texture2D[] runes = new Texture2D[9];
        float positionX = 800;

        public void InitializeInterface(ContentManager content)
        {
            sidebar = content.Load<Texture2D>("Graphics/Stuff/hud_base");
            //scroll = content.Load<Texture2D>("");
            //crafting = content.Load<Texture2D>("");
            //runebag = content.Load<Texture2D>("");
            //border = content.Load<Texture2D>("");
        }

        public void UpdateInterface(GameTime gameTime)
        {

        }

        public void DrawInterface(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sidebar, new Vector2(positionX, 0), Color.White);
            /*spriteBatch.Draw(runebag, new Vector2(positionX, 30), Color.White);
            for (int i = 1; i <= 9; i++)
            {
                spriteBatch.Draw(runes[i], new Vector2((i % 3) * 64, 0), Color.White);
            }
            spriteBatch.Draw(scroll, Vector2.Zero, Color.White);*/
            
        }

    }
}
