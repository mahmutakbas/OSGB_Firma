﻿using Entities.Concrete.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IYurutucuFirmaDal:IBaseDal<YurutucuFirma>
    {
        List<YurutucuFirma> GetAllFilter(string adi);
    }
}
