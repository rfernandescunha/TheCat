using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheCat.Domain.Entities;

namespace TheCat.Domain.Validation.AnuncioTheCat
{
    public class BreedsImagesUpdate : AbstractValidator<BreedsImages>
    {
        public BreedsImagesUpdate()
        {
            RuleFor(a => a.id)
            .NotEmpty()
            .WithMessage("Id é campo obrigatorio")
            .WithMessage("Id não pode ser 0");


            //RuleFor(a => a.Marca)
            //    .NotEmpty()
            //    .WithMessage("Marca é campo obrigatorio")
            //    .MaximumLength(45)
            //    .WithMessage("Marca deve conter 45 no maximo caracteres")
            //    .MinimumLength(3)
            //    .WithMessage("Marca deve conter 3 no minimo caracteres");


            //RuleFor(a => a.Modelo)
            //    .NotEmpty()
            //    .WithMessage("Modelo é campo obrigatorio")
            //    .MaximumLength(45)
            //    .WithMessage("Modelo deve conter 45 no maximo caracteres")
            //    .MinimumLength(3)
            //    .WithMessage("Modelo deve conter 3 no minimo caracteres");

            //RuleFor(a => a.Versao)
            //    .NotEmpty()
            //    .WithMessage("Versao é campo obrigatorio")
            //    .MaximumLength(45)
            //    .WithMessage("Versao deve conter 45 no maximo caracteres")
            //    .MinimumLength(3)
            //    .WithMessage("Versao deve conter 3 no minimo caracteres");

            //RuleFor(a => a.Ano)
            //    .NotEmpty()
            //    .WithMessage("Ano é campo obrigatorio");

            //RuleFor(a => a.Quilometragem)
            //    .NotEmpty()
            //    .WithMessage("Quilometragem é campo obrigatorio");

            //RuleFor(a => a.Observacao)
            //    .NotEmpty()
            //    .WithMessage("Observacao é campo obrigatorio")
            //    .MinimumLength(3)
            //    .WithMessage("Observacao deve conter 3 no minimo caracteres");
        }
    }
}
