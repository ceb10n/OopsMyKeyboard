using Newtonsoft.Json;
using System.IO;

namespace OopsMyKeyboard.Service
{
    public class ConfigurationService
    {
        private readonly string _path;
        public ConfigurationService(string path)
        {
            _path = path;
        }

        public Configuration Load()
        {
            var cfgFile = File.ReadAllText(_path);

            return JsonConvert.DeserializeObject<Configuration>(cfgFile);
        }
    }
}
