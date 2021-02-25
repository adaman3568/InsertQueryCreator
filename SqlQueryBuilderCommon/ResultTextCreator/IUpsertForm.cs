using System.Data;

namespace SqlQueryBuilderCommon.ResultTextCreator
{
    public interface IUpsertForm
    {
        DataTable SelectedDataTable { get; }
    }
}