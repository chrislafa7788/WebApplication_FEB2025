namespace WebApplication_FEB2025.Controllers
{
    public class Repository
    {

        public static List<People> People = new List<People>(){
        new People() {
            Id = 1, Name = "nombre1", Bday = new DateTime(1990,2,2) 
        }, new People() { 
            Id = 2, Name = "nombre1", Bday = new DateTime(1990,2,2) 
        }, new People() {  
            Id = 3, Name = "nombre1", Bday = new DateTime(1990,2,2) 
        }, new People() {  
            Id = 4, Name = "nombre1", Bday = new DateTime(1990,2,2) 
        }

        };
    }
}
