﻿using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IDoktorRepository:IRepository<Doktor>
    {
        public string GetDoktorServisName(int alanId);
    }
}
