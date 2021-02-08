using System;
using System.Windows.Forms;

namespace InsertQueryCreator
{
    public partial class FrmResult : Form
    {
        private Action _parentFormShowEvent;
        public FrmResult(Action parentFormShowEvent)
        {
            InitializeComponent();
            _parentFormShowEvent = parentFormShowEvent;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            _parentFormShowEvent();
        }
    }
}
