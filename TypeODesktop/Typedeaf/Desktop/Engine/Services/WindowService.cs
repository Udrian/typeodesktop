﻿using TypeOEngine.Typedeaf.Core;
using TypeOEngine.Typedeaf.Core.Common;
using TypeOEngine.Typedeaf.Core.Engine.Contents;
using TypeOEngine.Typedeaf.Core.Engine.Graphics;
using TypeOEngine.Typedeaf.Core.Engine.Graphics.Interfaces;
using TypeOEngine.Typedeaf.Core.Engine.Interfaces;
using TypeOEngine.Typedeaf.Core.Engine.Services;
using TypeOEngine.Typedeaf.Core.Interfaces;
using TypeOEngine.Typedeaf.Desktop.Engine.Graphics;
using TypeOEngine.Typedeaf.Desktop.Engine.Hardwares.Interfaces;

namespace TypeOEngine.Typedeaf.Desktop
{
    namespace Engine.Services
    {
        public class WindowService : Service, IHasGame
        {
            private ILogger Logger { get; set; }
            protected IWindowHardware WindowHardware { get; set; }

            public Game Game { get; set; }

            /// <inheritdoc/>
            protected override void Initialize() { }

            /// <inheritdoc/>
            protected override void Cleanup() { }

            private DesktopWindow InstantiateWindow()
            {
                var window = WindowHardware.CreateWindow();
                Logger?.Log($"Creating Window of type '{window.GetType().FullName}'");
                Context.InitializeObject(window);
                return window;
            }

            public DesktopWindow CreateWindow()
            {
                var window = InstantiateWindow();
                window.Initialize(Game.Name, Vec2i.Zero, new Vec2i(800, 600));

                return window;
            }

            public DesktopWindow CreateWindow(string title, Vec2i position, Vec2i size, bool fullscreen = false, bool borderless = false)
            {
                var window = InstantiateWindow();
                window.Initialize(title, position, size, fullscreen, borderless);

                return window;
            }

            public Canvas CreateCanvas(IWindow window)
            {
                var canvas = WindowHardware.CreateCanvas(window);
                Logger?.Log($"Creating Canvas of type '{canvas.GetType().FullName}'");
                Context.InitializeObject(canvas);
                canvas.Initialize();

                return canvas;
            }

            public Canvas CreateCanvas(IWindow window, Rectangle viewport)
            {
                var canvas = CreateCanvas(window);
                canvas.Viewport = viewport;
                return canvas;
            }

            public ContentLoader CreateContentLoader(Canvas canvas)
            {
                var contentLoader = WindowHardware.CreateContentLoader(canvas);
                Logger?.Log($"Creating ContentLoader of type '{canvas.GetType().FullName}'");
                Context.InitializeObject(contentLoader);

                return contentLoader;
            }
        }
    }
}
