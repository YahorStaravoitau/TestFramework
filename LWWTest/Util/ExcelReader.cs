using LWWTest.TestingData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace LWWTest
{
    public class ReadExcel
    {

        private static Excel.Application excelApp = new Excel.Application();
        private static Excel.Worksheet workSheet = new Excel.Worksheet();

        public static List<Journal> ParseExcel()
        {
            List<Journal> output = new List<Journal>();

            Journal jourModel;
            Category catModel;
            Element elemModel;


            var workBook = excelApp.Workbooks.Open(Data.excelPath);

            for (int journalCount = 1; journalCount <= workBook.Sheets.Count; journalCount++)
            {
                workSheet = workBook.Sheets[journalCount];
                jourModel = new Journal(workSheet.Name);

                for (int col = 1; GetValue(2, col) != ""; col++)
                {
                    string category = GetValue(2, col);
                    catModel = new Category(category);

                    for (int row = 3; GetValue(row, col) != ""; row++)
                    {
                        if (category == "")
                        {
                            break;
                        }
                        if (GetValue(row, col) != "")
                        {
                            elemModel = new Element(GetValue(row, col));
                            catModel.AddElement(elemModel);
                        }
                        else break;
                    }
                    if(category != "") jourModel.AddCategory(catModel);
                }
                output.Add(jourModel);
            }



            excelApp.Quit();
            excelApp = null;

            return output;
        }

        private static string GetValue(int row, int col)
        {
            string cellValue = "";
            Excel.Range cell = (Excel.Range)workSheet.Cells[row, col];
            if (cell.Value != null)
            {
                cellValue = Convert.ToString(cell.Value);
            }
            return cellValue;
        }
    }
}
