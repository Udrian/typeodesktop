using System.Collections.Generic;
using OpenTK.Mathematics;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace TypeOEngine.Typedeaf.Desktop.Engine.Hardwares.Interfaces
{
    /// <summary>
    /// Immutable snapshot of the mouse position, scroll and button state for the current and previous frame.
    /// </summary>
    public sealed class MouseStateSnapshot
    {
        private readonly HashSet<MouseButton> _buttonsDown;
        private readonly HashSet<MouseButton> _previousButtonsDown;

        /// <summary>Gets a snapshot with zeroed values and no buttons down.</summary>
        public static MouseStateSnapshot Empty { get; } = new(
            Vector2.Zero,
            Vector2.Zero,
            Vector2.Zero,
            Vector2.Zero,
            new HashSet<MouseButton>(),
            new HashSet<MouseButton>());

        /// <summary>Gets the current mouse position.</summary>
        public Vector2 Position { get; }
        /// <summary>Gets the previous mouse position.</summary>
        public Vector2 PreviousPosition { get; }
        /// <summary>Gets the current scroll value.</summary>
        public Vector2 Scroll { get; }
        /// <summary>Gets the previous scroll value.</summary>
        public Vector2 PreviousScroll { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MouseStateSnapshot"/> class.
        /// </summary>
        /// <param name="position">The current mouse position.</param>
        /// <param name="previousPosition">The previous mouse position.</param>
        /// <param name="scroll">The current scroll value.</param>
        /// <param name="previousScroll">The previous scroll value.</param>
        /// <param name="buttonsDown">The buttons currently down.</param>
        /// <param name="previousButtonsDown">The buttons that were down in the previous frame.</param>
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

        /// <summary>Determines whether the button is currently down.</summary>
        /// <param name="button">The mouse button.</param>
        /// <returns><c>true</c> if the button is down.</returns>
        public bool IsButtonDown(MouseButton button) => _buttonsDown.Contains(button);

        /// <summary>Determines whether the button was down in the previous frame.</summary>
        /// <param name="button">The mouse button.</param>
        /// <returns><c>true</c> if the button was down.</returns>
        public bool WasButtonDown(MouseButton button) => _previousButtonsDown.Contains(button);

        /// <summary>Determines whether the button was released since the previous frame.</summary>
        /// <param name="button">The mouse button.</param>
        /// <returns><c>true</c> if the button is up and was down previously.</returns>
        public bool IsButtonReleased(MouseButton button) =>
            !IsButtonDown(button) && WasButtonDown(button);
    }
}
