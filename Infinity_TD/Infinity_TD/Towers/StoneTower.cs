﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Infinity_TD
{
    class StoneTower : Tower
    {
        public StoneTower(Game game, float damage, Vector2 position, float fireRate)
            : base(game, @"torre-raio", damage, position, fireRate)
        {
        }
    }
}