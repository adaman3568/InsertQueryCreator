using System.Collections.Generic;
using ClosedXML.Excel;

namespace InsertQueryCreatorCommon.Extentions.Excel
{
    public static class ExcelRow
    {
        public static IEnumerable<string> GetStringArray(this IXLRow row)
        {
            foreach (var cell in row.Cells())
            {
                yield return cell.Value.ToString();
            }
        }
    }
}