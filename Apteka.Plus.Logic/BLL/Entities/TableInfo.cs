namespace Apteka.Plus.Logic.BLL.Entities
{
    public class TableInfo
    {
        public TableInfo()
        {

        }

        public TableInfo(string name, long maxID)
        {
            Name = name;
            MaxID = maxID;
        }

        public string Name;

        public long MaxID;

        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType()) return false;

            TableInfo other = (TableInfo)obj;
            return (Name == other.Name);

        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
