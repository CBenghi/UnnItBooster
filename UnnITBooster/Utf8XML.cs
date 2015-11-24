using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace StudentsFetcher
{
    public static class Utf8XML
    {
        public static string XMLSerializer(XmlSerializer Serializator, Object Obj)
        {
            MemoryStream m = new MemoryStream();
            TextWriter writer = new StreamWriter(m, Encoding.UTF8);
            Serializator.Serialize(writer, Obj);
            byte[] b = m.ToArray();
            string sOut = writer.Encoding.GetString(b);
            m.Close();
            m.Dispose();
            return sOut;
        }

        public static object XMLDeserializer(XmlSerializer ser, string xml)
        {
            MemoryStream m = new MemoryStream();
            TextReader reader = new StreamReader(m);
            byte[] bytes = Encoding.UTF8.GetBytes(xml);
            m.Write(bytes, 0, bytes.Length);
            m.Position = 0;
            object Out = ser.Deserialize(reader);
            m.Close();
            m.Dispose();
            return Out;
        }
    }
}
