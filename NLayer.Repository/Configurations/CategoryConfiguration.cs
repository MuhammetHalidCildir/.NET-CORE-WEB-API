using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Repository.Configurations
{
    // Entitylerin kaç karakter olması  yazılması zorunlu mu gibi işlemlerini burdan yapıyoruz
    // bu işlemi Entitylerin kendi içindede yapabiliriz ama kirli bir ekran oluşmuş olur
    //Entitylerle ilgili ayarlar yapabilmemiz için migration esnasında ovveride etmemiz gereken bir metotumzu var "OnModelCreatin" Yani model oluşurken çalışacak metodumuzdur.
    // Bu işlemi AppDbContexte yapıyoruz.
    // IEntityTypeConfiguration<Category> bu işlem değişiklikleri kime yapacagımızı göstermieş oluyor.
    internal class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            // Builder çağrıp ID sinin Key oldugunu belirtiyoruz 
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            //birer birer artan ıolmasını istiyoruz bu yüzden propertysine gidicez
            //UseIdentityColumn(); bu metodda kaçar kaçar artıcagını belirtiyoruz boş bırakırsak birer birer artan olmuş oluyor
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);

            builder.ToTable("Categories");
            //Tablo ismini belirtiyoruz belirtmessek propertysinin ismini tablo ismi olarka almiş olur. isim vermez isek DBsetteki ismini alır.

           


        }
    }
}
