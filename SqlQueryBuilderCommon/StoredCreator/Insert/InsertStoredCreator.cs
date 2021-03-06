﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace SqlQueryBuilderCommon.StoredCreator.Insert
{

    public class InsertStoredCreator : IStoredCreator
    {
        public string TableName { get; }
        public IParamCreatorCollection Collection { get; }

        private InsertParamCreatorCollection _collection => (InsertParamCreatorCollection) Collection;

        public InsertStoredCreator(string tableName, InsertParamCreatorCollection collection)
        {
            TableName = tableName;
            Collection = collection;
        }

        public InsertStoredCreator(string tableName) : this(tableName, new InsertParamCreatorCollection())
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
            stringBuilder.Append($@"create procedure usp_insert_{TableName}");
            stringBuilder.Append(Environment.NewLine);
            stringBuilder.Append($@"({Collection.GetHeaderParamStr()})");
            stringBuilder.Append(Environment.NewLine);
            stringBuilder.Append($@"insert into {TableName}({_collection.GetColumnStr()})");
            stringBuilder.Append(Environment.NewLine);
            stringBuilder.Append($@"values ({_collection.GetValueParamStr()})");

            return stringBuilder.ToString();
        }
    }
}