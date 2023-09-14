using Microsoft.VisualBasic;
using MyCloudProject.Common;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyExperiment
{
    public class ExcelWriter
    {
        private IExperiment myexperiment;

        private MyConfig config;

        private ExcelPackage package;
        private ExcelWorksheet worksheet;
        private int currentRow; // Track the current row number
        public ExcelWriter()
        {
            package = new ExcelPackage();
            worksheet = package.Workbook.Worksheets.Add("TestResults");
            config = new MyConfig();
            currentRow = 0;
        }


        public byte[] WriteTestOutputDataToExcel(List<Tuple<string, string, List<double>, List<double>, string?>> PermValueList)
        {
            ExperimentResult res = new ExperimentResult(this.config.GroupId, null);
            // Add headers
            worksheet.Cells[1, 1].Value = "TestCase No";
            worksheet.Cells[1, 2].Value = "TestCase Name";
            worksheet.Cells[1, 3].Value = "Input Permenance Value";
            worksheet.Cells[1, 4].Value = "Updated Permenance Value";
            worksheet.Cells[1, 7].Value = "Test Case Results";

            // Set the fill color and font color for the header row
            var headerCells = worksheet.Cells["A1:G1"];
            headerCells.Style.Fill.PatternType = ExcelFillStyle.Solid;
            headerCells.Style.Fill.BackgroundColor.SetColor(Color.LightGoldenrodYellow); // Set your desired background color
            headerCells.Style.Font.Color.SetColor(Color.Black); // Set your desired font color

            // Fill data
            for (int i = 0; i < PermValueList.Count; i++)
            {
                i = currentRow;
                worksheet.Cells[i + 2, 1].Value = PermValueList[i].Item1;
                worksheet.Cells[i + 2, 2].Value = PermValueList[i].Item2;
                worksheet.Cells[i + 2, 3].Value = string.Join(", ", PermValueList[i].Item3);
                worksheet.Cells[i + 2, 4].Value = string.Join(", ", PermValueList[i].Item4);
                worksheet.Cells[i + 2, 7].Value = PermValueList[i].Item5;

                // Set the color of the "Test Case Results" cell based on the boolean value
                var resultCell = worksheet.Cells[i + 2, 7];
                string testResult = PermValueList[i].Item5;
                if (!string.IsNullOrEmpty(testResult))
                {
                    resultCell.Value = testResult;
                    resultCell.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    resultCell.Style.Font.Color.SetColor( Color.Black);
                    resultCell.Style.Fill.BackgroundColor.SetColor(testResult.Equals("PASSED", StringComparison.OrdinalIgnoreCase) ? Color.LightGreen : Color.LightPink);
                }
                else
                {
                    resultCell.Value = "N/A";
                }
                currentRow++;
            }

            // Auto fit columns
            worksheet.Cells.AutoFitColumns();

            // Save the Excel package to a memory stream
            using (var stream = new MemoryStream())
            {
                package.SaveAs(stream);
                return stream.ToArray();
            }
        }


        public byte[] WriteTestOutputDataToExcel(List<Tuple<string, string, int, int, string>> PermValueList)
        {
            ExperimentResult res = new ExperimentResult(this.config.GroupId, null);
            // Add headers
            worksheet.Cells[1, 5].Value = "SynapseCount";
            worksheet.Cells[1, 6].Value = "SegmentCount";
            //worksheet.Cells[1, 7].Value = "Test Case Results";

            // Set the fill color and font color for the header row
            var headerCells = worksheet.Cells["A1:G1"];
            headerCells.Style.Fill.PatternType = ExcelFillStyle.Solid;
            headerCells.Style.Fill.BackgroundColor.SetColor(Color.LightGoldenrodYellow); // Set your desired background color
            headerCells.Style.Font.Color.SetColor(Color.Black); // Set your desired font color

            // Fill data
            for (int j = 0; j < PermValueList.Count; j++)
            {
                int i = currentRow;
                worksheet.Cells[i + 2, 1].Value = PermValueList[j].Item1;
                worksheet.Cells[i + 2, 2].Value = PermValueList[j].Item2;
                worksheet.Cells[i + 2, 5].Value = PermValueList[j].Item3;
                worksheet.Cells[i + 2, 6].Value = PermValueList[j].Item4;
                worksheet.Cells[i + 2, 7].Value = PermValueList[j].Item5;

                // Set the color of the "Test Case Results" cell based on the boolean value
                var resultCell = worksheet.Cells[i + 2, 7];
                string testResult = PermValueList[j].Item5;
                if (!string.IsNullOrEmpty(testResult))
                {
                    resultCell.Value = testResult;
                    resultCell.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    resultCell.Style.Font.Color.SetColor(Color.Black);
                    resultCell.Style.Fill.BackgroundColor.SetColor(testResult.Equals("PASSED", StringComparison.OrdinalIgnoreCase) ? Color.LightGreen : Color.LightPink);
                }
                else
                {
                    resultCell.Value = "N/A";
                }
                currentRow++;
            }

            // Auto fit columns
            worksheet.Cells.AutoFitColumns();

            // Save the Excel package to a memory stream
            using (var stream = new MemoryStream())
            {
                package.SaveAs(stream);
                return stream.ToArray();
            }
        }
    }
}
