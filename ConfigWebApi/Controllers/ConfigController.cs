using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConfigCommon;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ConfigWebApi.Controllers
{
    [ApiController]
    public class ConfigController<TConfig> : ControllerBase
        where TConfig : ConfigBase
    {
        AppSettings _settings;

        public ConfigController(IOptions<AppSettings> appSettingsOptions)
        {
            _settings = appSettingsOptions.Value;
        }

        [HttpGet("{name}")]
        public TConfig Get(string name)
        {
            try
            {
                var repo = new ConfigRepository<TConfig>(_settings.ConfigsPath);
                return repo.FindByName(name);
            }
            catch
            {
                return null;
            }
        }

        [HttpPut("{name}")]
        public void Put(string name, [FromBody] TConfig config)
        {
            var repo = new ConfigRepository<TConfig>(_settings.ConfigsPath);
            repo.Update(name, config);
        }
    }
}
