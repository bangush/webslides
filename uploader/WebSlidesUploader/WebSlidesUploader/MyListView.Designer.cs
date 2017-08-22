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
            this.lbl_counter = new System.Windows.Forms.Label();
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
            this.lsv_thumbnails.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lsv_thumbnails_MouseDown);
            // 
            // bkgwk_openfiles
            // 
            this.bkgwk_openfiles.WorkerReportsProgress = true;
            this.bkgwk_openfiles.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bkgwk_openfiles_DoWork);
            this.bkgwk_openfiles.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bkgwk_openfiles_ProgressChanged);
            this.bkgwk_openfiles.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bkgwk_openfiles_RunWorkerCompleted);
            // 
            // lbl_counter
            // 
            this.lbl_counter.AutoSize = true;
            this.lbl_counter.Location = new System.Drawing.Point(3, 302);
            this.lbl_counter.Name = "lbl_counter";
            this.lbl_counter.Size = new System.Drawing.Size(43, 13);
            this.lbl_counter.TabIndex = 2;
            this.lbl_counter.Text = "counter";
            // 
            // MyListView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.Controls.Add(this.lbl_counter);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.lsv_thumbnails);
            this.Name = "MyListView";
            this.Size = new System.Drawing.Size(390, 327);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.ListView lsv_thumbnails;
        private System.ComponentModel.BackgroundWorker bkgwk_openfiles;
        private System.Windows.Forms.Label lbl_counter;
    }
}
