using System.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SqlQueryBuilderCommon.Extentions;
using SqlQueryBuilderCommon.StoredCreator.Insert;

namespace SqlQueryBuilderTest.StoredCreator.Insert
{
    [TestClass]
    public class InsertParamCreatorCollectionのテスト
    {
        [TestMethod]
        public void GetColumnStrのテスト()
        {
            var dt = new DataTable("Test");
            var col1 = dt.Columns.Add("取込", typeof(bool));
            var col2 = dt.Columns.Add("カラム名", typeof(string));
            var col3 = dt.Columns.Add("型名", typeof(string));
            var col4 = dt.Columns.Add("型許容サイズ", typeof(int));
            var col5 = dt.Columns.Add("デフォルト値", typeof(object));

            dt.Rows.Add(new object[] { true, "車両名", "varchar", "200", null });
            dt.Rows.Add(new object[] { true, "車両名", "varchar", "200", "subaru" });
            dt.Rows.Add(new object[] { false, "車両名", "varchar", "200", "subaru" });

            var collection = new InsertParamCreatorCollection();
            foreach (DataRow row in dt.Rows)
            {
                collection.AddRow(row);
            }

            var answer = $@"車両名
,車両名
,車両名";
            collection.GetColumnStr().Is(answer);

        }

        [TestMethod]
        public void GetHeaderParamStrのテスト()
        {
            var dt = new DataTable("Test");
            var col1 = dt.Columns.Add("取込", typeof(bool));
            var col2 = dt.Columns.Add("カラム名", typeof(string));
            var col3 = dt.Columns.Add("型名", typeof(string));
            var col4 = dt.Columns.Add("型許容サイズ", typeof(int));
            var col5 = dt.Columns.Add("デフォルト値", typeof(object));

            dt.Rows.Add(new object[] { true, "車両名", "varchar", "200", null });
            dt.Rows.Add(new object[] { true, "車両名", "varchar", "200", "subaru" });
            dt.Rows.Add(new object[] { false, "車両名", "varchar", "200", "subaru" });

            var collection = new InsertParamCreatorCollection();
            foreach (DataRow row in dt.Rows)
            {
                collection.AddRow(row);
            }

            var answer = $@"@車両名 varchar(200)
,@車両名 varchar(200) = 'subaru'";
            collection.GetHeaderParamStr().Is(answer);

        }

        [TestMethod]
        public void GetValueParamStrのテスト()
        {
            var dt = new DataTable("Test");
            var col1 = dt.Columns.Add("取込", typeof(bool));
            var col2 = dt.Columns.Add("カラム名", typeof(string));
            var col3 = dt.Columns.Add("型名", typeof(string));
            var col4 = dt.Columns.Add("型許容サイズ", typeof(int));
            var col5 = dt.Columns.Add("デフォルト値", typeof(object));

            dt.Rows.Add(new object[] { true, "車両名", "varchar", "200", null });
            dt.Rows.Add(new object[] { true, "車両名", "varchar", "200", "subaru" });
            dt.Rows.Add(new object[] { false, "車両名", "varchar", "200", "subaru" });

            var collection = new InsertParamCreatorCollection();
            collection.AddRow(dt.Rows.ToEnumerable());

            var answer = $@"@車両名
,@車両名
,'subaru'";
            collection.GetValueParamStr().Is(answer);

        }
    }
}
