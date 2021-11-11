using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebApplication1.Controllers
{
    /* https://localhost:44318/api/RoverImages/{name} */ // URL to call

    [Route("api/RoverImages")]
    [ApiController]

    public class RoverImageController : ControllerBase
    {
        private readonly ILogger<RoverImageController> _logger;

        private readonly string imagesPath = "images/rovers"; //Path to images
        public RoverImageController(ILogger<RoverImageController> logger)
        {
            _logger = logger;
        }

        [HttpGet("{name}")]
        public IActionResult Get(string name)
        {
            try
            {
                string filename = this.imagesPath + "/" + name + ".jpg";
                Byte[] b = System.IO.File.ReadAllBytes(filename);
                return File(b, "image/jpeg");
            }
            catch (Exception e)
            {
                OkObjectResult result = this.Ok(e.Message);
                return result;
            }
        }
    }
}
