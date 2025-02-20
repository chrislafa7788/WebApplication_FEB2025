using AutoMapper;
using WebApplication_FEB2025.Controllers;
using WebApplication_FEB2025.DTOs;
using WebApplication_FEB2025.Models;
using WebApplication_FEB2025.Repository;
using WebApplication_FEB2025.Validators;

namespace WebApplication_FEB2025.Services
{
    public class BeerService : ICommonService<BeerDto, BeerInsertDto, BeerUpdateDto>
    {
        private IRepository<Beer> _beerRepository;
        private IMapper _mapper;
        public List<string> Errors { get; }

        public BeerService(IRepository<Beer> beerRepository, IMapper mapper)
        {
            _beerRepository = beerRepository;
            _mapper = mapper;
            Errors = new List<string>();
        }

        public async Task<IEnumerable<BeerDto>> Get()
        {
            var beers = await _beerRepository.Get();

            return beers.Select(b => _mapper.Map<BeerDto>(b) );

        }
        public async Task<BeerDto> GetById(int id)
        {
            var beer = await _beerRepository.GetById(id);

            if (beer!=null)
            {
                var beerDto = _mapper.Map<BeerDto>(beer);
                return beerDto;
            }
            return null;
           
        }
        public async Task<BeerDto> Add(BeerInsertDto beerInsertDto)
        {

            var beer = _mapper.Map<Beer>(beerInsertDto);

            await _beerRepository.Add(beer);
            await _beerRepository.Saver();

            //ya tengo el id aca

            var beerDto = _mapper.Map<BeerDto>(beer);

            return beerDto;
        }

        public async Task<BeerDto> Update(int id, BeerUpdateDto beerUpdated)
        {

            var beer = await _beerRepository.GetById(id);

            if (beer != null) {


                beer = _mapper.Map<BeerUpdateDto, Beer>(beerUpdated, beer);             

                _beerRepository.Update(beer);
                await _beerRepository.Saver();

                var beerDto = _mapper.Map<BeerDto>(beer);

                return (beerDto);
            }
            return null;
        }

        public async Task<BeerDto> Delete(int id)
        {
            var beer = await _beerRepository.GetById(id);

            if (beer == null)
            {
                return null;
            }
            //ANTES de eliminar lo lleno asi no se pide el objeto. Igual lo probe y en .net6 NO se pierde el objeto.
            var beerDto = _mapper.Map<BeerDto>(beer);

            _beerRepository.Delete(beer);
            _beerRepository.Saver();

            return (beerDto);
        }

        public bool ValidateInsert(BeerInsertDto dto)
        {
            if (_beerRepository.Search(b=>b.Name == dto.Name).Count()>0)
            {
                Errors.Add("No puede existir una cerveza con un nombre ya existente");
                return false;
            }
            return true;
        }

        public bool ValidateUpdate(BeerUpdateDto dto)
        {
            if (_beerRepository.Search(b => b.Name == dto.Name  
            && dto.Id != b.BeerID // asi no es el mismo , q no sea la misma entidad. esto es un update.
            ).Count() > 0)
            {
                Errors.Add("No puede existir una cerveza con un nombre ya existente");
                return false;
            }
            return true;
        }
    }
}
