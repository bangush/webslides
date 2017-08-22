namespace WebSlidesUploader
{
    partial class MyPictureBox
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pctbox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pctbox)).BeginInit();
            this.SuspendLayout();
            // 
            // pctbox
            // 
            this.pctbox.Location = new System.Drawing.Point(6, 6);
            this.pctbox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pctbox.Name = "pctbox";
            this.pctbox.Size = new System.Drawing.Size(556, 503);
            this.pctbox.TabIndex = 0;
            this.pctbox.TabStop = false;
            // 
            // MyPictureBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.Controls.Add(this.pctbox);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MyPictureBox";
            this.Size = new System.Drawing.Size(586, 540);
            ((System.ComponentModel.ISupportInitialize)(this.pctbox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pctbox;
    }
}
