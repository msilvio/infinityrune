using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Infinity_TD
{
    class Tower : ICollidable
    {
        private int range = 200;
        public Vector2 Position;
        Animacao animation;
        float towerSpawn = 0.0f;

        public List<Shot> Shots
        {
            get;
            private set;
        }

        private float Damage
        {
            get;
            set;
        }

        public float FireRate
        {
            get;
            set;
        }


        private Rectangle boundRect;
        public Rectangle BoundRect
        {
            get
            {
                return new Rectangle((int)Position.X, (int)Position.Y, animation.larguraFrame, animation.alturaFrame);
            }

            set
            {
                boundRect = value;
            }
        }

        public BoundingSphere boundCircle;
        public BoundingSphere BoundCircle
        {
            get
            {
                return new BoundingSphere(new Vector3(this.Position, 0.0f), range);
            }
            set
            {
                boundCircle = value;
            }
        }

        public static T getTower<T>(Texture2D _textura, float _dmg, Vector2 _pos, float _fireRate) where T : Tower
        {
            return (T)Activator.CreateInstance(typeof(T), _textura, _dmg, _pos, _fireRate);
        }

        public Tower(Texture2D texture, float _dmg, Vector2 position, float _fireRate)
        {
            Damage = _dmg;
            this.FireRate = _fireRate;
            this.Position = position;

            this.animation = new Animacao(texture, this.Position, 32, 32, 2, 90, 1.0f, true);
            Shots = new List<Shot>();
        }

        public void onCollision(Object sender)
        {

        }

        public virtual void FireToEnemy(Enemy enemy, Vector2 positionSource, Texture2D texture)
        {
            if (towerSpawn > FireRate)
            {
                Shot shot = new Shot(texture, positionSource, enemy, 5.0f);
                Shots.Add(shot);
                towerSpawn -= FireRate;
            }
            // return shot;
        }

        public virtual void Update(GameTime gameTime)
        {
            this.animation.Update(gameTime, Position);

            towerSpawn += (float)gameTime.ElapsedGameTime.TotalSeconds;

            for (int i = 0; i < Shots.Count; ++i)
            {
                Shot shot = Shots[i];
                if (!shot.Alive)
                {
                    Shots.RemoveAt(i);
                }

            }

            foreach (Shot shot in Shots)
            {
                shot.Update(gameTime);
            }
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            this.animation.Draw(spriteBatch, MathHelper.ToRadians(0.0f));

            foreach (Shot shot in Shots)
            {
                shot.Draw(spriteBatch);
            }
        }
    }
}
