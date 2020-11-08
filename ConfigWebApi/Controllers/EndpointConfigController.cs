using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConfigCommon;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ConfigWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EndpointConfigController : ConfigController<EndpointConfig>
    {
        public EndpointConfigController(IOptions<AppSettings> appSettingsOptions, IWebHostEnvironment env) 
            : base(appSettingsOptions, env) { }
    }
}
