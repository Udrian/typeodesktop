using System;
using TypeOEngine.Typedeaf.Core.Engine.Contents;
using TypeOEngine.Typedeaf.Core.Engine.Graphics.Interfaces;
using TypeOEngine.Typedeaf.Core.Engine.Hardwares;
using TypeOEngine.Typedeaf.Desktop.Engine.Graphics;
using TypeOEngine.Typedeaf.Desktop.Engine.Hardwares.Interfaces;
using TypeOEngine.Typedeaf.TK.Engine.Services;

namespace TypeOEngine.Typedeaf.Desktop
{
    namespace Engine.Hardwares
    {
        internal class TKWindowHardware : Hardware, IWindowHardware
        {
            private TKGameService GameService { get; set; }

            public override void Initialize() { }

            public override void Cleanup() { }

            public ContentLoader CreateContentLoader(ICanvas canvas)
            {
                throw new NotImplementedException();
            }

            public DesktopWindow CreateWindow()
            {
                return new TKWindow();
            }
        }
    }
}