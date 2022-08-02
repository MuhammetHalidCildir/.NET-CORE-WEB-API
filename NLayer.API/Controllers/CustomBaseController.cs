using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayer.Core.DTOs;

namespace NLayer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomBaseController : ControllerBase
    {

        [NonAction]
        //CustomBaseController kodların Endpoint olmadıgını belirtmek için [NonAction] kullanıyoruz. 
        //yoksa Swagger bunu Endpoint olarak algılar ve olmadıgı için get veya post olmadıgı için patlar
        public IActionResult CreateActionResult<T>(CustomResponseDto<T> response)
        //dinamik olarak bir T alsın bir daha dönebilir  CustomResponseDto muzu alsın Generic bir method yazıyoruz.
        //status codelarımızı oluşturdukdan sonra ProductController'a miras vericez.
        {
            if (response.StatusCode == 204)
                return new ObjectResult(null)
                {
                    StatusCode = response.StatusCode
                };

            return new ObjectResult(response)
            {
                StatusCode = response.StatusCode
            };


        }
    }
}
