using InsertQueryCreatorCommon.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using InsertQueryCreatorCommon.Extentions.Excel;

namespace InsertQueryCreatorCommon.Importer
{
    public class ExcelDataImporter : IDataImport
    {
        public string Path { get; }

        public ExcelDataImporter(string path)
        {
            Path = path;
        }

        public IEnumerable<TableDataPair> GetData()
        {
            return MakeData(Path);
        }

        public static IEnumerable<TableDataPair> MakeData(string filePath)
        {
            using (var excel = new XLWorkbook(filePath))
            {

                foreach (IXLWorksheet sheet in excel.Worksheets)
                {
                    var dt = new DataTable();
                    var firstRow = true;
                    
                    foreach (var row in sheet.Rows())
                    {
                        if (firstRow)
                        {
                            dt.Columns.AddRange(row.GetStringArray().Select(s => new DataColumn(s)).ToArray());                            
                        }
                        else
                        {
                            var colItem = row.GetStringArray().Take(dt.Columns.Count).ToArray();
                            dt.Rows.Add(colItem);
                        }
                        firstRow = false;
                    }

                    yield return new TableDataPair(sheet.Name, dt);
                }

            }
        }
    }
}
