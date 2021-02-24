using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace SqlQueryBuilderCommon.Helper
{
    public class XmlHelper<T> where T : class
    {
        public string TargetPath { get; set; }
        private Encoding encoding => System.Text.Encoding.GetEncoding("shift_jis");

        public XmlHelper(string targetPath)
        {
            TargetPath = targetPath;
        }

        public XmlHelper() : base()
        {
        }

        public void Save(T data)
        {
            var serializer = new XmlSerializer(typeof(T));
            using (var writer = new StreamWriter(TargetPath, false, encoding))
            {
                serializer.Serialize(writer, data);
                writer.Close();
            }
        }

        /// <summary>
        /// XMLファイルを読み込む
        /// </summary>
        public T Read()
        {
            var serializer = new XmlSerializer(typeof(T));
            T obj;
            using (var reader = new StreamReader(TargetPath, encoding))
            {
                obj = (T)serializer.Deserialize(reader);
                reader.Close();
            }
            return obj;
        }
        public void Delete()
        {
            FileInfo file = new FileInfo(TargetPath);
            file.Delete();
        }
    }
}