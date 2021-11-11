using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebApplication1.Controllers
{
    [Route("api/Readme")]
    [ApiController]

    public class ReadmeController1 : ControllerBase
    {
        private readonly ILogger<ReadmeController1> _logger;
        public ReadmeController1(ILogger<ReadmeController1> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                StringBuilder message = new StringBuilder("To get a Mars texture use this request:\n\n");
                message.Append("\thttps://localhost:44318/api/MarsTextures/{type}/{id}\n\n");
                message.Append("\tfor {type} use \"Color\", \"Normal\", or \"Topo\"\n");
                message.Append("\tfor {id} use \"1\" or \"2\" or \"3\" for 1k, 6k, or 12k resolution\n\n");
                message.Append("\tExample: https://localhost:44318/api/MarsTextures/Topo/1\n\n\n");

                message.Append("Otherwise, to get a Rover image use this request:\n\n");
                message.Append("\thttps://localhost:44318/api/RoverImages/{name}\n\n");
                message.Append("\tfor {name} give a rover name\n\n");
                message.Append("\tExample: https://localhost:44318/api/RoverImages/curiosity");



                OkObjectResult result = this.Ok(message.ToString());
                return result;
            }
            catch (Exception e)
            {
                OkObjectResult result = this.Ok(e.Message);
                return result;
            }
        }
    }
}
