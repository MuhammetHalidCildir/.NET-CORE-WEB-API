using NLayer.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Repository.UnitOfWorks
{
    //interface olarak IUnitOfWork kalıtımlıcaz bu nerden geliyor diye sorarsanız Core Katmanından gelmektedir.
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }
        //Bir senkron ve birde asenkron olmak üzere ikitane metot dan oluşmaktaydı mümkün oldukça asenkron olanı kullanıcaz.
        //SaveChanges işlemlerini bundan sonra bu iki metot ile yapmaya devam edicez.
        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
