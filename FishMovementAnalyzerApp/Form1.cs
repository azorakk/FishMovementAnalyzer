using IronXL;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;

namespace FishMovementAnalyzerApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
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
            if (fileExtension.CompareTo(".xls") != 0 && fileExtension.CompareTo(".xlsx") != 0)
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
                WorkBook workBook = WorkBook.Load(filePath);
                WorkSheet workSheet = workBook.WorkSheets.First();
                var columnCount = workSheet.ColumnCount;
                var rowCount = workSheet.RowCount;
            }
            catch (IOException e)
            {
                MessageBox.Show(e.Message ?? "Something went wrong. Couldn't open the file.",
                    "Failed Loading The File", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw new Exception();
            }
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