using WebApplication_FEB2025.DTOs;
using WebApplication_FEB2025.Models;

namespace WebApplication_FEB2025.Services
{
    public interface ICommonService<T,TI,TU>
    {
        public List<string> Errors { get; }//solo la obtenemos.
        Task<IEnumerable<T>> Get();
        Task<T> GetById(int id);
        Task<T> Add(TI beerInsertDto);
        Task<T> Update(int id, TU beer);
        Task<T> Delete(int id);
        bool ValidateInsert(TI dto);
        bool ValidateUpdate(TU dto);
    }
}
