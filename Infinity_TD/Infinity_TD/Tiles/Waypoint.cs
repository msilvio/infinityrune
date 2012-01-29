using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Infinity_TD.Tiles
{
    class Waypoint
    {
        public Vector2 position;
        public Rectangle area;
        public int index;
        Random rand = new Random();

        public enum Directions { UP, LEFT, RIGHT, DOWN };

        public List<Directions> DirectionList = new List<Directions>();

        public Directions getDirection()
        {
            int random = rand.Next(0, DirectionList.Count() - 1);
            return DirectionList.ElementAt(random);
        }

    }
}
