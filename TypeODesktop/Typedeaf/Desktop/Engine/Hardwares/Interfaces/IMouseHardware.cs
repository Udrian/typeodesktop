using TypeOEngine.Typedeaf.Core.Common;
using TypeOEngine.Typedeaf.Core.Engine.Hardwares.Interfaces;

namespace TypeOEngine.Typedeaf.Desktop
{
    namespace Engine.Hardwares.Interfaces
    {
        /// <summary>Provides access to the mouse hardware state.</summary>
        public interface IMouseHardware : IHardware
        {
            /// <summary>Gets or sets the current mouse position.</summary>
            public Vec2 CurrentMousePosition { get; set; }
            /// <summary>Gets or sets the mouse position of the previous frame.</summary>
            public Vec2 OldMousePosition { get; set; }
            /// <summary>Gets or sets the current scroll wheel position.</summary>
            public Vec2 CurrentWheelPosition { get; set; }
            /// <summary>Gets or sets the scroll wheel position of the previous frame.</summary>
            public Vec2 OldWheelPosition { get; set; }

            /// <summary>Determines whether the button is down in the current state.</summary>
            /// <param name="key">The mouse button.</param>
            /// <returns><c>true</c> if the button is down.</returns>
            public bool CurrentButtonDownEvent(object key);
            /// <summary>Determines whether the button is up in the current state.</summary>
            /// <param name="key">The mouse button.</param>
            /// <returns><c>true</c> if the button is up.</returns>
            public bool CurrentButtonUpEvent(object key);
            /// <summary>Determines whether the button was down in the previous state.</summary>
            /// <param name="key">The mouse button.</param>
            /// <returns><c>true</c> if the button was down.</returns>
            public bool OldButtonDownEvent(object key);
            /// <summary>Determines whether the button was up in the previous state.</summary>
            /// <param name="key">The mouse button.</param>
            /// <returns><c>true</c> if the button was up.</returns>
            public bool OldButtonUpEvent(object key);

            /// <summary>Updates the hardware with a new mouse state.</summary>
            /// <param name="state">The new state, or <c>null</c>.</param>
            public void SetState(object state);
        }
    }
}
