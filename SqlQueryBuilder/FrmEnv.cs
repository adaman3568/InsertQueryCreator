using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SqlQueryBuilder
{
    public partial class FrmEnv : Form
    {
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
                return;
            }

            btn_conTest.Enabled = false;

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
    }
}
