namespace WebApplication_FEB2025.Services
{
    public class RandomServiceScoped : IRandomServiceScoped
    {
        private readonly int _value;


        public int Value
        { 
            get => _value; 
        }

        public RandomServiceScoped()
        {
            _value = new Random().Next(1000);
        }

    }
}
