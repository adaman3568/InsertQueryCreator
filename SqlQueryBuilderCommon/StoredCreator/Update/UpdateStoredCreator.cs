using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using SqlQueryBuilderCommon.StoredCreator.Insert;

namespace SqlQueryBuilderCommon.StoredCreator.Update
{
    public class UpdateStoredCreator : IStoredCreator
    {
        public string TableName { get; }
        public IParamCreatorCollection Collection { get; }
        private UpdateParamCreatorCollection _collection => (UpdateParamCreatorCollection) Collection;

        public UpdateStoredCreator(string tableName, UpdateParamCreatorCollection collection)
        {
            TableName = tableName;
            Collection = collection;
        }

        public UpdateStoredCreator(string tableName):this(tableName,new UpdateParamCreatorCollection())
        {
            
        }

        public void AddRow(DataRow row)
        {
            Collection.AddRow(row);
        }

        public void AddRow(IEnumerable<DataRow> rows)
        {
            Collection.AddRow(rows);
        }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append($@"create procedure usp_update_{TableName}");
            stringBuilder.Append(Environment.NewLine);
            stringBuilder.Append($@"({Collection.GetHeaderParamStr()})");
            stringBuilder.Append(Environment.NewLine);
            stringBuilder.Append($@"update {TableName} set");
            stringBuilder.Append(Environment.NewLine);
            stringBuilder.Append(_collection.GetUpdateParamStr());

            return stringBuilder.ToString();
        }
    }
}