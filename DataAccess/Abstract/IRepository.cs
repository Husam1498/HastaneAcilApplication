using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    //Tüm sınıflarda ortak metodlar
    public interface IRepository<TEntity>
    {
        TEntity GetById(int id);

        List<TEntity> GetAll();

        void Create(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);
    }
}
