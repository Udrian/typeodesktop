﻿using TypeOEngine.Typedeaf.Core.Engine.Contents;
using TypeOEngine.Typedeaf.Core.Engine.Graphics.Interfaces;
using TypeOEngine.Typedeaf.Core.Engine.Hardwares.Interfaces;
using TypeOEngine.Typedeaf.Desktop.Engine.Graphics;

namespace TypeOEngine.Typedeaf.Desktop
{
    namespace Engine.Hardwares.Interfaces
    {
        public interface IWindowHardware : IHardware
        {
            public DesktopWindow CreateWindow();

            public ContentLoader CreateContentLoader(ICanvas canvas);
        }
    }
}
