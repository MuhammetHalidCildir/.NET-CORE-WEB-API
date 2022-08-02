using FluentValidation;
using NLayer.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Service.Validations
{
    public class ProductDtoValidator:AbstractValidator<ProductDto>
    {
        //[Required],[range] gibi Attributeları kullandıgımız zaman Entity veya Dtolarımızı kirletmiş oluyoruz mümkün oldugunca araları temiz tutmalıyız bu validation kısmını  tamamen ayrı bir yerde yapmamız gerekiyor.
        //FluentValidation Lİbrary kullanıcaz bizim modelimizi Fluent ile yer degiştiricez bu kod MVC dede geçerlidir. Validation Service katmanında bulunması lazım.
        public ProductDtoValidator()
        {

            RuleFor(x => x.Name).NotNull().WithMessage("{PropertyName} is required").NotEmpty().WithMessage("{PropertyName} is required");
            //RuleFor generic metot 
            RuleFor(x => x.Price).InclusiveBetween(1, int.MaxValue).WithMessage("{PropertyName} must be greater 0");
            RuleFor(x => x.Stock).InclusiveBetween(1, int.MaxValue).WithMessage("{PropertyName} must be greater 0");
            RuleFor(x => x.CategoryId).InclusiveBetween(1, int.MaxValue).WithMessage("{PropertyName} must be greater 0");
            //FluentValidation kendi verileni dönüyordu kendi filtrelerinizi yaparak kendi CustomResponse mızı döndürüceğiz.
        }


    }
}
