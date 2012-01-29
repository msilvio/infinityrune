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
        private List<Enemy> enemies = new List<Enemy>();

        public EnemyManager()
        {

        }

        public void Update(GameTime gameTime)
        {
            IEnumerator<Enemy> enumerator = enemies.GetEnumerator();
            using (enumerator)
            {
                while (enumerator.MoveNext())
                {
                    if (!enumerator.Current.Alive)
                        this.enemies.Remove(enumerator.Current);
                   // else
                        //enumerator.Current.Update(gameTime);

                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Enemy enemy in enemies)
            {
                enemy.Draw(spriteBatch);
            }
        }
    }
}
