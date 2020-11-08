using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConfigCommon;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ConfigWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigTypesController : ControllerBase
    {
        // GET: api/<ConfigTypesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            var baseType = typeof(ConfigBase);
            var configTypes = baseType.Assembly
                .GetTypes()
                .Where(type => type.IsSubclassOf(baseType))
                .Select(type => type.Name);
            return configTypes;
        }
    }
}
