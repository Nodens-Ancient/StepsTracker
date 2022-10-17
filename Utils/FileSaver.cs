using CsvHelper;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Xml.Serialization;

namespace StepsTracker.Utils
{
    public static class FileSaver
    {
        public static void SaveObjectToFile(object o, int filterIndex, string path ="")
        {
            switch (filterIndex)
            {
                case 1:
                    File.WriteAllText(path, JsonConvert.SerializeObject(o));
                    break;

                case 2:
                    XmlSerializer xmlSerializer = new XmlSerializer(o.GetType());
                    using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
                    {
                        xmlSerializer.Serialize(fs, o);
                    }
                    break;
                case 3:
                    using (var writer = new StreamWriter(path))
                    {
                        using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                        {
                            csv.WriteRecords(new List<object>() { o });
                        }
                    }
                    break;
            }
        }
    }
}
