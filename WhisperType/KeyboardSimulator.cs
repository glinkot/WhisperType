using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace WhisperType
{
    public class KeyboardSimulator
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct INPUT
        {
            public uint type;
            public InputUnion U;
            public static int Size => Marshal.SizeOf(typeof(INPUT));
        }

        [StructLayout(LayoutKind.Explicit)]
        public struct InputUnion
        {
            [FieldOffset(0)]
            public KEYBDINPUT ki;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct KEYBDINPUT
        {
            public ushort wVk;
            public ushort wScan;
            public uint dwFlags;
            public uint time;
            public IntPtr dwExtraInfo;
            public uint padding; // Required only for 64-bit architectures
        }

        [DllImport("user32.dll", SetLastError = true)]
        public static extern uint SendInput(uint nInputs, INPUT[] pInputs, int cbSize);

        public const int INPUT_KEYBOARD = 1;
        public const uint KEYEVENTF_KEYDOWN = 0x0000;
        public const uint KEYEVENTF_UNICODE = 0x0004;
        public const uint KEYEVENTF_KEYUP = 0x0002;

        public static int DelayBetweenKeystrokesMS { get; set; } = 10;

        public static async void TypeText(string text)
        {
            foreach (char c in text)
            {
                INPUT[] input = new INPUT[2];

                // Key down event
                input[0].type = INPUT_KEYBOARD;
                input[0].U.ki.wVk = 0;
                input[0].U.ki.wScan = c;
                input[0].U.ki.dwFlags = KEYEVENTF_UNICODE | KEYEVENTF_KEYDOWN;
                input[0].U.ki.time = 0;
                input[0].U.ki.dwExtraInfo = IntPtr.Zero;

                // Key up event
                input[1].type = INPUT_KEYBOARD;
                input[1].U.ki.wVk = 0;
                input[1].U.ki.wScan = c;
                input[1].U.ki.dwFlags = KEYEVENTF_UNICODE | KEYEVENTF_KEYUP;
                input[1].U.ki.time = 0;
                input[1].U.ki.dwExtraInfo = IntPtr.Zero;

                // Send key events
                SendInput((uint)input.Length, input, INPUT.Size);

                // Delay between keystrokes
                await Task.Delay(DelayBetweenKeystrokesMS);
            }
        }


    }
}