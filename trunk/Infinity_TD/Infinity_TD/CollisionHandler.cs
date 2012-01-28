using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Infinity_TD
{
    class CollisionHandler
    {
        List<ICollidable> collidableObjects = new List<ICollidable>();

        public CollisionHandler()
        {

        }

        public void AddCollidable(ICollidable colladable)
        {
            this.collidableObjects.Add(colladable);
        }

        public void RemoveCollidable(ICollidable colladable)
        {
            this.collidableObjects.Remove(colladable);
        }

        public void HandleCollision(Shot shot)
        {

            foreach (ICollidable collidable in this.collidableObjects)
            {
                if (collidable.BoundRect.Intersects(shot.BoundRect))
                {
                    collidable.onCollision(shot.Effect);
                    shot.onCollision(collidable);
                }
            }
        }

    }

    interface ICollidable
    {
        Rectangle BoundRect { get; set; }

        void onCollision(Object sender);
    }
}
