using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infinity_TD
{
    class Effect
    {
        public virtual float ReduceAmountVelocity { get { return 0; } }
        public virtual float ReduceAmountLife { get { return 0; } }
        public virtual float DamageArea { get { return 0; } }
    }
}
