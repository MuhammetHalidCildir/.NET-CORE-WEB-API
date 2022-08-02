using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.UnitOfWorks
{
    //  Veritabanında yapılacak işlemleri topluı bir şekilde Yönetmemize izin verir.
    public interface IUnitOfWork
    {
        // iki tane metot u olucak bunlar Dbcontexten SAveChange ve SaveChangesAsync methodları var biz burda commit ismini kullanıcaz 
        //Asenkron ve normal halini DbContexten  SaveChange ve SaveChangesAsync metodlarını çagırmış olucağız.
        Task CommitAsync();
        void Commit();


    }
}
