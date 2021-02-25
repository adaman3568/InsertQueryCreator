using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using SqlQueryBuilderCommon.Static;
using SqlQueryBuilderCommon.StoredCreator.ParamCreator;

namespace SqlQueryBuilderCommon.StoredCreator
{
    public class InsertParamCreatorCollection
    {
        private IEnumerable<InsertParamCreator> Creators;

        private string _separator = $@"{Environment.NewLine},";

        public InsertParamCreatorCollection()
        {
            Creators = new List<InsertParamCreator>();
        }

        public string GetHeaderParamStr()
        {
            var param = Creators.Where(c => c.IsHeader()). Select(c => c.GetHeaderParam());
            return string.Join(_separator, param);
        }

        public string GetColumnStr()
        {
            var param = Creators.Where(c => c.IsImport()).Select(c => c.ColumnName);
            return string.Join(_separator, param);
        }

        public string GetValueParamStr()
        {
            var param = Creators.Where(c => c.IsImport()).Select(c => c.GetValueParam());
            return string.Join(_separator, param);
        }

        public void AddRow(DataRow row)
        {
            Creators = Creators.Append(new InsertParamCreator(row));
        }

        public void AddRow(IEnumerable<DataRow> rows)
        {
            var creators = new List<InsertParamCreator>(Creators);
            creators.AddRange(rows.Select(r => new InsertParamCreator(r)));
            Creators = creators;
        }
    }
}