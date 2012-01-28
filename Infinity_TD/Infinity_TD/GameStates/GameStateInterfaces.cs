using System;
using Microsoft.Xna.Framework.Graphics;
using Infinity_TD_Library;
using Microsoft.Xna.Framework;

namespace Infinity_TD
{
    public interface ITitleIntroState : IGameState { }
    public interface IStartMenuState : IGameState { }
    public interface IOptionsMenuState : IGameState { }
    public interface IPlayingState : IGameState { }
    public interface IPausedState : IGameState { }
}
