using System.Data;
using SqlQueryBuilderCommon.Extentions;
using SqlQueryBuilderCommon.StoredCreator;

namespace SqlQueryBuilderCommon.ResultTextCreator
{
    public class InsertStoredResultTextCreator : IUpsertTextCreator
    {
        private DataTable _dt;
        public void SetData(DataTable selectedDataTable)
        {
            _dt = selectedDataTable;
        }

        public string toString()
        {
            var collection = new InsertParamCreatorCollection();
            collection.AddRow(_dt.Rows.ToEnumerable());
            var insertStoredCreator = new InsertStoredCreator(_dt.TableName, collection);
            return insertStoredCreator.ToString();
        }
    }
}