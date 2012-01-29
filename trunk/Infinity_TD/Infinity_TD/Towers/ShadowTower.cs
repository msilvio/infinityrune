using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Infinity_TD
{
    class ShadowTower : Tower
    {
        public ShadowTower(Game game, float damage, Vector2 position, float fireRate)
            : base(game, @"dark_flames", damage, position, fireRate, new Effect())
        {

        }
    }
}
