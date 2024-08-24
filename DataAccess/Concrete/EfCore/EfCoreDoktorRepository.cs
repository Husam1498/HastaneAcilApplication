using DataAccess.Abstract;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EfCore
{
    public class EfCoreDoktorRepository : EfCoreGenericRepository<Doktor, MsSqlContext>, IDoktorRepository
    {
        MsSqlContext _sqlContext = new MsSqlContext();

        public string GetDoktorServisName(int alanId)
        {
            string alanAdi = " ";
            var _alan = _sqlContext.Alanlar.Find(alanId);
            if (_alan != null)
            {

                alanAdi = _alan.AlanName;

            }
            return alanAdi;
        }
    }
}
