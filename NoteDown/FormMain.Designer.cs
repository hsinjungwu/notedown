namespace NoteDown
{
    partial class FormMain
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
        /// 修改這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.TreeViewList = new System.Windows.Forms.TreeView();
            this.Content = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // TreeViewList
            // 
            this.TreeViewList.Dock = System.Windows.Forms.DockStyle.Left;
            this.TreeViewList.Indent = 10;
            this.TreeViewList.Location = new System.Drawing.Point(0, 0);
            this.TreeViewList.Name = "TreeViewList";
            this.TreeViewList.Size = new System.Drawing.Size(127, 412);
            this.TreeViewList.TabIndex = 0;
            // 
            // Content
            // 
            this.Content.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Content.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Content.Location = new System.Drawing.Point(127, 0);
            this.Content.Name = "Content";
            this.Content.Size = new System.Drawing.Size(774, 412);
            this.Content.TabIndex = 3;
            this.Content.Text = "";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(901, 412);
            this.Controls.Add(this.Content);
            this.Controls.Add(this.TreeViewList);
            this.Name = "FormMain";
            this.Text = "NoteDown";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView TreeViewList;
        private System.Windows.Forms.RichTextBox Content;
    }
}

