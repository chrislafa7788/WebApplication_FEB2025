using FluentValidation;
using WebApplication_FEB2025.DTOs;

namespace WebApplication_FEB2025.Validators
{
    public class BeerInsertValidator :AbstractValidator<BeerInsertDto>
    {
        public BeerInsertValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("El nombre es obligatorio");//que no venga null ni vacio.
            RuleFor(x => x.Name).Length(2,20).WithMessage("El nombre debe medir entre 2 y 20 caracteres");
            RuleFor(x => x.BrandId).NotNull().WithMessage("La marca es obligatorioa");
            RuleFor(x => x.BrandId).GreaterThan(0).WithMessage("Error con la marca enviada");
            RuleFor(x => x.Alcohol).GreaterThan(0).WithMessage("El {PropertyName} debe ser mayor a 0");


        }
    }
}
