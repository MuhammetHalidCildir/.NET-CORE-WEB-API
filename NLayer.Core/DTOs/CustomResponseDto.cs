using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NLayer.Core.DTOs
{
   // Apı de endpointlerimizi kullanırken (Ürün kaydet sil güncelleme gibi..) geriye tek bir model dönüyor  bizim geriye dönecegimiz model tek olsun
   // o model içerinde başarılıysa datamızı dönsün başarısız ise  hatamızı dönsün  örnegin başarılı ise succes başarıszı ise Fail gibi. tek bir model dönmek daha iyi olacaktır daha kolay
   // ve Sürdürülebilir bir kod olmuş olucaktır.

    public class CustomResponseDto<T>
    {
        public T Data { get; set; }
        // datayı aldık .
        [JsonIgnore]
        //Json çevirirken susturmak(İgnore) etmek için
        public int StatusCode { get; set; }
        //Dış dünyaya kapatıcaz ,Endpoint istek yapınmca geriye mutlaka bir durum code almak zorundayız.

        public List<String> Errors { get; set; }
        //hataları tutmak için
        //Statik bir kod oluşturalım succes olunca dönsün fail olunca dönsün şeklinde
        public static CustomResponseDto<T> Success(int statusCode,T data)
        {
            return new CustomResponseDto<T> { Data = data, StatusCode = statusCode };
        }
        public static CustomResponseDto<T> Success(int statusCode)
        {
            return new CustomResponseDto<T> { StatusCode = statusCode };
        }

        public static CustomResponseDto<T> Fail(int statusCode, List<string> errors)
        {
            return new CustomResponseDto<T> { StatusCode = statusCode, Errors=errors };
        }

        public static CustomResponseDto<T> Fail(int statusCode, string error)
        {
            return new CustomResponseDto<T> { StatusCode = statusCode, Errors = new List<string> { error } };
        }
        //Tek biR hata gelirse.

    }
}
