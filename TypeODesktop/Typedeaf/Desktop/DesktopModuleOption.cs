using TypeOEngine.Typedeaf.Core.Common;
using TypeOEngine.Typedeaf.Core.Engine;

namespace TypeOEngine.Typedeaf.Desktop
{
    public class DesktopModuleOption : ModuleOption
    {
        public string WindowTitle { get; set; }
        public Vec2 WindowSize { get; set; }
        public Vec2 WindowPosition { get; set; }
        public bool WindowFullscreen { get; set; }
        public bool WindowBorderless { get; set; }
    }
}
