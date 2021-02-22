using System;
using System.Collections.Generic;
using System.Data;
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

        public FrmResult(Action parentFormShowEvent, ITableSelectForm parentForm)
        {
            InitializeComponent();
            _parentFormShowEvent = parentFormShowEvent;
            _parentForm = parentForm;
        }

        public void Show(ShowType show)
        {
            _showType = show;





            this.Show();
        }



        private void button4_Click(object sender, EventArgs e)
        {
            _parentFormShowEvent();
        }
    }
}
