using Microsoft.EntityFrameworkCore;
using NLayer.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Repository.Repositories
{
    // Core katmanındaki IGenericRepository nin implemantasyonunu Gerçekleştiricez  Çünkü DB ile ilgili bir işlem yapabilmek için bize yardımcı olucak yer burasıdır.
   
    public class GenericRepository<T> : IGenericRepository<T> where T : class
        //Generic olma sebebi tüm enetitylerimiz için geçerli olabilmesi içinç public olmalı ve kalıtım olarak IGenericRepository<T> where T : class almalıyız .
        //T tipinde bir class oldugunu belirtme sebebimiz çünkü Ef.Core classlar ile çalışıyor. bu yüzdende class olarak belirtmekde zorundayız. 
    {
        // Db ile işlem yapabilmemiz için bir AppDbContexten elemana ihtiyacımız var. alt satırlarda elemanımıza ulaşım sağlamış bulunmaktayız.
        protected readonly AppDbContext _context;
        // Protect olma sebebi bazı durumlarda methodlar yetmedigi durumda context ulaşıp yeni metodlar yazabilelim diye .
        private readonly DbSet<T> _dbSet;
        // Readonly olma sebebi  bu degişkenlerin ya bu esnada deger atılacak yada constructor içinde atılsın diye. bu yüzden kesinlikle farklı şeyler set edilmemesi için readonly olmaktaddır
        // Buyüzden bu iki arkadaşın constructorlarını oluşturucaz. 

        public GenericRepository(AppDbContext context)
        {
            _context = context;
            // Dbset bize contextin içindeki Set'den gelicek 
            _dbSet = _context.Set<T>();
        }

        public async Task AddAsync(T entity)
        {

        await _dbSet.AddAsync(entity);
            //await işlemin sonucunu hemen döndürür geriye birşey dönmez.
           
        
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await _dbSet.AddRangeAsync(entities);
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
        {
          return await _dbSet.AnyAsync(expression);
        }

        public IQueryable<T> GetAll()
        {
            return _dbSet.AsNoTracking().AsQueryable();
            //ASnotracking kullanmazisek 1000 tane data çekeceksek 1000 tane datayı memoriye alır ve anlık olarak durumlarını izler
            //buda uygulamamızın performansını düşürür bin kayıt memoride dispause edilene kadar bekler. 
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
            //FindAsync(id) bizden primerykey bekler bir parametre kabul eder
        }

        public void Remove(T entity)
        {
           //Remove ve RemoneRange in asenkronu olmaz propertysini set ettigimiz şeyin asenkron olmasına gerek yoktur.
             _dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
           _dbSet.RemoveRange(entities);
        }
        //Foreach ile her bir entity  statenin deleted olarak seçiyor ne zaman save Change yapınca otamatik olarak Dbden siliyor.

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> expression)
        {
            return _dbSet.Where(expression);
        }
    }
}
