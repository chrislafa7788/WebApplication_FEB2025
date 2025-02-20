using AutoMapper;
using WebApplication_FEB2025.DTOs;
using WebApplication_FEB2025.Models;

namespace WebApplication_FEB2025.AutoMappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BeerInsertDto, Beer>();
            CreateMap<Beer, BeerDto>()
                .ForMember(dto => dto.Id,
                m => m.MapFrom(b => b.BeerID));

            CreateMap<BeerUpdateDto, Beer>();


        }
    }
}
