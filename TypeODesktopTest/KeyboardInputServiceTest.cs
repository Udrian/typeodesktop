using TypeODesktopTest.Mock;
using TypeOEngine.Typedeaf.Core;
using TypeOEngine.Typedeaf.Core.Engine;
using TypeOEngine.Typedeaf.Desktop.Engine.Hardwares;
using TypeOEngine.Typedeaf.Desktop.Engine.Hardwares.Interfaces;
using TypeOEngine.Typedeaf.Desktop.Engine.Services;

namespace TypeODesktopTest
{
    public class KeyboardInputServiceTest
    {
        public class ProbeKeyboardService : KeyboardInputService
        {
            public FakeKeyboardHardware GetHardware() => (FakeKeyboardHardware)KeyboardHardware;
        }

        public class ProbeGame : Game
        {
            public ProbeKeyboardService Keyboard { get; set; }

            protected override void Initialize() { base.Initialize(); }
            protected override void Cleanup() { }
            public override void Update(double dt) { Exit(); }
            public override void Draw() { }
        }

        private static ProbeKeyboardService Start()
        {
            var typeO = TypeO.Create<ProbeGame>("test")
                .AddHardware<IKeyboardHardware, FakeKeyboardHardware>()
                .AddService<ProbeKeyboardService>() as TypeO;
            typeO.Start();
            return ((ProbeGame)typeO.Context.Game).Keyboard;
        }

        [Fact]
        public void IsDown_FollowsCurrentKeyState()
        {
            var keyboard = Start();

            Assert.False(keyboard.IsDown(KeyboardKey.A));
            keyboard.GetHardware().Down.Add(KeyboardKey.A);
            Assert.True(keyboard.IsDown(KeyboardKey.A));
            Assert.False(keyboard.IsDown(KeyboardKey.Space));
        }

        [Fact]
        public void IsPressed_RequiresDownNowAndUpBefore()
        {
            var keyboard = Start();

            keyboard.GetHardware().Down.Add(KeyboardKey.A);
            Assert.True(keyboard.IsPressed(KeyboardKey.A));

            keyboard.GetHardware().OldDown.Add(KeyboardKey.A);
            Assert.False(keyboard.IsPressed(KeyboardKey.A));
        }

        [Fact]
        public void IsReleased_RequiresUpNowAndDownBefore()
        {
            var keyboard = Start();

            keyboard.GetHardware().OldDown.Add(KeyboardKey.A);
            Assert.True(keyboard.IsReleased(KeyboardKey.A));

            keyboard.GetHardware().Down.Add(KeyboardKey.A);
            Assert.False(keyboard.IsReleased(KeyboardKey.A));
        }

        [Fact]
        public void KeyAlias_ResolvesToMappedKey()
        {
            var keyboard = Start();
            keyboard.SetKeyAlias("jump", KeyboardKey.Space);

            Assert.False(keyboard.IsDown("jump"));

            keyboard.GetHardware().Down.Add(KeyboardKey.Space);
            Assert.True(keyboard.IsDown("jump"));
            Assert.True(keyboard.IsPressed("jump"));
            Assert.False(keyboard.IsReleased("jump"));

            keyboard.GetHardware().Down.Clear();
            keyboard.GetHardware().OldDown.Add(KeyboardKey.Space);
            Assert.True(keyboard.IsReleased("jump"));
        }

        [Fact]
        public void UnknownAlias_IsNeverActive()
        {
            var keyboard = Start();
            keyboard.GetHardware().Down.Add(KeyboardKey.A);

            Assert.False(keyboard.IsDown("missing"));
            Assert.False(keyboard.IsPressed("missing"));
            Assert.False(keyboard.IsReleased("missing"));
        }

        [Fact]
        public void SetKeyAlias_DuplicateAliasThrows()
        {
            var keyboard = Start();
            keyboard.SetKeyAlias("jump", KeyboardKey.Space);

            Assert.Throws<ArgumentException>(() => keyboard.SetKeyAlias("jump", KeyboardKey.A));
        }
    }
}
