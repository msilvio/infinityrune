using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Infinity_TD
{
    public class RuneManager
    {
        public int[] RuneBag = new int[10];
        public bool[] CheckRecipe = new bool[12];
        public String[] RecipeBag = new String[12];
 
        public void RemoveRune(int i, int quantid)
        {
            RuneBag[i] -= quantid;
        }

        public void InsertRune(int i, int quantid)
        {
            RuneBag[i] += quantid;
        }

        public void RecipeLoad()
        {

            #region RecipeArrays
            RecipeBag[0] = "Fire + Fire + Air = Fireball Rune";
            RecipeBag[1] = "Water + Water + Air = Glacier Rune";
            RecipeBag[2] = "Air + Air + Air = Tornado Rune";
            RecipeBag[3] = " Water + Air + Thunder =  Thunderstorm Rune";
            RecipeBag[4] = "Earth + Earth + Fire = Earthquake Rune";
            RecipeBag[5] = "Nature + Nature + Earth = Corrisive Rune";
            RecipeBag[6] = "Fire + Earth + Fire = Magmatic Rune";
            RecipeBag[7] = "Light + Light + Thunder = Glyph of Blinding Light";
            RecipeBag[8] = "Darkness + Fire + Darkness = Glyph of Dark Flames";
            RecipeBag[9] = "Cosmic + Light + Fire = Major Glyph of the Sun";
            RecipeBag[10] = "Cosmic + Darkness + Darkness = Major Glyph of the Black Hole";
            RecipeBag[11] = "Infinity + Infinity + Infinity = Essence of Infinity";

            CheckRecipe[0] = true;
            CheckRecipe[1] = false;
            CheckRecipe[2] = false;
            CheckRecipe[3] = false;
            CheckRecipe[4] = false;
            CheckRecipe[5] = false;
            CheckRecipe[6] = false;
            CheckRecipe[7] = false;
            CheckRecipe[8] = false;
            CheckRecipe[9] = false;
            CheckRecipe[10] = false;
            CheckRecipe[11] = false;
            #endregion

        }

        public void OpenRecipe(int i)
        {

            CheckRecipe[i] = true;

        }


    }
}
