using FishMovementAnalyzerApp.Library.FileHandler.Models;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Reflection;
using System.Text;
using Excel = Microsoft.Office.Interop.Excel;

namespace FishMovementAnalyzerApp.Library.FileHandler
{
    public class FileHandler : IFileHandler
    {
        public List<string> GetAllLinesFromFile(string filePath, Encoding? encoding = null)
        {
            var lines = new List<string> { };
            if (!File.Exists(filePath))
                return lines;

            StreamReader reader;
            if (encoding == null)
                reader = new StreamReader(filePath);
            else
                reader = new StreamReader(filePath, encoding);

            using (reader)
            {
                while (!reader.EndOfStream)
                {
                    lines.Add(reader.ReadLine());
                }
            }

            return lines;
        }

        public List<T> ParseCsvFileContentToObject<T>(string filePath,
            Func<T, bool>? filter = null) where T : class
        {
            var lines = GetAllLinesFromFile(filePath);

            if (!lines.Any())
                return new List<T>();

            List<T> objects = new();

            lines.RemoveAt(0);
            var currentLineNumber = 1;
            foreach (var line in lines)
            {
                try
                {
                    if (string.IsNullOrEmpty(line))
                        continue;

                    var content = line;
                    content = content.Replace("\"", "");

                    var values = content.Split(',');
                    var @object = (T)Activator.CreateInstance(typeof(T), new object[] { values });
                    objects.Add(@object);
                    currentLineNumber++;
                }
                catch (Exception e)
                {
                    //_logger.LogError(e, "Failed to parse line for file {File}. Line={Line}. LineNumber={LineNumber}", filePath, line, currentLineNumber);
                }
            }

            if (filter != null)
                objects = objects.Where(filter).ToList();

            return objects;
        }

        private static DataTable ConvertToDataTable<T>(List<T> models)
        {
            // creating a data table instance and typed it as our incoming model   
            // as I make it generic, if you want, you can make it the model typed you want.  
            DataTable dataTable = new DataTable(typeof(T).Name);

            //Get all the properties of that model  
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            // Loop through all the properties              
            // Adding Column name to our datatable  
            foreach (PropertyInfo prop in Props)
            {
                //Setting column names as Property names    
                dataTable.Columns.Add(prop.Name);
            }
            // Adding Row and its value to our dataTable  
            foreach (T item in models)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows    
                    values[i] = Props[i].GetValue(item, null);
                }
                // Finally add value to datatable    
                dataTable.Rows.Add(values);
            }
            return dataTable;
        }

        private static int GetTotalRows(DataTable[] dataTables)
        {
            var total = 0;
            foreach (var data in dataTables)
            {
                total += data.Rows.Count;
            }
            return total;
        }


        private DataTable[] GetDataTables(ExcelSheets dataResolutions)
        {
            var dataSets = new[] {
                    ConvertToDataTable(dataResolutions.CycleData!),
                    ConvertToDataTable(dataResolutions.FiveMinuteResolutionData!),
                    ConvertToDataTable(dataResolutions.OneMinuteResolutionData!),
                    ConvertToDataTable(dataResolutions.SecondResolutionData!)
                };

            return dataSets;
        }

        public string GetFileOutputPath(string filePath)
        {
            var outputPath = Path.GetDirectoryName(filePath) + "\\" + Path.GetFileNameWithoutExtension(filePath) + "_analayzed_" + Ulid.NewUlid() + ".xlsx";
            return outputPath!;
        }

        public void GenerateExcel(object sender, ExcelSheets dataResolutions, string path)
        {
            var dataTables = GetDataTables(dataResolutions);
            var backgroundWorker = sender as BackgroundWorker;
            DataSet dataSet = new DataSet();
            dataSet.Tables.AddRange(dataTables);
            var totalRows = GetTotalRows(dataTables);
            var progressBarCounter = 0;
            // create a excel app along side with workbook and worksheet and give a name to it  
            Excel.Application excelApp = new Excel.Application();
            Excel.Workbook excelWorkBook = excelApp.Workbooks.Add();
            Excel._Worksheet xlWorksheet = (Excel._Worksheet)excelWorkBook.Sheets[1];
            Excel.Range xlRange = xlWorksheet.UsedRange;
            foreach (DataTable table in dataSet.Tables)
            {
                //Add a new worksheet to workbook with the Datatable name  
                Excel.Worksheet excelWorkSheet = (Excel.Worksheet)excelWorkBook.Sheets.Add();
                excelWorkSheet.Name = table.TableName;

                // add all the columns  
                for (int i = 1; i < table.Columns.Count + 1; i++)
                {
                    excelWorkSheet.Cells[1, i] = table.Columns[i - 1].ColumnName;
                }

                // add all the rows  
                for (int j = 0; j < table.Rows.Count; j++)
                {
                    for (int k = 0; k < table.Columns.Count; k++)
                    {
                        excelWorkSheet.Cells[j + 2, k + 1] = table.Rows[j]?.ItemArray[k]?.ToString();
                    }
                    backgroundWorker!.ReportProgress((progressBarCounter * 1000) / totalRows);
                    progressBarCounter++;
                }
            }
            excelWorkBook.SaveAs(path);
            excelWorkBook.Close();
            excelApp.Quit();
        }
    }
}
