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
    public static class RuneManager
    {
        public static int[] RuneBag = new int[10];
        public static bool[] CheckRecipe = new bool[12];
        public static String[] RecipeBag = new String[12];
        public static Combinator.Runes[] RuneList = new Combinator.Runes[10];

        public static void RemoveRune(int i, int quantid)
        {
            RuneBag[i] -= quantid;
        }

        public static void InsertRune(int i, int quantid)
        {
            RuneBag[i] += quantid;
        }

        public static void RecipeLoad()
        {

            #region RecipeArrays
            RecipeBag[0] = "Fireball Rune \nFire + Fire + Air";
            RecipeBag[1] = "Glacier Rune \nWater + Water + Air";
            RecipeBag[2] = "Tornado Rune \nAir + Air + Air";
            RecipeBag[3] = "Thunderstorm Rune \nWater + Air + Thunder";
            RecipeBag[4] = "Earthquake Rune \nEarth + Earth + Fire";
            RecipeBag[5] = "Corrosive Rune \nNature + Nature + Earth";
            RecipeBag[6] = "Magmatic Rune \nFire + Earth + Fire";
            RecipeBag[7] = "Glyph of Blinding Light \nLight + Light + Thunder";
            RecipeBag[8] = "Glyph of Dark Flames \nDark + Fire + Dark";
            RecipeBag[9] = "Glyph of the Sun \nCosmic + Light + Fire";
            RecipeBag[10] = "Glyph of Black Hole \nCosmic + Dark + Dark";
            RecipeBag[11] = "Essence of Infinity \nInfinity x 3";

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

            #region RuneArrays

            RuneList[0] = Combinator.Runes.FIRE;
            RuneList[1] = Combinator.Runes.WATER;
            RuneList[2] = Combinator.Runes.AIR;
            RuneList[3] = Combinator.Runes.EARTH;
            RuneList[4] = Combinator.Runes.LIGHTNING;
            RuneList[5] = Combinator.Runes.NATURE;
            RuneList[6] = Combinator.Runes.LIGHT;
            RuneList[7] = Combinator.Runes.DARKNESS;
            RuneList[8] = Combinator.Runes.COSMIC;
            RuneList[9] = Combinator.Runes.INFINITY;

            #endregion

        }

        public static void OpenRecipe(int i)
        {

            CheckRecipe[i] = true;

        }
    }
}
