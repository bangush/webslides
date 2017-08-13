namespace WebSlides
{
    partial class Slides
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Slides));
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.internetConnection = new System.Windows.Forms.Button();
            this.timer_checkup = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(12, 12);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(100, 10);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar.TabIndex = 0;
            this.progressBar.Visible = false;
            // 
            // timer
            // 
            this.timer.Interval = 5000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // internetConnection
            // 
            this.internetConnection.BackColor = System.Drawing.Color.Gray;
            this.internetConnection.FlatAppearance.BorderSize = 0;
            this.internetConnection.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.internetConnection.Location = new System.Drawing.Point(12, 12);
            this.internetConnection.Name = "internetConnection";
            this.internetConnection.Size = new System.Drawing.Size(10, 10);
            this.internetConnection.TabIndex = 1;
            this.internetConnection.TabStop = false;
            this.internetConnection.UseVisualStyleBackColor = false;
            this.internetConnection.Visible = false;
            // 
            // timer_checkup
            // 
            this.timer_checkup.Enabled = true;
            this.timer_checkup.Interval = 45000;
            this.timer_checkup.Tick += new System.EventHandler(this.timer_checkup_Tick);
            // 
            // Slides
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(776, 505);
            this.Controls.Add(this.internetConnection);
            this.Controls.Add(this.progressBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Slides";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Slides";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Slides_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Slides_KeyPress);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Slides_MouseClick);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Button internetConnection;
        private System.Windows.Forms.Timer timer_checkup;
    }
}