﻿using System.Collections.Generic;
using Apteka.Plus.Logic.BLL.Entities;
using Apteka.Plus.Logic.DAL.Accessors;
using BLToolkit.DataAccess;

namespace Apteka.Plus.Logic.BLL.Collections
{
    public class SuppliersCollection
    {
        private static List<Supplier> _liSuppliers;

        public static List<Supplier> AllSuppliers
        {
            get
            {
                if (_liSuppliers == null)
                {
                    var sa = DataAccessor.CreateInstance<SuppliersAccessor>();
                    _liSuppliers = sa.SelectAllActive();
                }
                return new List<Supplier>(_liSuppliers);
            }
        }
    }
}
