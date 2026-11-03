using TypeOEngine.Typedeaf.Core.Common;
using TypeOEngine.Typedeaf.Core.Engine.Hardwares;
using TypeOEngine.Typedeaf.Desktop.Engine.Graphics;
using TypeOEngine.Typedeaf.Desktop.Engine.Hardwares;
using TypeOEngine.Typedeaf.Desktop.Engine.Hardwares.Interfaces;

namespace TypeODesktopTest.Mock
{
    public class FakeKeyboardHardware : Hardware, IKeyboardHardware
    {
        public HashSet<KeyboardKey> Down { get; } = new();
        public HashSet<KeyboardKey> OldDown { get; } = new();

        protected override void Initialize() { }
        protected override void Cleanup() { }

        public bool CurrentKeyDownEvent(KeyboardKey key) => Down.Contains(key);
        public bool CurrentKeyUpEvent(KeyboardKey key) => !Down.Contains(key);
        public bool OldKeyDownEvent(KeyboardKey key) => OldDown.Contains(key);
        public bool OldKeyUpEvent(KeyboardKey key) => !OldDown.Contains(key);
    }

    public class FakeMouseHardware : Hardware, IMouseHardware
    {
        public Vec2 CurrentMousePosition { get; set; }
        public Vec2 OldMousePosition { get; set; }
        public Vec2 CurrentWheelPosition { get; set; }
        public Vec2 OldWheelPosition { get; set; }
        public HashSet<object> Down { get; } = new();
        public HashSet<object> OldDown { get; } = new();
        public object LastState { get; private set; }

        protected override void Initialize() { }
        protected override void Cleanup() { }

        public bool CurrentButtonDownEvent(object key) => Down.Contains(key);
        public bool CurrentButtonUpEvent(object key) => !Down.Contains(key);
        public bool OldButtonDownEvent(object key) => OldDown.Contains(key);
        public bool OldButtonUpEvent(object key) => !OldDown.Contains(key);
        public void SetState(object state) { LastState = state; }
    }

    public class FakeWindow : DesktopWindow
    {
        public bool Initialized { get; private set; }
        public bool SetCalled { get; private set; }

        public override Vec2i Position { get; set; }
        public override bool Fullscreen { get; set; }
        public override bool Borderless { get; set; }
        public override string Title { get; set; }
        public override Vec2i Size { get; set; }

        public override void Set(string title, Vec2i position, Vec2i size, bool fullscreen = false, bool borderless = false)
        {
            SetCalled = true;
            Title = title;
            Position = position;
            Size = size;
            Fullscreen = fullscreen;
            Borderless = borderless;
        }

        // The base implementation creates a GL canvas, which needs a real window.
        protected override void Initialize() { Initialized = true; }
        protected override void Cleanup() { }
    }

    public class FakeWindowHardware : Hardware, IWindowHardware
    {
        public FakeWindow LastWindow { get; private set; }

        protected override void Initialize() { }
        protected override void Cleanup() { }

        public DesktopWindow CreateWindow() => LastWindow = new FakeWindow();
    }
}
