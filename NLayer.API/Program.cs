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
    // her Fluent in kendi filtresini bask�lay�p kendi yapt�g�m�z filtreyi se�meni sa�l�yor.
});




// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMemoryCache();

builder.Services.AddScoped(typeof(NotFoundFilter<>));
//�al��abilmesi  Auto Mapper eklememiz laz�m. Mapping i�in.
builder.Services.AddAutoMapper(typeof(MapProfile));



//bu Connection String kullanabilmesi i�in Ef.Core connection string bilgisini vermeliyim.
//bu istemi s�yle yap�caz API i�indeki program.Cs services K�sm�na  a��ag�daki kod ile bilgimizi ula�t�r�yoruz.
builder.Services.AddDbContext<AppDbContext>(x =>
{
    x.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"), option =>
    {
        option.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDbContext)).GetName().Name);
    });
});


builder.Host.UseServiceProviderFactory
    (new AutofacServiceProviderFactory());
//AutoFac (�nversion of control) Asp.net de dinamik  olarak servisleri eleme �zelligimiz yok mesela ��yle yapamiyoruz.
//Sonu services ile biten t�m interfaceleri kar��l�k gelen ssonu services ile biten t�m classlar� ekle diyemiyoruz. AutoFac ile dinamic olarak
//DI containera nesne ekleme �zelligi var. bu �zellik i�in AUtofac.Dependency nugettan indiricez. 
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
