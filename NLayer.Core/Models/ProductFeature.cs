using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core
{
    public class ProductFeature
    {
        //BaseEntity miras vermiyoruz çünkü zaten productan kendisine ulaşabiliyoruz.
        public int Id { get; set; }
        public string Color { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }

        public int ProductId { get; set; }

        public Product Product { get; set; }
        // birde product tutmalıyız ki producta ulaşabilsin diye  bu yüzdenden Productada ProductFeature tutmalıyız.
        // Bu işleme Navigation Propertysi denir.
    }
}
