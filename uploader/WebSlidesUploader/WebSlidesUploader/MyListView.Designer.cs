namespace WebSlidesUploader
{
    partial class MyListView
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
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.lsv_thumbnails = new System.Windows.Forms.ListView();
            this.bkgwk_openfiles = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(3, 3);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(100, 15);
            this.progressBar.TabIndex = 0;
            this.progressBar.Visible = false;
            // 
            // lsv_thumbnails
            // 
            this.lsv_thumbnails.Location = new System.Drawing.Point(0, 0);
            this.lsv_thumbnails.Margin = new System.Windows.Forms.Padding(0);
            this.lsv_thumbnails.Name = "lsv_thumbnails";
            this.lsv_thumbnails.Size = new System.Drawing.Size(342, 279);
            this.lsv_thumbnails.TabIndex = 1;
            this.lsv_thumbnails.UseCompatibleStateImageBehavior = false;
            // 
            // bkgwk_openfiles
            // 
            this.bkgwk_openfiles.WorkerReportsProgress = true;
            // 
            // MyListView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.lsv_thumbnails);
            this.Name = "MyListView";
            this.Size = new System.Drawing.Size(390, 327);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.ListView lsv_thumbnails;
        private System.ComponentModel.BackgroundWorker bkgwk_openfiles;
    }
}
