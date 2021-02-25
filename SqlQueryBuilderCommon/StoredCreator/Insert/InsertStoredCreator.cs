using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace SqlQueryBuilderCommon.StoredCreator.Insert
{
    public class InsertStoredCreator
    {
        private string _tableName;
        private InsertParamCreatorCollection _collection;
        public InsertStoredCreator(string tableName, InsertParamCreatorCollection collection)
        {
            _tableName = tableName;
            _collection = collection;
        }

        public InsertStoredCreator(string tableName) : this(tableName, new InsertParamCreatorCollection())
        {

        }

        public void AddRow(DataRow row)
        {
            _collection.AddRow(row);
        }

        public void AddRow(IEnumerable<DataRow> rows)
        {
            _collection.AddRow(rows);
        }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append($@"create procedure usp_insert_{_tableName}");
            stringBuilder.Append(Environment.NewLine);
            stringBuilder.Append($@"({_collection.GetHeaderParamStr()})");
            stringBuilder.Append(Environment.NewLine);
            stringBuilder.Append($@"insert into {_tableName}({_collection.GetColumnStr()})");
            stringBuilder.Append(Environment.NewLine);
            stringBuilder.Append($@"values ({_collection.GetValueParamStr()})");

            return stringBuilder.ToString();
        }
    }
}