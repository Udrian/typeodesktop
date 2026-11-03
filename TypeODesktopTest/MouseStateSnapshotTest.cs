using OpenTK.Mathematics;
using OpenTK.Windowing.GraphicsLibraryFramework;
using TypeOEngine.Typedeaf.Desktop.Engine.Hardwares.Interfaces;

namespace TypeODesktopTest
{
    public class MouseStateSnapshotTest
    {
        private static MouseStateSnapshot Create(IEnumerable<MouseButton> down, IEnumerable<MouseButton> previousDown) =>
            new(new Vector2(1, 2), new Vector2(3, 4), new Vector2(5, 6), new Vector2(7, 8), down, previousDown);

        [Fact]
        public void Constructor_StoresPositionsAndScroll()
        {
            var snapshot = Create(new MouseButton[0], new MouseButton[0]);

            Assert.Equal(new Vector2(1, 2), snapshot.Position);
            Assert.Equal(new Vector2(3, 4), snapshot.PreviousPosition);
            Assert.Equal(new Vector2(5, 6), snapshot.Scroll);
            Assert.Equal(new Vector2(7, 8), snapshot.PreviousScroll);
        }

        [Fact]
        public void Empty_HasNoStateAndNoButtons()
        {
            var empty = MouseStateSnapshot.Empty;

            Assert.Equal(Vector2.Zero, empty.Position);
            Assert.Equal(Vector2.Zero, empty.PreviousPosition);
            Assert.Equal(Vector2.Zero, empty.Scroll);
            Assert.Equal(Vector2.Zero, empty.PreviousScroll);
            Assert.False(empty.IsButtonDown(MouseButton.Left));
            Assert.False(empty.WasButtonDown(MouseButton.Left));
            Assert.False(empty.IsButtonReleased(MouseButton.Left));
        }

        [Fact]
        public void Empty_IsSingleton()
        {
            Assert.Same(MouseStateSnapshot.Empty, MouseStateSnapshot.Empty);
        }

        [Fact]
        public void IsButtonDown_OnlyForCurrentlyDownButtons()
        {
            var snapshot = Create(new[] { MouseButton.Left }, new[] { MouseButton.Right });

            Assert.True(snapshot.IsButtonDown(MouseButton.Left));
            Assert.False(snapshot.IsButtonDown(MouseButton.Right));
        }

        [Fact]
        public void WasButtonDown_OnlyForPreviouslyDownButtons()
        {
            var snapshot = Create(new[] { MouseButton.Left }, new[] { MouseButton.Right });

            Assert.True(snapshot.WasButtonDown(MouseButton.Right));
            Assert.False(snapshot.WasButtonDown(MouseButton.Left));
        }

        [Fact]
        public void IsButtonReleased_TrueOnlyWhenDownBeforeAndUpNow()
        {
            var snapshot = Create(new[] { MouseButton.Left, MouseButton.Middle }, new[] { MouseButton.Right, MouseButton.Middle });

            Assert.True(snapshot.IsButtonReleased(MouseButton.Right));
            Assert.False(snapshot.IsButtonReleased(MouseButton.Left));
            Assert.False(snapshot.IsButtonReleased(MouseButton.Middle));
        }

        [Fact]
        public void Constructor_CopiesButtonCollections()
        {
            var down = new List<MouseButton> { MouseButton.Left };
            var previous = new List<MouseButton>();
            var snapshot = Create(down, previous);

            down.Clear();
            previous.Add(MouseButton.Left);

            Assert.True(snapshot.IsButtonDown(MouseButton.Left));
            Assert.False(snapshot.WasButtonDown(MouseButton.Left));
        }
    }
}
