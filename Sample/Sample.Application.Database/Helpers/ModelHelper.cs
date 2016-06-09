using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Sample.Application.Database.Helpers
{
    public static class ModelHelper
    {
        public static string GenerateModel(DbContext context)
        {
            var modelXml = GetModel(context);
            var modelBytes = Compress(modelXml);
            return Convert.ToBase64String(modelBytes);
        }

        private static XDocument GetModel(this DbContext context)
        {
            var document = GetModel(delegate(XmlWriter w)
            {
                EdmxWriter.WriteEdmx(context, w);
            });

            return document;
        }

        private static byte[] Compress(XDocument model)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                using (GZipStream stream2 = new GZipStream(stream, CompressionMode.Compress))
                {
                    model.Save(stream2);
                }
                return stream.ToArray();
            }
        }

        private static XDocument GetModel(Action<XmlWriter> writeXml)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                XmlWriterSettings settings = new XmlWriterSettings
                {
                    Indent = true
                };
                using (XmlWriter writer = XmlWriter.Create(stream, settings))
                {
                    writeXml(writer);
                }
                stream.Position = 0;
                return XDocument.Load(stream);
            }
        }
    }
}
