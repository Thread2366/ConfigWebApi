using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ConfigCommon;
using Microsoft.AspNetCore.Hosting;
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
        IWebHostEnvironment _env;

        public ConfigController(IOptions<AppSettings> appSettingsOptions, IWebHostEnvironment env)
        {
            _settings = appSettingsOptions.Value;
            _env = env;
        }

        [HttpGet("{name}")]
        public TConfig Get(string name)
        {
            var repo = GetRepo();
            return repo.FindByName(name);
        }

        [HttpPut("{name}")]
        public void Put(string name, [FromBody] TConfig config)
        {
            var repo = GetRepo();
            repo.Update(name, config);
        }

        private ConfigRepository<TConfig> GetRepo()
        {
            return new ConfigRepository<TConfig>(
                Path.Combine(_env.ContentRootPath, _settings.ConfigsPath));
        }
    }
}
