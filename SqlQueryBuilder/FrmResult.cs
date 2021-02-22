using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;
using SqlQueryBuilderCommon.Forms;
using SqlQueryBuilderCommon.Model;

namespace SqlQueryBuilder
{
    public partial class FrmResult : Form
    {
        private Action _parentFormShowEvent;
        private ITableSelectForm _parentForm;
        private ShowType _showType;

        private StringBuilder _showStr;

        public FrmResult(Action parentFormShowEvent, ITableSelectForm parentForm)
        {
            InitializeComponent();
            _parentFormShowEvent = parentFormShowEvent;
            _parentForm = parentForm;
        }

        public void Show(ShowType show)
        {
            _showStr = new StringBuilder();
            _showType = show;

            IEnumerable<TableDataPair> targetData;
            switch (show)
            {
                case ShowType.All:
                    targetData = _parentForm.DataPairs;
                    break;
                case ShowType.Limited:
                    targetData = _parentForm.SelectedDataPairs;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(show), show, null);
            }

            foreach (var data in targetData)
            {
                var str = new SqlQueryBuilderCommon.Model.InsertQueryCreator(data.TableName, data.DataTable)
                    .GetQuery();
                _showStr.Append(string.Format("{0};{1}{1}",str,Environment.NewLine));
            }

            textBox1.Text = _showStr.ToString();

            this.Show();
        }



        private void button4_Click(object sender, EventArgs e)
        {
            _parentFormShowEvent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(textBox1.Text);
            MessageBox.Show("クリップボードにコピーしました。");
        }
    }
}
