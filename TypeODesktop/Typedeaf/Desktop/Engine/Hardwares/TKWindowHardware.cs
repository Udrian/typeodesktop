using TypeOEngine.Typedeaf.Core.Engine.Hardwares;
using TypeOEngine.Typedeaf.Desktop.Engine.Graphics;
using TypeOEngine.Typedeaf.Desktop.Engine.Hardwares.Interfaces;

namespace TypeOEngine.Typedeaf.Desktop
{
    namespace Engine.Hardwares
    {
        internal class TKWindowHardware : Hardware, IWindowHardware
        {
            public override void Initialize() { }

            public override void Cleanup() { }

            public DesktopWindow CreateWindow()
            {
                return new TKWindow();
            }
        }
    }
}