using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Scrambler
{
    public class ScramblerViewModel
    {
        public string DecodeText { get; set; }
        public string EncodeText { get; set; }
        public string Key { get; set; }
        public string ResultEncode { get; set; }
        public string ResultDecode { get; set; }

        public static readonly Dictionary<string, string> encodeDictionary = new Dictionary<string, string>
        {
            {"E", "100"},  {"D", "11011"}, {"W", "011101"},
            {"T", "001"},  {"L", "01111"}, {"B", "011100"},
            {"A", "1111"}, {"F", "01001"}, {"V", "1101001"},
            {"O", "1110"}, {"C", "01000"}, {"K", "110100011"},
            {"N", "1100"}, {"M", "00011"}, {"X", "110100001"},
            {"R", "1011"}, {"U", "00010"}, {"J", "110100000"},
            {"I", "1010"}, {"G", "00001"}, {"Q", "1101000101"},
            {"S", "0110"}, {"Y", "00000"}, {"Z", "1101000100"},
            {"H", "0101"}, {"P", "110101"},
        };

        public ScramblerViewModel()
        {

        }

        public static string Encode(string message)
        {
            string result = "";
            char[] text = message.ToUpper().ToCharArray();

            foreach (var i in text)
            {
                result += encodeDictionary[i.ToString()];
            }

            return result;
        }

        public static string GetKey(string message)
        {
            string key = "";
            char[] text = message.ToUpper().ToCharArray();

            foreach (var i in text)
            {
                key += encodeDictionary[i.ToString()].Length.ToString();
            }

            return key;
        }

        public static string Decode(string message, string key)
        {
            int index = 0;
            string result = "";
            char[] keyArray = key.ToCharArray();
            foreach (var i in keyArray)
            {

                char[] text = message.ToUpper().ToCharArray(index, i);
                index += i;

                foreach (var s in text)
                {
                    result += encodeDictionary[s.ToString()].Length.ToString(); // работает по ключу, а нужно по значению. Либо поменять словарь.
                }
            }

            return result.ToString();
        }
    }
}
