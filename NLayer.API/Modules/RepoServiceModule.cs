using Autofac;
using NLayer.Caching;
using NLayer.Core.Repositories;
using NLayer.Core.Services;
using NLayer.Core.UnitOfWorks;
using NLayer.Repository;
using NLayer.Repository.Repositories;
using NLayer.Repository.UnitOfWorks;
using NLayer.Service.Mapping;
using NLayer.Service.Services;
using System.Reflection;
using Module = Autofac.Module;
namespace NLayer.API.Modules
{
    public class RepoServiceModule:Module
    {
        //AutoFac (İnversion of control) Asp.net de dinamik  olarak servisleri eleme özelligimiz yok mesela şöyle yapamiyoruz.
        //Sonu services ile biten tüm interfaceleri karşılık gelen ssonu services ile biten tüm classları ekle diyemiyoruz. AutoFac ile dinamic olarak
        //DI containera nesne ekleme özelligi var. bu özellik için AUtofac.Dependency nugettan indiricez. 
        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IGenericRepository<>)).InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(Service<>)).As(typeof(IService<>)).InstancePerLifetimeScope();

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();



            var apiAssembly = Assembly.GetExecutingAssembly();
            var repoAssembly = Assembly.GetAssembly(typeof(AppDbContext));
            var serviceAssembly = Assembly.GetAssembly(typeof(MapProfile));

            builder.RegisterAssemblyTypes(apiAssembly, repoAssembly, serviceAssembly).Where(x => x.Name.EndsWith("Repository")).AsImplementedInterfaces().InstancePerLifetimeScope();


            builder.RegisterAssemblyTypes(apiAssembly, repoAssembly, serviceAssembly).Where(x => x.Name.EndsWith("Service")).AsImplementedInterfaces().InstancePerLifetimeScope();


            builder.RegisterType<ProductServiceWithCaching>().As<IProductService>();

        }
    }
}
