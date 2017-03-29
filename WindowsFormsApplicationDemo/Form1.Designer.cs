namespace WindowsFormsApplicationDemo
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.Insert = new System.Windows.Forms.Button();
            this.Delete = new System.Windows.Forms.Button();
            this.Update = new System.Windows.Forms.Button();
            this.Query = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Insert
            // 
            this.Insert.Location = new System.Drawing.Point(175, 130);
            this.Insert.Name = "Insert";
            this.Insert.Size = new System.Drawing.Size(122, 47);
            this.Insert.TabIndex = 0;
            this.Insert.Text = "MongoDB新增";
            this.Insert.UseVisualStyleBackColor = true;
            this.Insert.Click += new System.EventHandler(this.Insert_Click);
            // 
            // Delete
            // 
            this.Delete.Location = new System.Drawing.Point(175, 206);
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(122, 47);
            this.Delete.TabIndex = 1;
            this.Delete.Text = "MongoDB删除";
            this.Delete.UseVisualStyleBackColor = true;
            this.Delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // Update
            // 
            this.Update.Location = new System.Drawing.Point(403, 130);
            this.Update.Name = "Update";
            this.Update.Size = new System.Drawing.Size(122, 47);
            this.Update.TabIndex = 2;
            this.Update.Text = "MongoDB修改";
            this.Update.UseVisualStyleBackColor = true;
            this.Update.Click += new System.EventHandler(this.Update_Click);
            // 
            // Query
            // 
            this.Query.Location = new System.Drawing.Point(403, 206);
            this.Query.Name = "Query";
            this.Query.Size = new System.Drawing.Size(122, 44);
            this.Query.TabIndex = 3;
            this.Query.Text = "MongoDB查询";
            this.Query.UseVisualStyleBackColor = true;
            this.Query.Click += new System.EventHandler(this.Query_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(735, 490);
            this.Controls.Add(this.Query);
            this.Controls.Add(this.Update);
            this.Controls.Add(this.Delete);
            this.Controls.Add(this.Insert);
            this.Name = "Form1";
            this.Text = "MongoDB";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Insert;
        private System.Windows.Forms.Button Delete;
        private System.Windows.Forms.Button Update;
        private System.Windows.Forms.Button Query;
    }
}

