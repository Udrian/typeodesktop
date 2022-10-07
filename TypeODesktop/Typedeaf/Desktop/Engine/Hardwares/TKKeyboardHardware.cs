using OpenTK.Windowing.GraphicsLibraryFramework;
using TypeOEngine.Typedeaf.Core.Engine.Hardwares;
using TypeOEngine.Typedeaf.Desktop.Engine.Hardwares.Interfaces;
using TypeOEngine.Typedeaf.TK.Engine.Services;

namespace TypeOEngine.Typedeaf.Desktop
{
    namespace Engine.Hardwares
    {
        internal class TKKeyboardHardware : Hardware, IKeyboardHardware
        {
            private TKGameService TKGameService { get; set; }

            public override void Initialize()
            {
            }

            public override void Cleanup()
            {
            }

            public bool CurrentKeyDownEvent(KeyboardKey key)
            {
                foreach(var game in TKGameService.TKGames)
                {
                    return game.KeyboardState.IsKeyDown((Keys)key);
                }
                return false;
            }

            public bool CurrentKeyUpEvent(KeyboardKey key)
            {
                foreach (var game in TKGameService.TKGames)
                {
                    return !game.KeyboardState.IsKeyDown((Keys)key);
                }
                return false;
            }

            public bool OldKeyDownEvent(KeyboardKey key)
            {
                foreach (var game in TKGameService.TKGames)
                {
                    return game.KeyboardState.WasKeyDown((Keys)key);
                }
                return false;
            }

            public bool OldKeyUpEvent(KeyboardKey key)
            {
                foreach (var game in TKGameService.TKGames)
                {
                    return !game.KeyboardState.WasKeyDown((Keys)key);
                }
                return false;
            }
        }
    }
}
