using System.IO;
using System.Xml.Serialization;

namespace Apteka.Helpers
{
    public class SerializeHelper
    {
        public static void SerializeObjectToFile<T>(T entity, string fileName)
        {
            var serializer = new XmlSerializer(typeof(T));
            using (var writer = new StreamWriter(fileName))
            {
                serializer.Serialize(writer, entity);
            }
        }

        public static T DeserializeObjectFromFile<T>(string fileName)
        {
            var serializer = new XmlSerializer(typeof(T));
            using (var reader = new StreamReader(fileName))
            {
                return (T)serializer.Deserialize(reader);
            }
        }
    }
}
