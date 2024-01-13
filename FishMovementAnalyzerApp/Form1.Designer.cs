namespace FishMovementAnalyzerApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.DragAndDrop = new System.Windows.Forms.Label();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.messagelbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // DragAndDrop
            // 
            this.DragAndDrop.AllowDrop = true;
            this.DragAndDrop.Image = ((System.Drawing.Image)(resources.GetObject("DragAndDrop.Image")));
            this.DragAndDrop.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.DragAndDrop.Location = new System.Drawing.Point(244, 95);
            this.DragAndDrop.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.DragAndDrop.Name = "DragAndDrop";
            this.DragAndDrop.Padding = new System.Windows.Forms.Padding(0, 0, 0, 13);
            this.DragAndDrop.Size = new System.Drawing.Size(296, 172);
            this.DragAndDrop.TabIndex = 0;
            this.DragAndDrop.Text = "Drag And Drop CSV File";
            this.DragAndDrop.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.WorkerReportsProgress = true;
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(110, 363);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(589, 52);
            this.progressBar1.TabIndex = 2;
            this.progressBar1.Visible = false;
            // 
            // messagelbl
            // 
            this.messagelbl.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.messagelbl.Location = new System.Drawing.Point(110, 281);
            this.messagelbl.Name = "messagelbl";
            this.messagelbl.Size = new System.Drawing.Size(589, 66);
            this.messagelbl.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(800, 451);
            this.Controls.Add(this.messagelbl);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.DragAndDrop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Fish Movement Analyzer";
            this.ResumeLayout(false);

        }

        #endregion

        private Label DragAndDrop;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private ProgressBar progressBar1;
        private Label messagelbl;
    }
}