using FishMovementAnalyzerApp.Library.FileHandler.Models;
using MiniExcelLibs;
using System.Data;
using System.Reflection;
using System.Text;

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

        public List<PlateData> ReadExcelData(string filePath, Func<PlateData, bool>? filter = null)
        {
            var rows = MiniExcel.Query<PlateData>(filePath).AsQueryable();

            if (filter != null)
                rows = rows.Where(filter).AsQueryable();

            return rows.ToList();
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

        public string GetFileOutputPath(string filePath)
        {
            var outputPath = Path.GetDirectoryName(filePath) + "\\" + Path.GetFileNameWithoutExtension(filePath) + "_analayzed_" + Guid.NewGuid() + ".xlsx";
            return outputPath!;
        }

        public void GenerateExcel(ExcelSheets dataResolutions, string path)
        {
            var sheets = new Dictionary<string, object>
            {
                ["SecondResolutionData"] = dataResolutions.SecondResolutionData!,
                ["OneMinuteResolutionData"] = dataResolutions.OneMinuteResolutionData!,
                ["FiveMinuteResolutionData"] = dataResolutions.FiveMinuteResolutionData!,
                ["CycleData"] = dataResolutions.CycleData!,

            };
            MiniExcel.SaveAs(path, sheets);
        }
    }
}
