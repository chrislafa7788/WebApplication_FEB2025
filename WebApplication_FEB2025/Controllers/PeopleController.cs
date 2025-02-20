using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication_FEB2025.Services;

namespace WebApplication_FEB2025.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private IPeopleService _peopleService;

        public PeopleController(IPeopleService peopleService)
        {
                _peopleService = peopleService;
        }

        [HttpGet("All")]
        public List<People> GetPeople() => Repository.People;

        [HttpGet("{id}")]
        public ActionResult<People> Get(int id) {
           
            var people= Repository.People.FirstOrDefault(p => p.Id == id);

            if (people==null)
            {
                return NotFound();
            }
            return Ok(people);
         }


        [HttpGet("search/{search}")]
        public List<People> Get(string search)
        {
            try
            {
                return Repository.People.Where(p => p.Name.Contains(search)).ToList();
            }
            catch (Exception ex)
            {
                return new List<People>() { };

            }
        }



        [HttpPost]
        public IActionResult Add(People people)
        {
            if (!_peopleService.Validate(people))
            {
                return BadRequest();
            }
            Repository.People.Add(people);
            return Ok();
        }

    }
}
