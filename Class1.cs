using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WpfApp5
{
    public class Class1
    {
        public string id { get; set; }

        public string ÍD { get; set; }

        public string FName { get; set; }

        public string LName { get; set; }

        public string Date { get; set; }

        public string Event_Type { get; set; }

        public string Venue { get; set; }

        public string Food { get; set; }

        public string Guest_No { get; set; }

        public string Days { get; set; }


        public static Class1 D(string filename)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Class1), new XmlRootAttribute("XmlDataProvider"));
            FileStream stream = new FileStream(filename, FileMode.Open);
            return (Class1)serializer.Deserialize(stream);
        }
    }
}
