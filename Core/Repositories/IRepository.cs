using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Domains;
namespace Core.Repositories
{
    public  interface IRepository<T1,T2> where T1:BaseDomain<T2> 
    {
        IList<T1> GetAll();
        T1 GetByID(T2 id);

        T1 Create(T1 entity);

        T1 Update(T1 entity, T2 id);

        void Delete(T2 id);
    }
}
