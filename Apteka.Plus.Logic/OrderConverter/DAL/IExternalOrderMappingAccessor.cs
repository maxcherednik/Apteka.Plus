using Apteka.Plus.Logic.OrderConverter.BLL;
using System.Collections.Generic;

namespace Apteka.Plus.Logic.OrderConverter.DAL
{
    public interface IExternalOrderMappingAccessor
    {
        IList<ExternalOrderSupplier> GetSuppliers();

        void Delete(ExternalOrderSupplier externalOrderSupplier);

        IList<ExternalOrderMappingRow> GetMappingFor(ExternalOrderSupplier externalOrderSupplier);

        void Save(ExternalOrderSupplier externalOrderSupplier, IList<ExternalOrderMappingRow> mappings);
    }
}
