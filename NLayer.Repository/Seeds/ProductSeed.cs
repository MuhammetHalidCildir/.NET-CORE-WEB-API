using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Repository.Seeds
{
    // Seed Data veri tabanında ilgili tabloların oluşurken ilgili kayıtların atılması
    // yani tablo oluşurken tablonun içine default deger atılması diyebiliriz.
    // Migration yaparken ilgili tablolar oluşurken default deger atabiliriz.
    //Yada migraiton yaparız tablo oluşur uygulama ayağı kaldırırken atabiliriz
    //IEntityTypeConfiguration<Product> verdiigmiz kalıtım sayesinde seed işlemini hangi entity yapıcagımızı anlıyor.
    internal class ProductSeed : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(new Product
            {
                Id = 1,
                CategoryId = 1,
                Name = "Kalem 1",
                Price = 100,
                Stock = 20,
                CreatedDate = DateTime.Now


            },
            new Product
            {
                Id = 2,
                CategoryId = 1,
                Name = "Kalem 2",
                Price = 200,
                Stock = 30,
                CreatedDate = DateTime.Now


            },
             new Product
             {
                 Id = 3,
                 CategoryId = 1,
                 Name = "Kalem 3",
                 Price = 600,
                 Stock = 60,
                 CreatedDate = DateTime.Now


             },
               new Product
               {
                   Id = 4,
                   CategoryId = 2,
                   Name = "Kitap 1",
                   Price = 600,
                   Stock = 60,
                   CreatedDate = DateTime.Now


               },
               new Product
               {
                   Id = 5,
                   CategoryId = 2,
                   Name = "Kitap 2",
                   Price = 6600,
                   Stock = 320,
                   CreatedDate = DateTime.Now


               });
              
        }
    }
}
