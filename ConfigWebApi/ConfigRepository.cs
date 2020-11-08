using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ConfigCommon;

namespace ConfigWebApi
{
    public class ConfigRepository<TConfig> : IConfigRepository<TConfig>
        where TConfig : ConfigBase
    {
        public string ConfigsPath { get; }

        public ConfigRepository(string configsPath)
        {
            ConfigsPath = configsPath;
        }

        public TConfig FindByName(string name)
        {
            var file = FindFileByName(name);

            var configJson = File.ReadAllText(Path.Combine(ConfigsPath, $"{name}.json"));
            try
            {
                var jSettings = new JsonSerializerSettings()
                {
                    MissingMemberHandling = MissingMemberHandling.Error
                };
                return JsonConvert.DeserializeObject<TConfig>(configJson, jSettings);
            }
            catch (JsonException jex)
            {
                throw new ConfigException("Invalid config type", jex);
            }
        }

        public void Update(string name, TConfig config)
        {
            var file = FindFileByName(name);

            var configJson = JsonConvert.SerializeObject(config, Formatting.Indented);
            File.WriteAllText(file, configJson);
        }

        private string FindFileByName(string name)
        {
            var file = Directory.EnumerateFiles(ConfigsPath)
                .FirstOrDefault(f => Path.GetFileNameWithoutExtension(f) == name);
            if (file == null) throw new ConfigException($"Config {name} not found by its name");
            return file;
        }
    }
}
