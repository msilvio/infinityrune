using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Infinity_TD
{
    class LightningTower : Tower
    {
        public LightningTower(Game game, float damage, Vector2 position, float fireRate)
            : base(game, @"thunderstorm rune", damage, position, fireRate, new Effect())
        { 
        
        }
    }
}
