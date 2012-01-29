using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Infinity_TD
{
    class WaterTower : Tower
    {
        public WaterTower(Texture2D _textura, float _dmg, Vector2 _pos, float _fireRate)
            : base(_textura, _dmg, _pos, _fireRate)
        {

        }
    }
}
