using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Infinity_TD
{
    class Tower
    {
        private Vector2 position;
        private Texture2D texture;
        private int range = 4;

        public List<Shot> Shots
        {
            get;
            private set;
        }

        private float Damage
        {
            get;
            set;
        }

        private float fireRate
        {
            get;
            set;
        }

        private TimeSpan duration;
        private float filerate;

        public static T getTower<T>(Texture2D _textura, float _dmg, Vector2 _pos, float _fireRate, TimeSpan _duration) where T : Tower
        {
            return (T)Activator.CreateInstance(typeof(T), _textura, _dmg, _pos, _fireRate, _duration); 
        }

        public Tower(Texture2D _textura, float _dmg, Vector2 _pos, float _fireRate, TimeSpan duration)
        {
            Damage = _dmg;
            this.texture = _textura;
            this.fireRate = _fireRate;
            this.position = _pos;
            this.duration = duration;
        }

        public virtual void Update(GameTime gameTime)
        {

        }

        public virtual void Draw(SpriteBatch sb)
        {
            sb.Draw(texture, position, Color.Wheat);
        }
    }
}
