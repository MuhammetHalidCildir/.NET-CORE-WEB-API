using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.DTOs
{
    //product ile beraber productın bağlımoldugu kategorileride almak istiyoruz. listelerken product arkasında Json datasıyla beraber bağlı oldugu
    //Categorysinide gözükecek bizim GenericRepository ortak Custom bir Db yazmamız lazım Veri tabanına karşı
    //böyle durumlarda product özel IproductRepository ,ProductRepository,IProductService,ProductService oluşturucaz
    public class ProductWithCategoryDto:ProductDto
    {
        public CategoryDto Category { get; set; }
    }
}
