using System.Collections.Generic;
using System.Data;

namespace SqlQueryBuilderCommon.StoredCreator
{
    public interface IParamCreatorCollection
    {
        IEnumerable<ParamCreator> Creators { get; }
        string GetHeaderParamStr();
        void AddRow(DataRow row);
        void AddRow(IEnumerable<DataRow> rows);
    }
}