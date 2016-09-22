using System;
using System.Speech.Synthesis;

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

    }
}