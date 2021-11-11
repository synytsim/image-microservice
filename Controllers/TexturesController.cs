using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebApplication1.Controllers
{
    /* https://localhost:44318/api/MarsTextures/Resolution/{type}/{id} */ // URL to call

    [Route("api/MarsTextures")]
    [ApiController]

    public class TexturesController : ControllerBase
    {
        private readonly ILogger<TexturesController> _logger;

        private readonly string imagesPath = "images/textures"; //Path to images
        public TexturesController(ILogger<TexturesController> logger)
        {
            _logger = logger;
        }

        [HttpGet("{type}/{id}")]
        public IActionResult Get(string type, int id)
        {
            try
            {
                string filename = this.imagesPath + "/mars" + type + id.ToString() + ".jpg";
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
