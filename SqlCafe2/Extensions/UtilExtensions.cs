using System.IO;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace SqlCafe2.Extensions
{
    public static class UtilExtensions
    {
        public static string ToJson<T>(this T obj, bool indent = false)
        {
            return JsonConvert.SerializeObject(obj, indent ? Formatting.Indented : Formatting.None, new JsonSerializerSettings {NullValueHandling = NullValueHandling.Ignore});
        }

        public static T? FromJson<T>(this string obj)
        {
            return JsonConvert.DeserializeObject<T>(obj);
        }

        public static string ToXML<T>(this T obj)
        {
            string retVal;
            using (var ms = new MemoryStream()) {
                var xs = new XmlSerializer(typeof(T));
                xs.Serialize(ms, obj);
                ms.Flush();
                ms.Position = 0;
                var sr = new StreamReader(ms);
                retVal = sr.ReadToEnd();
            }
            return retVal;
        }
    }
}