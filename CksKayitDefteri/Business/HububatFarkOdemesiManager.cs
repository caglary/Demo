﻿using App.Business.Abstract;
using Database.Concrete.Sqlite;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Business
{
    public class HububatFarkOdemesiManager : BaseService<HububatFarkOdemesi>
    {
        
        public HububatFarkOdemesiManager()
        {
            _dal = new HububatFarkOdemesiDal();
        }
      
    }
}
