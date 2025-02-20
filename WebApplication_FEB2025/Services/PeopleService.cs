using WebApplication_FEB2025.Controllers;

namespace WebApplication_FEB2025.Services
{
    public class PeopleService : IPeopleService
    {
        public bool Validate(People people)
        {
            if (string.IsNullOrEmpty(people.Name))
            {

                return false;
            }
            return true;
        }
    }
}
