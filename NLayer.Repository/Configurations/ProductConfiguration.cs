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
    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            //birer birer artan ıolmasını istiyoruz bu yüzden propertysine gidicez
            //UseIdentityColumn(); bu metodda kaçar kaçar artıcagını belirtiyoruz boş bırakırsak birer birer artan olmuş oluyor
            builder.Property(x => x.Name).IsRequired().HasMaxLength(200);
            //byrda propertylerindeki namelerin maximum karakter sayısını belirtiyoruz
            builder.Property(x => x.Stock).IsRequired();

            builder.Property(x => x.Price).IsRequired().HasColumnType("decimal(18,2)");
            builder.ToTable("Products");

            builder.HasOne(x => x.Category).WithMany(x => x.Products).HasForeignKey(x => x.CategoryId);
            //bir propertynin bir category si olabilir bir category ninde birden fazla productı olabilcegini kodlar ile yazıyoruz.
        }
    }
}
