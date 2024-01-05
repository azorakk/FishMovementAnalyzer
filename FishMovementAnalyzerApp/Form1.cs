using FishMovementAnalyzerApp.Library.FileHandler;
using FishMovementAnalyzerApp.Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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
            plateData = plateData.OrderBy(x => x.StartTimeInSecond).ToList();
            var cycleDuration = 300;
            var cycleType = CycleType.Light;

            foreach (var data in plateData)
            {
                if (data.EndTimeInSecond > cycleDuration)
                {
                    cycleDuration += cycleDuration;
                    cycleType = cycleType == CycleType.Dark ? CycleType.Light : CycleType.Dark;
                    data.CycleType = cycleType;
                }

                data.CycleType = cycleType;
            }

            return plateData;
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