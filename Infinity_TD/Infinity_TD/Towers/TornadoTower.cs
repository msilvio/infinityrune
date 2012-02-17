using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Infinity_TD.Towers
{
    class TornadoTower : Tower
    {
        //public TornadoTower(Game game, float damage, Vector2 position, float fireRate)
        //: base(game, @"tornado rune", @"thunderstorm", damage, position, fireRate, new Effect()) { }

        public override void Initialize(Game game, float damage, Vector2 position, float fireRate)
        {
            base.Initialize(game, @"tornado rune", @"thunderstorm", damage, position, fireRate, new BlackHoleEffect());
        }

        public override void Update(GameTime gameTime)
        {
            animation.Update(gameTime, Position);

            towerSpawn += (float)gameTime.ElapsedGameTime.TotalSeconds;
            
        }

        public override void FireToEnemy(Enemy enemy, Vector2 positionSource, Texture2D texture)
        {
            FireToEnemy(enemy, positionSource, texture, 0);
        }
    }


}
