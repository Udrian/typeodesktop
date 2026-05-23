using OpenTK.Windowing.GraphicsLibraryFramework;
using TypeOEngine.Typedeaf.Core.Common;
using TypeOEngine.Typedeaf.Core.Engine.Hardwares;
using TypeOEngine.Typedeaf.Core.Interfaces;
using TypeOEngine.Typedeaf.Desktop.Engine.Hardwares.Interfaces;
using TypeOEngine.Typedeaf.TK;
using TypeOEngine.Typedeaf.TK.Engine.Services;

namespace TypeOEngine.Typedeaf.Desktop
{
    namespace Engine.Hardwares
    {
        internal class TKMouseHardware : Hardware, IMouseHardware, IUpdatable
        {
            private TKGameService GameService { get; set; }

            private MouseState CurrentState { get; set; }

            public Vec2 CurrentMousePosition { get; set; }
            public Vec2 OldMousePosition { get; set; }
            public Vec2 CurrentWheelPosition { get; set; }
            public Vec2 OldWheelPosition { get; set; }
            public bool Pause { get; set; }

            protected override void Initialize()
            {

            }

            protected override void Cleanup()
            {
            }

            public bool CurrentButtonDownEvent(object key)
            {
                return CurrentState.IsButtonDown((MouseButton)key);
            }

            public bool CurrentButtonUpEvent(object key)
            {
                return CurrentState.IsButtonReleased((MouseButton)key); ;
            }

            public bool OldButtonDownEvent(object key)
            {
                return CurrentState.WasButtonDown((MouseButton)key);
            }

            public bool OldButtonUpEvent(object key)
            {
                return !CurrentState.WasButtonDown((MouseButton)key);
            }

            public void Update(double dt)
            {
                TKGameWindow game = GameService.TKGames.FirstOrDefault();
                
                if(game != null)
                {
                    CurrentState = game.MouseState.GetSnapshot();

                    CurrentMousePosition = new Vec2(CurrentState.Position.X, CurrentState.Position.Y);
                    OldMousePosition = new Vec2(CurrentState.PreviousPosition.X, CurrentState.PreviousPosition.Y);
                    CurrentWheelPosition = new Vec2(CurrentState.Scroll.X, CurrentState.Scroll.Y);
                    OldWheelPosition = new Vec2(CurrentState.PreviousScroll.X, CurrentState.PreviousScroll.Y);
                }
            }
        }
    }
}