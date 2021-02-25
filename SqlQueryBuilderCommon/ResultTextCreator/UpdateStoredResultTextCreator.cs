using System.Data;

namespace SqlQueryBuilderCommon.ResultTextCreator
{
    public class UpdateStoredResultTextCreator : IUpsertTextCreator
    {
        private DataTable _dt;
        public void SetData(DataTable selectedDataTable)
        {
            _dt = selectedDataTable;
        }

        public string toString()
        {
            return "";
        }
    }
}