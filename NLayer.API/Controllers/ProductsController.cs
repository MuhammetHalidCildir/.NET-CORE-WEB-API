using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NLayer.API.Filters;
using NLayer.Core;
using NLayer.Core.DTOs;
using NLayer.Core.Services;

namespace NLayer.API.Controllers
{


    public class ProductsController : CustomBaseController
    {
        //mapleme işlemini burda gerçekleştiricez.
        private readonly IMapper _mapper;
        private readonly IProductService _service;

        public ProductsController(IMapper mapper, IProductService productService)
        {
          
            _mapper = mapper;
            _service = productService;
        }


        /// GET api/products/GetProductsWithCategory
        [HttpGet("[action]")]
        public async Task<IActionResult>  GetProductsWithCategory()
        {

            return CreateActionResult(await _service.GetProductsWitCategory());
        }





        /// GET api/products
        [HttpGet]
        //All metodunun bizden ne istedigini belirtiyoruz
        public async Task<IActionResult> All()
        {
            var products = await _service.GetAllAsync();
            // productları serviceden alıyoruz  GetAll ile 
            var productsDtos = _mapper.Map<List<ProductDto>>(products.ToList());
            //productsDtos = Entity oldugu için Dtos dönmeli.
            return CreateActionResult(CustomResponseDto<List<ProductDto>>.Success(200, productsDtos));
            //böyle bir kodlama çirkin duruyor ama bizimde geriye bir durum kodu dönmemiz lazım , bunu tek tek oluşturmak yerine 
            //birtane BaseController oluşturalım ve bu dönme işlemi orda gerçekleştirelim.
        }

       
    [ServiceFilter(typeof(NotFoundFilter<Product>))] //burda ServiceFilter Attributene kendi filtremizi tip olarka veriyoruz.
        // GET /api/products/5
        [HttpGet("{id}")]
        //burda ise GetById nin bize ID getiricegini [HttpGet("{id}")] ile belirtmiş olduk.
        //Eğer belirtmeseydik ör: WWW.mysite.com/api/product/5 5 dersek Id si 5 olan data gelir o yüzden
        //GetById methodunun içine "var product = await _service.GetByIdAsync(id); olucak. 
        public async Task<IActionResult> GetById(int id)
        {

            
            var product = await _service.GetByIdAsync(id);
            var productsDto = _mapper.Map<ProductDto>(product);
            return CreateActionResult(CustomResponseDto<ProductDto>.Success(200, productsDto));
        }



        [HttpPost]
        public async Task<IActionResult> Save(ProductDto productDto)
        {
            var product = await _service.AddAsync(_mapper.Map<Product>(productDto));
            var productsDto = _mapper.Map<ProductDto>(product);
            return CreateActionResult(CustomResponseDto<ProductDto>.Success(201, productsDto));
        }


        [HttpPut]
        public async Task<IActionResult> Update(ProductUpdateDto productDto)
        {
             await _service.UpdateAsync(_mapper.Map<Product>(productDto));
          
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
            //NoContentDto boş döncegini bildigimiz için boş data yolladık.
        }

        // DELETE api/products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var product = await _service.GetByIdAsync(id);
            //GetByIdAsync silecegimiz eşyayı getiriyor


         

            await _service.RemoveAsync(product);
          
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

    }
}
