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
        public IResultTextCreator ResultTextCreator;

        public FrmResult(Action parentFormShowEvent, IResultTextCreator resultTextCreator)
        {
            InitializeComponent();
            _parentFormShowEvent = parentFormShowEvent;
            ResultTextCreator = resultTextCreator;
        }

        public new void Show()
        {
            textBox1.Text = ResultTextCreator.toString();
            base.Show();
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
