using System;

namespace Apteka.Plus.Logic.BLL.Entities
{
    public class SupplierSummary
    {
        private Supplier _Supplier = new Supplier();

        public Supplier Supplier
        {
            get { return _Supplier; }
            set { _Supplier = value; }
        }

        public DateTime DateSupply { get; set; }

        public string SupplierBillNumber { get; set; }

        public double Sum { get; set; }

        public string SupplierName => _Supplier.Name;
    }
}
