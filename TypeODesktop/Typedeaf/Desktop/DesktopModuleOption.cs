using TypeOEngine.Typedeaf.Core.Common;
using TypeOEngine.Typedeaf.Core.Engine;

namespace TypeOEngine.Typedeaf.Desktop
{
    /// <summary>Options for the desktop module.</summary>
    public class DesktopModuleOption : ModuleOption
    {
        /// <summary>Gets or sets the window title.</summary>
        public string WindowTitle { get; set; }
        /// <summary>Gets or sets the window size.</summary>
        public Vec2 WindowSize { get; set; }
        /// <summary>Gets or sets the window position on the desktop.</summary>
        public Vec2 WindowPosition { get; set; }
        /// <summary>Gets or sets a value indicating whether the window starts in fullscreen.</summary>
        public bool WindowFullscreen { get; set; }
        /// <summary>Gets or sets a value indicating whether the window has no border.</summary>
        public bool WindowBorderless { get; set; }
    }
}
