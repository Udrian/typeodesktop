using TypeOEngine.Typedeaf.Core.Engine.Hardwares.Interfaces;

namespace TypeOEngine.Typedeaf.Desktop
{
    namespace Engine.Hardwares.Interfaces
    {
        /// <summary>
        /// Interface for checking current state of keyboard hardware
        /// </summary>
        public interface IKeyboardHardware : IHardware
        {
            /// <summary>
            /// Check if supplied keyboard object is currently held down
            /// </summary>
            /// <param name="key">Input key</param>
            /// <returns>True if key is down</returns>
            public bool CurrentKeyDownEvent(KeyboardKey key);
            /// <summary>
            /// Check if supplied keyboard object is currently not held down
            /// </summary>
            /// <param name="key">Input key</param>
            /// <returns>True if key is up</returns>
            public bool CurrentKeyUpEvent(KeyboardKey key);
            /// <summary>
            /// Check if supplied keyboard object was previosly held down last tick
            /// </summary>
            /// <param name="key">Input key</param>
            /// <returns>True if key is down</returns>
            public bool OldKeyDownEvent(KeyboardKey key);
            /// <summary>
            /// Check if supplied keyboard object was previosly not held down last tick
            /// </summary>
            /// <param name="key">Input key</param>
            /// <returns>True if key is up</returns>
            public bool OldKeyUpEvent(KeyboardKey key);
        }
    }
}
