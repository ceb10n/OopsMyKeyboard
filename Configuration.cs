namespace OopsMyKeyboard
{
    public class Configuration
    {
        public int maxCharBeforeLog { get; set; }
        public Log log { get; set; }
        public Email email { get; set; }
    }

    public class Log
    {
        public bool logToFile { get; set; }
        public bool hidden { get; set; }
        public string location { get; set; }
    }

    public class Email
    {
        public bool sendEmail { get; set; }
        public string smpt { get; set; }
        public int port { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string to { get; set; }
    }
}
