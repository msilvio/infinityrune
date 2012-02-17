﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Infinity_TD
{
    class Shot : ICollidable
    {
        public Effect Effect { get; set; }

        public Vector2 Position;
        private Enemy targetEnemy;
        public float speed;
        private Texture2D texture;
        private Animacao animation;
        public bool Alive { get; set; }

        private Rectangle boundRect;
        public Rectangle BoundRect
        {
            get
            {
                return new Rectangle((int)Position.X, (int)Position.Y, texture.Width, texture.Height);
            }

            set
            {
                boundRect = value;
            }
        }


        public BoundingSphere BoundCircle { get; set; }
        public void onCollision(Object sender)
        {

        }

        public Shot(Texture2D texture, Vector2 position, Enemy targetEnemy, float speed)
        {
            this.texture = texture;
            this.Position = position;
            this.targetEnemy = targetEnemy;
            this.speed = speed;
            this.animation = new Animacao(texture, this.Position, 16, 16, 2, 90, 1.0f, true);
            Alive = true;
        }

        public virtual void Update(GameTime gameTime)
        {
            Vector2 direction = targetEnemy.Position - Position;
            direction.Normalize();

            Position += direction * speed;
            if (new Rectangle((int)Position.X, (int)Position.Y, 16, 16).Intersects(new Rectangle((int)targetEnemy.Position.X, (int)targetEnemy.Position.Y, 28, 28)))
                this.Alive = false;
            animation.Update(gameTime,Position);
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            animation.Draw(spriteBatch, 0.0f);
        }

    }
}
