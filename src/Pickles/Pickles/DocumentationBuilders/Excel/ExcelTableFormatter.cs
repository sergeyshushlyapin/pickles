﻿#region License

/*
    Copyright [2011] [Jeffrey Cameron]

   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
*/

#endregion

using System;
using ClosedXML.Excel;

using PicklesDoc.Pickles.ObjectModel;
using PicklesDoc.Pickles.Parser;

namespace PicklesDoc.Pickles.DocumentationBuilders.Excel
{
    public class ExcelTableFormatter
    {
        private const int TableStartColumn = 4;

        public void Format(IXLWorksheet worksheet, Table table, ref int row)
        {
            int startRow = row;
            int headerColumn = TableStartColumn;
            foreach (string cell in table.HeaderRow)
            {
                worksheet.Cell(row, headerColumn).Style.Font.SetBold();
                worksheet.Cell(row, headerColumn).Style.Font.SetItalic();
                worksheet.Cell(row, headerColumn).Style.Fill.SetBackgroundColor(XLColor.AliceBlue);
                worksheet.Cell(row, headerColumn++).Value = cell;
            }
            row++;

            foreach (TableRow dataRow in table.DataRows)
            {
                int dataColumn = TableStartColumn;
                foreach (string cell in dataRow)
                {
                    worksheet.Cell(row, dataColumn++).Value = cell;
                }
                row++;
            }

            int lastRow = row - 1;
            int lastColumn = headerColumn - 1;

            worksheet.Range(startRow, TableStartColumn, lastRow, lastColumn).Style.Border.TopBorder =
                XLBorderStyleValues.Thin;
            worksheet.Range(startRow, TableStartColumn, lastRow, lastColumn).Style.Border.LeftBorder =
                XLBorderStyleValues.Thin;
            worksheet.Range(startRow, TableStartColumn, lastRow, lastColumn).Style.Border.BottomBorder =
                XLBorderStyleValues.Thin;
            worksheet.Range(startRow, TableStartColumn, lastRow, lastColumn).Style.Border.RightBorder =
                XLBorderStyleValues.Thin;
        }
    }
}