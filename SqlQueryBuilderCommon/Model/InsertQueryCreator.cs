using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using DocumentFormat.OpenXml.Drawing.Charts;
using DataTable = System.Data.DataTable;

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

        private string getHeader()
        {
            var str = string.Join(",",getColumnNames().ToArray());
            return $@"insert into {TableName}({str})";
        }

        private IEnumerable<string> getColumnNames()
        {
            foreach (DataColumn col in DataTable.Columns)
            {
                yield return col.ColumnName;
            }
        }

        private IEnumerable<string> getBodies()
        {
            var rowEnum = DataTable.Rows.GetEnumerator();
            while (rowEnum.MoveNext())
            {
                yield return getBodyValues((DataRow) rowEnum.Current);
            }
        }

        private string getBodyValues(DataRow row)
        {
            var res = row.ItemArray.Select(item => $@"'{item.ToString()}'");
            return $@"({string.Join(",", res)})";
        }

        public string GetQuery()
        {
            var bodies = getBodies().ToArray();
            return $@"{getHeader()}
                        {Environment.NewLine}values
                        {Environment.NewLine}{string.Join($@"{Environment.NewLine},", bodies)};";
        }
    }
}
