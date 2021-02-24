using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SqlQueryBuilderCommon.SqlCon;

namespace SqlQueryBuilder
{
    public partial class FrmUpsert : Form
    {
        private DataSet _dataSet;
        private IEnumerable<string> _tableList;

        private IEnumerable<string> _hideColumnNames => new List<string>()
        {
            "テーブルID",
            "テーブル名",
            "カラムID",
            "型ID",
        };

        private IEnumerable<string> _readOnlyColumnNames => new List<string>()
        {
            "カラム名",
            "型許容サイズ",
            "型名"
        };

        public FrmUpsert()
        {
            InitializeComponent();
            SetData();

            listBox1.DataSource = _tableList;

            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.CornflowerBlue;
            dataGridView1.AlternatingRowsDefaultCellStyle.ForeColor = Color.White;
        }

        private void SetData()
        {
            _dataSet = new DataSet();


            var dt = new DataTable();
            using (var con = SqlConSingleton.GetSqlConnection())
            {
                var q = $@"select 
                o.object_id as テーブルID,
                o.name as 'テーブル名',
                c.column_id as カラムID,
                c.name as カラム名,
                t.system_type_id as 型ID,
                t.name as 型名,
                c.max_length as 型許容サイズ


                from sys.columns as c
                    inner join sys.objects as o
                on(c.object_id = o.object_id)

                inner join sys.types as t
                on(c.system_type_id = t.system_type_id)

                where o.type = 'U'

                order by o.object_id,c.column_id";

                using (var command = new SqlCommand(q,con))
                {

                    using (var adapter = new SqlDataAdapter(command))
                    {
                        con.Open();
                        adapter.Fill(dt);
                    }
                }
            }

            var tList = new List<string>();
            var groupedList = dt.AsEnumerable().GroupBy(r => r["テーブル名"]);
            foreach (var groupedItem in groupedList)
            {
                var table = groupedItem.CopyToDataTable();
                table.Columns.Add(new DataColumn("取込", typeof(bool)){DefaultValue = true});
                table.Columns["取込"].SetOrdinal(0);

                table.Columns.Add(new DataColumn("デフォルト値", typeof(object)){DefaultValue = null});
                table.TableName = groupedItem.First()["テーブル名"].ToString();
                _dataSet.Tables.Add(table);
                tList.Add(table.TableName);
            }

            _tableList = tList;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var tableName = listBox1.SelectedItem.ToString();
            var targetTable = _dataSet.Tables[tableName];
            if (targetTable != null)
            {
                dataGridView1.DataSource = targetTable;
            }
        }

        private void dataGridView1_DataSourceChanged(object sender, EventArgs e)
        {
            var dgv = (DataGridView) sender;

            foreach (DataGridViewColumn col in dgv.Columns)
            {
                if (_hideColumnNames.Contains(col.Name))
                {
                    col.Visible = false;
                }

                if (_readOnlyColumnNames.Contains(col.Name))
                {
                    col.ReadOnly = true;
                }

                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            var row = dataGridView1.Rows[e.RowIndex];
            var isImport = bool.Parse(row.Cells["取込"].Value.ToString());
            var defaultValue = row.Cells["デフォルト値"].Value;
            if (!isImport && (defaultValue == null || string.IsNullOrWhiteSpace(defaultValue.ToString())))
            {
                row.DefaultCellStyle.BackColor = Color.Gray;
                row.DefaultCellStyle.ForeColor = Color.Black;
            }
            else
            {
                row.DefaultCellStyle.BackColor = default;
                row.DefaultCellStyle.ForeColor = Color.Black;
            }
        }
    }
}
