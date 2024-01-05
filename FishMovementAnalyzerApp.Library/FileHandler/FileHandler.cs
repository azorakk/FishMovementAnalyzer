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
    }
}
