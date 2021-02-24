using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SqlQueryBuilderCommon.Helper;
using SqlQueryBuilderCommon.Model;
using SqlQueryBuilderCommon.Static;

namespace SqlQueryBuilder
{
    public partial class FrmEnv : Form
    {

        private string _envFileName => "dbSetting.xml";
        public FrmEnv()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txt_DBName.Text) && !string.IsNullOrWhiteSpace(txt_Password.Text) &&
                !string.IsNullOrWhiteSpace(txt_UserName.Text) && !string.IsNullOrWhiteSpace(txt_serverName.Text))
            {
                btn_conTest.Enabled = true;
                btn_save.Enabled = true;
                return;
            }

            btn_conTest.Enabled = false;
            btn_save.Enabled = false;

        }

        private void btn_conTest_Click(object sender, EventArgs e)
        {
            var conStr = new SqlConnectionStringBuilder()
            {
                InitialCatalog = txt_DBName.Text,
                UserID = txt_UserName.Text,
                Password = txt_Password.Text,
                DataSource = txt_serverName.Text
            };

            using (var con = new SqlConnection(conStr.ToString()))
            {
                try
                {
                    con.Open();
                    lbl_conResult.Text = $@"接続確認が取れました。{Environment.NewLine}{con.State.ToString()}";
                }
                catch (Exception exception)
                {
                    lbl_conResult.Text = $@"接続確認が取れませんでした。{Environment.NewLine}{con.State.ToString()}";
                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var instance = new DbConnectionString(txt_DBName.Text, txt_serverName.Text, txt_UserName.Text,
                txt_Password.Text);
            var xmlHelper = new XmlHelper<DbConnectionString>(Pathes.GetEnvPath(_envFileName));
            xmlHelper.Save(instance);
        }

        private void FrmEnv_Load(object sender, EventArgs e)
        {
            if (Pathes.ExistsFile(_envFileName))
            {
                var ins = new XmlHelper<DbConnectionString>(Pathes.GetEnvPath(_envFileName)).Read();
                txt_DBName.Text = ins.InitialCatalog;
                txt_serverName.Text = ins.DataSource;
                txt_UserName.Text = ins.UserName;
                txt_Password.Text = ins.PassWord;
            }
        }
    }
}
