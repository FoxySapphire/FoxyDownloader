namespace FoxyDownloader.Forms
{
    partial class FrmDownload
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDownload));
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.imagelistDownload = new System.Windows.Forms.ImageList(this.components);
            this.btnOpen = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.listviewDownloads = new FoxyDownloader.Controls.FoxyListView();
            this.clmName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmProgress = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(536, 15);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStart.Location = new System.Drawing.Point(617, 15);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 4;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // imagelistDownload
            // 
            this.imagelistDownload.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imagelistDownload.ImageStream")));
            this.imagelistDownload.TransparentColor = System.Drawing.Color.Transparent;
            this.imagelistDownload.Images.SetKeyName(0, "1406062970_tick_64.png");
            this.imagelistDownload.Images.SetKeyName(1, "arrow-32-256.png");
            this.imagelistDownload.Images.SetKeyName(2, "140602047551456.png");
            this.imagelistDownload.Images.SetKeyName(3, "yco4y6M9i.png");
            // 
            // btnOpen
            // 
            this.btnOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOpen.Location = new System.Drawing.Point(12, 15);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(75, 23);
            this.btnOpen.TabIndex = 5;
            this.btnOpen.Text = "Open Folder";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnStart);
            this.panel1.Controls.Add(this.btnOpen);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 311);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(704, 50);
            this.panel1.TabIndex = 7;
            // 
            // listviewDownloads
            // 
            this.listviewDownloads.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmName,
            this.clmProgress,
            this.clmSize,
            this.clmStatus});
            this.listviewDownloads.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listviewDownloads.FullRowSelect = true;
            this.listviewDownloads.GridLines = true;
            this.listviewDownloads.Location = new System.Drawing.Point(0, 0);
            this.listviewDownloads.Name = "listviewDownloads";
            this.listviewDownloads.Size = new System.Drawing.Size(704, 311);
            this.listviewDownloads.SmallImageList = this.imagelistDownload;
            this.listviewDownloads.TabIndex = 6;
            this.listviewDownloads.UseCompatibleStateImageBehavior = false;
            this.listviewDownloads.View = System.Windows.Forms.View.Details;
            // 
            // clmName
            // 
            this.clmName.Text = "Name";
            this.clmName.Width = 300;
            // 
            // clmProgress
            // 
            this.clmProgress.Text = "Progress";
            this.clmProgress.Width = 179;
            // 
            // clmSize
            // 
            this.clmSize.Text = "Size";
            this.clmSize.Width = 99;
            // 
            // clmStatus
            // 
            this.clmStatus.Text = "Status";
            this.clmStatus.Width = 100;
            // 
            // FrmDownload
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 361);
            this.Controls.Add(this.listviewDownloads);
            this.Controls.Add(this.panel1);
            this.MinimumSize = new System.Drawing.Size(625, 400);
            this.Name = "FrmDownload";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Downloader";
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.ImageList imagelistDownload;
        private System.Windows.Forms.Button btnOpen;
        private Controls.FoxyListView listviewDownloads;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ColumnHeader clmName;
        private System.Windows.Forms.ColumnHeader clmProgress;
        private System.Windows.Forms.ColumnHeader clmSize;
        private System.Windows.Forms.ColumnHeader clmStatus;

    }
}

