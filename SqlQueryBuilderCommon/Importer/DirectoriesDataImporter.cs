using SqlQueryBuilderCommon.Model;
using System.Collections.Generic;

namespace SqlQueryBuilderCommon.Importer
{
    public class DirectoriesDataImporter : IDataImport
    {
        public string Path { get; }
        private string[] _csvFileList;

        public DirectoriesDataImporter(string path)
        {
            Path = path;
            _csvFileList = getCsvFileList();
        }

        private string[] getCsvFileList()
        {
            return System.IO.Directory.GetFiles(this.Path, "*.csv");
        }

        public IEnumerable<TableDataPair> GetData()
        {
            return CsvDataImporter.GetData(_csvFileList);
        }
    }
}
