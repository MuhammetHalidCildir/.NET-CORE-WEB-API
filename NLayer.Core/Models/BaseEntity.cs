using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core
{
    // İlk başta Entitylerimizi oluşturucaz  
    public abstract class BaseEntity
    {
       // BaseEntity Abstract olma sebebi abstract soyuttur new ile eleman oluşturamayız baseentity
       // new ile kullanmıcağımız için abstract olarak kalıcak.

      
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
