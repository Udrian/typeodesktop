using TypeOEngine.Typedeaf.Core.Common;
using TypeOEngine.Typedeaf.Desktop;

namespace TypeODesktopTest
{
    public class DesktopModuleOptionTest
    {
        [Fact]
        public void Defaults_AreEmpty()
        {
            var option = new DesktopModuleOption();

            Assert.Null(option.WindowTitle);
            Assert.False(option.WindowFullscreen);
            Assert.False(option.WindowBorderless);
        }

        [Fact]
        public void Properties_RoundTrip()
        {
            var option = new DesktopModuleOption
            {
                WindowTitle = "title",
                WindowSize = new Vec2(640, 480),
                WindowPosition = new Vec2(10, 20),
                WindowFullscreen = true,
                WindowBorderless = true
            };

            Assert.Equal("title", option.WindowTitle);
            Assert.Equal(new Vec2(640, 480), option.WindowSize);
            Assert.Equal(new Vec2(10, 20), option.WindowPosition);
            Assert.True(option.WindowFullscreen);
            Assert.True(option.WindowBorderless);
        }
    }
}
