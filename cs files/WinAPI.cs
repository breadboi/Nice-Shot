using System;
using System.Runtime.InteropServices;

namespace TwitchPlaysSharp.Utilities.Windows
{
    public class WinAPI
    {
        #region P/Invokes

        [DllImport("User32.Dll", EntryPoint = "PostMessageA")]
        public static extern bool PostMessage(IntPtr hWnd, uint msg, int wParam, int lParam);

        [DllImport("user32.dll")]
        static extern void keybd_event(byte bVk, byte bScan, uint dwFlags,
        int dwExtraInfo);        

        #endregion P/Invokes      

        public static void PressKey(byte keyCode)
        {
            keybd_event(keyCode, 0, 0, 0);
            System.Threading.Thread.Sleep(100);
            keybd_event(keyCode, 0, KeyEvent.KeyUp, 0);
        }
    }

    public struct WindowMessage
    {
        public const uint WM_KEYDOWN = 0x100;
        public const uint WM_KEYUP = 0x101;
        public const uint WM_LBUTTONDOWN = 0x201;
        public const uint WM_LBUTTONUP = 0x202;
        public const uint WM_CHAR = 0x102;
    }

    public struct Key
    {
        //Mouse buttons
        public const byte MouseLeft = 0x01;
        public const byte MouseRight = 0x02;
        public const byte MouseMiddle = 0x04;

        //Control Keys
        public const byte Backspace = 0x08;
        public const byte Tab = 0x09;
        public const byte Enter = 0x0d;
        public const byte Shift = 0x10;
        public const byte Control = 0x11;
        public const byte Alt = 0x12;
        public const byte Escape = 0x1b;
        public const byte Space = 0x20;
        public const byte PageUp = 0x21;
        public const byte PageDown = 0x22;
        public const byte End = 0x23;
        public const byte Home = 0x24;
        public const byte Left = 0x25;
        public const byte Up = 0x26;
        public const byte Right = 0x27;
        public const byte Down = 0x28;
        public const byte PrintScreen = 0x2c;
        public const byte Insert = 0x2d;
        public const byte Delete = 0x2e;

        //Number row keys
        public const byte Num0 = 0x30;
        public const byte Num1 = 0x31;
        public const byte Num2 = 0x32;
        public const byte Num3 = 0x33;
        public const byte Num4 = 0x34;
        public const byte Num5 = 0x35;
        public const byte Num6 = 0x36;
        public const byte Num7 = 0x37;
        public const byte Num8 = 0x38;
        public const byte Num9 = 0x39;

        //Alphabet keys
        public const byte A = 0x41;
        public const byte B = 0x42;
        public const byte C = 0x43;
        public const byte D = 0x44;
        public const byte E = 0x45;
        public const byte F = 0x46;
        public const byte G = 0x47;
        public const byte H = 0x48;
        public const byte I = 0x49;
        public const byte J = 0x4a;
        public const byte K = 0x4b;
        public const byte L = 0x4c;
        public const byte M = 0x4d;
        public const byte N = 0x4e;
        public const byte O = 0x4f;
        public const byte P = 0x50;
        public const byte Q = 0x51;
        public const byte R = 0x52;
        public const byte S = 0x53;
        public const byte T = 0x54;
        public const byte U = 0x55;
        public const byte V = 0x56;
        public const byte W = 0x57;
        public const byte X = 0x58;
        public const byte Y = 0x59;
        public const byte Z = 0x5a;

        //Windows keys
        public const byte WindowsLeft = 0x5b;
        public const byte WindowsRight = 0x5c;

        //Numpad
        public const byte Numpad0 = 0x60;
        public const byte Numpad1 = 0x61;
        public const byte Numpad2 = 0x62;
        public const byte Numpad3 = 0x63;
        public const byte Numpad4 = 0x64;
        public const byte Numpad5 = 0x65;
        public const byte Numpad6 = 0x66;
        public const byte Numpad7 = 0x67;
        public const byte Numpad8 = 0x68;
        public const byte Numpad9 = 0x69;
        public const byte Multiply = 0x6a;
        public const byte Add = 0x6b;
        public const byte Subtract = 0x6d;
        public const byte Decimal = 0x6e;
        public const byte Divide = 0x6f;

        //Function keys
        public const byte F1 = 0x70;
        public const byte F2 = 0x71;
        public const byte F3 = 0x72;
        public const byte F4 = 0x73;
        public const byte F5 = 0x74;
        public const byte F6 = 0x75;
        public const byte F7 = 0x76;
        public const byte F8 = 0x77;
        public const byte F9 = 0x78;
        public const byte F10 = 0x79;
        public const byte F11 = 0x7a;
        public const byte F12 = 0x7b;

        //Non-typical Function keys
        public const byte F13 = 0x7c;
        public const byte F14 = 0x7d;
        public const byte F15 = 0x7e;
        public const byte F16 = 0x7f;
        public const byte F17 = 0x80;
        public const byte F18 = 0x81;
        public const byte F19 = 0x82;
        public const byte F20 = 0x83;
        public const byte F21 = 0x84;
        public const byte F22 = 0x85;
        public const byte F23 = 0x86;
        public const byte F24 = 0x87;

        //Extra shift keys
        public const byte ShiftLeft = 0xa0;
        public const byte ShiftRight = 0xa1;

        //Extra control keys
        public const byte ControlLeft = 0xa2;
        public const byte ControlRight = 0xa3;

        //OEM keys
        public const byte ColonsKey = 0xba; //OEM_1
        public const byte PlusEqualsKey = 0xbb; //OEM_PLUS
        public const byte CommaLeftAngleKey = 0xbc; //OEM_COMMA
        public const byte DashHyphonKey = 0xbd; //OEM_MINUS
        public const byte PeriodRightAngleKey = 0xbe; //OEM_PERIOD
        public const byte SlashQuestionkey = 0xbf; //OEM_2
        public const byte TildeKey = 0xc0; //OEM_3
        public const byte LeftBracketsKey = 0xdb; //OEM_4
        public const byte SlashPipeKey = 0xdc; //OEM_5
        public const byte RightBracketsKey = 0xdd; //OEM_6
        public const byte QuotesKey = 0xde; //OEM_7
    }

    public struct InputType
    {
        public const int Mouse = 0;
        public const int Keyboard = 1;
        public const int Hardware = 2;
    }

    public struct KeyEvent
    {
        public const uint ExtendedKey = 0x0001;
        public const uint KeyUp = 0x0002;
        public const uint Unicode = 0x0004;
        public const uint ScanCode = 0x0008;
    }

    public struct MouseEvent
    {
        public const uint Move = 0x0001;
        public const uint LeftDown = 0x0002;
        public const uint LeftUp = 0x0004;
        public const uint RightDown = 0x0008;
        public const uint RightUp = 0x0010;
        public const uint MiddleDown = 0x0020;
        public const uint MiddleUp = 0x0040;
        public const uint XDown = 0x0080;
        public const uint XUp = 0x0100;
        public const uint Wheel = 0x0800;
        public const uint VirtualDesk = 0x4000;
        public const uint Absolute = 0x8000;
    }

    public struct VirtualKeyMapType
    {
        public const uint VirtualKeyToScanCode = 0;
        public const uint ScanCodeToVirtualKey = 1;
        public const uint VirtualKeyToChar = 2;
        public const uint ScanCodeToVirtualKeyExtended = 3;
    }    
}