using AutoMapper;
using NLayer.Core;
using NLayer.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Service.Mapping
{
    public class MapProfile : Profile
    {
        // Otamatik olarak entityleri DTO ,DTO ları entity yapıcaz.
        // Service katmanına nugettan AutoMapper yüklicez."AutoMapper.Extansions.Micrasoft.Dependency.İnjection"
        //Çalışabilmesi için Nlayer Apı içinde Builder kısmına Auto Mapper eklememiz lazım. "builder.service.AddAutoMapper(TypeOf(MapProfile));" uygulamayı derlicez ve auto mapper hazır olmuş olucak.

        public MapProfile()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<ProductFeature, ProductFeatureDto>().ReverseMap();
            CreateMap<ProductUpdateDto, Product>();
            //ReverseMap yapmamıza gerek yok çünkü herhangi bir yerden entity dönüştürmek yeterli
            CreateMap<Product, ProductWithCategoryDto>();
            CreateMap<Category, CategoryWithProductsDto>();
        }
    }
}
