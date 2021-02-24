using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;
using SqlQueryBuilderCommon.Forms;
using SqlQueryBuilderCommon.Model;
using SqlQueryBuilderCommon.ResultTextCreator;

namespace SqlQueryBuilder
{
    public partial class FrmResult : Form
    {
        private Action _parentFormShowEvent;
        private IResultTextCreator _resultTextCreator;

        public FrmResult(Action parentFormShowEvent, IResultTextCreator resultTextCreator)
        {
            InitializeComponent();
            _parentFormShowEvent = parentFormShowEvent;
            _resultTextCreator = resultTextCreator;
        }

        public new void Show()
        {
            textBox1.Text = _resultTextCreator.ToString();
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
