using System.Collections.Generic;
using InsertQueryCreatorCommon.Model;

namespace InsertQueryCreatorCommon.Importer
{
    public interface IDataImport
    {
        string Path { get; }
        IEnumerable<TableDataPair> GetData();
    }
}
