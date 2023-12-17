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
            this.Message = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // DragAndDrop
            // 
            this.DragAndDrop.AllowDrop = true;
            this.DragAndDrop.Image = ((System.Drawing.Image)(resources.GetObject("DragAndDrop.Image")));
            this.DragAndDrop.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.DragAndDrop.Location = new System.Drawing.Point(214, 87);
            this.DragAndDrop.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.DragAndDrop.Name = "DragAndDrop";
            this.DragAndDrop.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.DragAndDrop.Size = new System.Drawing.Size(259, 129);
            this.DragAndDrop.TabIndex = 0;
            this.DragAndDrop.Text = "Drag And Drop Files";
            this.DragAndDrop.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Message
            // 
            this.Message.Location = new System.Drawing.Point(182, 279);
            this.Message.Name = "Message";
            this.Message.Size = new System.Drawing.Size(346, 23);
            this.Message.TabIndex = 1;
            this.Message.Text = "Message";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(700, 338);
            this.Controls.Add(this.Message);
            this.Controls.Add(this.DragAndDrop);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Fish Movement Analyzer";
            this.ResumeLayout(false);

        }

        #endregion

        private Label DragAndDrop;
        private Label Message;
    }
}