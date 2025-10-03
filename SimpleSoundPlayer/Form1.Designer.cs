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
            textBox_FolderPath = new TextBox();
            listView_FileList = new ListView();
            columnHeader_FileName = new ColumnHeader();
            columnHeader_No = new ColumnHeader();
            columnHeader_Length = new ColumnHeader();
            columnHeader_Ext = new ColumnHeader();
            columnHeader_FolderPath = new ColumnHeader();
            columnHeader_FullPath = new ColumnHeader();
            groupBox_Filiter = new GroupBox();
            button_ClearFilter = new Button();
            textBox_Filter3 = new TextBox();
            comboBox_Filter3 = new ComboBox();
            textBox_Filter2 = new TextBox();
            comboBox_Filter2 = new ComboBox();
            textBox_Filter1 = new TextBox();
            comboBox_Filter1 = new ComboBox();
            splitContainer1 = new SplitContainer();
            groupBox_Filiter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // textBox_FolderPath
            // 
            textBox_FolderPath.AllowDrop = true;
            textBox_FolderPath.Location = new Point(12, 12);
            textBox_FolderPath.Name = "textBox_FolderPath";
            textBox_FolderPath.Size = new Size(920, 23);
            textBox_FolderPath.TabIndex = 0;
            textBox_FolderPath.TextChanged += textBox_FolderPath_TextChanged;
            textBox_FolderPath.DragDrop += textBox_FolderPath_DragDrop;
            textBox_FolderPath.DragEnter += textBox_FolderPath_DragEnter;
            // 
            // listView_FileList
            // 
            listView_FileList.AllowDrop = true;
            listView_FileList.Columns.AddRange(new ColumnHeader[] { columnHeader_FileName, columnHeader_No, columnHeader_Length, columnHeader_Ext, columnHeader_FolderPath, columnHeader_FullPath });
            listView_FileList.Dock = DockStyle.Fill;
            listView_FileList.Location = new Point(0, 0);
            listView_FileList.MultiSelect = false;
            listView_FileList.Name = "listView_FileList";
            listView_FileList.Size = new Size(952, 639);
            listView_FileList.TabIndex = 2;
            listView_FileList.UseCompatibleStateImageBehavior = false;
            listView_FileList.View = View.Details;
            listView_FileList.SelectedIndexChanged += listView_FileList_SelectedIndexChanged;
            listView_FileList.DragDrop += textBox_FolderPath_DragDrop;
            listView_FileList.DragEnter += textBox_FolderPath_DragEnter;
            listView_FileList.KeyDown += listView_FileList_KeyDown;
            listView_FileList.MouseClick += listView_FileList_MouseClick;
            // 
            // columnHeader_FileName
            // 
            columnHeader_FileName.DisplayIndex = 1;
            columnHeader_FileName.Text = "ファイル名";
            columnHeader_FileName.Width = 180;
            // 
            // columnHeader_No
            // 
            columnHeader_No.DisplayIndex = 0;
            columnHeader_No.Text = "No.";
            columnHeader_No.Width = 45;
            // 
            // columnHeader_Length
            // 
            columnHeader_Length.Text = "長さ";
            // 
            // columnHeader_Ext
            // 
            columnHeader_Ext.Text = "形式";
            // 
            // columnHeader_FolderPath
            // 
            columnHeader_FolderPath.Text = "フォルダパス";
            columnHeader_FolderPath.Width = 600;
            // 
            // columnHeader_FullPath
            // 
            columnHeader_FullPath.Text = "フルパス";
            columnHeader_FullPath.Width = 0;
            // 
            // groupBox_Filiter
            // 
            groupBox_Filiter.Controls.Add(button_ClearFilter);
            groupBox_Filiter.Controls.Add(textBox_Filter3);
            groupBox_Filiter.Controls.Add(comboBox_Filter3);
            groupBox_Filiter.Controls.Add(textBox_Filter2);
            groupBox_Filiter.Controls.Add(comboBox_Filter2);
            groupBox_Filiter.Controls.Add(textBox_Filter1);
            groupBox_Filiter.Controls.Add(comboBox_Filter1);
            groupBox_Filiter.Location = new Point(12, 41);
            groupBox_Filiter.Name = "groupBox_Filiter";
            groupBox_Filiter.Size = new Size(920, 140);
            groupBox_Filiter.TabIndex = 3;
            groupBox_Filiter.TabStop = false;
            groupBox_Filiter.Text = "Filter";
            // 
            // button_ClearFilter
            // 
            button_ClearFilter.Location = new Point(6, 108);
            button_ClearFilter.Name = "button_ClearFilter";
            button_ClearFilter.Size = new Size(75, 23);
            button_ClearFilter.TabIndex = 6;
            button_ClearFilter.Text = "クリア";
            button_ClearFilter.UseVisualStyleBackColor = true;
            button_ClearFilter.Click += button_ClearFilter_Click;
            // 
            // textBox_Filter3
            // 
            textBox_Filter3.Location = new Point(133, 79);
            textBox_Filter3.Name = "textBox_Filter3";
            textBox_Filter3.Size = new Size(781, 23);
            textBox_Filter3.TabIndex = 5;
            textBox_Filter3.TextChanged += textBox_Filter3_TextChanged;
            // 
            // comboBox_Filter3
            // 
            comboBox_Filter3.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_Filter3.FormattingEnabled = true;
            comboBox_Filter3.Items.AddRange(new object[] { "含む", "含まない" });
            comboBox_Filter3.Location = new Point(6, 79);
            comboBox_Filter3.Name = "comboBox_Filter3";
            comboBox_Filter3.Size = new Size(121, 23);
            comboBox_Filter3.TabIndex = 4;
            comboBox_Filter3.SelectedIndexChanged += comboBox_Filter3_SelectedIndexChanged;
            // 
            // textBox_Filter2
            // 
            textBox_Filter2.Location = new Point(133, 51);
            textBox_Filter2.Name = "textBox_Filter2";
            textBox_Filter2.Size = new Size(781, 23);
            textBox_Filter2.TabIndex = 3;
            textBox_Filter2.TextChanged += textBox_Filter2_TextChanged;
            // 
            // comboBox_Filter2
            // 
            comboBox_Filter2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_Filter2.FormattingEnabled = true;
            comboBox_Filter2.Items.AddRange(new object[] { "含む", "含まない" });
            comboBox_Filter2.Location = new Point(6, 51);
            comboBox_Filter2.Name = "comboBox_Filter2";
            comboBox_Filter2.Size = new Size(121, 23);
            comboBox_Filter2.TabIndex = 2;
            comboBox_Filter2.SelectedIndexChanged += comboBox_Filter2_SelectedIndexChanged;
            // 
            // textBox_Filter1
            // 
            textBox_Filter1.Location = new Point(133, 22);
            textBox_Filter1.Name = "textBox_Filter1";
            textBox_Filter1.Size = new Size(781, 23);
            textBox_Filter1.TabIndex = 1;
            textBox_Filter1.TextChanged += textBox_Filter1_TextChanged;
            // 
            // comboBox_Filter1
            // 
            comboBox_Filter1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_Filter1.FormattingEnabled = true;
            comboBox_Filter1.Items.AddRange(new object[] { "含む", "含まない" });
            comboBox_Filter1.Location = new Point(6, 22);
            comboBox_Filter1.Name = "comboBox_Filter1";
            comboBox_Filter1.Size = new Size(121, 23);
            comboBox_Filter1.TabIndex = 0;
            comboBox_Filter1.SelectedIndexChanged += comboBox_Filter1_SelectedIndexChanged;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.FixedPanel = FixedPanel.Panel1;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(groupBox_Filiter);
            splitContainer1.Panel1.Controls.Add(textBox_FolderPath);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(listView_FileList);
            splitContainer1.Size = new Size(952, 833);
            splitContainer1.SplitterDistance = 190;
            splitContainer1.TabIndex = 4;
            // 
            // Form_SimpleSoundPlayer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(952, 833);
            Controls.Add(splitContainer1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form_SimpleSoundPlayer";
            Text = "SimpleSoundPlayer";
            FormClosing += Form_SimpleSoundPlayer_FormClosing;
            ResizeEnd += Form_SimpleSoundPlayer_ResizeEnd;
            Resize += Form_SimpleSoundPlayer_Resize;
            groupBox_Filiter.ResumeLayout(false);
            groupBox_Filiter.PerformLayout();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);

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
        private GroupBox groupBox_Filiter;
        private TextBox textBox_Filter1;
        private ComboBox comboBox_Filter1;
        private TextBox textBox_Filter3;
        private ComboBox comboBox_Filter3;
        private TextBox textBox_Filter2;
        private ComboBox comboBox_Filter2;
        private Button button_ClearFilter;
        private SplitContainer splitContainer1;
    }
}