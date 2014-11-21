using System;
using System.IO;
using System.Xml.Serialization;

namespace Apteka.Plus.Logic.Helpers
{
    public class SerializeHelper
    {
        public static void SerializeObjectToFile(object entity, string fileName)
        {
            XmlSerializer serializer = new XmlSerializer(entity.GetType());
            TextWriter writer = new StreamWriter(fileName);
            serializer.Serialize(writer, entity);
            writer.Close();
        }

        public static object DeserializeObjectFromFile(Type type, string fileName)
        {
            XmlSerializer serializer = new XmlSerializer(type);
            TextReader reader = new StreamReader(fileName);
            object newentity = serializer.Deserialize(reader);
            reader.Close();
            return newentity;
        }


    }
}
