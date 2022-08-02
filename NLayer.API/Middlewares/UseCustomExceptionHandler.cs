using Microsoft.AspNetCore.Diagnostics;
using NLayer.Core.DTOs;
using NLayer.Service.Exceptions;
using System.Text.Json;

namespace NLayer.API.Middlewares
{
    public static class UseCustomExceptionHandler
    {
        // uygulama herhangi bir hata yollandıgında uygulama o hatayı yakalar API uygulamasında geriye response dönücegiz error sayfası.
        //Exception methodu yazmak için classs ve methodlar static olmalı.
       //dönücegimiz hata mesajlarını oluşturdugumuz yer 400 404 500 gibi istedigimiz kadar oluşturabiliriz.
       //kendimiz middleware döndügümüz için Json dönüyoruz.
        public static void UseCustomException(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(config =>
            {

                config.Run(async context =>
                {
                    context.Response.ContentType = "application/json";

                    var exceptionFeature = context.Features.Get<IExceptionHandlerFeature>();

                    var statusCode = exceptionFeature.Error switch
                    {
                        ClientSideException => 400,
                        NotFoundExcepiton=> 404,
                        _ => 500
                    };
                    context.Response.StatusCode = statusCode;


                    var response = CustomResponseDto<NoContentDto>.Fail(statusCode, exceptionFeature.Error.Message);


                    await context.Response.WriteAsync(JsonSerializer.Serialize(response));

                });










            });





        }
    }
}
