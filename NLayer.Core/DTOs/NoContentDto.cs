using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.DTOs
{
    // DTo başarılı olursa T dataya null yollicaz, FArklı farklı sınıflarımızda farklı farklı property dönmemek lazımdır biz burda
    // istek yapınca clientlere T data ile, List Errors dönüyoruz ama burda bunlar Json dönüşücekleri için propertyleri aynı olucak ,Datayıda 
    //boş bırakacağımız zaman buraya NoContentDto yollıcaz bu yüzdende Responseda boş gözükücek.
    public class NoContentDto
    {
    }
}
