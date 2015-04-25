using System;
using System.IO;

namespace OopsMyKeyboard.Service
{
    public class FileService
    {
        private readonly Log _log;

        public FileService(Log log)
        {
            _log = log;       
        }

        public async void LogToFile(string text)
        {
            {
                var filePath = String.Format("{0}{1}.log", @_log.location, DateTime.Now.ToString("ddMMyyyyhhmmss"));
                var writer = new StreamWriter(filePath, true);

                await writer.WriteAsync(text);
                writer.Close();

                if (_log.hidden)
                    File.SetAttributes(filePath, File.GetAttributes(filePath) | FileAttributes.Hidden);
            }
        }
    }
}
