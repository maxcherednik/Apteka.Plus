using System.Collections.Generic;
using Apteka.Plus.Satelite.Logic.BLL.Entities;
using BLToolkit.Data;

namespace Apteka.Plus.Satelite.Logic.DAL
{
    public class DictionariesGateway
    {

        public void SyncDictionaries(DbManager db, List<LocalBillsRow> liLocalBillRows)
        {
            FullProductsInfosAccessor fullProductInfoAcc = FullProductsInfosAccessor.CreateInstance<FullProductsInfosAccessor>(db);
            ProductsAccessor proda = ProductsAccessor.CreateInstance<ProductsAccessor>(db);
            PackageAccessor packa = PackageAccessor.CreateInstance<PackageAccessor>(db);
            SuppliersAccessor suppla = SuppliersAccessor.CreateInstance<SuppliersAccessor>(db);

            List<FullProductInfo> liAllreadyCheckedFullProductInfo = new List<FullProductInfo>();
            List<Product> liAllreadyCheckedProducts = new List<Product>();
            List<Package> liAllreadyCheckedPackages = new List<Package>();
            List<Supplier> liAllreadyCheckedSuppliers = new List<Supplier>();

            foreach (LocalBillsRow localBillRow in liLocalBillRows)
            {
                #region FullProductInfo

                #endregion
                
                #region Products
                if (!liAllreadyCheckedProducts.Contains(localBillRow.ProductInfo.Product))
                {
                    Product productFromSatelite = proda.Query.SelectByKey(db, localBillRow.ProductInfo.Product.ID);
                    if (productFromSatelite == null)
                    {
                        proda.Query.Insert(db, localBillRow.ProductInfo.Product);
                    }
                    else if (!productFromSatelite.Equals(localBillRow.ProductInfo.Product))
                    {
                        proda.Query.Update(db, localBillRow.ProductInfo.Product);
                    }

                    liAllreadyCheckedProducts.Add(localBillRow.ProductInfo.Product);
                } 
                #endregion

                #region Packages
                if (!liAllreadyCheckedPackages.Contains(localBillRow.ProductInfo.Package))
                {
                    Package packageFromSatelite = packa.Query.SelectByKey(db, localBillRow.ProductInfo.Package.ID);
                    if (packageFromSatelite == null)
                    {
                        packa.Query.Insert(db, localBillRow.ProductInfo.Package);                        
                    }
                    else if (!packageFromSatelite.Equals(localBillRow.ProductInfo.Package))
                    {
                        packa.Query.Update(db, localBillRow.ProductInfo.Package);
                    }

                    liAllreadyCheckedPackages.Add(localBillRow.ProductInfo.Package);
                } 
                #endregion

                #region Suppliers
                if (!liAllreadyCheckedSuppliers.Contains(localBillRow.Supplier))
                {
                    Supplier supplierFromSatelite = suppla.Query.SelectByKey(db, localBillRow.Supplier.ID);
                        
                    if (supplierFromSatelite == null)
                    {
                        suppla.Query.Insert(db, localBillRow.Supplier);                        
                    }
                    else if (!supplierFromSatelite.Equals(localBillRow.Supplier))
                    {
                        suppla.Query.Update(db, localBillRow.Supplier);
                    }

                    liAllreadyCheckedSuppliers.Add(localBillRow.Supplier);
                } 
                #endregion

            }
            



        }

    }
}
