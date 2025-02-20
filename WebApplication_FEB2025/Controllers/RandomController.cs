using Microsoft.AspNetCore.Mvc;
using WebApplication_FEB2025.Services;

namespace WebApplication_FEB2025.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RandomController : Controller
    {
        private IRandomServiceSingleton _randomServiceSingleton;
        private IRandomServiceScoped _randomServiceScoped;
        private IRandomServiceTransient _randomServiceTransient;

        private IRandomServiceSingleton _randomService2Singleton;
        private IRandomServiceScoped _randomService2Scoped;
        private IRandomServiceTransient _randomService2Transient;

        public RandomController( IRandomServiceSingleton randomServiceSingleton, 
            IRandomServiceSingleton randomServiceSingleton2 ,
            IRandomServiceScoped randomServiceScoped , IRandomServiceScoped randomServiceScoped2,
            IRandomServiceTransient randomServiceTransient , IRandomServiceTransient randomServiceTransient2
            )
        {
            _randomServiceSingleton = randomServiceSingleton;
            _randomServiceScoped = randomServiceScoped;
            _randomServiceTransient = randomServiceTransient;
            _randomService2Singleton = randomServiceSingleton2;
            _randomService2Scoped = randomServiceScoped2;
            _randomService2Transient = randomServiceTransient2;

        }
        [HttpGet]
        public ActionResult<Dictionary<string,int>> Get()
        {

           var result = new Dictionary<string, int>();
            result.Add("Singleton 1 :", _randomServiceSingleton.Value);
            result.Add("Singleton 2 :", _randomService2Singleton.Value);

            result.Add("Scoped 1 :", _randomServiceScoped.Value);
            result.Add("Scoped 2 :", _randomService2Scoped.Value);

            result.Add("Transient 1 :", _randomServiceTransient.Value);
            result.Add("Transient 2 :", _randomService2Transient.Value);


            return result;

        }


    }
}
