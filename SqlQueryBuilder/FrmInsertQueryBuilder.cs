using System;
using System.Windows.Forms;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using SqlQueryBuilderCommon.Forms;
using SqlQueryBuilderCommon.Model;
using SqlQueryBuilderCommon.Importer;

namespace SqlQueryBuilder
{
    public partial class FrmInsertQueryBuilder : Form, ITableSelectForm
    {
        private IEnumerable<TableDataPair> _tableItems;
        public IEnumerable<TableDataPair> SelectedDataPairs { get; private set; }
        private Action<ShowType> _childFormShowEvent;

        public FrmInsertQueryBuilder(Action<ShowType> childFormShowEvent)
        {
            InitializeComponent();
            _childFormShowEvent = childFormShowEvent;
        }
        
        #region イベントハンドラ
        private void button5_Click(object sender, EventArgs e)
        {
            _childFormShowEvent(ShowType.Limited);
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            // ここでCSVパスを取得
            
            string fileName = "";
            using (var ofd = new OpenFileDialog())
            {
                ofd.Filter = "csvファイル|*.csv";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    fileName = ofd.FileName;
                }
                else
                {
                    return;
                }
            }
            
            SetData(new CsvDataImporter(fileName));
        }

        private void btn_fromExcel_Click(object sender, EventArgs e)
        {
            // ここでエクセルパスを取得
            string fileName = "";
            using (var ofd = new OpenFileDialog())
            {
                ofd.Filter = "エクセルファイル|*.xls;*.xlsx;*.xlsm;";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    fileName = ofd.FileName;
                }
                else
                {
                    return;
                }
            }
            SetData(new ExcelDataImporter(fileName));
        }
        
        private void btn_fromDirectory_Click(object sender, EventArgs e)
        {
            // ここでディレクトリパスを取得
            string direPath = "";
            using (var fbd = new FolderBrowserDialog())
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    direPath = fbd.SelectedPath;
                }
                else
                {
                    return;
                }
            }
            
            SetData(new DirectoriesDataImporter(direPath));
        }
        #endregion

        #region 通常メソッド
        private void SetData(IDataImport importer)
        {
            _tableItems = importer.GetData();
            var tableDataPairs = _tableItems as TableDataPair[] ?? _tableItems.ToArray();
            
            if (!tableDataPairs.Any())
                return;

            string[] tableNames = tableDataPairs.Select(t => t.TableName).ToArray();
            listBox1.Items.AddRange(tableNames);
        }
        
        private void ShowEvent()
        {
            this.Show();
        }
        #endregion

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectdTable = listBox1.SelectedItem.ToString();
            var data = _tableItems.First(t => t.TableName == selectdTable);
            dataGridView1.DataSource = data.DataTable;
            setSelectedItem();
        }

        private void setSelectedItem()
        {
            var selectedItems = getSelectedItemList().ToArray();
            var res = _tableItems.ToList().Where(item => selectedItems.Contains(item.TableName));
            SelectedDataPairs = new List<TableDataPair>(res);

        }

        private IEnumerable<string> getSelectedItemList()
        {
            var itemEnum = listBox1.SelectedItems.GetEnumerator();
            while (itemEnum.MoveNext())
            {
                yield return (string)itemEnum.Current;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            _childFormShowEvent(ShowType.All);
        }
    }
}
