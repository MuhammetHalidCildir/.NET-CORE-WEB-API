using AutoMapper;
using NLayer.Core;
using NLayer.Core.DTOs;
using NLayer.Core.Repositories;
using NLayer.Core.Services;
using NLayer.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Service.Services
{
    public class ProductServiceWithNoCaching : Service<Product>, IProductService
    {
        private readonly IProductRepository _productRepository;
        //Product service geldigimde benim Product Repository erişmem lazım o yüzden bu kodu yazıyoruz.  
        private readonly IMapper _mapper;
        //Mapleme işlemi içinde yapıyoruz.
        public ProductServiceWithNoCaching(IGenericRepository<Product> repository, IUnitOfWork unitOfWork, IMapper mapper, IProductRepository productRepository) : base(repository, unitOfWork)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<CustomResponseDto<List<ProductWithCategoryDto>>> GetProductsWitCategory()
        {
            //bu metot geri dönüşü list dönüyor ama biz burda direk CustomReponse dönelim madem
            //Apı bizden CustomResponse bekliyor biz bu kodu productsController da oluşturmayalım direk olarak Product Servicede yapalım
            var products = await _productRepository.GetProductsWitCategory();
           
            var productsDto= _mapper.Map<List<ProductWithCategoryDto>>(products);
            return CustomResponseDto<List<ProductWithCategoryDto>>.Success(200, productsDto);

        }
    }
}
