using System.Data;

namespace SqlQueryBuilderCommon.Model
{
    public class InsertQueryCreator
    {
        public string TableName { get; }
        private DataTable DataTable { get; }


        public InsertQueryCreator(string tableName,DataTable table)
        {
            TableName = tableName;
            DataTable = table;
        }

        public string GetQuery()
        {
            return "";
        }
    }
}
