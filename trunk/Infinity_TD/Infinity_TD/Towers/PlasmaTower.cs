using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Infinity_TD
{
    class PlasmaTower : Tower
    {
        public PlasmaTower(Texture2D _textura, float _dmg, Vector2 _pos, float _fireRate)
            : base(_textura, _dmg, _pos, _fireRate) { }
    }
}
