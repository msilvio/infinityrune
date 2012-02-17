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
        //public LightningTower(Game game, float damage, Vector2 position, float fireRate)
        //    : base(game, @"thunderstorm rune", @"thunderstorm", damage, position, fireRate, new Effect())
        //{ 

        //}

        public override void Initialize(Game game, float damage, Vector2 position, float fireRate)
        {
            base.Initialize(game, @"thunderstorm rune", @"thunderstorm", damage, position, fireRate, new BlackHoleEffect());
        }

        public override void FireToEnemy(Enemy enemy, Vector2 positionSource, Texture2D texture)
        {
            FireToEnemy(enemy, positionSource, texture, 3);
        }

        public override void UpgradeTower()
        {
            this.upgradeCostRune = 4;
            if ((RuneManager.RuneBag[upgradeCostRune] > 0) && (upgradeCount <= 5))
            {
                this.FireRate = FireRate * 0.85f;
                this.Damage += 100.0f;
                this.rotationSpeed += 0.25f;
                RuneManager.RemoveRune(this.upgradeCostRune, 1);
                upgradeCount++;
                this.effect.Damage = this.Damage;
                base.UpgradeTower();
            }
        }
    }
}
