using OpenTK.Mathematics;
using OpenTK.Windowing.GraphicsLibraryFramework;
using TypeOEngine.Typedeaf.Core;
using TypeOEngine.Typedeaf.Core.Common;
using TypeOEngine.Typedeaf.Core.Engine;
using TypeOEngine.Typedeaf.Desktop;
using TypeOEngine.Typedeaf.Desktop.Engine.Hardwares.Interfaces;
using TypeOEngine.Typedeaf.Desktop.Engine.Services;
using TypeOEngine.Typedeaf.TK.Engine.Services;

namespace TypeODesktopTest
{
    // Exercises the internal TKMouseHardware through its public interface, without a real window.
    public class TKMouseHardwareTest
    {
        public class ProbeMouseService : MouseInputService
        {
            public IMouseHardware GetHardware() => MouseHardware;
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
                .AddService<TKGameService>()
                .LoadModule<DesktopModule>()
                .AddService<ProbeMouseService>() as TypeO;
            typeO.Start();
            return ((ProbeGame)typeO.Context.Game).Mouse;
        }

        private static MouseStateSnapshot Snapshot(MouseButton[] down, MouseButton[] previous) =>
            new(new Vector2(10, 20), new Vector2(4, 8), new Vector2(0, 3), new Vector2(0, 1), down, previous);

        [Fact]
        public void WithoutState_NoButtonIsActive()
        {
            var hardware = Start().GetHardware();

            Assert.False(hardware.CurrentButtonDownEvent(MouseButton.Left));
            Assert.False(hardware.CurrentButtonUpEvent(MouseButton.Left));
            Assert.False(hardware.OldButtonDownEvent(MouseButton.Left));
            Assert.False(hardware.OldButtonUpEvent(MouseButton.Left));
        }

        [Fact]
        public void SetState_Snapshot_UpdatesPositionsAndWheel()
        {
            var hardware = Start().GetHardware();

            hardware.SetState(Snapshot(new MouseButton[0], new MouseButton[0]));

            Assert.Equal(new Vec2(10, 20), hardware.CurrentMousePosition);
            Assert.Equal(new Vec2(4, 8), hardware.OldMousePosition);
            Assert.Equal(new Vec2(0, 3), hardware.CurrentWheelPosition);
            Assert.Equal(new Vec2(0, 1), hardware.OldWheelPosition);
        }

        [Fact]
        public void SetState_Snapshot_ReportsButtonStates()
        {
            var hardware = Start().GetHardware();

            hardware.SetState(Snapshot(new[] { MouseButton.Left }, new[] { MouseButton.Right }));

            Assert.True(hardware.CurrentButtonDownEvent(MouseButton.Left));
            Assert.False(hardware.CurrentButtonUpEvent(MouseButton.Left));
            Assert.False(hardware.OldButtonDownEvent(MouseButton.Left));
            Assert.True(hardware.OldButtonUpEvent(MouseButton.Left));

            Assert.True(hardware.OldButtonDownEvent(MouseButton.Right));
            Assert.True(hardware.CurrentButtonUpEvent(MouseButton.Right));
        }

        [Fact]
        public void SetState_ReplacesPreviousState()
        {
            var hardware = Start().GetHardware();
            hardware.SetState(Snapshot(new[] { MouseButton.Left }, new MouseButton[0]));

            hardware.SetState(Snapshot(new MouseButton[0], new[] { MouseButton.Left }));

            Assert.False(hardware.CurrentButtonDownEvent(MouseButton.Left));
            Assert.True(hardware.CurrentButtonUpEvent(MouseButton.Left));
        }

        [Fact]
        public void SetState_UnsupportedObject_IsIgnored()
        {
            var hardware = Start().GetHardware();
            hardware.SetState(Snapshot(new[] { MouseButton.Left }, new MouseButton[0]));

            hardware.SetState("not a mouse state");

            Assert.True(hardware.CurrentButtonDownEvent(MouseButton.Left));
            Assert.Equal(new Vec2(10, 20), hardware.CurrentMousePosition);
        }

        [Fact]
        public void MouseInputService_UsesHardwareState()
        {
            var mouse = Start();
            mouse.SetKeyAlias("fire", MouseButton.Left);

            mouse.GetHardware().SetState(Snapshot(new[] { MouseButton.Left }, new MouseButton[0]));
            Assert.True(mouse.IsDown("fire"));
            Assert.True(mouse.IsPressed("fire"));
            Assert.False(mouse.IsReleased("fire"));
            Assert.Equal(new Vec2(6, 12), mouse.MousePositionRelative);

            mouse.GetHardware().SetState(Snapshot(new MouseButton[0], new[] { MouseButton.Left }));
            Assert.True(mouse.IsReleased("fire"));
        }
    }
}
