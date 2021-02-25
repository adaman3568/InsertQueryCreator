using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using SqlQueryBuilderCommon.Static;

namespace SqlQueryBuilderCommon.StoredCreator
{

    public class InsertParamCreatorCollection : IParamCreatorCollection
    {
        public IEnumerable<ParamCreator> Creators { get; private set; }

        private string _separator = $@"{Environment.NewLine},";

        public InsertParamCreatorCollection():this(new List<ParamCreator>())
        {
        }

        public InsertParamCreatorCollection(IEnumerable<ParamCreator> creators)
        {
            Creators = creators;
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
            Creators = Creators.Append(new ParamCreator(row));
        }

        public void AddRow(IEnumerable<DataRow> rows)
        {
            var creators = new List<ParamCreator>(Creators);
            creators.AddRange(rows.Select(r => new ParamCreator(r)));
            Creators = creators;
        }
    }
}