using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
using WebApplication_FEB2025.DTOs;
using WebApplication_FEB2025.Models;
using WebApplication_FEB2025.Services;
using WebApplication_FEB2025.Validators;

namespace WebApplication_FEB2025.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeerController : ControllerBase
    {        
        private IValidator<BeerInsertDto> _beerInsertValidator;

        private IValidator<BeerUpdateDto> _beerUpdateValidator;

        private ICommonService<BeerDto,BeerInsertDto,BeerUpdateDto> _beerService;

        public BeerController(IValidator<BeerInsertDto> beerInsertValidator, 
            IValidator<BeerUpdateDto> beerUpdateValidator,
            [FromKeyedServices("beerService")]ICommonService<BeerDto, BeerInsertDto, BeerUpdateDto> beerService)
        {            
            _beerInsertValidator = beerInsertValidator;
            _beerUpdateValidator = beerUpdateValidator;
            _beerService = beerService;

        }

        [HttpGet]
        public async Task<IEnumerable<BeerDto>> Get() => await _beerService.Get();
           

        [HttpGet("{id}")]
        public async Task<ActionResult<BeerDto>> GetById(int id) {

           var beer = await _beerService.GetById(id);
            
           return beer != null ? Ok(beer) : NotFound();
        }


        [HttpPost]
        public async Task<ActionResult<BeerDto>> Add(BeerInsertDto beerInsertDto) {

            var validationResult = await _beerInsertValidator.ValidateAsync(beerInsertDto);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }


            if (!_beerService.ValidateInsert(beerInsertDto))
            {
                return BadRequest(_beerService.Errors);
            }


            var beerDto = await _beerService.Add(beerInsertDto);

            //este metodo CreatedAtAction posee 3 cosas, retorna en
            //un encabezado la url donde tu podrias obtener el
            //recurso GetById retorna el recurso si le mandas el id,
            //asi el front sabe como obtener el recurso, y el tercer
            //elemento es el dto y retorna el 201 ok tmb

            return CreatedAtAction(nameof(GetById), new { id= beerDto.Id }, beerDto);
        
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<BeerDto>> Update(int id, BeerUpdateDto beerUpdatetDto)
        {
            var validationRule = await _beerUpdateValidator.ValidateAsync(beerUpdatetDto);
            if (!validationRule.IsValid) {

                return BadRequest(validationRule.Errors);
            }

            if (!_beerService.ValidateUpdate(beerUpdatetDto))
            {
                return BadRequest(_beerService.Errors);
            }

            var beerDto = await _beerService.Update(id , beerUpdatetDto);

            return beerDto==null? NotFound(): Ok(beerDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<BeerDto>> Delete(int id)
        {
           var beerDto = await _beerService.Delete(id);

            return Ok(beerDto);
        }
    }
}
