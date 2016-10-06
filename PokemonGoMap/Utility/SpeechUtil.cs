using System;
using System.Speech.Synthesis;
using System.Windows.Forms;
using System.Runtime.InteropServices;
namespace Pgmasst.Utility
{
    public class SpeechUtil
    {
        private static readonly SpeechSynthesizer Speaker;

        /// <summary>
        /// 0 to 100
        /// </summary>
        public int Volume
        {
            get { return Speaker.Volume; }
            set
            {
                if (value >= 0 && value <= 100)
                {
                    Speaker.Volume = value;
                }
            }
        }

        /// <summary>
        /// Speaking rate, range -10 to 10
        /// </summary>
        public int Rate
        {
            get { return Speaker.Rate; }
            set
            {
                if (value >= -10 && value <= 10)
                {
                    Speaker.Rate = value;
                }
            }
        }

        static SpeechUtil()
        {
            Speaker = new SpeechSynthesizer
            {
                Rate = 0,
                Volume = 100,
            };
        }

        public static void SpeakSync(string word)
        {
            Speaker.Speak(word);
        }

        public static void SpeakAsync(string word)
        {
            var ret = Speaker.SpeakAsync(word);         
        }


        private const int APPCOMMAND_VOLUME_MUTE = 0x80000;
        private const int APPCOMMAND_VOLUME_UP = 0xA0000;
        private const int APPCOMMAND_VOLUME_DOWN = 0x90000;
        private const int WM_APPCOMMAND = 0x319;

        [DllImport("user32.dll")]
        public static extern IntPtr SendMessageW(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);

        public static void Mute(IntPtr handle)
        {
            SendMessageW(handle, WM_APPCOMMAND, handle,
                (IntPtr)APPCOMMAND_VOLUME_MUTE);
        }

        public static void VolDown(IntPtr handle)
        {
            SendMessageW(handle, WM_APPCOMMAND, handle,
                (IntPtr)APPCOMMAND_VOLUME_DOWN);
        }

        public static void VolUp(IntPtr handle)
        {
            SendMessageW(handle, WM_APPCOMMAND, handle,
                (IntPtr)APPCOMMAND_VOLUME_UP);
        }
    }
}