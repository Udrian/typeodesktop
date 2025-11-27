using TypeOEngine.Typedeaf.Core;
using TypeOEngine.Typedeaf.Core.Engine;
using TypeOEngine.Typedeaf.Core.Engine.Hardwares;
using TypeOEngine.Typedeaf.Desktop.Engine.Hardwares;
using TypeOEngine.Typedeaf.Desktop.Engine.Hardwares.Interfaces;
using TypeOEngine.Typedeaf.Desktop.Engine.Services;
using Xunit;

namespace TypeODesktopTest
{
    public class KeyboardTest
    {
        public string GameName { get; set; } = "test";

        public class TestKeyboardGame : Game
        {
            public TestKeyboardInputService KeyboardInputService { get; set; }

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

        public class TestKeyboardInputService : KeyboardInputService
        {
            public new IKeyboardHardware KeyboardHardware { get { return base.KeyboardHardware; } set { base.KeyboardHardware = value; } }
        }

        public class TestKeyboardHardware : Hardware, IKeyboardHardware
        {
            protected override void Initialize()
            {
                throw new System.NotImplementedException();
            }

            protected override void Cleanup()
            {
            }

            public bool CurrentKeyDownEvent(KeyboardKey key)
            {
                throw new System.NotImplementedException();
            }

            public bool CurrentKeyUpEvent(KeyboardKey key)
            {
                throw new System.NotImplementedException();
            }

            public bool OldKeyDownEvent(KeyboardKey key)
            {
                throw new System.NotImplementedException();
            }

            public bool OldKeyUpEvent(KeyboardKey key)
            {
                throw new System.NotImplementedException();
            }
        }

        [Fact]
        public void CreateKeyboardInputService()
        {
            var typeO = TypeO.Create<TestKeyboardGame>(GameName)
                .AddHardware<IKeyboardHardware, TestKeyboardHardware>()
                .AddService<TestKeyboardInputService>() as TypeO;
            typeO.Start();

            var testGame = typeO.Context.Game as TestKeyboardGame;
            Assert.NotNull(testGame.KeyboardInputService);
            Assert.IsType<TestKeyboardInputService>(testGame.KeyboardInputService);

            Assert.NotNull(testGame.KeyboardInputService.KeyboardHardware);
            Assert.IsType<TestKeyboardHardware>(testGame.KeyboardInputService.KeyboardHardware);
        }
    }
}
