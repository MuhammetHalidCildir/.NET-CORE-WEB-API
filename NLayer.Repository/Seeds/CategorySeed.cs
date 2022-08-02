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
    internal class CategorySeed : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {


            builder.HasData(
                new Category { Id = 1, Name = "Kalemler" }, 
                new Category { Id = 2, Name = "Kitaplar" }, 
                new Category { Id = 3, Name = "Defterler" });
        }
    }
}
