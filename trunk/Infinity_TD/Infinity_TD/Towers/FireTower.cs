using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Infinity_TD
{
    class FireTower : Tower
    {

        //public FireTower(Game game, float damage, Vector2 position, float fireRate)
        //    : base(game, @"fireball rune",@"fireball" ,damage, position, fireRate, new Effect())
        //{

        //}

        public override void Initialize(Game game, float damage, Vector2 position, float fireRate)
        {
            base.Initialize(game, @"fireball rune", @"fireball", damage, position, fireRate, new BlackHoleEffect());
        }

        public override void FireToEnemy(Enemy enemy, Vector2 positionSource, Texture2D texture)
        {

            FireToEnemy(enemy, positionSource, texture, 0);
        }

        public override void UpgradeTower()
        {
            this.upgradeCostRune = 0;
            if ((RuneManager.RuneBag[upgradeCostRune] > 0) && (upgradeCount <= 5))
            {
                this.FireRate = FireRate * 0.90f;
                this.Damage = Damage * 5.25f;
                this.rotationSpeed += 0.25f;
                RuneManager.RemoveRune(this.upgradeCostRune, 1);
                upgradeCount++;
                base.UpgradeTower();
            }
        }

    }
}
