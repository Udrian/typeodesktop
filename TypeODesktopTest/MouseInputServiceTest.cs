using TypeODesktopTest.Mock;
using TypeOEngine.Typedeaf.Core;
using TypeOEngine.Typedeaf.Core.Common;
using TypeOEngine.Typedeaf.Core.Engine;
using TypeOEngine.Typedeaf.Desktop.Engine.Hardwares.Interfaces;
using TypeOEngine.Typedeaf.Desktop.Engine.Services;

namespace TypeODesktopTest
{
    public class MouseInputServiceTest
    {
        public class ProbeMouseService : MouseInputService
        {
            public FakeMouseHardware GetHardware() => (FakeMouseHardware)MouseHardware;
        }

        public class ProbeGame : Game
        {
            public ProbeMouseService Mouse { get; set; }

            protected override void Initialize() { base.Initialize(); }
            protected override void Cleanup() { }
            public override void Update(double dt) { Exit(); }
            public override void Draw() { }
        }

        private static ProbeMouseService Start()
        {
            var typeO = TypeO.Create<ProbeGame>("test")
                .AddHardware<IMouseHardware, FakeMouseHardware>()
                .AddService<ProbeMouseService>() as TypeO;
            typeO.Start();
            return ((ProbeGame)typeO.Context.Game).Mouse;
        }

        [Fact]
        public void MousePosition_ReturnsCurrentPosition()
        {
            var mouse = Start();
            mouse.GetHardware().CurrentMousePosition = new Vec2(10, 20);

            Assert.Equal(new Vec2(10, 20), mouse.MousePosition);
        }

        [Fact]
        public void MousePositionRelative_IsDeltaFromOldPosition()
        {
            var mouse = Start();
            mouse.GetHardware().CurrentMousePosition = new Vec2(10, 20);
            mouse.GetHardware().OldMousePosition = new Vec2(4, 25);

            Assert.Equal(new Vec2(6, -5), mouse.MousePositionRelative);
        }

        [Fact]
        public void WheelPosition_ReturnsCurrentAndRelativeWheel()
        {
            var mouse = Start();
            mouse.GetHardware().CurrentWheelPosition = new Vec2(0, 7);
            mouse.GetHardware().OldWheelPosition = new Vec2(0, 3);

            Assert.Equal(new Vec2(0, 7), mouse.WheelPosition);
            Assert.Equal(new Vec2(0, 4), mouse.WheelPositionRelative);
        }

        [Fact]
        public void Buttons_ResolveThroughAlias()
        {
            var mouse = Start();
            mouse.SetKeyAlias("fire", 1);

            Assert.False(mouse.IsDown("fire"));

            mouse.GetHardware().Down.Add(1);
            Assert.True(mouse.IsDown("fire"));
            Assert.True(mouse.IsPressed("fire"));
            Assert.False(mouse.IsReleased("fire"));

            mouse.GetHardware().OldDown.Add(1);
            Assert.False(mouse.IsPressed("fire"));

            mouse.GetHardware().Down.Clear();
            Assert.True(mouse.IsReleased("fire"));
        }

        [Fact]
        public void UnknownAlias_IsNeverActive()
        {
            var mouse = Start();
            mouse.GetHardware().Down.Add(1);

            Assert.False(mouse.IsDown("missing"));
            Assert.False(mouse.IsPressed("missing"));
            Assert.False(mouse.IsReleased("missing"));
        }
    }
}
