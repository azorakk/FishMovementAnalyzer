namespace FishMovementAnalyzerApp.Library.FileHandler.Models
{
    public class ExcelSheets
    {
        public List<SecondResolutionData>? SecondResolutionData { get; set; }
        public List<OneMinuteResolutionData>? OneMinuteResolutionData { get; set; }
        public List<FiveMinuteResolutionData>? FiveMinuteResolutionData { get; set; }
        public List<CycleData>? CycleData { get; set; }
    }
}
