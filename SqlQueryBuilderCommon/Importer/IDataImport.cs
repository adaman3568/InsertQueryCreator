using SqlQueryBuilderCommon.Model;
using System.Collections.Generic;

namespace SqlQueryBuilderCommon.Importer
{
    public interface IDataImport
    {
        string Path { get; }
        IEnumerable<TableDataPair> GetData();
    }
}
