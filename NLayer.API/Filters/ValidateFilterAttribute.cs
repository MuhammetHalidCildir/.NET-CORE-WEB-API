using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using NLayer.Core.DTOs;

namespace NLayer.API.Filters
{
 
    public class ValidateFilterAttribute :ActionFilterAttribute
    {
        //VAlidate kutuphanesi context üzerinde gelen model state ile entegredir biz FluentValidation kullanmasakda Validation hatalarını,
        //görmek için İsvalid üzerinden bir hata var mı yok mu kontrol edebiliriz eger burdan false geliyorsa hatalı
        public override void OnActionExecuting(ActionExecutingContext context)
        {
           if(!context.ModelState.IsValid)
            {
                var errors = context.ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList();
                //hataları ben alıyım Var errors  Context üzerinden ModelState üzerinden degerlerini alıyorum select many ile tek tek alıyorum lambda ile bu sınıftaki 
                // hataları ver bana lambdadan gelen sadece hata mesajlarını ver  ve lite geçir 

                context.Result = new BadRequestObjectResult(CustomResponseDto<NoContentDto>.Fail(400, errors));
                //Context üzerinden Resultını New hata clientin oldugundan 400 ile dönmemiz lazım server ise 500 

            }
        }
    }
}
