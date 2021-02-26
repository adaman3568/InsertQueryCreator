using System;
using SqlQueryBuilderCommon.ResultTextCreator.Insert;
using SqlQueryBuilderCommon.ResultTextCreator.Update;

namespace SqlQueryBuilderCommon.ResultTextCreator
{
    public class UpsertResultTextCreator : IResultTextCreator
    {
        private IUpsertTextCreator _upsertTextCreator;
        private IUpsertForm _upsertForm;

        public UpsertResultTextCreator(IUpsertForm upsertForm)
        {
            _upsertForm = upsertForm;
        }

        public string toString()
        {
            _upsertTextCreator.SetData(_upsertForm.SelectedDataTable);
            return _upsertTextCreator.toString();
        }

        public void SetUpsertType(UpsertType type)
        {
            switch (type)
            {
                case UpsertType.Insert:
                    _upsertTextCreator = new InsertStoredResultTextCreator();
                    break;
                case UpsertType.Update:
                    _upsertTextCreator = new UpdateStoredResultTextCreator();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }
    }

    public enum UpsertType
    {
        Insert = 1,
        Update
    }
}