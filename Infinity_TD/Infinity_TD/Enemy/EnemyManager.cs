using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Infinity_TD
{
    class EnemyManager
    {
        public List<Enemy> Enemies { get; set; }

        private int drops;
        public int Drops
        {
            get
            {
                int tempDrops = drops;
                drops = 0;
                return tempDrops;
            }

            private set
            {
                drops = value;
            }
        }

        public EnemyManager()
        {
            Enemies = new List<Enemy>();
        }

        public void Add(Enemy enemy)
        {
            Enemies.Add(enemy);
        }

        public List<Enemy> Collide(ICollidable collidable)
        {

            List<Enemy> collideEnemies = new List<Enemy>(); ;
            foreach (Enemy enemy in Enemies)
            {
                if (enemy.BoundCircle.Intersects(collidable.BoundCircle))
                {
                    collideEnemies.Add(enemy);
                }
            }

            if (collideEnemies.Count == 0) return null;

            return collideEnemies;
        }

        public void Update(GameTime gameTime, TileMap tileMap)
        {

            for (int i = 0; i < Enemies.Count; ++i)
            {
                Enemy enemy = Enemies[i];
                if (!enemy.Alive)
                {
                    this.Enemies.Remove(enemy);
                    drops++;
                }
                else
                    enemy.Update(gameTime, tileMap);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Enemy enemy in Enemies)
            {
                enemy.Draw(spriteBatch);
            }
        }
    }
}
