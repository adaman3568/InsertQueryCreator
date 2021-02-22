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
    }
}
