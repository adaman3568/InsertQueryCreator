using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SqlQueryBuilderCommon.CustomControl;
using SqlQueryBuilderCommon.Forms;

namespace SqlQueryBuilder
{
    public partial class FrmIndex : Form
    {

        #region プライベートメンバ
        private Color _currentBtnColor => Color.AliceBlue;
        private Color _defaultBtnColor => Color.Navy;

        private Form _frmInsertQueryBuilder;
        private FrmResult _frmResult;
        private FrmEnv _frmEnv;
        private IEnumerable<Form> _forms;

        #endregion

        public FrmIndex()
        {
            InitializeComponent();

            _frmInsertQueryBuilder = new FrmInsertQueryBuilder((type) =>
            {
                _frmInsertQueryBuilder.Hide();
                _frmResult.Show(type);

            }) {TopLevel = false};

            formPanel.Controls.Add(_frmInsertQueryBuilder);
            _frmInsertQueryBuilder.Dock = DockStyle.Fill;
            _frmInsertQueryBuilder.Show();

            _frmResult = new FrmResult(() =>
            {
                _frmResult.Hide();
                _frmInsertQueryBuilder.Show();
            },(ITableSelectForm)_frmInsertQueryBuilder)
            {
                TopLevel = false, Dock = DockStyle.Fill
            };
            formPanel.Controls.Add(_frmResult);

            _frmEnv = new FrmEnv()
            {
                TopLevel = false,
                Dock = DockStyle.Fill
            };
            formPanel.Controls.Add(_frmEnv);

            _forms = new List<Form>()
            {
                _frmInsertQueryBuilder,
                _frmResult,
                _frmEnv
            };
        }

        private void FrmIndex_Load(object sender, EventArgs e)
        {
            InitializeToolStrip();
        }

        #region 初期化

        private void InitializeToolStrip()
        {
            toolStripStatusLabel1.Text =
                System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly()
                    .Location).ProductVersion;
        }

        #endregion

        #region イベントハンドラ

        public void SelectorBtnClick(object sender, EventArgs e)
        {
            var btn = (SelectorButton) sender;
        }

        private void FrmIndex_Load_1(object sender, EventArgs e)
        {

        }

        #endregion

        #region 通常メソッド




        #endregion

        private void button2_Click(object sender, EventArgs e)
        {
            _forms.ToList().ForEach(f => f.Hide());
            _frmEnv.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _forms.ToList().ForEach(f => f.Hide());
            _frmInsertQueryBuilder.Show();
        }
    }
}
