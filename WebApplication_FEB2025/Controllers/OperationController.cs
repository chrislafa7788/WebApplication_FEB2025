using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication_FEB2025.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationController : ControllerBase
    {
        [HttpGet]
        public int Get() { 
        
            return 10;
        
        }

        [HttpGet]
        [Route("api/Get2")]
        public int Get2()
        {

            return 10;

        }



        [HttpPost]
        public int Pepe( Numbers num, [FromHeader] string Host, [FromHeader(Name = "Content-Length")] string asdasd, [FromHeader(Name = "X-Some")] string asdasds)
        {

            return num.NumeroA + num.NumeroB +0;

        }





    }

    public class Numbers {

        public int NumeroA { get; set; }
        public int NumeroB { get; set; }
    }
}
