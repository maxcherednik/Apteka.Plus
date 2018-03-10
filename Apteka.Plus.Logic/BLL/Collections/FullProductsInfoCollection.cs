using System.Collections.Generic;
using Apteka.Plus.Logic.BLL.Entities;
using Apteka.Plus.Logic.DAL.Accessors;

namespace Apteka.Plus.Logic.BLL.Collections
{
    public class FullProductsInfoCollection
    {
        private static List<FullProductInfo> _liFullProductInfos;

        public static List<FullProductInfo> FullProductInfoList
        {
            get
            {
                if (_liFullProductInfos == null)
                {
                    FullProductInfoAccessor fpia = FullProductInfoAccessor.CreateInstance<FullProductInfoAccessor>();
                    _liFullProductInfos = fpia.GetAllActiveProductInfos() ;
                }
                return new List<FullProductInfo>(_liFullProductInfos);
            }
        }
    }
}
