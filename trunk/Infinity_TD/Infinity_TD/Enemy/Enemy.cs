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
        public Vector2 Position;
        public Vector2 speed;
        Animacao enemyAnimation;
        public float rotation = MathHelper.ToRadians(90f);
        Color color = Color.White;

        private static Random random = new Random();

        private bool alive;
        public bool Alive
        {
            get
            {
                return life > 0;
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
                return new Rectangle((int)Position.X, (int)Position.Y, enemyAnimation.larguraFrame, enemyAnimation.alturaFrame);
            }

            set
            {
                boundRect = value;
            }
        }

        private BoundingSphere boundCircle;
        public BoundingSphere BoundCircle
        {
            get
            {
                return new BoundingSphere(new Vector3(this.Position, 0.0f), enemyAnimation.playerTextura.Width/2);
            }
            set
            {
                boundCircle = value;
            }
        }


        public Enemy(Vector2 position, Texture2D texture)
        {
            this.Position = position;
            speed.X = 1.0f + Enemy.random.Next(0, 3);
            life = 100.0f;
            Alive = true;
            enemyAnimation = new Animacao(texture, position, 32, 32, 2, 90, 1f, true);
        }

        public void onCollision(Object sender)
        {
            Shot shot = (Shot)sender;

            Effect effec = shot.Effect;


            shot.Alive = false;

        }

        public void Update(GameTime gameTime, TileMap tileMap)
        {

            #region UpdateWaypoints
            foreach (Tiles.Waypoint waypoint in tileMap.WaypointList)
            {
                if (waypoint.area.Contains(this.BoundRect))
                {
                    Infinity_TD.Tiles.Waypoint.Directions directions = waypoint.getDirection();

                    switch (directions)
                    {
                        case Tiles.Waypoint.Directions.UP:
                            if (speed.X != 0)
                            {
                                speed.Y = 0 - Math.Abs(speed.X);
                                speed.X = 0;
                                rotation = MathHelper.ToRadians(0f);

                            }
                            break;
                        case Tiles.Waypoint.Directions.DOWN:
                            if (speed.X != 0)
                            {
                                speed.Y = 0 + Math.Abs(speed.X);
                                speed.X = 0;
                                rotation = MathHelper.ToRadians(180f);

                            }
                            break;
                        case Tiles.Waypoint.Directions.LEFT:
                            if (speed.Y != 0)
                            {
                                speed.X = 0 - Math.Abs(speed.Y);
                                speed.Y = 0;
                                rotation = MathHelper.ToRadians(270f);

                            }
                            break;
                        case Tiles.Waypoint.Directions.RIGHT:
                            if (speed.Y != 0)
                            {
                                speed.X = 0 + Math.Abs(speed.Y);
                                speed.Y = 0;
                                rotation = MathHelper.ToRadians(90f);

                            }
                            break;
                    }
                }
            }

            #endregion

            //UPDATE NEXUS
            foreach (Nexus nexus in tileMap.NexusList)
            {
                if (nexus.area.Contains(BoundRect))
                {
                    GameManager.vidas--;
                    this.life = 0.0f;
                }
            }

            if (life <= 0) this.alive = false;

            enemyAnimation.Update(gameTime, Position);

            Position += speed;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            enemyAnimation.Draw(spriteBatch, rotation);
        }

    }
}
