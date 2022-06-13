using TypeOEngine.Typedeaf.Core.Engine;
using TypeOEngine.Typedeaf.Desktop.Engine.Services;

namespace TypeOEngine.Typedeaf.Desktop
{
    public class DesktopModule : Module<DesktopModuleOption>
    {
        public DesktopModule() : base()
        {
        }

        public override void Initialize()
        {
        }

        public override void Cleanup()
        {
        }

        public override void LoadExtensions()
        {
            TypeO.AddService<WindowService>();
            TypeO.AddService<KeyboardInputService>();
            TypeO.AddService<MouseInputService>();
        }
    }
}