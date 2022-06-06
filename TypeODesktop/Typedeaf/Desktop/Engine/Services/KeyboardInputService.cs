﻿using TypeOEngine.Typedeaf.Core.Engine.Services;
using TypeOEngine.Typedeaf.Core.Engine.Services.Input;
using TypeOEngine.Typedeaf.Desktop.Engine.Hardwares.Interfaces;

namespace TypeOEngine.Typedeaf.Desktop
{
    namespace Engine.Services
    {
        public class KeyboardInputService : Service
        {
            protected IKeyboardHardware KeyboardHardware { get; set; }

            protected KeyConverter KeyConverter { get; set; }

            public override void Initialize()
            {
                KeyConverter = new KeyConverter();
            }

            public override void Cleanup()
            {
            }

            public void SetKeyAlias(object input, object key)
            {
                KeyConverter.SetKeyAlias(input, key);
            }

            public bool IsDown(object input)
            {
                if(!KeyConverter.ContainsInput(input)) return false;

                return KeyboardHardware.CurrentKeyDownEvent(KeyConverter.GetKey(input));
            }
            public bool IsPressed(object input)
            {
                if(!KeyConverter.ContainsInput(input)) return false;

                return KeyboardHardware.CurrentKeyDownEvent(KeyConverter.GetKey(input)) && KeyboardHardware.OldKeyUpEvent(KeyConverter.GetKey(input));
            }
            public bool IsReleased(object input)
            {
                if(!KeyConverter.ContainsInput(input)) return false;

                return KeyboardHardware.CurrentKeyUpEvent(KeyConverter.GetKey(input)) && KeyboardHardware.OldKeyDownEvent(KeyConverter.GetKey(input));
            }
        }
    }
}
