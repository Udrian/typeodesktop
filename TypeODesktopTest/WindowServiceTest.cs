using TypeODesktopTest.Mock;
using TypeOEngine.Typedeaf.Core;
using TypeOEngine.Typedeaf.Core.Common;
using TypeOEngine.Typedeaf.Core.Engine;
using TypeOEngine.Typedeaf.Desktop.Engine.Hardwares.Interfaces;
using TypeOEngine.Typedeaf.Desktop.Engine.Services;

namespace TypeODesktopTest
{
    public class WindowServiceTest
    {
        public class ProbeGame : Game
        {
            public WindowService Windows { get; set; }

            protected override void Initialize() { base.Initialize(); }
            protected override void Cleanup() { }
            public override void Update(double dt) { Exit(); }
            public override void Draw() { }
        }

        private static WindowService Start()
        {
            var typeO = TypeO.Create<ProbeGame>("my game")
                .AddHardware<IWindowHardware, FakeWindowHardware>()
                .AddService<WindowService>() as TypeO;
            typeO.Start();
            return ((ProbeGame)typeO.Context.Game).Windows;
        }

        [Fact]
        public void CreateWindow_UsesGameNameAndDefaultSize()
        {
            var service = Start();

            var window = (FakeWindow)service.CreateWindow();

            Assert.True(window.SetCalled);
            Assert.Equal("my game", window.Title);
            Assert.Equal(Vec2i.Zero, window.Position);
            Assert.Equal(new Vec2i(800, 600), window.Size);
            Assert.False(window.Fullscreen);
            Assert.False(window.Borderless);
        }

        [Fact]
        public void CreateWindow_PassesThroughArguments()
        {
            var service = Start();

            var window = service.CreateWindow("custom", new Vec2i(5, 6), new Vec2i(320, 240), true, true);

            Assert.Equal("custom", window.Title);
            Assert.Equal(new Vec2i(5, 6), window.Position);
            Assert.Equal(new Vec2i(320, 240), window.Size);
            Assert.True(window.Fullscreen);
            Assert.True(window.Borderless);
        }

        [Fact]
        public void CreateWindow_InitializesWindowThroughContext()
        {
            var service = Start();

            var window = (FakeWindow)service.CreateWindow();

            Assert.True(window.Initialized);
        }
    }
}
