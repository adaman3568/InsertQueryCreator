using System.Data;

namespace SqlQueryBuilderCommon.StoredCreator
{
    public class ParamCreator
    {

        #region プライベートメンバ


        private bool _isImport;
        private string _columnName;
        private string _typeName;
        private int _typeSize;
        private object _defaultValue;

        #endregion

        #region プライベートプロパティ

        private string _headerTypeName => _typeName == "varchar" ? $@"{_typeName}({_typeSize})" : _typeName;

        private string _headerParam => $@"{ParamName} {_headerTypeName}";

        #endregion

        #region パブリックプロパティ

        public string ParamName => $@"@{_columnName}";

        public string ColumnName => $@"{_columnName}";

        public bool HasDefaultValue => !string.IsNullOrWhiteSpace(_defaultValue.ToString());

        #endregion

        public ParamCreator(DataRow row)
        {
            _isImport = bool.Parse(row["取込"].ToString());
            _columnName = row["カラム名"].ToString();
            _typeName = row["型名"].ToString();
            _typeSize = int.Parse(row["型許容サイズ"].ToString());
            _defaultValue = row["デフォルト値"];
        }

        /// <summary>
        /// デフォルト値がNullでないもしくは、Importフラグが有れば、Importする。
        /// </summary>
        /// <returns></returns>
        public bool IsImport()
        {
            return _isImport || HasDefaultValue;
        }

        /// <summary>
        /// ヘッダーのParamに含まれるか？
        /// </summary>
        /// <returns></returns>
        public bool IsHeader()
        {
            return _isImport;
        }

        /// <summary>
        /// デフォルト値のImportだけ設定されている場合。
        /// </summary>
        /// <returns></returns>
        public bool IsOnlyDefaultValue()
        {
            return !_isImport && _defaultValue != null;
        }

        /// <summary>
        /// ヘッダーのParam引数で使用する
        /// </summary>
        /// <returns></returns>
        public string GetHeaderParam()
        {
            if (HasDefaultValue)
            {
                return $@"{_headerParam} = '{_defaultValue}'";
            }
            else
            {
                return _headerParam;
            }
        }

        public string GetValueParam()
        {
            if (IsOnlyDefaultValue())
            {
                return $@"'{_defaultValue.ToString()}'";
            }
            else
            {
                return ParamName;
            }
        }
    }
}