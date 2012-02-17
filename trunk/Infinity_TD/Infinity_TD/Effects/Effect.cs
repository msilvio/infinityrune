using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Infinity_TD
{
    class Effect
    {
        public Vector2 origin;
        public bool isValid { get; set; }
        public float Radious { get; set; }


        public virtual float ReduceAmountVelocity { get; set; }
        public virtual float ReduceAmountLife { get; set; }
        public virtual float Damage { get; set; }
        public virtual float stopTime { get; set; }

        protected static Random random = new Random();
    }
}
