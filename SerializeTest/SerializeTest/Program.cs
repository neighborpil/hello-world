using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SerializeTest
{
    public class SampleSerializableClass
    {
        public string Value { get; set; }
    }


    class Program
    {
        static void Main(string[] args)
        {
            SampleSerializableClass obj = new SampleSerializableClass();
            obj.Value = "Hello!";
            XmlSerializer serializer = new XmlSerializer(typeof(SampleSerializableClass));

            using(Stream stream = new FileStream("sample.xml", FileMode.Create))
            {
                serializer.Serialize(stream, obj);
            }

            using(Stream stream = new FileStream("sample.xml", FileMode.Open))
            {
                SampleSerializableClass read = (SampleSerializableClass)serializer.Deserialize(stream);
                Console.WriteLine(read.Value);
            }
        }
    }
}
