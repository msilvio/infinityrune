﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infinity_TD
{
    public class Combinator
    {
        public enum Tower { INVALID, FIREBALL, GLACIER, TORNADO, THUNDERSTORM, EARTHQUAKE, CORROSIVE, MAGMATIC, BLINDING, DARKFLAMES, SOLAR, BLACKHOLE, INFINITY } //TODO: ADICIONAR OUTRAS TORRES

        public enum Runes { NONE, FIRE, WATER, AIR, EARTH, LIGHTNING, NATURE, LIGHT, DARKNESS, COSMIC, INFINITY }

        public Recipe[] recipeArray = new Recipe[12];
        
        //INICIALIZA RECIPES
        public void InitializeRecipes()
        {
            RuneManager.RecipeLoad();

            recipeArray[0] = new Recipe(Runes.FIRE, Runes.FIRE, Runes.AIR, Tower.FIREBALL);
            recipeArray[1] = new Recipe(Runes.WATER, Runes.WATER, Runes.AIR, Tower.GLACIER);
            recipeArray[2] = new Recipe(Runes.AIR, Runes.AIR, Runes.AIR, Tower.TORNADO);
            recipeArray[3] = new Recipe(Runes.WATER, Runes.AIR, Runes.LIGHTNING, Tower.THUNDERSTORM);
            recipeArray[4] = new Recipe(Runes.EARTH, Runes.EARTH, Runes.FIRE, Tower.EARTHQUAKE);
            recipeArray[5] = new Recipe(Runes.NATURE, Runes.NATURE, Runes.EARTH, Tower.CORROSIVE);
            recipeArray[6] = new Recipe(Runes.FIRE, Runes.EARTH, Runes.FIRE, Tower.MAGMATIC);
            recipeArray[7] = new Recipe(Runes.LIGHT, Runes.LIGHT, Runes.LIGHTNING, Tower.BLINDING);
            recipeArray[8] = new Recipe(Runes.DARKNESS, Runes.FIRE, Runes.DARKNESS, Tower.DARKFLAMES);
            recipeArray[9] = new Recipe(Runes.COSMIC, Runes.LIGHT, Runes.FIRE, Tower.SOLAR);
            recipeArray[10] = new Recipe(Runes.COSMIC, Runes.DARKNESS, Runes.DARKNESS, Tower.BLACKHOLE);
            recipeArray[11] = new Recipe(Runes.INFINITY, Runes.INFINITY, Runes.INFINITY, Tower.INFINITY);

        }

        //VERIFICA A COMBINAÇÃO DE RUNAS E RETORNA A TORRE EQUIVALENTE A ELAS
        public Tower parseCombination(Runes rune1, Runes rune2, Runes rune3)
        {
            
            for (int i = 0; i < 12; i++)
            {
                if (rune1 == recipeArray[i].rune1)
                {
                    if (rune2 == recipeArray[i].rune2)
                    {
                        if (rune3 == recipeArray[i].rune3)
                        {
                            Console.WriteLine("1- " + rune1.ToString() + "2- " + rune2.ToString() + "3- " + rune3.ToString() + "  " + recipeArray[i].towerType.ToString());
                            return recipeArray[i].towerType;
                        }
                    }
                }
            }

            return Tower.INVALID;
        }

    }

  public  class Recipe
    {
        public Combinator.Runes rune1, rune2, rune3;
        public Combinator.Tower towerType;

        public Recipe(Combinator.Runes _rune1, Combinator.Runes _rune2, Combinator.Runes _rune3, Combinator.Tower _tower)
        {
            rune1 = _rune1;
            rune2 = _rune2;
            rune3 = _rune3;
            towerType = _tower;
        }

    }

}
