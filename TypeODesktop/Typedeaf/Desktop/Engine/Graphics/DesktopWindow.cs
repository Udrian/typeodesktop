using TypeOEngine.Typedeaf.Core.Common;
using TypeOEngine.Typedeaf.Core.Engine;
using TypeOEngine.Typedeaf.Core.Engine.Graphics.Interfaces;

namespace TypeOEngine.Typedeaf.Desktop
{
    namespace Engine.Graphics
    {
        /// <summary>
        /// Abstract base class for Desktop windows that can be positioned and in windowed mode
        /// </summary>
        public abstract class DesktopWindow : TypeObject, IWindow
        {
            /// <summary>
            /// Window position
            /// </summary>
            public virtual Vec2i Position { get; set; }
            /// <summary>
            /// Determines if the window should be in fullscreen
            /// </summary>
            public virtual bool Fullscreen { get; set; }
            /// <summary>
            /// Determines if the window should be without border
            /// </summary>
            public virtual bool Borderless { get; set; }
            /// <inheritdoc/>
            public virtual string Title { get; set; }
            /// <inheritdoc/>
            public virtual Vec2i Size { get; set; }

            /// <inheritdoc/>
            protected override void Initialize()
            {
                Initialize("", Vec2i.Zero, Vec2i.Zero);
            }

            /// <summary>
            /// Initialize the Desktop Window
            /// </summary>
            /// <param name="title">Desktop window title</param>
            /// <param name="position">Desktop position for the window</param>
            /// <param name="size">Window size</param>
            /// <param name="fullscreen">Window fullscreen</param>
            /// <param name="borderless">Window borders</param>
            public abstract void Initialize(string title, Vec2i position, Vec2i size, bool fullscreen = false, bool borderless = false);
        }
    }
}
