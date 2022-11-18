using TypeOEngine.Typedeaf.Core.Engine.Hardwares.Interfaces;
using TypeOEngine.Typedeaf.Desktop.Engine.Graphics;

namespace TypeOEngine.Typedeaf.Desktop
{
    namespace Engine.Hardwares.Interfaces
    {
        /// <summary>
        /// Interface for Window hardware handling
        /// </summary>
        public interface IWindowHardware : IHardware
        {
            /// <summary>
            /// Initialize a new Window
            /// </summary>
            /// <returns>The newly created window</returns>
            public DesktopWindow CreateWindow();
        }
    }
}
