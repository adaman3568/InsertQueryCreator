using System.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SqlQueryBuilderCommon.StoredCreator;

namespace SqlQueryBuilderTest.StoredCreator.Insert
{
    [TestClass]
    public class ParamCreatorのテスト
    {
        [TestMethod]
        public void TestMethod1()
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

            var creator = new ParamCreator(dt.Rows[0]);
            creator.ColumnName.Is("車両名");
            creator.HasDefaultValue.IsFalse();
            creator.ParamName.Is("@車両名");
            creator.GetValueParam().Is("@車両名");
            creator.GetHeaderParam().Is("@車両名 varchar(200)");
            creator.IsImport().IsTrue();
            creator.IsOnlyDefaultValue().IsFalse();

            var creator2 = new ParamCreator(dt.Rows[1]);
            creator2.GetHeaderParam().Is("@車両名 varchar(200) = 'subaru'");

            var creator3 = new ParamCreator(dt.Rows[2]);
            creator3.GetValueParam().Is("'subaru'");
        }
    }


}
