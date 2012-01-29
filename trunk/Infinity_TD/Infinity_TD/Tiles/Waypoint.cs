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

        public enum Directions { UP, LEFT, RIGHT, DOWN };

        public List<Directions> DirectionList = new List<Directions>();

        public Directions getDirection(Random rand)
        {
            int random = rand.Next(1, DirectionList.Count());
            return DirectionList.ElementAt(random);
        }

    }
}
