using DataAccess.Abstract;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Abstract
{
    public interface IHastaService:IValidatator<Hasta>,IHastaRepository
    {
        Hasta GetById(int id);

        List<Hasta> GetAll();

        void Create(Hasta entity);

        void Update(Hasta entity);

        void Delete(Hasta entity);
    }
}
