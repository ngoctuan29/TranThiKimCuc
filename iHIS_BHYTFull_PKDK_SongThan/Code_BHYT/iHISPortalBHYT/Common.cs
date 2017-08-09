using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Web.Script.Serialization;
using System.Dynamic;
using System.Security.Cryptography;
using System.Globalization;
using System.Xml;
using System.Xml.Serialization;

namespace iHISPortalBHYT
{
    public class Common
    {
        public static string MD5Encode(string str_encode)
        {
            MD5 md5Hash = MD5.Create();            
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(str_encode));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }

        public static DateTime CoverStringtoDate(string str)
        {
            if (str.Length > 7)
            {
                string yyyy = str.Substring(0, 4);
                string MM = str.Substring(4, 2);
                if (MM.Equals("00"))
                    MM = "01";
                string dd = str.Substring(6, 2);
                if (dd.Equals("00"))
                    dd = "01";
                string value = dd + "/" + MM + "/" + yyyy;
                DateTime result = DateTime.ParseExact(value, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                return result;
            }
            else { return DateTime.Now.Date; }
        }

        public static string ConvertFileToBase64(string pathFileXML)
        {
            FileStream fs = new FileStream(pathFileXML, FileMode.Open, FileAccess.Read);
            byte[] filebytes = new byte[fs.Length];
            fs.Read(filebytes, 0, Convert.ToInt32(fs.Length));
            string encodedData = Convert.ToBase64String(filebytes, Base64FormattingOptions.None);
            return encodedData;
        }

        public static void CreateFileXMLFromBase64(string base64, string pathSaveXML)
        {
            byte[] file = Convert.FromBase64String(base64);
            FileStream fs = new FileStream(pathSaveXML, FileMode.CreateNew, FileAccess.Write, FileShare.None);
            fs.Write(file, 0, file.Length);
            fs.Close();
        }

        public static void SerializeObject<T>(T serializableObject, string fileName, string rootAttributeName)
        {
            if (serializableObject == null) { return; }
            try
            {
                XmlDocument xmlDocument = new XmlDocument();
                XmlWriterSettings xmlsetting = new XmlWriterSettings();
                xmlsetting.OmitXmlDeclaration = true;
                XmlSerializer serializer = new XmlSerializer(serializableObject.GetType(), new XmlRootAttribute(rootAttributeName));
                using (MemoryStream stream = new MemoryStream())
                {
                    XmlWriter xmlwt = XmlWriter.Create(stream, xmlsetting);
                    XmlSerializerNamespaces xmlnamespaces = new XmlSerializerNamespaces();
                    xmlnamespaces.Add(string.Empty, string.Empty);
                    serializer.Serialize(xmlwt, serializableObject, xmlnamespaces);
                    stream.Position = 0;
                    xmlDocument.Load(stream);
                    xmlDocument.Save(fileName);
                    stream.Close();
                }
            }
            catch
            {
                throw new Exception();
            }
        }

        public static T DeSerializeObject<T>(string fileName, string rootAttributeName)
        {
            if (string.IsNullOrEmpty(fileName)) { return default(T); }
            T objectOut = default(T);
            try
            {
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(fileName);
                string xmlString = xmlDocument.OuterXml;
                using (StringReader read = new StringReader(xmlString))
                {
                    Type outType = typeof(T);
                    XmlSerializer serializer = new XmlSerializer(outType, new XmlRootAttribute(rootAttributeName));
                    using (XmlReader reader = new XmlTextReader(read))
                    {
                        objectOut = (T)serializer.Deserialize(reader);
                        reader.Close();
                    }
                    read.Close();
                }
            }
            catch
            {
                throw new Exception();
            }
            return objectOut;
        }

        public static string ConvertObjectToXMLString(object obj, string rootAttributeName)
        {
            string xmlString = null;
            if (obj == null) { return null; }
            try
            {
                var settings = new XmlWriterSettings
                {
                    Indent = true,
                    OmitXmlDeclaration = true,
                    Encoding = Encoding.GetEncoding("UTF-8")
                };
                var namespaces = new XmlSerializerNamespaces();
                namespaces.Add(string.Empty, string.Empty);
                var serializer = new XmlSerializer(obj.GetType(), new XmlRootAttribute(rootAttributeName));
                using (var stringWriter = new StringWriter())
                {
                    using (var xmlWriter = XmlWriter.Create(stringWriter, settings))
                    {
                        serializer.Serialize(xmlWriter, obj, namespaces);
                    }
                    xmlString = stringWriter.ToString();
                }
            }
            catch
            {
                throw new Exception();
            }
            return xmlString;
        }

        public static void WriteToXmlFile<T>(string filePath, string xmlRootName, T objectToWrite, bool append = false) where T : new()
        {
            TextWriter writer = null;
            try
            {
                var serializer = new XmlSerializer(typeof(T), new XmlRootAttribute(xmlRootName));
                writer = new StreamWriter(filePath, append);
                serializer.Serialize(writer, objectToWrite);
            }
            finally
            {
                if (writer != null)
                    writer.Close();
            }
        }
    }
}
