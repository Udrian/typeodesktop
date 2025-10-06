using TypeOEngine.Typedeaf.Core;
using TypeOEngine.Typedeaf.Core.Common;
using TypeOEngine.Typedeaf.Core.Engine;
using TypeOEngine.Typedeaf.Core.Engine.Contents;
using TypeOEngine.Typedeaf.Core.Engine.Graphics;
using TypeOEngine.Typedeaf.Core.Engine.Graphics.Interfaces;
using TypeOEngine.Typedeaf.Core.Engine.Hardwares;
using TypeOEngine.Typedeaf.Desktop.Engine.Graphics;
using TypeOEngine.Typedeaf.Desktop.Engine.Hardwares.Interfaces;
using TypeOEngine.Typedeaf.Desktop.Engine.Services;
using Xunit;

namespace TypeODesktopTest
{
    public class WindowTest
    {
        public string GameName { get; set; } = "test";

        public class TestGame : Game
        {
            public TestWindowService WindowService { get; set; }
            public override void Initialize() { }
            public override void Update(double dt) { Exit(); }
            public override void Draw() { }
            public override void Cleanup() { }
        }

        public class TestCanvas : Canvas
        {
            public TestCanvas(IWindow window, Rectangle viewport, Matrix worldMatrix) : base(window, viewport, worldMatrix) { }
            public override void Clear(Color clearColor) { }
            public override void PostDraw() { }
            public override void PreDraw() { }
            public override void Present() { }

            public override Texture Screenshot(Rectangle screenRect)
            {
                throw new System.NotImplementedException();
            }
        }

        public class TestWindow : DesktopWindow
        {
            public override Vec2i Position { get; set; }
            public override bool Fullscreen { get; set; }
            public override bool Borderless { get; set; }
            public override string Title { get; set; }
            public override Vec2i Size { get; set; }

            public override void Set(string title, Vec2i position, Vec2i size, bool fullscreen = false, bool borderless = false) { }
            protected override void Cleanup() { }
        }

        public class TestWindowHardware : Hardware, IWindowHardware
        {
            public override void Initialize() { }
            public DesktopWindow CreateWindow() { return new TestWindow(); }
            public Canvas CreateCanvas(IWindow desktopWindow) { return new TestCanvas(desktopWindow, new Rectangle(), new Matrix()); }
            public override void Cleanup() { }
        }
        
        public class TestWindowService : WindowService
        {
            public new IWindowHardware WindowHardware { get { return base.WindowHardware; } set { base.WindowHardware = value; } }
        }

        [Fact]
        public void CreateWindowService()
        {
            var typeO = TypeO.Create<TestGame>(GameName)
                .AddHardware<IWindowHardware, TestWindowHardware>()
                .AddService<TestWindowService>() as TypeO;
            typeO.Start();

            var testGame = typeO.Context.Game as TestGame;
            Assert.NotNull(testGame.WindowService);
            Assert.IsType<TestWindowService>(testGame.WindowService);

            Assert.NotNull(testGame.WindowService.WindowHardware);
            Assert.IsType<TestWindowHardware>(testGame.WindowService.WindowHardware);

            var window = testGame.WindowService.CreateWindow();
            Assert.NotNull(window);
            Assert.IsType<TestWindow>(window);

            var canvas = testGame.WindowService.CreateCanvas(window);
            Assert.NotNull(canvas);
            Assert.IsType<TestCanvas>(canvas);
        }
    }
}
