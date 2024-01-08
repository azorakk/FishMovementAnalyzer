using FishMovementAnalyzerApp.Library.FileHandler;
using FishMovementAnalyzerApp.Models;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace FishMovementAnalyzerApp
{
    public partial class Form1 : Form
    {
        private readonly IFileHandler _fileHandler;
        public Form1(IFileHandler fileHandler)
        {
            _fileHandler = fileHandler;
            InitializeComponent();
            this.AllowDrop = true;
            this.DragAndDrop.DragEnter += new DragEventHandler(DragAndDrop_DragEnter);
            this.DragAndDrop.DragDrop += new DragEventHandler(DragAndDrop_DragDrop);
        }

        private void DragAndDrop_DragDrop(object? sender, DragEventArgs e)
        {
            try
            {
                var files = (string[])e.Data.GetData(DataFormats.FileDrop, false);
                var filePath = files.FirstOrDefault();

                AssertFileCount(files);
                AssertFileExtension(Path.GetExtension(filePath)!);
                GetExcelFile(filePath!);

            }
            catch (ValidationException)
            {
                ActivateDragAndDropBox();
                return;
            }
            catch (IOException)
            {
                ActivateDragAndDropBox();
                return;
            }
        }

        private void DragAndDrop_DragEnter(object? sender, DragEventArgs e)
        {
            if (e.Data != null && e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.All;
            else
                e.Effect = DragDropEffects.None;
        }

        private static void AssertFileCount(string[] filePaths)
        {

            if (filePaths?.Length > 1)
            {
                var firstFileName = filePaths?.FirstOrDefault()?.Split("\\").LastOrDefault();
                var response = MessageBox.Show($"Please add only one file. Do you want to continue with the first file {firstFileName}?",
                    "Multiple file error", MessageBoxButtons.YesNo, MessageBoxIcon.Error);

                if (response == DialogResult.No)
                    throw new ValidationException();
            }
        }

        private static void AssertFileExtension(string fileExtension)
        {
            if (fileExtension.CompareTo(".csv") != 0)
            {
                MessageBox.Show($"Invalid file. Only .xlxs files are allowed",
                    "Multiple file error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw new ValidationException();
            }
        }

        void GetExcelFile(string filePath)
        {
            DisableDragAndDropBox();
            try
            {
                var fileContent = _fileHandler.ParseCsvFileContentToObject<PlateData>(filePath, PlateValidValueFilter);
                fileContent = CalculateCycleType(fileContent);

                var secondResolution = fileContent;
                var minuteResolution = fileContent.GroupBy(x => 
                        new { x.LocationId, TimeSpan = new TimeSpan(x.StartTime.Hours, x.StartTime.Minutes, 0) })
                    .Select(x => GetPlateDataValueForGroup(x.ToList())).OrderBy(x => x.LocationId).ToList();

                var fiveResolution = minuteResolution.GroupBy(x =>
                        new { x.LocationId, TimeSpan = new TimeSpan(x.StartTime.Hours, x.StartTime.Minutes - (x.StartTime.Minutes % 5), 0) })
                    .Select(x => GetPlateDataValueForGroup(x.ToList())).OrderBy(x => x.LocationId).ToList();

                var cycleResolution = fiveResolution.GroupBy(x => new { x.LocationId, x.CycleType })
                    .Select(x => GetPlateDataValueForGroup(x.ToList())).OrderBy(x => x.LocationId).ToList();
            }
            catch (IOException e)
            {
                MessageBox.Show(e.Message ?? "Something went wrong. Couldn't open the file.",
                    "Failed Loading The File", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw new Exception();
            }
        }

        private bool PlateValidValueFilter(PlateData data)
        {
            return data.An == 0 && data.DataType?.ToLower() == "trackerr" && data.EndTimeInSecond != null;
        }

        private List<PlateData> CalculateCycleType(List<PlateData> plateData)
        {
            var fiveMinuteData = plateData
                .GroupBy(x =>
                new { TimeSpan = new TimeSpan(x.StartTime.Hours, x.StartTime.Minutes - (x.StartTime.Minutes % 5), 0) })
                .SelectMany((items, index) => items.Select(c => c with
                {
                    CycleType = (index % 2) != 0 ? CycleType.Dark : CycleType.Light
                }))
                .ToList();

            return fiveMinuteData;
        }

        private PlateData GetPlateDataValueForGroup(List<PlateData> plateDataList)
        {
            return new PlateData()
            {
                LocationId = plateDataList.FirstOrDefault()?.LocationId,
                An = plateDataList.FirstOrDefault()?.An,
                DataType = plateDataList.FirstOrDefault()?.DataType,
                StartTimeInSecond = plateDataList.FirstOrDefault()?.StartTimeInSecond,
                StartTime = plateDataList.FirstOrDefault()!.StartTime,
                EndTimeInSecond = plateDataList.LastOrDefault()?.EndTimeInSecond,
                EndTime = plateDataList.LastOrDefault()!.EndTime,
                Inactivity = plateDataList.Sum(v => v.Inactivity),
                InactiveDuration = plateDataList.Sum(v => v.InactiveDuration),
                InactiveDistance = plateDataList.Sum(v => v.InactiveDistance),
                SmallActivity = plateDataList.Sum(v => v.SmallActivity),
                SmallDuration = plateDataList.Sum(v => v.SmallDuration),
                SmallDistance = plateDataList.Sum(v => v.SmallDistance),
                LargeActivity = plateDataList.Sum(v => v.LargeActivity),
                LargeDuration = plateDataList.Sum(v => v.LargeDuration),
                LargeDistance = plateDataList.Sum(v => v.LargeDistance),
                BigActivity = plateDataList.Sum(v => v.BigActivity),
                BigDistance = plateDataList.Sum(v => v.BigDistance),
                BigDuration = plateDataList.Sum(v => v.BigDuration),
                TotalActivity = plateDataList.Sum(v => v.TotalActivity),
                TotalDistance = plateDataList.Sum(v => v.TotalDistance),
                TotalDuration = plateDataList.Sum(v => v.TotalDuration),
                CycleType = plateDataList.FirstOrDefault()?.CycleType
            };
        }

        void DisableDragAndDropBox()
        {
            this.DragAndDrop.Visible = false;
        }

        void ActivateDragAndDropBox()
        {
            this.DragAndDrop.Visible = true;

        }
    }

    public class ValidationException : Exception { }
}