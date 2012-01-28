using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Infinity_TD
{
    class EffectControl
    {
        public List<SoundEffect> lista = new List<SoundEffect>();
        public Game1 game;
        private SoundEffect soundEffect;

        public EffectControl(Game1 game)
        {
            this.game = game;
        }


        public void EffectLoad()
        {
            soundEffect = game.Content.Load<SoundEffect>("Sounds/Effects/Effect1");
            lista.Add(soundEffect);
            soundEffect = game.Content.Load<SoundEffect>("Sounds/Effects/Effect2");
            lista.Add(soundEffect);
            soundEffect = game.Content.Load<SoundEffect>("Sounds/Effects/Effect3");
            lista.Add(soundEffect);
            soundEffect = game.Content.Load<SoundEffect>("Sounds/Effects/Effect4");
            lista.Add(soundEffect);
        }
    }
}
