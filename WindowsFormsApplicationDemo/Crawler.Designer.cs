namespace WindowsFormsApplicationDemo
{
    partial class Crawler
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtKeyword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.numPagecount = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDesdir = new System.Windows.Forms.TextBox();
            this.btnSelectDesdir = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.txtLog = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.numPagecount)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "关键词";
            // 
            // txtKeyword
            // 
            this.txtKeyword.Location = new System.Drawing.Point(96, 39);
            this.txtKeyword.Name = "txtKeyword";
            this.txtKeyword.Size = new System.Drawing.Size(123, 25);
            this.txtKeyword.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(253, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "获取多少页";
            // 
            // numPagecount
            // 
            this.numPagecount.Location = new System.Drawing.Point(356, 39);
            this.numPagecount.Name = "numPagecount";
            this.numPagecount.Size = new System.Drawing.Size(120, 25);
            this.numPagecount.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(38, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "保存到";
            // 
            // txtDesdir
            // 
            this.txtDesdir.Location = new System.Drawing.Point(97, 102);
            this.txtDesdir.Name = "txtDesdir";
            this.txtDesdir.Size = new System.Drawing.Size(379, 25);
            this.txtDesdir.TabIndex = 5;
            // 
            // btnSelectDesdir
            // 
            this.btnSelectDesdir.Location = new System.Drawing.Point(482, 102);
            this.btnSelectDesdir.Name = "btnSelectDesdir";
            this.btnSelectDesdir.Size = new System.Drawing.Size(45, 25);
            this.btnSelectDesdir.TabIndex = 6;
            this.btnSelectDesdir.Text = "...";
            this.btnSelectDesdir.UseVisualStyleBackColor = true;
            this.btnSelectDesdir.Click += new System.EventHandler(this.btnSelectDesdir_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(41, 152);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 36);
            this.btnStart.TabIndex = 7;
            this.btnStart.Text = "开始";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(140, 152);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 36);
            this.btnStop.TabIndex = 8;
            this.btnStop.Text = "停止";
            this.btnStop.UseVisualStyleBackColor = true;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(239, 152);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(301, 36);
            this.progressBar.TabIndex = 9;
            // 
            // txtLog
            // 
            this.txtLog.Location = new System.Drawing.Point(41, 206);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.Size = new System.Drawing.Size(499, 254);
            this.txtLog.TabIndex = 10;
            // 
            // Crawler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(651, 472);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnSelectDesdir);
            this.Controls.Add(this.txtDesdir);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numPagecount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtKeyword);
            this.Controls.Add(this.label1);
            this.Name = "Crawler";
            this.Text = "爬取图片";
            ((System.ComponentModel.ISupportInitialize)(this.numPagecount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtKeyword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numPagecount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDesdir;
        private System.Windows.Forms.Button btnSelectDesdir;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.TextBox txtLog;
    }
}