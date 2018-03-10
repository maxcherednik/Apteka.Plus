using BLToolkit.DataAccess;

namespace Apteka.Plus.Logic.BLL.Entities
{
    [TableName("Suppliers")]
    public class Supplier
    {
        [PrimaryKey, NonUpdatable]
        public int ID { get; set; }

        public string Name { get; set; }

        public override string ToString() => Name;

        public override bool Equals(object obj)
        {
            // If this and obj do not refer to the same type, then they are not equal.
            if (obj.GetType() != this.GetType()) return false;

            // Return true if  x and y fields match.
            Supplier other = (Supplier)obj;
            return (ID == other.ID) && (Name == other.Name);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}