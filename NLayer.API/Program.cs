using Autofac;
using Autofac.Extensions.DependencyInjection;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NLayer.API.Filters;
using NLayer.API.Middlewares;
using NLayer.API.Modules;
using NLayer.Core.Repositories;
using NLayer.Core.Services;
using NLayer.Core.UnitOfWorks;
using NLayer.Repository;
using NLayer.Repository.Repositories;
using NLayer.Repository.UnitOfWorks;
using NLayer.Service.Mapping;
using NLayer.Service.Services;
using NLayer.Service.Validations;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
// Configuration
// Add services to the container.

builder.Services.AddControllers(options =>  options.Filters.Add(new ValidateFilterAttribute())).AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<ProductDtoValidator>());

builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
    // her Fluent in kendi filtresini baskýlayýp kendi yaptýgýmýz filtreyi seçmeni saðlýyor.
});




// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMemoryCache();

builder.Services.AddScoped(typeof(NotFoundFilter<>));
//Çalýþabilmesi  Auto Mapper eklememiz lazým. Mapping için.
builder.Services.AddAutoMapper(typeof(MapProfile));



//bu Connection String kullanabilmesi için Ef.Core connection string bilgisini vermeliyim.
//bu istemi söyle yapýcaz API içindeki program.Cs services Kýsmýna  aþþagýdaki kod ile bilgimizi ulaþtýrýyoruz.
builder.Services.AddDbContext<AppDbContext>(x =>
{
    x.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"), option =>
    {
        option.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDbContext)).GetName().Name);
    });
});


builder.Host.UseServiceProviderFactory
    (new AutofacServiceProviderFactory());
//AutoFac (Ýnversion of control) Asp.net de dinamik  olarak servisleri eleme özelligimiz yok mesela þöyle yapamiyoruz.
//Sonu services ile biten tüm interfaceleri karþýlýk gelen ssonu services ile biten tüm classlarý ekle diyemiyoruz. AutoFac ile dinamic olarak
//DI containera nesne ekleme özelligi var. bu özellik için AUtofac.Dependency nugettan indiricez. 
builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder => containerBuilder.RegisterModule(new RepoServiceModule()));



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCustomException();


app.UseAuthorization();

app.MapControllers();

app.Run();
