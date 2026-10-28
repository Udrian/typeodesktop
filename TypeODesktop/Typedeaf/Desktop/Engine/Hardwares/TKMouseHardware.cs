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
            private MouseStateSnapshot SnapshotState { get; set; }

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
                return SnapshotState?.IsButtonDown((MouseButton)key)
                    ?? CurrentState?.IsButtonDown((MouseButton)key)
                    ?? false;
            }

            public bool CurrentButtonUpEvent(object key)
            {
                return SnapshotState?.IsButtonReleased((MouseButton)key)
                    ?? CurrentState?.IsButtonReleased((MouseButton)key)
                    ?? false;
            }

            public bool OldButtonDownEvent(object key)
            {
                return SnapshotState?.WasButtonDown((MouseButton)key)
                    ?? CurrentState?.WasButtonDown((MouseButton)key)
                    ?? false;
            }

            public bool OldButtonUpEvent(object key)
            {
                if (SnapshotState != null)
                    return !SnapshotState.WasButtonDown((MouseButton)key);
                if (CurrentState == null)
                    return false;
                return !CurrentState.WasButtonDown((MouseButton)key);
            }

            public void Update(double dt)
            {
                TKGameWindow game = GameService.TKGames.FirstOrDefault();
                
                if(game != null && SnapshotState == null)
                {
                    SetState(game.MouseState.GetSnapshot());
                }
            }

            public void SetState(object? state)
            {
                if (state is MouseState mouseState)
                {
                    CurrentState = mouseState;
                    SnapshotState = null;

                    CurrentMousePosition = new Vec2(CurrentState.Position.X, CurrentState.Position.Y);
                    OldMousePosition = new Vec2(CurrentState.PreviousPosition.X, CurrentState.PreviousPosition.Y);
                    CurrentWheelPosition = new Vec2(CurrentState.Scroll.X, CurrentState.Scroll.Y);
                    OldWheelPosition = new Vec2(CurrentState.PreviousScroll.X, CurrentState.PreviousScroll.Y);
                }
                else if (state is MouseStateSnapshot snapshotState)
                {
                    CurrentState = null;
                    SnapshotState = snapshotState;

                    CurrentMousePosition = new Vec2(snapshotState.Position.X, snapshotState.Position.Y);
                    OldMousePosition = new Vec2(snapshotState.PreviousPosition.X, snapshotState.PreviousPosition.Y);
                    CurrentWheelPosition = new Vec2(snapshotState.Scroll.X, snapshotState.Scroll.Y);
                    OldWheelPosition = new Vec2(snapshotState.PreviousScroll.X, snapshotState.PreviousScroll.Y);
                }
            }
        }
    }
}