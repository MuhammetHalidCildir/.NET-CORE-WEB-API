using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core
{
    public class Category:BaseEntity
    {
        // ilk tablomuz olan Category BaseEntity miras alıcaz 
        public string Name{ get; set; }

        public ICollection<Product> Products { get; set; }
        //Categorynin birden fazla product tutuyor olabilceginden Icollection ile product tutuyoruz.
        //Buna Navigation Property diyoruz entitye referance verdigimiz için categoryden Producta ulaşabiliriz.
    }
}
