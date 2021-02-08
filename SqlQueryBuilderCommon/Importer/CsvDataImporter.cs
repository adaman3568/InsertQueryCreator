using SqlQueryBuilderCommon.Model;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;

namespace SqlQueryBuilderCommon.Importer
{
    public class CsvDataImporter : IDataImport
    {
        public string Path { get; }

        public CsvDataImporter(string path)
        {
            Path = path;
        }

        public IEnumerable<TableDataPair> GetData()
        {
            return CsvDataImporter.GetData(Path);
        }
        
        public static IEnumerable<TableDataPair> GetData(params string[] fileNames)
        {
            var res = new List<TableDataPair>();
            var firstFileName = fileNames.FirstOrDefault();
            if (string.IsNullOrWhiteSpace(firstFileName))
                return new List<TableDataPair>();
            
            var directoryName = System.IO.Path.GetDirectoryName(firstFileName);
            var conStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source="
                         + directoryName + ";Extended Properties=\"text;HDR=Yes;FMT=Delimited\"";
            
            using (var con = new OleDbConnection(conStr))
            {
                foreach (var fName in fileNames)
                {
                    var fileName = System.IO.Path.GetFileName(fName);
                    var commandText = $@"select * from [{fileName}]";
                    using (var dataAdapter = new OleDbDataAdapter(commandText, con))
                    {
                        var dt = new DataTable();
                        dataAdapter.Fill(dt);
                        res.Add(new TableDataPair(fileName.Replace(".csv",""),dt));
                    }
                }
            }
            return res;
        }
    }
}
