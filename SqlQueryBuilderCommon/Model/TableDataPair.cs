using System.Data;

namespace SqlQueryBuilderCommon.Model
{
    public class TableDataPair
    {
        public string TableName { get; }
        public DataTable DataTable { get; }
        public InsertQueryCreator QueryCreator => new InsertQueryCreator(TableName, DataTable);

        public TableDataPair(string tableName,DataTable table)
        {
            TableName = tableName;
            DataTable = table;
        }
    }
}
