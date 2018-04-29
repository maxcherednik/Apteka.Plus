using System.Collections.Generic;
using Apteka.Plus.Logic.OrderConverter.BLL;
using BLToolkit.DataAccess;

namespace Apteka.Plus.Logic.OrderConverter.DAL
{
    public abstract class ExternalOrderMappingAccessor : DataAccessor, IExternalOrderMappingAccessor
    {
        [SqlQuery("delete from dbo.ExternalOrderSuppliers where Id = @Id")]
        public abstract void Delete(ExternalOrderSupplier externalOrderSupplier);

        [SqlQuery("select * from dbo.ExternalOrderSuppliers where Name = @Name")]
        public abstract ExternalOrderSupplier GetByName(ExternalOrderSupplier externalOrderSupplier);

        [SqlQuery("select * from dbo.ExternalOrderFieldMapping where ExternalOrderSupplierId = @Id")]
        public abstract IList<ExternalOrderMappingRow> GetMappingFor(ExternalOrderSupplier externalOrderSupplier);

        [SqlQuery("select * from dbo.ExternalOrderSuppliers")]
        public abstract IList<ExternalOrderSupplier> GetSuppliers();

        public void Save(ExternalOrderSupplier externalOrderSupplier, IList<ExternalOrderMappingRow> mappings)
        {
            if (externalOrderSupplier.Id == 0)
            {
                InsertSupplier(externalOrderSupplier);

                var newSupplier = GetByName(externalOrderSupplier);

                foreach (var mapping in mappings)
                {
                    mapping.ExternalOrderSupplierId = newSupplier.Id;
                    InsertMapping(mapping);
                }
            }
            else
            {
                UpdateSupplier(externalOrderSupplier);

                foreach (var mapping in mappings)
                {
                    UpdateMapping(mapping);
                }
            }
        }

        [SqlQuery("insert into dbo.ExternalOrderSuppliers values(@Name)")]
        public abstract void InsertSupplier(ExternalOrderSupplier externalOrderSupplier);

        [SqlQuery("update dbo.ExternalOrderSuppliers set Name=@Name where Id = @Id")]
        public abstract void UpdateSupplier(ExternalOrderSupplier externalOrderSupplier);

        [SqlQuery("insert into dbo.ExternalOrderFieldMapping values(@ExternalOrderSupplierId,@LocalName,@ExternalName)")]
        public abstract void InsertMapping(ExternalOrderMappingRow externalOrderMappingRow);

        [SqlQuery("update dbo.ExternalOrderFieldMapping set ExternalName = @ExternalName where Id = @Id")]
        public abstract void UpdateMapping(ExternalOrderMappingRow externalOrderMappingRow);
    }
}
