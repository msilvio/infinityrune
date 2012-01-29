﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infinity_TD
{
    public class Combinator
    {
        public enum Tower { INVALID, FIREBALL, GLACIER, TORNADO, THUNDERSTORM, EARTHQUAKE, CORROSIVE,  } //TODO: ADICIONAR OUTRAS TORRES

        public enum Runes { NONE, FIRE, WATER, AIR, EARTH, LIGHTNING, NATURE, LIGHT, DARKNESS, COSMIC, INFINITY }

        public Recipe[] recipeArray = new Recipe[12];
        
        //INICIALIZA RECIPES
        public void InitializeRecipes()
        {
            recipeArray[1] = new Recipe(Runes.FIRE, Runes.FIRE, Runes.AIR, Tower.FIREBALL);
            recipeArray[2] = new Recipe(Runes.WATER, Runes.WATER, Runes.AIR, Tower.GLACIER);
            recipeArray[3] = new Recipe(Runes.AIR, Runes.AIR, Runes.AIR, Tower.TORNADO);
            //TODO: FAZER OUTROS RECIPES
        }

        //VERIFICA A COMBINAÇÃO DE RUNAS E RETORNA A TORRE EQUIVALENTE A ELAS
        public Tower parseCombination(Runes rune1, Runes rune2, Runes rune3)
        {
            for (int i = 1; i <= 12; i++)
            {
                if (rune1 == recipeArray[i].rune1)
                {
                    if (rune2 == recipeArray[i].rune2)
                    {
                        if (rune3 == recipeArray[i].rune3)
                        {
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
