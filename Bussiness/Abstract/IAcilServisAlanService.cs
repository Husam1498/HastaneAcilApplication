using DataAccess.Abstract;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Abstract
{
    public interface IAcilServisAlanService:IValidatator<AcilServisAlan>,IAcilServisAlanRepository
    {
        AcilServisAlan GetById(int id);

        List<AcilServisAlan> GetAll();

        void Create(AcilServisAlan entity);

        void Update(AcilServisAlan entity);

        void Delete(AcilServisAlan entity);
    }
}
