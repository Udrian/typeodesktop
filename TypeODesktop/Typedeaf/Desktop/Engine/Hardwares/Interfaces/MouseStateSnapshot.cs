using System.Collections.Generic;
using OpenTK.Mathematics;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace TypeOEngine.Typedeaf.Desktop.Engine.Hardwares.Interfaces
{
    public sealed class MouseStateSnapshot
    {
        private readonly HashSet<MouseButton> _buttonsDown;
        private readonly HashSet<MouseButton> _previousButtonsDown;

        public static MouseStateSnapshot Empty { get; } = new(
            Vector2.Zero,
            Vector2.Zero,
            Vector2.Zero,
            Vector2.Zero,
            new HashSet<MouseButton>(),
            new HashSet<MouseButton>());

        public Vector2 Position { get; }
        public Vector2 PreviousPosition { get; }
        public Vector2 Scroll { get; }
        public Vector2 PreviousScroll { get; }

        public MouseStateSnapshot(
            Vector2 position,
            Vector2 previousPosition,
            Vector2 scroll,
            Vector2 previousScroll,
            IEnumerable<MouseButton> buttonsDown,
            IEnumerable<MouseButton> previousButtonsDown)
        {
            Position = position;
            PreviousPosition = previousPosition;
            Scroll = scroll;
            PreviousScroll = previousScroll;
            _buttonsDown = new HashSet<MouseButton>(buttonsDown);
            _previousButtonsDown = new HashSet<MouseButton>(previousButtonsDown);
        }

        public bool IsButtonDown(MouseButton button) => _buttonsDown.Contains(button);

        public bool WasButtonDown(MouseButton button) => _previousButtonsDown.Contains(button);

        public bool IsButtonReleased(MouseButton button) =>
            !IsButtonDown(button) && WasButtonDown(button);
    }
}
