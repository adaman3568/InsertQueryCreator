using System;
using System.Data;

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

    public class UpdateStoredResultTextCreator : IUpsertTextCreator
    {
        private DataTable _dt;
        public void SetData(DataTable selectedDataTable)
        {
            _dt = selectedDataTable;
        }

        public string toString()
        {
            throw new NotImplementedException();
        }
    }

    public class InsertStoredResultTextCreator : IUpsertTextCreator
    {
        private DataTable _dt;
        public void SetData(DataTable selectedDataTable)
        {
            _dt = selectedDataTable;
        }

        public string toString()
        {
            throw new NotImplementedException();
        }
    }

    public interface IUpsertForm
    {
        DataTable SelectedDataTable { get;}
    }

    public interface IUpsertTextCreator
    {
        void SetData(DataTable selectedDataTable);
        string toString();
    }

    public enum UpsertType
    {
        Insert = 1,
        Update
    }
}