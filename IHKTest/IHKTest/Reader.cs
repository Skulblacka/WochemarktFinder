using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.IO;
using System.Data;
using Excel = Microsoft.Office.Interop.Excel;

namespace IHKTest
{/// <summary>
/// Klasse liest aus einen xls Datei und gibt einen List mit Daten zurueck
/// erstellt von Tilmann Paczoch    
/// </summary>
    class Reader

        //http://csharp.net-informations.com/excel/csharp-read-excel.htm 14.05.2018 11:04 Excel auslesen
    {
        public List<Data> ReadExcel()
        {
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            Excel.Range range;

            string str;
            int rCnt;
            int cCnt;
            int rw = 0;
            int cl = 0;
           
            xlApp = new Excel.Application();
            xlWorkBook = xlApp.Workbooks.Open(getPathFromXLS(), 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

            range = xlWorkSheet.UsedRange;
            rw = range.Rows.Count;
            cl = range.Columns.Count;

            List<Data> data = new List<Data>();
            String[] arr;
            
            //durchlaufe xls Datei Zelle fuer Zelle
            for (rCnt = 2; rCnt <= rw; rCnt++)
            {
                arr = new String[cl + 1];
                for (cCnt = 1; cCnt <= cl; cCnt++)
                {
                    str = ""+(range.Cells[rCnt, cCnt] as Excel.Range).Value2;
                    arr[cCnt] = str;
                }
                data.Add(new Data {Bezirk=arr[1], Marktort=arr[2], Tage=arr[3], Zeiten=arr[4], Betreiber=arr[5], EMail=arr[6], WWW=arr[7], Bemerkungen=arr[8] });
            }

            xlWorkBook.Close(true, null, null);
            xlApp.Quit();

            //Marshal.ReleaseComObject(xlWorkSheet);
            //Marshal.ReleaseComObject(xlWorkBook);
            //Marshal.ReleaseComObject(xlApp);
            return data;
        }

        private String getPathFromXLS()
        {
            String location = System.Reflection.Assembly.GetEntryAssembly().Location;
            String path = "";
            if (location.Contains("IHKTest.exe"))
            {
                int index = location.IndexOf("IHKTest.exe");
                path = location.Remove(index);
                path = path + "Wochenmaerkte.xls";
            }


            return path;
        }
    }

    
}
