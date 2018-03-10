﻿using System;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;

namespace Apteka.Plus.Logic.BLL.Entities
{

    [TableName("MainStoreSupplies")]
    [MapField("FullProductInfoID", "FullProductInfo.ID")]
    [MapField("SupplierID", "Supplier.ID")]
    public class MainStoreRow
    {
        private Supplier _Supplier = new Supplier();

        private FullProductInfo _FullProductInfo = new FullProductInfo();

        [PrimaryKey, NonUpdatable]
        public long ID { get; set; }

        public double SupplierPrice { get; set; }

        public double Extra { get; set; }

        public double LocalPrice { get; set; }

        public int StartAmount { get; set; }

        public int Amount { get; set; }

        public DateTime DateSupply { get; set; }

        public string SupplierBillNumber { get; set; }

        public Supplier Supplier
        {
            get { return _Supplier; }
            set { _Supplier = value; }
        }

        public FullProductInfo FullProductInfo
        {
            get { return _FullProductInfo; }
            set { _FullProductInfo = value; }
        }

        public DateTime? ExpirationDate { get; set; }

        public string Series { get; set; }

        [Nullable]
        public string EAN13 { get; set; }

        public string ProductName => _FullProductInfo.ProductName;

        public string PackageName => _FullProductInfo.PackageName;

        public string SupplierName => _Supplier.Name;
    }
}
