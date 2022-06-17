using TypeOEngine.Typedeaf.Core.Engine;
using TypeOEngine.Typedeaf.Desktop.Engine.Services;

namespace TypeOEngine.Typedeaf.Desktop
{
    /// <summary>
    /// Module that contains interfaces for Window and Keyboard Hardware classes
    /// </summary>
    public class DesktopModule : Module<DesktopModuleOption>
    {
        /// <inheritdoc/>
        public DesktopModule() : base() {}

        /// <inheritdoc/>
        protected override void Initialize()
        {
        }

        /// <inheritdoc/>
        protected override void Cleanup()
        {
        }

        /// <inheritdoc/>
        protected override void LoadExtensions(TypeO typeO)
        {
            typeO.AddService<WindowService>();
            typeO.AddService<KeyboardInputService>();
            typeO.AddService<MouseInputService>();
        }
    }
}