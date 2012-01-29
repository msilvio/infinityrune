using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Infinity_TD
{
    class Enemy : ICollidable
    {
        float life;
        Vector2 position;
        public Vector2 speed;
        Animacao enemyAnimation;
        Texture2D enemyTexture;
        float rotation = MathHelper.ToRadians(90f);
        Color color = Color.White;

        private bool alive;
        public bool Alive
        {
            get
            {
                return life < 0;
            }

            private set
            {
                alive = value;
            }
        }

        private Rectangle boundRect;
        public Rectangle BoundRect
        {
            get
            {
                return new Rectangle((int)position.X, (int)position.Y, enemyTexture.Width, enemyTexture.Height);
            }

            set
            {
                boundRect = value;
            }
        }

        public Enemy(Vector2 position, Texture2D texture)
        {
            this.position = position;
            this.enemyTexture = texture;
            life = 100.0f;
            alive = true;
            enemyAnimation = new Animacao(enemyTexture, position, 32, 32, 2, 90, 1f, true);
        }

        public void onCollision(Object sender)
        {

        }

        public void Update(GameTime gameTime)
        {
            enemyAnimation.Update(gameTime, position);

            position += speed;


        }

        public void Draw(SpriteBatch spriteBatch)
        {
            enemyAnimation.Draw(spriteBatch, rotation);
        }

    }
}
