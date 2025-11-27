using TypeOEngine.Typedeaf.Core;
using TypeOEngine.Typedeaf.Core.Engine;
using TypeOEngine.Typedeaf.Desktop;
using TypeOEngine.Typedeaf.Desktop.Engine.Services;
using TypeOEngine.Typedeaf.TK.Engine.Services;

namespace TypeODesktopTest
{
    public class DesktopModuleTest
    {
        public string GameName { get; set; } = "test";

        public class TestGame : Game
        {
            protected override void Initialize()
            {
                base.Initialize();
            }

            protected override void Cleanup()
            {
            }

            public override void Update(double dt)
            {
                Exit();
            }

            public override void Draw()
            {
            }
        }

        [Fact]
        public void LoadDesktopModule()
        {
            var typeO = TypeO.Create<TestGame>(GameName)
                             .AddService<TKGameService>()
                             .LoadModule<DesktopModule>() as TypeO;
            typeO.Start();
            var module = typeO.Context.Modules.FirstOrDefault(m => m.GetType() == typeof(DesktopModule)) as DesktopModule;
            Assert.NotNull(module);
            Assert.IsType<DesktopModule>(module);
            Assert.NotEmpty(typeO.Context.Modules);

            Assert.NotEmpty(typeO.Context.Services);

            Assert.NotNull(typeO.Context.Services[typeof(WindowService)]);
            Assert.NotNull(typeO.Context.Services[typeof(KeyboardInputService)]);
            Assert.NotNull(typeO.Context.Services[typeof(MouseInputService)]);
        }
    }
}
