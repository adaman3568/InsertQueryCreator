using System.Data;
using SqlQueryBuilderCommon.Extentions;
using SqlQueryBuilderCommon.StoredCreator.Update;

namespace SqlQueryBuilderCommon.ResultTextCreator.Update
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
            var collection = new UpdateParamCreatorCollection();
            collection.AddRow(_dt.Rows.ToEnumerable());
            var creator = new UpdateStoredCreator(_dt.TableName, collection);
            return creator.ToString();
        }
    }
}