using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Scrambler
{
    public class ScramblerViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _encodeMessage = "";
        private string _keyEncode = "";
        private string _resultEncode = "";

        private string _decodeMessage = "";
        private string _keyDecode = "";


        public string EncodeMessage
        {
            get { return _encodeMessage; }
            set
            {
                _encodeMessage = value;
                OnPropertyChanged("KeyEncode");
                OnPropertyChanged("ResultEncode");
            }
        }

        public string KeyEncode
        {
            get { return GetKey(_encodeMessage); }
            set { _keyEncode = value; }
        }

        public string ResultEncode
        {
            get { return Encode(EncodeMessage); }
            set { _resultEncode = value; }
        }


        public string DecodeMessage
        {
            get { return _decodeMessage; }
            set
            {
                _decodeMessage = value;
                OnPropertyChanged("ResultDecode");
            }
        }

        public string KeyDecode
        {
            get { return _keyDecode; }
            set
            {
                _keyDecode = value;
                OnPropertyChanged("ResultDecode");
            }
        }

        public string ResultDecode
        {
            get { return Decode(_decodeMessage, _keyDecode); }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

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
            {"H", "0101"}, {"P", "110101"}, {" ", " "}
        };

        public static readonly Dictionary<string, string> decodeDictionary = new Dictionary<string, string>
        {
            {"100", "E"},  {"11011", "D"}, {"011101", "W"},
            {"001", "T"},  {"01111", "L"}, {"011100", "B"},
            {"1111", "A"}, {"01001", "F"}, {"1101001", "V"},
            {"1110", "O"}, {"01000", "C"}, {"110100011", "K"},
            {"1100", "N"}, {"00011", "M"}, {"110100001", "X"},
            {"1011", "R"}, {"00010", "U"}, {"110100000", "J"},
            {"1010", "I"}, {"00001", "G"}, {"1101000101", "Q"},
            {"0110", "S"}, {"00000", "Y"}, {"1101000100", "Z"},
            {"0101", "H"}, {"110101", "P"}, {" ", " "}
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
                try
                {
                    result += encodeDictionary[i.ToString()];
                }
                catch (Exception)
                {
                }
            }

            return result;
        }

        public static string GetKey(string message)
        {
            string key = "";
            char[] text = message.ToUpper().ToCharArray();

            foreach (var i in text)
            {
                try
                {
                    key += encodeDictionary[i.ToString()].Length.ToString();
                }
                catch (Exception)
                {
                }
            }

            return key;
        }

        public static string Decode(string message, string key)
        {
            int index = 0;
            string result = "";
                    string text = "";
            for (int i = 0; i < key.Length; i++)
            {
                try
                {
                    int l = int.Parse(key[i].ToString());
                    text = message.Substring(index, l);
                    index += l;

                    result += decodeDictionary[text];

                }
                catch (Exception)
                {

                }
            }

            return result;
        }
    }
}
