using Microsoft.EntityFrameworkCore;
using NLayer.Core;
using NLayer.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Repository.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<Product>> GetProductsWitCategory()
        {

            return await _context.Products.Include(x => x.Category).ToListAsync();
            //context üzerinden products a gidiyoruz include diyerek kimi dahil emek istiyorsam burda Bağlı oldugu Categoryleri çagrıyoruz
            //,Burda Eager loading yaptık datayı çekerken Categorylerinde olmasını istedik.
            //Lazy Loading : Product'a bağlı  category ihtiyaç durumunda sonra çekersen oda lazy loading olmuş oluyor.

        }
    }
}
