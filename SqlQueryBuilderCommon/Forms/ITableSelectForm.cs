using System.Collections.Generic;
using SqlQueryBuilderCommon.Model;

namespace SqlQueryBuilderCommon.Forms
{
    public interface ITableSelectForm
    {
        IEnumerable<TableDataPair> SelectedDataPairs { get; }
    }
}