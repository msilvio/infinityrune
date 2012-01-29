using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Infinity_TD
{
    class EarthTower : Tower
    {
        //public EarthTower(Game game, float damage, Vector2 position, float fireRate)
        //    : base(game, @"earthquake rune", @"fireball", damage, position, fireRate, new Effect())
        //{
        //}

        public override void Initialize(Game game, float damage, Vector2 position, float fireRate)
        {
            base.Initialize(game, @"earthquake rune", @"fireball", damage, position, fireRate, new BlackHoleEffect());
        }

        public override void FireToEnemy(Enemy enemy, Vector2 positionSource, Texture2D texture)
        {
            FireToEnemy(enemy, positionSource, texture, 0);
        }
    }
}
