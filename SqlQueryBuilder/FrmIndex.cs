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
using System.Windows.Forms.VisualStyles;
using SqlQueryBuilderCommon.CustomControl;
using SqlQueryBuilderCommon.Forms;
using SqlQueryBuilderCommon.ResultTextCreator;
using SqlQueryBuilderCommon.ResultTextCreator.Insert;
using SqlQueryBuilderCommon.ResultTextCreator.Update;

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
        private FrmUpsert _frmUpsert;
        private FrmResult _frmUpsertResult;
        private IEnumerable<Form> _forms;

        private InsertResultTextCreator _insertResultTextCreator;

        #endregion

        public FrmIndex()
        {
            InitializeComponent();

            InitializeInsertGroup();
            InitializeFrmResult();
            InitializeFrmEnv();
            InitializeFrmUpsert();
            InitializeToolStrip();
            InitializeFrmUpsertResult();


            _forms = new List<Form>()
            {
                _frmInsertQueryBuilder,
                _frmResult,
                _frmEnv,
                _frmUpsert
            };
        }


        #region 初期化

        private void InitializeToolStrip()
        {
            toolStripStatusLabel1.Text =
                System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly()
                    .Location).ProductVersion;
        }

        private void InitializeInsertGroup()
        {
            _frmInsertQueryBuilder = new FrmInsertQueryBuilder((type) =>
                {
                    _frmInsertQueryBuilder.Hide();
                    _insertResultTextCreator.SetShowType(type);
                    _frmResult.Show();

                })
                { TopLevel = false };
            _insertResultTextCreator = new InsertResultTextCreator((ITableSelectForm)_frmInsertQueryBuilder);

            formPanel.Controls.Add(_frmInsertQueryBuilder);
            _frmInsertQueryBuilder.Dock = DockStyle.Fill;
            _frmInsertQueryBuilder.Show();
        }

        private void InitializeFrmResult()
        {
            _frmResult = new FrmResult(() =>
            {
                _frmResult.Hide();
                _frmInsertQueryBuilder.Show();
            }, _insertResultTextCreator)
            {
                TopLevel = false,
                Dock = DockStyle.Fill
            };
            formPanel.Controls.Add(_frmResult);
        }

        private void InitializeFrmEnv()
        {
            _frmEnv = new FrmEnv()
            {
                TopLevel = false,
                Dock = DockStyle.Fill
            };
            formPanel.Controls.Add(_frmEnv);
        }

        private void InitializeFrmUpsert()
        {
            Action showInsertResult = () =>
            {
                var r = (UpsertResultTextCreator) _frmUpsertResult.ResultTextCreator;
                r.SetUpsertType(UpsertType.Insert);
                _frmUpsert.Hide();
                _frmUpsertResult.Show();


            };

            Action showUpdateResult = () =>
            {
                var r = (UpsertResultTextCreator)_frmUpsertResult.ResultTextCreator;
                r.SetUpsertType(UpsertType.Update);
                _frmUpsert.Hide();
                _frmUpsertResult.Show();
            };

            _frmUpsert = new FrmUpsert(showInsertResult,showUpdateResult)
            {
                TopLevel = false,
                Dock = DockStyle.Fill
            };
            formPanel.Controls.Add(_frmUpsert);
        }

        private void InitializeFrmUpsertResult()
        {
            _frmUpsertResult = new FrmResult(() =>
            {
                _frmUpsert.Show();
            },new UpsertResultTextCreator(_frmUpsert));
            _frmUpsertResult.TopLevel = false;
            _frmUpsertResult.Dock = DockStyle.Fill;

            formPanel.Controls.Add(_frmUpsertResult);
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

        private void button3_Click(object sender, EventArgs e)
        {
            _forms.ToList().ForEach(f => f.Hide());
            _frmUpsert.Show();
        }

        #endregion

        #region 通常メソッド




        #endregion


    }
}
