using FishMovementAnalyzerApp.Library.FileHandler.Models;
using System.Data;
using System.Text;

namespace FishMovementAnalyzerApp.Library.FileHandler
{
    public interface IFileHandler
    {
        List<string> GetAllLinesFromFile(string filePath, Encoding? encoding = null);
        List<T> ParseCsvFileContentToObject<T>(string filePath, Func<T, bool>? filter = null) where T : class;
        void GenerateExcel(object sender, ExcelSheets dataResolutions, string path);
        string GetFileOutputPath(string filePath);
    }
}
