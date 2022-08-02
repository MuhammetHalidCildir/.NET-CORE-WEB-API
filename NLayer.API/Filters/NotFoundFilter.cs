using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using NLayer.Core;
using NLayer.Core.DTOs;
using NLayer.Core.Services;

namespace NLayer.API.Filters
{
    public class NotFoundFilter<T> :IAsyncActionFilter where T : BaseEntity
    {

        private readonly IService<T> _service;

        public NotFoundFilter(IService<T> service)
        {
            _service = service;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {

            var idValue = context.ActionArguments.Values.FirstOrDefault();
            //context bizim uygulamamızın kalbi tüm bu Contextten reques ve response ulaşabilmesi
            //ActionArguments.isimli propertyden Values.üzerinden FirstOrDefault ile ilk property al. 

            if (idValue == null)
            {
                await next.Invoke();
                return;
                // eger null ise yoluna devam et diyoruz ve gireden daha aşşagı inmesine gerek olmadıgını söglüyoruz.
            }

            var id = (int)idValue;
            var anyEntity = await _service.AnyAsync(x => x.Id == id);
            // Entity var mı yokmu onu kontorl edicez kontrol edebilmemiz için service katmanına ihtiyacımız var bu yüzden üstte classın içine.
            // private readonly IService<T> _service; constructor etmeliyiz 

            if (anyEntity)
            {
                await next.Invoke();
                return;
            }

            context.Result = new NotFoundObjectResult(CustomResponseDto<NoContentDto>.Fail(404, $"{typeof(T).Name}({id}) not found"));
          
        }
    }
}
