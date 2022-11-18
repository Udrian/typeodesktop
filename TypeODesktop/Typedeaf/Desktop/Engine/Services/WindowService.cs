using TypeOEngine.Typedeaf.Core;
using TypeOEngine.Typedeaf.Core.Common;
using TypeOEngine.Typedeaf.Core.Engine;
using TypeOEngine.Typedeaf.Core.Engine.Graphics.Interfaces;
using TypeOEngine.Typedeaf.Core.Engine.Interfaces;
using TypeOEngine.Typedeaf.Core.Engine.Services;
using TypeOEngine.Typedeaf.Core.Interfaces;
using TypeOEngine.Typedeaf.Desktop.Engine.Graphics;
using TypeOEngine.Typedeaf.Desktop.Engine.Hardwares.Interfaces;
using TypeOEngine.Typedeaf.TK.Engine.Graphics;

namespace TypeOEngine.Typedeaf.Desktop
{
    namespace Engine.Services
    {
        /// <summary>
        /// Services for creating Windows
        /// </summary>
        public class WindowService : Service, IHasGame
        {
            private ILogger Logger { get; set; }
            private IWindowHardware WindowHardware { get; set; }

            public Game Game { get; set; }

            /// <inheritdoc/>
            protected override void Initialize() { }

            /// <inheritdoc/>
            protected override void Cleanup() { }

            /// <summary>
            /// Create a new Window with title of Game name and with a size of 800x600
            /// </summary>
            /// <returns>Newly created Window</returns>
            public DesktopWindow CreateWindow()
            {
                var window = CreateWindow(Game.Name, Vec2i.Zero, new Vec2i(800, 600));

                return window;
            }

            /// <summary>
            /// Create a new Window and display it
            /// </summary>
            /// <param name="title">Text to show on Title bar</param>
            /// <param name="position">Desktop position to show the window in</param>
            /// <param name="size">Window size</param>
            /// <param name="fullscreen">True to start window in fullscreen mode</param>
            /// <param name="borderless">True to have no border on the window</param>
            /// <returns>Newly created Window</returns>
            public DesktopWindow CreateWindow(string title, Vec2i position, Vec2i size, bool fullscreen = false, bool borderless = false)
            {
                var window = WindowHardware.CreateWindow();
                Logger?.Log($"Creating Window of type '{window.GetType().FullName}'");
                window.Set(title, position, size, fullscreen, borderless);
                Context.InitializeObject(window);

                return window;
            }

            /// <summary>
            /// Creates a new Canvas tied to a window that covers the entire screen
            /// </summary>
            /// <param name="window">Window to attach Canvas to</param>
            /// <returns>The newly created Canvas</returns>
            public ICanvas CreateCanvas(IWindow window)
            {
                var canvas = new TKCanvas(window, new Rectangle(new Vec2(), window.Size), (window as TKWindow)?.TKGameWindow);
                Logger?.Log($"Creating Canvas of type '{canvas.GetType().FullName}'");
                Context.InitializeObject(canvas);

                return canvas;
            }

            /// <summary>
            /// Creates a new Canvas tied to a window that covers the size of the viewport
            /// </summary>
            /// <param name="window">Window to attach Canvas to</param>
            /// <param name="viewport">Canvas viewport</param>
            /// <returns>The newly created Canvas</returns>
            public ICanvas CreateCanvas(IWindow window, Rectangle viewport)
            {
                var canvas = CreateCanvas(window);
                canvas.Viewport = viewport;

                return canvas;
            }
        }
    }
}
