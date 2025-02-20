namespace WebApplication_FEB2025.Services
{
    public class RandomServiceSingleton : IRandomServiceSingleton
    {
        private readonly int _value;


        public int Value
        { 
            get => _value; 
        }

        public RandomServiceSingleton()
        {
            _value = new Random().Next(1000);
        }

    }
}
