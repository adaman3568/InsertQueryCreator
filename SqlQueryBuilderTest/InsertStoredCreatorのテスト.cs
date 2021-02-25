using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data;
using System.Linq;
using SqlQueryBuilderCommon.Extentions;
using SqlQueryBuilderCommon.StoredCreator;

namespace SqlQueryBuilderTest
{
    [TestClass]
    public class InsertStoredCreatorのテスト
    {
        [TestMethod]
        public void 初期化Aパターン()
        {
            var dt = new DataTable("Test");
            var col1 = dt.Columns.Add("取込",typeof(bool));
            var col2 = dt.Columns.Add("カラム名",typeof(string));
            var col3 = dt.Columns.Add("型名",typeof(string));
            var col4 = dt.Columns.Add("型許容サイズ",typeof(int));
            var col5 = dt.Columns.Add("デフォルト値",typeof(object));

            dt.Rows.Add(new object[] {true, "車両名", "varchar","200",null});
            dt.Rows.Add(new object[] { true, "購入価格", "int", "16", null });
            dt.Rows.Add(new object[] { true, "車検満了日", "datetime", "8", null });
            dt.Rows.Add(new object[] { false, "選択内容1", "datetime", "8", "1" });
            dt.Rows.Add(new object[] { true, "備考", "varchar", "200", "備考内容" });
            dt.Rows.Add(new object[] { false, "車検満了日", "datetime", "8", null });

            var collection = new InsertParamCreatorCollection();
            foreach (DataRow row in dt.Rows)
            {
                collection.AddRow(row);
            }
            
            var insertStoredCreator = new InsertStoredCreator("Test1", collection);
            var answer = $@"create procedure usp_insert_Test1
(@車両名 varchar(200)
,@購入価格 int
,@車検満了日 datetime
,@備考 varchar(200) = '備考内容')
insert into Test1(車両名
,購入価格
,車検満了日
,選択内容1
,備考)
values (@車両名
,@購入価格
,@車検満了日
,'1'
,@備考)";
            insertStoredCreator.ToString().Is(answer);

        }

        [TestMethod]
        public void 初期化Bパターン()
        {
            var dt = new DataTable("Test");
            var col1 = dt.Columns.Add("取込", typeof(bool));
            var col2 = dt.Columns.Add("カラム名", typeof(string));
            var col3 = dt.Columns.Add("型名", typeof(string));
            var col4 = dt.Columns.Add("型許容サイズ", typeof(int));
            var col5 = dt.Columns.Add("デフォルト値", typeof(object));

            dt.Rows.Add(new object[] { true, "車両名", "varchar", "200", null });
            dt.Rows.Add(new object[] { true, "購入価格", "int", "16", null });
            dt.Rows.Add(new object[] { true, "車検満了日", "datetime", "8", null });
            dt.Rows.Add(new object[] { false, "選択内容1", "datetime", "8", "1" });
            dt.Rows.Add(new object[] { true, "備考", "varchar", "200", "備考内容" });
            dt.Rows.Add(new object[] { false, "車検満了日", "datetime", "8", null });

            var insertStoredCreator = new InsertStoredCreator("Test1");
            insertStoredCreator.AddRow(dt.Rows.ToEnumerable());
            var answer = $@"create procedure usp_insert_Test1
(@車両名 varchar(200)
,@購入価格 int
,@車検満了日 datetime
,@備考 varchar(200) = '備考内容')
insert into Test1(車両名
,購入価格
,車検満了日
,選択内容1
,備考)
values (@車両名
,@購入価格
,@車検満了日
,'1'
,@備考)";
            insertStoredCreator.ToString().Is(answer);

        }

        [TestMethod]
        public void 初期化Cパターン()
        {
            var dt = new DataTable("Test");
            var col1 = dt.Columns.Add("取込", typeof(bool));
            var col2 = dt.Columns.Add("カラム名", typeof(string));
            var col3 = dt.Columns.Add("型名", typeof(string));
            var col4 = dt.Columns.Add("型許容サイズ", typeof(int));
            var col5 = dt.Columns.Add("デフォルト値", typeof(object));

            dt.Rows.Add(new object[] { true, "車両名", "varchar", "200", null });
            dt.Rows.Add(new object[] { true, "購入価格", "int", "16", null });
            dt.Rows.Add(new object[] { true, "車検満了日", "datetime", "8", null });
            dt.Rows.Add(new object[] { false, "選択内容1", "datetime", "8", "1" });
            dt.Rows.Add(new object[] { true, "備考", "varchar", "200", "備考内容" });
            dt.Rows.Add(new object[] { false, "車検満了日", "datetime", "8", null });

            var insertStoredCreator = new InsertStoredCreator("Test1");
            dt.Rows.ToEnumerable().ToList().ForEach(r => insertStoredCreator.AddRow(r));
            var answer = $@"create procedure usp_insert_Test1
(@車両名 varchar(200)
,@購入価格 int
,@車検満了日 datetime
,@備考 varchar(200) = '備考内容')
insert into Test1(車両名
,購入価格
,車検満了日
,選択内容1
,備考)
values (@車両名
,@購入価格
,@車検満了日
,'1'
,@備考)";
            insertStoredCreator.ToString().Is(answer);

        }
    }
}
