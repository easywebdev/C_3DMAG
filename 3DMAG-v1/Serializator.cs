using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;

namespace _3DMAG_v1
{
    class Serializator
    {
        public Settings getSerialize(string file)
        {
            XmlSerializer settings = new XmlSerializer(typeof(Settings));

            using (FileStream fs = new FileStream(file, FileMode.Open))
            {
                Settings output = (Settings)settings.Deserialize(fs);
                return output;
            }
        }

        public void setSerialize(Settings input, string file)
        {
            XmlSerializer settings = new XmlSerializer(typeof(Settings));

            using (FileStream fs = new FileStream(file, FileMode.Create))
            {
                settings.Serialize(fs, input);
            }
        }
    }
}
