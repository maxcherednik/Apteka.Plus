﻿using System.Collections.Generic;
using Apteka.Plus.Logic.BLL.Entities;
using BLToolkit.DataAccess;

namespace Apteka.Plus.Logic.DAL.Accessors
{
    
    public abstract class SuppliersAccessor: DataAccessor<Supplier>
    {

        private SqlQuery<Supplier> _query;
        public SqlQuery<Supplier> Query
        {
            get
            {
                if (_query == null)
                    _query = new SqlQuery<Supplier>(DbManager);
                return _query;
            }
        }

        [SprocName("Supplier_SelectAllActive")]
        public abstract List<Supplier> SelectAllActive();

        public abstract long Insert(Supplier row);
    }
}
