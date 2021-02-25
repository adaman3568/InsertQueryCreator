using System.Collections.Generic;
using System.Data;
using SqlQueryBuilderCommon.StoredCreator.Insert;

namespace SqlQueryBuilderCommon.StoredCreator
{
    public interface IStoredCreator
    {
        string TableName { get; }
        InsertParamCreatorCollection Collection { get; }
        void AddRow(DataRow row);
        void AddRow(IEnumerable<DataRow> rows);
        string ToString();
    }
}