using System;

namespace Apteka.Plus.Logic.BLL.Entities
{
    public class SupplierSummary
    {
        public Supplier Supplier { get; set; } = new Supplier();

        public DateTime DateSupply { get; set; }

        public string SupplierBillNumber { get; set; }

        public double Sum { get; set; }

        public string SupplierName => Supplier.Name;
    }
}
