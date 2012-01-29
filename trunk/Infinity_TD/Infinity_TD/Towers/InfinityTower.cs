﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Infinity_TD.Towers
{
    class InfinityTower : Tower
    {
         public InfinityTower(Game game, float damage, Vector2 position, float fireRate)
            : base(game, @"infinity", damage, position, fireRate, new Effect())
        {
        }
    }
}
