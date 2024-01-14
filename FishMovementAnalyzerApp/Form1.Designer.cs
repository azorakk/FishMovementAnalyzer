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
            this.messagelbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // DragAndDrop
            // 
            this.DragAndDrop.AllowDrop = true;
            this.DragAndDrop.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.DragAndDrop.Location = new System.Drawing.Point(193, 62);
            this.DragAndDrop.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.DragAndDrop.Name = "DragAndDrop";
            this.DragAndDrop.Padding = new System.Windows.Forms.Padding(0, 0, 0, 13);
            this.DragAndDrop.Size = new System.Drawing.Size(433, 273);
            this.DragAndDrop.TabIndex = 0;
            this.DragAndDrop.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // messagelbl
            // 
            this.messagelbl.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.messagelbl.Location = new System.Drawing.Point(106, 364);
            this.messagelbl.Name = "messagelbl";
            this.messagelbl.Size = new System.Drawing.Size(589, 66);
            this.messagelbl.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 451);
            this.Controls.Add(this.messagelbl);
            this.Controls.Add(this.DragAndDrop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Fish Movement Analyzer";
            this.ResumeLayout(false);

        }

        #endregion

        private Label DragAndDrop;
        private Label messagelbl;
    }
}