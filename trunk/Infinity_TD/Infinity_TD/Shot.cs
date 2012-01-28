using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Infinity_TD
{
    class Shot : ICollidable
    {
        public Effect Effect { get; set; }


        public Rectangle BoundRect { get; set; }
        public void onCollision(Object sender)
        {

        }
    }
}
