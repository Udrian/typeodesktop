using TypeOEngine.Typedeaf.Core.Engine.Services;
using TypeOEngine.Typedeaf.Core.Engine.Services.Input;
using TypeOEngine.Typedeaf.Desktop.Engine.Hardwares;
using TypeOEngine.Typedeaf.Desktop.Engine.Hardwares.Interfaces;

namespace TypeOEngine.Typedeaf.Desktop
{
    namespace Engine.Services
    {
        /// <summary>
        /// Service for more easily handling Keyboard inputs
        /// </summary>
        public class KeyboardInputService : Service
        {
            /// <summary>
            /// The low level keyboard handling implementation
            /// </summary>
            protected IKeyboardHardware KeyboardHardware { get; set; }

            /// <summary>
            /// Key converter to map high level to low level conversation
            /// </summary>
            protected KeyConverter KeyConverter { get; set; }

            /// <inheritdoc/>
            protected override void Initialize()
            {
                KeyConverter = new KeyConverter();
            }

            /// <inheritdoc/>
            protected override void Cleanup()
            {
            }

            /// <summary>
            /// Set a key alias for easier key mapping management
            /// </summary>
            /// <param name="input">Input alias to map the key to</param>
            /// <param name="key">Low level key to map</param>
            public void SetKeyAlias(object input, KeyboardKey key)
            {
                KeyConverter.SetKeyAlias(input, key);
            }

            /// <summary>
            /// True when input is held down
            /// </summary>
            /// <param name="input">Input alias to check</param>
            /// <returns>True when input is held down</returns>
            public bool IsDown(object input)
            {
                if(!KeyConverter.ContainsInput(input)) return false;

                return IsDown((KeyboardKey)KeyConverter.GetKey(input));
            }

            /// <summary>
            /// True when input is held down
            /// </summary>
            /// <param name="input">Input key to check</param>
            /// <returns>True when input is held down</returns>
            public bool IsDown(KeyboardKey input)
            {
                return KeyboardHardware.CurrentKeyDownEvent(input);
            }

            /// <summary>
            /// True when input is pressed
            /// </summary>
            /// <param name="input">Input alias to check</param>
            /// <returns>True when input is pressed</returns>
            public bool IsPressed(object input)
            {
                if(!KeyConverter.ContainsInput(input)) return false;

                return IsPressed((KeyboardKey)KeyConverter.GetKey(input));
            }

            /// <summary>
            /// True when input is pressed
            /// </summary>
            /// <param name="input">Input key to check</param>
            /// <returns>True when input is pressed</returns>
            public bool IsPressed(KeyboardKey input)
            {
                return KeyboardHardware.CurrentKeyDownEvent(input) && KeyboardHardware.OldKeyUpEvent(input);
            }

            /// <summary>
            /// True when input is released
            /// </summary>
            /// <param name="input">Input alias to check</param>
            /// <returns>True when input is released</returns>
            public bool IsReleased(object input)
            {
                if(!KeyConverter.ContainsInput(input)) return false;

                return IsReleased((KeyboardKey)KeyConverter.GetKey(input));
            }

            /// <summary>
            /// True when input is released
            /// </summary>
            /// <param name="input">Input alias to check</param>
            /// <returns>True when input is released</returns>
            public bool IsReleased(KeyboardKey input)
            {
                return KeyboardHardware.CurrentKeyUpEvent(input) && KeyboardHardware.OldKeyDownEvent(input);
            }
        }
    }
}
