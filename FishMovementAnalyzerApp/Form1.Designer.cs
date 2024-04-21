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
            DragAndDrop = new Label();
            messagelbl = new Label();
            SuspendLayout();
            // 
            // DragAndDrop
            // 
            DragAndDrop.AllowDrop = true;
            DragAndDrop.ImageAlign = ContentAlignment.BottomCenter;
            DragAndDrop.Location = new System.Drawing.Point(193, 62);
            DragAndDrop.Margin = new Padding(0, 0, 3, 0);
            DragAndDrop.Name = "DragAndDrop";
            DragAndDrop.Padding = new Padding(0, 0, 0, 13);
            DragAndDrop.Size = new System.Drawing.Size(433, 273);
            DragAndDrop.TabIndex = 0;
            DragAndDrop.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // messagelbl
            // 
            messagelbl.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            messagelbl.Location = new System.Drawing.Point(106, 364);
            messagelbl.Name = "messagelbl";
            messagelbl.Size = new System.Drawing.Size(589, 66);
            messagelbl.TabIndex = 3;
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = System.Drawing.Color.White;
            ClientSize = new System.Drawing.Size(800, 553);
            Controls.Add(messagelbl);
            Controls.Add(DragAndDrop);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "Fish Movement Analyzer";
            ResumeLayout(false);
        }

        #endregion

        private Label DragAndDrop;
        private Label messagelbl;
    }
}