using System.Data;

namespace SqlQueryBuilderCommon.ResultTextCreator
{
    public interface IUpsertTextCreator
    {
        void SetData(DataTable selectedDataTable);
        string toString();
    }
}