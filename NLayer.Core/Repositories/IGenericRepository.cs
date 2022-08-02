using System.Linq.Expressions;

namespace NLayer.Core.Repositories
{
     /*bu olay Nedir ? öncelikle komuduz ile veri tabanı arası bir katman yerleştirilir ve bu katman sayesinde yapacagımız temel Crud işlemlerini bir
    bir  Entityde işlem yapmamızı sağlar GEneriz olma sebebi ise bu repo katmanı üzerinden  her bir entity için Crud işlemi Yapabilmek için*/
    public interface IGenericRepository<T> where T : class
    {
        // Asenkron olanlara Task  
        Task<T> GetByIdAsync(int id);  

        IQueryable<T> GetAll();
        //burda IEnum dönmüyoruz çünkü data aldıktan sonra Tolist metodunu kullanğımızda sorguyu atar IQueryable ise atmaz
        //memoride birleştiriyor tek bir seferde veri tabanına gönderir.
        
        IQueryable<T> Where(Expression<Func<T, bool>> expression);
        //geriye bir where sorgumuz olabilir bu yüzden geriye IQueryable dönücem çünkü IQueryable döndügümüzde yazmış oldugumuz sorgular veri tabanına gitmez.
        // Tolist gibi method çağırısak o zaman gider. Özellikle where kullanıyoruz ki döndükten sonra orderby yapabilirim  başka sorgular yazabiliriz
        // o yüzden bu sorguları yaptıgım yerde çağırdıktan sınra veri tabanına gidicek yani daha performanslı çalışabilmesi içiin 
        Task<bool> AnyAsync(Expression<Func<T, bool>> expression);
        //Var mı yokmu metot'u
        Task AddAsync(T entity);
        //Ekleme işlemi
        Task AddRangeAsync(IEnumerable<T> entities);
        
        void Update(T entity);
        //Update ve Remove asenkronu yok çünkü uzun süren bir işlemi yok.
        void Remove(T entity);
        //silme
        void RemoveRange(IEnumerable<T> entities);
        
    }
}
