using System.Collections.Generic;
using Apteka.Plus.Logic.BLL.Entities;
using Apteka.Plus.Logic.DAL.Accessors;

namespace Apteka.Plus.Logic.BLL.Collections
{
    public class MyStoresCollection
    {
        private static List<MyStore> _liMyStores;
        public static List<MyStore> AllStores
        {
            get
            {
                if (_liMyStores == null)
                {
                    MyStoresAccessor msa = MyStoresAccessor.CreateInstance<MyStoresAccessor>();
                    _liMyStores = msa.SelectAll();
                }
                return new List<MyStore>(_liMyStores);
            }
        }

        public static void Refresh()
        {
            _liMyStores = null;
        }
    }
}
