using DataAccess.Abstract;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Abstract
{
    public interface IDoktorService:IValidatator<Doktor>,IDoktorRepository
    {
        Doktor GetById(int id);

        List<Doktor> GetAll();

        void Create(Doktor entity);

        void Update(Doktor entity);

        void Delete(Doktor entity);
    }
}
