﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Infinity_TD.Towers
{
    class LightTower : Tower
    {
        //public LightTower(Game game, float damage, Vector2 position, float fireRate)
        //    : base(game, @"blinding_light", @"thunderstorm", damage, position, fireRate, new LightningEffect())
        //{
        //}

        public override void Initialize(Game game, float damage, Vector2 position, float fireRate)
        {
            base.Initialize(game, @"blinding_light", @"thunderstorm", damage, position, fireRate, new LightningEffect());
        }

        public override void FireToEnemy(Enemy enemy, Vector2 positionSource, Texture2D texture)
        {
            FireToEnemy(enemy, positionSource, texture, 3);
        }
    }
}
