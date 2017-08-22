namespace WebSlidesUploader
{
    partial class Uploader
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Uploader));
            this.btn_quitter = new System.Windows.Forms.Button();
            this.btn_test = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fichierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ajouterUneImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.supprimerToutesLesImagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.supprimerLesImagesSélectionnéesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.quitterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.aProposToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.tsb_addFiles = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsb_delFiles = new System.Windows.Forms.ToolStripButton();
            this.tsb_delAllFiles = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsb_synchroFTP = new System.Windows.Forms.ToolStripButton();
            this.tab_thumbnails = new System.Windows.Forms.TabControl();
            this.tab_localImages = new System.Windows.Forms.TabPage();
            this.listView1 = new System.Windows.Forms.ListView();
            this.tab_remoteImages = new System.Windows.Forms.TabPage();
            this.lbl_comingSoon = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuStrip.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.tab_thumbnails.SuspendLayout();
            this.tab_localImages.SuspendLayout();
            this.tab_remoteImages.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_quitter
            // 
            this.btn_quitter.Location = new System.Drawing.Point(1048, 657);
            this.btn_quitter.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_quitter.Name = "btn_quitter";
            this.btn_quitter.Size = new System.Drawing.Size(290, 51);
            this.btn_quitter.TabIndex = 1;
            this.btn_quitter.Text = "Quitter";
            this.btn_quitter.UseVisualStyleBackColor = true;
            this.btn_quitter.Click += new System.EventHandler(this.btn_quitter_Click);
            // 
            // btn_test
            // 
            this.btn_test.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_test.ForeColor = System.Drawing.Color.Maroon;
            this.btn_test.Location = new System.Drawing.Point(507, 660);
            this.btn_test.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_test.Name = "btn_test";
            this.btn_test.Size = new System.Drawing.Size(112, 35);
            this.btn_test.TabIndex = 8;
            this.btn_test.Text = "TEST";
            this.btn_test.UseVisualStyleBackColor = true;
            this.btn_test.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Silver;
            this.pictureBox1.Location = new System.Drawing.Point(628, 120);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(710, 528);
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fichierToolStripMenuItem,
            this.toolStripMenuItem1});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(9, 3, 0, 3);
            this.menuStrip.Size = new System.Drawing.Size(1356, 35);
            this.menuStrip.TabIndex = 10;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fichierToolStripMenuItem
            // 
            this.fichierToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ajouterUneImageToolStripMenuItem,
            this.supprimerToutesLesImagesToolStripMenuItem,
            this.supprimerLesImagesSélectionnéesToolStripMenuItem,
            this.toolStripMenuItem2,
            this.quitterToolStripMenuItem});
            this.fichierToolStripMenuItem.Name = "fichierToolStripMenuItem";
            this.fichierToolStripMenuItem.Size = new System.Drawing.Size(74, 29);
            this.fichierToolStripMenuItem.Text = "Fichier";
            this.fichierToolStripMenuItem.Click += new System.EventHandler(this.fichierToolStripMenuItem_Click);
            // 
            // ajouterUneImageToolStripMenuItem
            // 
            this.ajouterUneImageToolStripMenuItem.Name = "ajouterUneImageToolStripMenuItem";
            this.ajouterUneImageToolStripMenuItem.Size = new System.Drawing.Size(378, 30);
            this.ajouterUneImageToolStripMenuItem.Text = "Ajouter une image...";
            // 
            // supprimerToutesLesImagesToolStripMenuItem
            // 
            this.supprimerToutesLesImagesToolStripMenuItem.Name = "supprimerToutesLesImagesToolStripMenuItem";
            this.supprimerToutesLesImagesToolStripMenuItem.Size = new System.Drawing.Size(378, 30);
            this.supprimerToutesLesImagesToolStripMenuItem.Text = "Supprimer toutes les images";
            // 
            // supprimerLesImagesSélectionnéesToolStripMenuItem
            // 
            this.supprimerLesImagesSélectionnéesToolStripMenuItem.Name = "supprimerLesImagesSélectionnéesToolStripMenuItem";
            this.supprimerLesImagesSélectionnéesToolStripMenuItem.Size = new System.Drawing.Size(378, 30);
            this.supprimerLesImagesSélectionnéesToolStripMenuItem.Text = "Supprimer les images sélectionnées";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(375, 6);
            // 
            // quitterToolStripMenuItem
            // 
            this.quitterToolStripMenuItem.Name = "quitterToolStripMenuItem";
            this.quitterToolStripMenuItem.Size = new System.Drawing.Size(378, 30);
            this.quitterToolStripMenuItem.Text = "Quitter";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aProposToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(32, 29);
            this.toolStripMenuItem1.Text = "?";
            // 
            // aProposToolStripMenuItem
            // 
            this.aProposToolStripMenuItem.Name = "aProposToolStripMenuItem";
            this.aProposToolStripMenuItem.Size = new System.Drawing.Size(184, 30);
            this.aProposToolStripMenuItem.Text = "A propos...";
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth16Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(100, 56);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // toolStrip
            // 
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsb_addFiles,
            this.toolStripSeparator2,
            this.tsb_delFiles,
            this.tsb_delAllFiles,
            this.toolStripSeparator1,
            this.tsb_synchroFTP});
            this.toolStrip.Location = new System.Drawing.Point(0, 35);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStrip.Size = new System.Drawing.Size(1356, 31);
            this.toolStrip.TabIndex = 11;
            this.toolStrip.Text = "toolStrip1";
            // 
            // tsb_addFiles
            // 
            this.tsb_addFiles.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_addFiles.Image = ((System.Drawing.Image)(resources.GetObject("tsb_addFiles.Image")));
            this.tsb_addFiles.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_addFiles.Name = "tsb_addFiles";
            this.tsb_addFiles.Size = new System.Drawing.Size(28, 28);
            this.tsb_addFiles.Text = "Ajouter une image";
            this.tsb_addFiles.Click += new System.EventHandler(this.tsb_addFiles_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 31);
            // 
            // tsb_delFiles
            // 
            this.tsb_delFiles.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_delFiles.Image = ((System.Drawing.Image)(resources.GetObject("tsb_delFiles.Image")));
            this.tsb_delFiles.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_delFiles.Name = "tsb_delFiles";
            this.tsb_delFiles.Size = new System.Drawing.Size(28, 28);
            this.tsb_delFiles.Text = "Effacer les images sélectionnées";
            // 
            // tsb_delAllFiles
            // 
            this.tsb_delAllFiles.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_delAllFiles.Image = ((System.Drawing.Image)(resources.GetObject("tsb_delAllFiles.Image")));
            this.tsb_delAllFiles.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_delAllFiles.Name = "tsb_delAllFiles";
            this.tsb_delAllFiles.Size = new System.Drawing.Size(28, 28);
            this.tsb_delAllFiles.Text = "Supprimer toutes les images";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // tsb_synchroFTP
            // 
            this.tsb_synchroFTP.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_synchroFTP.Image = ((System.Drawing.Image)(resources.GetObject("tsb_synchroFTP.Image")));
            this.tsb_synchroFTP.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_synchroFTP.Name = "tsb_synchroFTP";
            this.tsb_synchroFTP.Size = new System.Drawing.Size(28, 28);
            this.tsb_synchroFTP.Text = "Synchronisation";
            // 
            // tab_thumbnails
            // 
            this.tab_thumbnails.Controls.Add(this.tab_localImages);
            this.tab_thumbnails.Controls.Add(this.tab_remoteImages);
            this.tab_thumbnails.Location = new System.Drawing.Point(18, 86);
            this.tab_thumbnails.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tab_thumbnails.Name = "tab_thumbnails";
            this.tab_thumbnails.SelectedIndex = 0;
            this.tab_thumbnails.Size = new System.Drawing.Size(602, 565);
            this.tab_thumbnails.TabIndex = 12;
            // 
            // tab_localImages
            // 
            this.tab_localImages.Controls.Add(this.listView1);
            this.tab_localImages.Location = new System.Drawing.Point(4, 29);
            this.tab_localImages.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tab_localImages.Name = "tab_localImages";
            this.tab_localImages.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tab_localImages.Size = new System.Drawing.Size(594, 532);
            this.tab_localImages.TabIndex = 0;
            this.tab_localImages.Text = "Images locales";
            this.tab_localImages.UseVisualStyleBackColor = true;
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.Color.Silver;
            this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(588, 524);
            this.listView1.TabIndex = 4;
            this.listView1.TabStop = false;
            this.listView1.TileSize = new System.Drawing.Size(140, 30);
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.Visible = false;
            // 
            // tab_remoteImages
            // 
            this.tab_remoteImages.Controls.Add(this.lbl_comingSoon);
            this.tab_remoteImages.Location = new System.Drawing.Point(4, 29);
            this.tab_remoteImages.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tab_remoteImages.Name = "tab_remoteImages";
            this.tab_remoteImages.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tab_remoteImages.Size = new System.Drawing.Size(594, 532);
            this.tab_remoteImages.TabIndex = 1;
            this.tab_remoteImages.Text = "Images serveur";
            this.tab_remoteImages.UseVisualStyleBackColor = true;
            // 
            // lbl_comingSoon
            // 
            this.lbl_comingSoon.AutoSize = true;
            this.lbl_comingSoon.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_comingSoon.ForeColor = System.Drawing.Color.Gray;
            this.lbl_comingSoon.Location = new System.Drawing.Point(96, 238);
            this.lbl_comingSoon.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_comingSoon.Name = "lbl_comingSoon";
            this.lbl_comingSoon.Size = new System.Drawing.Size(397, 33);
            this.lbl_comingSoon.TabIndex = 0;
            this.lbl_comingSoon.Text = "Indisponible actuellement...";
            // 
            // Uploader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1356, 972);
            this.Controls.Add(this.tab_thumbnails);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btn_test);
            this.Controls.Add(this.btn_quitter);
            this.Controls.Add(this.menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "Uploader";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WebSlides Uploader";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.tab_thumbnails.ResumeLayout(false);
            this.tab_localImages.ResumeLayout(false);
            this.tab_remoteImages.ResumeLayout(false);
            this.tab_remoteImages.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_quitter;
        private System.Windows.Forms.Button btn_test;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolStripMenuItem fichierToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ajouterUneImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem aProposToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton tsb_addFiles;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsb_delFiles;
        private System.Windows.Forms.ToolStripButton tsb_delAllFiles;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsb_synchroFTP;
        private System.Windows.Forms.TabControl tab_thumbnails;
        private System.Windows.Forms.TabPage tab_localImages;
        private System.Windows.Forms.TabPage tab_remoteImages;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ToolStripMenuItem supprimerToutesLesImagesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem supprimerLesImagesSélectionnéesToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.Label lbl_comingSoon;
    }
}

