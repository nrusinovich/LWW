using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
namespace Framework1
{
    class DataInput
    {
        private static Excel.Application excelApp = new Excel.Application();
       
        private static string GetCellValue(int row, int col, Excel.Worksheet workSheet)
        {
            string cellValue = "";
            Excel.Range cell = (Excel.Range)workSheet.Cells[row, col];
            if (cell.Value != null)
            {
                cellValue = Convert.ToString(cell.Value);
            }
            return cellValue;
        }

        public static Journal GetJournal(Excel.Worksheet workSheet)
        {
            Journal journal = new Journal(workSheet.Name);
            int row = 2, column = 1;
            while(GetCellValue(row, column, workSheet) != "")
            {
                Category category = new Category(GetCellValue(row, column, workSheet));
                
                row++;
                while (GetCellValue(row, column, workSheet) != "")
                {
                    category.AddItem(GetCellValue(row, column, workSheet));
                    row++;
                }
                journal.AddMenuItem(category);
                row = 2;
                column++;
            }
            return journal;
        }

        public static Dictionary <string, Journal> GetFile()
        {
            Dictionary<string,Journal> journals = new Dictionary<string, Journal>();
            var workBook = excelApp.Workbooks.Open(Resource1.TestDataFile);
            foreach (var sheet in workBook.Sheets)
            {
                var wsheet = (Excel.Worksheet)sheet;
                journals.Add(wsheet.Name, GetJournal(wsheet));
            }
            excelApp.Quit();
            excelApp = null;
            return journals;
        }

        public static string[] GetTestSelection()
        {
            string[] journalNames=null;
            var workBook = excelApp.Workbooks.Open(Resource1.TestSelectionFile);
            foreach (var sheet in workBook.Sheets)
                journalNames = GetTestSelection1((Excel.Worksheet)sheet).ToArray();

            return journalNames;
        }
        public static List<string> GetTestSelection1(Excel.Worksheet workSheet)
        {
            List<string> journalNames = new List<string>();
            int row = 2, column = 1;
            while(GetCellValue(row, column, workSheet) != "")
            {
                journalNames.Add(GetCellValue(row, column, workSheet));
                row++;
            }
            return journalNames;
        }
        static void Main(string[] args)
        {
        }

    }
}
