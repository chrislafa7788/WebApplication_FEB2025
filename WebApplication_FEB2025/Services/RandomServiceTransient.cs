namespace WebApplication_FEB2025.Services
{
    public class RandomServiceTransient : IRandomServiceTransient
    {
        private readonly int _value;


        public int Value
        { 
            get => _value; 
        }

        public RandomServiceTransient()
        {
            _value = new Random().Next(1000);
        }

    }
}
