using TypeOEngine.Typedeaf.Core.Common;
using TypeOEngine.Typedeaf.Core.Engine.Services;
using TypeOEngine.Typedeaf.Core.Engine.Services.Input;
using TypeOEngine.Typedeaf.Desktop.Engine.Hardwares.Interfaces;

namespace TypeOEngine.Typedeaf.Desktop
{
    namespace Engine.Services
    {
        /// <summary>Service that exposes mouse position, wheel and button state.</summary>
        public class MouseInputService : Service
        {
            /// <summary>Gets or sets the mouse hardware.</summary>
            protected IMouseHardware MouseHardware { get; set; }

            /// <summary>Gets or sets the converter that maps input aliases to hardware buttons.</summary>
            protected KeyConverter KeyConverter { get; set; }


            /// <summary>Gets the current mouse position.</summary>
            public Vec2 MousePosition { get { return MouseHardware.CurrentMousePosition; } }
            /// <summary>Gets the mouse movement since the previous frame.</summary>
            public Vec2 MousePositionRelative { get { return MouseHardware.CurrentMousePosition - MouseHardware.OldMousePosition; } }

            /// <summary>Gets the current scroll wheel position.</summary>
            public Vec2 WheelPosition { get { return MouseHardware.CurrentWheelPosition; } }
            /// <summary>Gets the scroll wheel movement since the previous frame.</summary>
            public Vec2 WheelPositionRelative { get { return MouseHardware.CurrentWheelPosition - MouseHardware.OldWheelPosition; } }

            /// <inheritdoc/>
            protected override void Initialize()
            {
                KeyConverter = new KeyConverter();
            }

            /// <inheritdoc/>
            protected override void Cleanup()
            {
            }

            /// <summary>Maps an input to a hardware mouse button.</summary>
            /// <param name="input">The input to alias.</param>
            /// <param name="key">The mouse button it maps to.</param>
            public void SetKeyAlias(object input, object key)
            {
                KeyConverter.SetKeyAlias(input, key);
            }
            /// <summary>Determines whether the input is currently held down.</summary>
            /// <param name="input">The input to check.</param>
            /// <returns><c>true</c> if the input is down.</returns>
            public bool IsDown(object input)
            {
                if(!KeyConverter.ContainsInput(input)) return false;

                return MouseHardware.CurrentButtonDownEvent(KeyConverter.GetKey(input));
            }
            /// <summary>Determines whether the input was pressed this frame.</summary>
            /// <param name="input">The input to check.</param>
            /// <returns><c>true</c> if the input went down this frame.</returns>
            public bool IsPressed(object input)
            {
                if(!KeyConverter.ContainsInput(input)) return false;

                return MouseHardware.CurrentButtonDownEvent(KeyConverter.GetKey(input)) && MouseHardware.OldButtonUpEvent(KeyConverter.GetKey(input));
            }
            /// <summary>Determines whether the input was released this frame.</summary>
            /// <param name="input">The input to check.</param>
            /// <returns><c>true</c> if the input went up this frame.</returns>
            public bool IsReleased(object input)
            {
                if(!KeyConverter.ContainsInput(input)) return false;

                return MouseHardware.CurrentButtonUpEvent(KeyConverter.GetKey(input)) && MouseHardware.OldButtonDownEvent(KeyConverter.GetKey(input));
            }
        }
    }
}
