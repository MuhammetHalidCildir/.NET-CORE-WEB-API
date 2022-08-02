using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.DTOs
{
    //DTOs kullanma sebebimiz Entitylerin dış dünyaya açmak istemiyoruz bunun yerine ara katman olarak bir sınıf kullanıcaz bunlar Dto olarak
    //geçmektedir . Entities içerinde gözükmesini istemedigimiz bilgileri gizlemek için kullanıcaz. bu işlemi yaparken
    //entitylerimizin sonuna Dto ekleyerek gözükmesini istediklerimizi yazıcaz. Navigation Propertylere gerek yok.
    public abstract class BaseDto
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
