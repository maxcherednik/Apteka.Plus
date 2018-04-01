﻿using System;
using Apteka.Plus.Logic.BLL.Enums;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;

namespace Apteka.Plus.Logic.BLL.Entities
{
    [TableName("SuppliesReturnHistory")]
    [MapField("EmployeeID", "Employee.ID")]
    [MapField("LocalBillRowID", "LocalBillsRow.ID")]

    public class SuppliesReturnHistoryRow
    {
        [PrimaryKey, NonUpdatable]
        public long ID { get; set; }

        public DateTime DateAccepted { get; set; }

        public int Amount { get; set; }

        public double Price { get; set; }

        public string Comment { get; set; }

        public SuppliesReturnReasonEnum Reason { get; set; }

        public Employee Employee { get; set; } = new Employee();

        public string ProductName => LocalBillsRow.ProductName;

        public string PackageName => LocalBillsRow.PackageName;

        public string SupplierName => LocalBillsRow.SupplierName;

        public string SupplierBillNumber => LocalBillsRow.SupplierBillNumber;

        public DateTime SupplierDateSupply => LocalBillsRow.DateSupply;

        public LocalBillsRowEx LocalBillsRow { get; set; } = new LocalBillsRowEx();
    }
}