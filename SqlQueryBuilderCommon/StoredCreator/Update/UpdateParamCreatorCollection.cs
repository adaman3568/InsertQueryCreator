using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace SqlQueryBuilderCommon.StoredCreator.Update
{
    public class UpdateParamCreatorCollection : IParamCreatorCollection
    {
        public IEnumerable<ParamCreator> Creators { get; private set; }
        private string _separator => $@"{Environment.NewLine},";
        
        public UpdateParamCreatorCollection(IEnumerable<ParamCreator> paramCreators)
        {
            Creators = paramCreators;
        }

        public UpdateParamCreatorCollection() : this(new List<ParamCreator>())
        {
            
        }


        public string GetHeaderParamStr()
        {
            var param = Creators.Where(c => c.IsHeader()).Select(c => c.GetHeaderParam());
            return string.Join(_separator, param);
        }

        public string GetUpdateParamStr()
        {
            var updateStrs = Creators.Where(c => c.IsImport())
                .Select(c => getUpdateParamStr(c.ColumnName, c.GetValueParam()));

            return string.Join(_separator, updateStrs);
        }

        public void AddRow(DataRow row)
        {
            Creators = Creators.Append(new ParamCreator(row));
        }

        public void AddRow(IEnumerable<DataRow> rows)
        {

            var res = new List<ParamCreator>(Creators);
            res.AddRange(rows.Select(r => new ParamCreator(r)));
            Creators = res;
        }

        #region Privateメソッド

        private string getUpdateParamStr(string columnName,string paramValue)
        {
            return $@"{columnName} = {paramValue}";
        }

        #endregion

    }
}