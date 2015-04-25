namespace OopsMyKeyboard.Service
{
    public class LogService
    {
        private readonly EmailService _emailService;
        private readonly FileService _fileService;
        private readonly Configuration _configuration;
        private readonly TextBuffer _buffer;

        public LogService(Configuration configuration)
        {
            _configuration = configuration;
            _emailService = new EmailService(configuration.email);
            _fileService = new FileService(configuration.log);

            _buffer = new TextBuffer(configuration.maxCharBeforeLog);
            _buffer.BufferOverflowed += _buffer_BufferOverflowed;
        }

        public void AddEntryToLog(string text)
        {
            _buffer.Add(text);
        }

        private void _buffer_BufferOverflowed(string text)
        {
            if (_configuration.email.sendEmail)
                _emailService.SendIfInternetIsAvailable(text);

            if (_configuration.log.logToFile)
                _fileService.LogToFile(text);
        }
    }
}
