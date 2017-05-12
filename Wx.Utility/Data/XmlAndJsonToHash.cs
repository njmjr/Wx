using System.Collections;
using System.Text;
using System.Xml;
using Newtonsoft.Json;

namespace Wx.Utility.Data
{
    /// <summary>
    /// JSON,Xml,Hsahtable互转
    /// </summary>
    public static class XmlAndJsonToHash
    {
        /// <summary>
        /// Xml转HashTable
        /// </summary>
        /// <param name="xmlStr"></param>
        /// <returns></returns>
        public static Hashtable XmlToHashTable(string xmlStr)
        {
            Hashtable kvs = new Hashtable();
            XmlDocument xdoc = new XmlDocument();
            xdoc.LoadXml(xmlStr);
            if (xdoc.DocumentElement == null) return kvs;
            XmlNodeList eles = xdoc.DocumentElement.ChildNodes;
            foreach (XmlElement xmlElement in eles)
            {
                kvs.Add(xmlElement.Name, xmlElement.InnerText);
            }
            return kvs;
        }

        /// <summary>
        /// HashTable转Xml
        /// </summary>
        /// <param name="kvs"></param>
        /// <returns></returns>
        public static string HashTableToXml(Hashtable kvs)
        {
            StringBuilder xml = new StringBuilder();
            xml.Append("<xml>");
            foreach (DictionaryEntry kv in kvs)
            {
                xml.Append("<" + kv.Key + ">" + kv.Value + "</" + kv.Key + ">");
            }
            xml.Append("</xml>");
            return xml.ToString();
        }

        public static string XmlToJson(string xml)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            string json = JsonConvert.SerializeXmlNode(doc.GetElementById("xml"));
            return json;
        }


    }
}