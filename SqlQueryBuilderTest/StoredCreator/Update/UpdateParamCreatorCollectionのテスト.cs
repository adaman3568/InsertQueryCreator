using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data;
using SqlQueryBuilderCommon.Extentions;
using SqlQueryBuilderCommon.StoredCreator.Update;

namespace SqlQueryBuilderTest.StoredCreator.Update
{
    [TestClass]
    public class UpdateParamCreatorCollectionのテスト
    {
        public static DataTable MockDataTable()
        {
            var dt = new DataTable("Test");
            var col1 = dt.Columns.Add("取込", typeof(bool));
            var col2 = dt.Columns.Add("カラム名", typeof(string));
            var col3 = dt.Columns.Add("型名", typeof(string));
            var col4 = dt.Columns.Add("型許容サイズ", typeof(int));
            var col5 = dt.Columns.Add("デフォルト値", typeof(object));

            dt.Rows.Add(new object[] { true, "車両名", "varchar", "200", null });
            dt.Rows.Add(new object[] { true, "車両名", "varchar", "200", "subaru" });
            dt.Rows.Add(new object[] {false, "車両名", "varchar", "200", "subaru"});

            return dt;
        }

        [TestMethod]
        public void GetHeaderParamStrのテスト()
        {
            var dt = MockDataTable();
            var c = new UpdateParamCreatorCollection();
            c.AddRow(dt.Rows.ToEnumerable());
            var answer = $@"@車両名 varchar(200)
,@車両名 varchar(200) = 'subaru'";
            c.GetHeaderParamStr().Is(answer);
        }

        [TestMethod]
        public void GetUpdateParamStrのテスト()
        {
            var dt = MockDataTable();
            var c = new UpdateParamCreatorCollection();
            c.AddRow(dt.Rows.ToEnumerable());
            var answer = $@"車両名 = @車両名
,車両名 = @車両名
,車両名 = 'subaru'";
            c.GetHeaderParamStr().Is(answer);
        }
    }
}
