using Microsoft.EntityFrameworkCore;
using WebApplication_FEB2025.Models;

namespace WebApplication_FEB2025.Repository
{
    public class BeerRepository : IRepository<Beer>
    {
        private StoreContext _context;
        public BeerRepository(StoreContext context)
        {
            _context = context; 
        }
        public async Task<IEnumerable<Beer>> Get()
            => await _context.Beers.ToListAsync();
        

        public async Task<Beer> GetById(int id)        
            => await _context.Beers.FindAsync(id);
        
        public async Task Add(Beer beer)
            => await _context.Beers.AddAsync(beer);            
        

        public async Task Saver()
        => await _context.SaveChangesAsync();
            
        

        public void Update(Beer entity)
        {
            _context.Beers.Attach(entity);
            _context.Beers.Entry(entity).State = EntityState.Modified;
        }
        public void Delete(Beer beer)
        => _context.Beers.Remove(beer);

        public IEnumerable<Beer> Search(Func<Beer,bool> filter) =>
            _context.Beers.Where(filter).ToList();
    }
}
