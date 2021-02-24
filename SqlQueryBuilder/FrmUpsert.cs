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

        public FrmUpsert()
        {
            InitializeComponent();
            SetData();

            listBox1.DataSource = _tableList;
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
                table.TableName = groupedItem.First()["テーブル名"].ToString();
                _dataSet.Tables.Add(table);
                tList.Add(table.TableName);
            }

            _tableList = tList;
        }
    }
}
