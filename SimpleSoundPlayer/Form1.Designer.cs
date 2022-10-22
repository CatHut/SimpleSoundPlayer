namespace SimpleSoundPlayer
{
    partial class Form_SimpleSoundPlayer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_SimpleSoundPlayer));
            this.textBox_FolderPath = new System.Windows.Forms.TextBox();
            this.listView_FileList = new System.Windows.Forms.ListView();
            this.columnHeader_FileName = new System.Windows.Forms.ColumnHeader();
            this.columnHeader_No = new System.Windows.Forms.ColumnHeader();
            this.columnHeader_Length = new System.Windows.Forms.ColumnHeader();
            this.columnHeader_Ext = new System.Windows.Forms.ColumnHeader();
            this.columnHeader_FolderPath = new System.Windows.Forms.ColumnHeader();
            this.columnHeader_FullPath = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // textBox_FolderPath
            // 
            this.textBox_FolderPath.AllowDrop = true;
            this.textBox_FolderPath.Location = new System.Drawing.Point(12, 12);
            this.textBox_FolderPath.Name = "textBox_FolderPath";
            this.textBox_FolderPath.Size = new System.Drawing.Size(920, 23);
            this.textBox_FolderPath.TabIndex = 0;
            this.textBox_FolderPath.TextChanged += new System.EventHandler(this.textBox_FolderPath_TextChanged);
            this.textBox_FolderPath.DragDrop += new System.Windows.Forms.DragEventHandler(this.textBox_FolderPath_DragDrop);
            this.textBox_FolderPath.DragEnter += new System.Windows.Forms.DragEventHandler(this.textBox_FolderPath_DragEnter);
            // 
            // listView_FileList
            // 
            this.listView_FileList.AllowDrop = true;
            this.listView_FileList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader_FileName,
            this.columnHeader_No,
            this.columnHeader_Length,
            this.columnHeader_Ext,
            this.columnHeader_FolderPath,
            this.columnHeader_FullPath});
            this.listView_FileList.Location = new System.Drawing.Point(12, 41);
            this.listView_FileList.MultiSelect = false;
            this.listView_FileList.Name = "listView_FileList";
            this.listView_FileList.Size = new System.Drawing.Size(920, 548);
            this.listView_FileList.TabIndex = 2;
            this.listView_FileList.UseCompatibleStateImageBehavior = false;
            this.listView_FileList.View = System.Windows.Forms.View.Details;
            this.listView_FileList.SelectedIndexChanged += new System.EventHandler(this.listView_FileList_SelectedIndexChanged);
            this.listView_FileList.DragDrop += new System.Windows.Forms.DragEventHandler(this.textBox_FolderPath_DragDrop);
            this.listView_FileList.DragEnter += new System.Windows.Forms.DragEventHandler(this.textBox_FolderPath_DragEnter);
            this.listView_FileList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listView_FileList_KeyDown);
            this.listView_FileList.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listView_FileList_MouseClick);
            // 
            // columnHeader_FileName
            // 
            this.columnHeader_FileName.DisplayIndex = 1;
            this.columnHeader_FileName.Text = "ファイル名";
            this.columnHeader_FileName.Width = 180;
            // 
            // columnHeader_No
            // 
            this.columnHeader_No.DisplayIndex = 0;
            this.columnHeader_No.Text = "No.";
            this.columnHeader_No.Width = 45;
            // 
            // columnHeader_Length
            // 
            this.columnHeader_Length.Text = "長さ";
            // 
            // columnHeader_Ext
            // 
            this.columnHeader_Ext.Text = "形式";
            // 
            // columnHeader_FolderPath
            // 
            this.columnHeader_FolderPath.Text = "フォルダパス";
            this.columnHeader_FolderPath.Width = 600;
            // 
            // columnHeader_FullPath
            // 
            this.columnHeader_FullPath.Text = "フルパス";
            this.columnHeader_FullPath.Width = 0;
            // 
            // Form_SimpleSoundPlayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 601);
            this.Controls.Add(this.listView_FileList);
            this.Controls.Add(this.textBox_FolderPath);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_SimpleSoundPlayer";
            this.Text = "SimpleSoundPlayer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_SimpleSoundPlayer_FormClosing);
            this.ResizeEnd += new System.EventHandler(this.Form_SimpleSoundPlayer_ResizeEnd);
            this.Resize += new System.EventHandler(this.Form_SimpleSoundPlayer_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox textBox_FolderPath;
        private ListView listView_FileList;
        private ColumnHeader columnHeader_FileName;
        private ColumnHeader columnHeader_Length;
        private ColumnHeader columnHeader_FolderPath;
        private ColumnHeader columnHeader_No;
        private ColumnHeader columnHeader_Ext;
        private ColumnHeader columnHeader_FullPath;
    }
}