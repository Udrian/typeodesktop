using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using TypeOEngine.Typedeaf.Core.Common;
using TypeOEngine.Typedeaf.Core.Engine.Interfaces;
using TypeOEngine.Typedeaf.TK;
using TypeOEngine.Typedeaf.TK.Engine.Services;

namespace TypeOEngine.Typedeaf.Desktop
{
    namespace Engine.Graphics
    {
        internal class TKWindow : DesktopWindow
        {
            private TKGameService TKGameService { get; set; }

            internal TKGameWindow TKGameWindow { get; set; }

            private ILogger Logger { get; set; }
            
            private NativeWindowSettings Setting { get; set; }

            public override void Set(string title, Vec2i position, Vec2i size, bool fullscreen = false, bool borderless = false)
            {
                Setting = new NativeWindowSettings
                {
                    Location = new Vector2i(position.X, position.Y),
                    WindowState = fullscreen ? WindowState.Fullscreen : WindowState.Normal,
                    WindowBorder = borderless ? WindowBorder.Hidden : WindowBorder.Fixed,
                    Size = new Vector2i(size.X, size.Y),
                    Title = title
                };

            }

            protected override void Initialize()
            {
                if(Setting == null)
                {
                    Logger.Log(Core.Engine.LogLevel.Fatal, "Window Settings can't be null, Call Set() to fix");
                    return;
                }
                TKGameWindow = TKGameService.CreateTKGameWindow(Setting);

                base.Initialize();
            }

            protected override void Cleanup()
            {
                TKGameWindow.Close();
            }

            public override string Title
            {
                get => TKGameWindow.Title;
                set => TKGameWindow.Title = value;
            }
            public override Vec2i Position
            {
                get => new Vec2i(TKGameWindow.Location.X, TKGameWindow.Location.Y);
                set => TKGameWindow.Location = new Vector2i(value.X, value.Y);
            }
            public override Vec2i Size
            {
                get => new Vec2i(TKGameWindow.Size.X, TKGameWindow.Size.Y);
                set => TKGameWindow.Size = new Vector2i(value.X, value.Y);
            }
            public override bool Fullscreen
            {
                get => TKGameWindow.IsFullscreen;
                set => TKGameWindow.WindowState = value ? WindowState.Fullscreen : WindowState.Normal;
            }
            public override bool Borderless
            {
                get => TKGameWindow.WindowBorder == WindowBorder.Hidden;
                set => TKGameWindow.WindowBorder = value ? WindowBorder.Hidden : WindowBorder.Fixed;
            }
        }
    }
}
