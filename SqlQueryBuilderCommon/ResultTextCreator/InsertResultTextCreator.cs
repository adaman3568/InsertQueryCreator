using System;
using System.Collections.Generic;
using System.Text;
using SqlQueryBuilderCommon.Forms;
using SqlQueryBuilderCommon.Model;

namespace SqlQueryBuilderCommon.ResultTextCreator
{
    public class InsertResultTextCreator : IResultTextCreator
    {
        private ITableSelectForm _parentForm;
        private ShowType _showType;
        private StringBuilder _showStr;

        public InsertResultTextCreator(ITableSelectForm parentForm)
        {
            _parentForm = parentForm;
        }

        public void SetShowType(ShowType type)
        {
            _showType = type;
        }

        public string toString()
        {
            _showStr = new StringBuilder();

            IEnumerable<TableDataPair> targetData;
            switch (_showType)
            {
                case ShowType.All:
                    targetData = _parentForm.DataPairs;
                    break;
                case ShowType.Limited:
                    targetData = _parentForm.SelectedDataPairs;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(_showType), _showType, null);
            }

            foreach (var data in targetData)
            {
                var str = new SqlQueryBuilderCommon.Model.InsertQueryCreator(data.TableName, data.DataTable)
                    .GetQuery();
                _showStr.Append(string.Format("{0};{1}{1}", str, Environment.NewLine));
            }

            return _showStr.ToString();
        }
    }
}