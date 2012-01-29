using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Infinity_TD.Towers
{
    class BlackHoleTower : Tower
    {
        //public BlackHoleTower()
        //{
        //}

        public override void Initialize(Game game, float damage, Vector2 position, float fireRate)
        {
            base.Initialize(game, @"blackhole", @"fireball", damage, position, fireRate, new BlackHoleEffect());
        }

        public override void FireToEnemy(Enemy enemy, Vector2 positionSource, Texture2D texture)
        {
            base.FireToEnemy(enemy, positionSource, texture, 0);
        }
    }
}
