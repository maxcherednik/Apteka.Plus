namespace Apteka.Plus.Logic.BLL.Entities
{
    public class TableInfo
    {
        public TableInfo()
        {

        }

        public TableInfo(string name, long maxId)
        {
            Name = name;
            MaxID = maxId;
        }

        public string Name;

        public long MaxID;

        public override bool Equals(object obj)
        {
            if (obj.GetType() != GetType()) return false;

            var other = (TableInfo)obj;
            return Name == other.Name;

        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
