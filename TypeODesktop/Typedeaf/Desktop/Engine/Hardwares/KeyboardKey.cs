namespace TypeOEngine.Typedeaf.Desktop.Engine.Hardwares
{
    /// <summary>Keyboard keys, using GLFW key codes.</summary>
    public enum KeyboardKey
    {
        /// <summary>An unknown key.</summary>
        Unknown = -1,
        /// <summary>The Space key.</summary>
        Space = 0x20,
        /// <summary>The Apostrophe key.</summary>
        Apostrophe = 39,
        /// <summary>The Comma key.</summary>
        Comma = 44,
        /// <summary>The Minus key.</summary>
        Minus = 45,
        /// <summary>The Period key.</summary>
        Period = 46,
        /// <summary>The Slash key.</summary>
        Slash = 47,
        /// <summary>The 0 key.</summary>
        D0 = 48,
        /// <summary>The 1 key.</summary>
        D1 = 49,
        /// <summary>The 2 key.</summary>
        D2 = 50,
        /// <summary>The 3 key.</summary>
        D3 = 51,
        /// <summary>The 4 key.</summary>
        D4 = 52,
        /// <summary>The 5 key.</summary>
        D5 = 53,
        /// <summary>The 6 key.</summary>
        D6 = 54,
        /// <summary>The 7 key.</summary>
        D7 = 55,
        /// <summary>The 8 key.</summary>
        D8 = 56,
        /// <summary>The 9 key.</summary>
        D9 = 57,
        /// <summary>The Semicolon key.</summary>
        Semicolon = 59,
        /// <summary>The Equal key.</summary>
        Equal = 61,
        /// <summary>The A key.</summary>
        A = 65,
        /// <summary>The B key.</summary>
        B = 66,
        /// <summary>The C key.</summary>
        C = 67,
        /// <summary>The D key.</summary>
        D = 68,
        /// <summary>The E key.</summary>
        E = 69,
        /// <summary>The F key.</summary>
        F = 70,
        /// <summary>The G key.</summary>
        G = 71,
        /// <summary>The H key.</summary>
        H = 72,
        /// <summary>The I key.</summary>
        I = 73,
        /// <summary>The J key.</summary>
        J = 74,
        /// <summary>The K key.</summary>
        K = 75,
        /// <summary>The L key.</summary>
        L = 76,
        /// <summary>The M key.</summary>
        M = 77,
        /// <summary>The N key.</summary>
        N = 78,
        /// <summary>The O key.</summary>
        O = 79,
        /// <summary>The P key.</summary>
        P = 80,
        /// <summary>The Q key.</summary>
        Q = 81,
        /// <summary>The R key.</summary>
        R = 82,
        /// <summary>The S key.</summary>
        S = 83,
        /// <summary>The T key.</summary>
        T = 84,
        /// <summary>The U key.</summary>
        U = 85,
        /// <summary>The V key.</summary>
        V = 86,
        /// <summary>The W key.</summary>
        W = 87,
        /// <summary>The X key.</summary>
        X = 88,
        /// <summary>The Y key.</summary>
        Y = 89,
        /// <summary>The Z key.</summary>
        Z = 90,
        /// <summary>The Left Bracket key.</summary>
        LeftBracket = 91,
        /// <summary>The Backslash key.</summary>
        Backslash = 92,
        /// <summary>The Right Bracket key.</summary>
        RightBracket = 93,
        /// <summary>The Grave Accent key.</summary>
        GraveAccent = 96,
        /// <summary>The Escape key.</summary>
        Escape = 0x100,
        /// <summary>The Enter key.</summary>
        Enter = 257,
        /// <summary>The Tab key.</summary>
        Tab = 258,
        /// <summary>The Backspace key.</summary>
        Backspace = 259,
        /// <summary>The Insert key.</summary>
        Insert = 260,
        /// <summary>The Delete key.</summary>
        Delete = 261,
        /// <summary>The Right arrow key.</summary>
        Right = 262,
        /// <summary>The Left arrow key.</summary>
        Left = 263,
        /// <summary>The Down arrow key.</summary>
        Down = 264,
        /// <summary>The Up arrow key.</summary>
        Up = 265,
        /// <summary>The Page Up key.</summary>
        PageUp = 266,
        /// <summary>The Page Down key.</summary>
        PageDown = 267,
        /// <summary>The Home key.</summary>
        Home = 268,
        /// <summary>The End key.</summary>
        End = 269,
        /// <summary>The Caps Lock key.</summary>
        CapsLock = 280,
        /// <summary>The Scroll Lock key.</summary>
        ScrollLock = 281,
        /// <summary>The Num Lock key.</summary>
        NumLock = 282,
        /// <summary>The Print Screen key.</summary>
        PrintScreen = 283,
        /// <summary>The Pause key.</summary>
        Pause = 284,
        /// <summary>The F1 key.</summary>
        F1 = 290,
        /// <summary>The F2 key.</summary>
        F2 = 291,
        /// <summary>The F3 key.</summary>
        F3 = 292,
        /// <summary>The F4 key.</summary>
        F4 = 293,
        /// <summary>The F5 key.</summary>
        F5 = 294,
        /// <summary>The F6 key.</summary>
        F6 = 295,
        /// <summary>The F7 key.</summary>
        F7 = 296,
        /// <summary>The F8 key.</summary>
        F8 = 297,
        /// <summary>The F9 key.</summary>
        F9 = 298,
        /// <summary>The F10 key.</summary>
        F10 = 299,
        /// <summary>The F11 key.</summary>
        F11 = 300,
        /// <summary>The F12 key.</summary>
        F12 = 301,
        /// <summary>The F13 key.</summary>
        F13 = 302,
        /// <summary>The F14 key.</summary>
        F14 = 303,
        /// <summary>The F15 key.</summary>
        F15 = 304,
        /// <summary>The F16 key.</summary>
        F16 = 305,
        /// <summary>The F17 key.</summary>
        F17 = 306,
        /// <summary>The F18 key.</summary>
        F18 = 307,
        /// <summary>The F19 key.</summary>
        F19 = 308,
        /// <summary>The F20 key.</summary>
        F20 = 309,
        /// <summary>The F21 key.</summary>
        F21 = 310,
        /// <summary>The F22 key.</summary>
        F22 = 311,
        /// <summary>The F23 key.</summary>
        F23 = 312,
        /// <summary>The F24 key.</summary>
        F24 = 313,
        /// <summary>The F25 key.</summary>
        F25 = 314,
        /// <summary>The keypad 0 key.</summary>
        KeyPad0 = 320,
        /// <summary>The keypad 1 key.</summary>
        KeyPad1 = 321,
        /// <summary>The keypad 2 key.</summary>
        KeyPad2 = 322,
        /// <summary>The keypad 3 key.</summary>
        KeyPad3 = 323,
        /// <summary>The keypad 4 key.</summary>
        KeyPad4 = 324,
        /// <summary>The keypad 5 key.</summary>
        KeyPad5 = 325,
        /// <summary>The keypad 6 key.</summary>
        KeyPad6 = 326,
        /// <summary>The keypad 7 key.</summary>
        KeyPad7 = 327,
        /// <summary>The keypad 8 key.</summary>
        KeyPad8 = 328,
        /// <summary>The keypad 9 key.</summary>
        KeyPad9 = 329,
        /// <summary>The keypad Decimal key.</summary>
        KeyPadDecimal = 330,
        /// <summary>The keypad Divide key.</summary>
        KeyPadDivide = 331,
        /// <summary>The keypad Multiply key.</summary>
        KeyPadMultiply = 332,
        /// <summary>The keypad Subtract key.</summary>
        KeyPadSubtract = 333,
        /// <summary>The keypad Add key.</summary>
        KeyPadAdd = 334,
        /// <summary>The keypad Enter key.</summary>
        KeyPadEnter = 335,
        /// <summary>The keypad Equal key.</summary>
        KeyPadEqual = 336,
        /// <summary>The Left Shift key.</summary>
        LeftShift = 340,
        /// <summary>The Left Control key.</summary>
        LeftControl = 341,
        /// <summary>The Left Alt key.</summary>
        LeftAlt = 342,
        /// <summary>The Left Super (Windows) key.</summary>
        LeftSuper = 343,
        /// <summary>The Right Shift key.</summary>
        RightShift = 344,
        /// <summary>The Right Control key.</summary>
        RightControl = 345,
        /// <summary>The Right Alt key.</summary>
        RightAlt = 346,
        /// <summary>The Right Super (Windows) key.</summary>
        RightSuper = 347,
        /// <summary>The Menu key.</summary>
        Menu = 348,
    }
}