using System.Collections.Generic;
using System.Data;

namespace SqlQueryBuilderCommon.Extentions
{
    public static class DataRowCollectionExtensions
    {
        public static IEnumerable<System.Data.DataRow> ToEnumerable(this DataRowCollection collection)
        {
            var rowEnum = collection.GetEnumerator();
            while (rowEnum.MoveNext())
            {
                yield return (DataRow) rowEnum.Current;
            }
        }
    }
}