using System;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;

namespace Apteka.Plus.Logic.BLL.Entities
{
    [TableName("FullProductInfos")]
    public class FullProductInfo
    {
        [PrimaryKey, NonUpdatable]
        public long ID { get; set; }

        public string EAN13 { get; set; }

        public string ProductName { get; set; }

        public string PackageName { get; set; }

        public string CountryProducer { get; set; }

        public int Divider { get; set; }

        public bool IsDiscountExcluded { get; set; }

        [MapIgnore]
        public Boolean IsLifeImportant { get; set; }

        public override bool Equals(object obj)
        {
            // If this and obj do not refer to the same type, then they are not equal.
            if (obj.GetType() != this.GetType()) return false;

            // Return true if  x and y fields match.
            FullProductInfo other = (FullProductInfo)obj;
            return ID == other.ID
                    && EAN13 == other.EAN13
                    && Divider == other.Divider
                    && ProductName == other.ProductName
                    && PackageName == other.PackageName
                    && CountryProducer == other.CountryProducer
                    && IsDiscountExcluded == other.IsDiscountExcluded;
        }

        public override int GetHashCode() => base.GetHashCode();
    }
}
