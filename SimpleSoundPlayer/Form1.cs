using System.Diagnostics;
using WMPLib;
using CatHut;

namespace SimpleSoundPlayer
{
    public partial class Form_SimpleSoundPlayer : Form
    {
        WMPLib.WindowsMediaPlayer m_WMP = null;
        AppSetting m_AppSetting;

        enum COLUMNS
        {
            FILE_NAME = 0,
            NO,
            Length,
            EXT,
            FOLDER_PATH,
            FULL_PATH
        }

        public Form_SimpleSoundPlayer()
        {
            InitializeComponent();
            m_AppSetting = new AppSetting();
            textBox_FolderPath.Text = m_AppSetting.Settings.Path;
            this.ActiveControl = this.listView_FileList;
        }

        private void textBox_FolderPath_DragDrop(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent(DataFormats.FileDrop)) return;

            string[] dragFilePathArr = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            textBox_FolderPath.Text = dragFilePathArr[0];

        }

        private void textBox_FolderPath_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }


        private void listView_FileList_KeyDown(object sender, KeyEventArgs e)
        {
            //キーが押されたか調べる
            if (e.KeyCode == Keys.Enter)
            {
                var selected = this.listView_FileList.SelectedItems;

                if (selected.Count < 1)
                {
                    listView_FileList.Items[0].Selected = true;
                    listView_FileList.Items[0].Focused = true;
                    return;
                }

                var idx = listView_FileList.SelectedItems[0].Index;
                var next = (idx + 1) % listView_FileList.Items.Count;

                listView_FileList.Items[next].Selected = true;
                listView_FileList.Items[next].Focused = true;
                listView_FileList.EnsureVisible(next);

            }
        }

        private void listView_FileList_MouseClick(object sender, MouseEventArgs e)
        {
            var selected = this.listView_FileList.SelectedItems;

            if (selected.Count < 1)
            {
                return;
            }

            var file = selected[0].SubItems[(int)COLUMNS.FULL_PATH].Text;

            if (m_WMP == null)
            {
                m_WMP = new WindowsMediaPlayer();
            }
            else
            {
                m_WMP.controls.stop();
            }
            m_WMP.URL = file;
            m_WMP.controls.play();

            if ((e.Button & MouseButtons.Right) == MouseButtons.Right)
            {
                OpenExplorer(file);
            }
        }

        private void listView_FileList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selected = this.listView_FileList.SelectedItems;

            if (selected.Count < 1)
            {
                return;
            }

            var file = selected[0].SubItems[(int)COLUMNS.FULL_PATH].Text;

            if (m_WMP == null)
            {
                m_WMP = new WindowsMediaPlayer();
            }
            else
            {
                m_WMP.controls.stop();
            }
            m_WMP.URL = file;
            m_WMP.controls.play();

        }

        private void OpenExplorer(string path)
        {
            try
            {
                Process.Start("explorer.exe", @"/select,""" + path + @"""");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.GetType());
            }
        }

        private void Form_SimpleSoundPlayer_ResizeEnd(object sender, EventArgs e)
        {

        }

        private void Form_SimpleSoundPlayer_Resize(object sender, EventArgs e)
        {
            listView_FileList.Size = new Size(this.Width - 40, this.Height - 92);
            textBox_FolderPath.Size = new Size(this.Width - 40, textBox_FolderPath.Height);
        }

        private void textBox_FolderPath_TextChanged(object sender, EventArgs e)
        {
            if (true == Directory.Exists(textBox_FolderPath.Text))
            {
                System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(textBox_FolderPath.Text);
                IEnumerable<System.IO.FileInfo> files = di.EnumerateFiles("*", System.IO.SearchOption.AllDirectories);

                listView_FileList.Items.Clear();

                var idx = 1;

                foreach (System.IO.FileInfo f in files)
                {
                    var ext = Path.GetExtension(f.Name);
                    if (ext != @".mp3" && ext != @".wav")
                    {
                        continue;
                    }

                    var file = f.FullName;

                    var item = new ListViewItem();
                    item.Text = Path.GetFileNameWithoutExtension(f.FullName);

                    item.SubItems.Add(idx.ToString());
                    idx++;

                    //再生時間
                    var tfile = TagLib.File.Create(file);
                    TimeSpan duration = tfile.Properties.Duration;
                    item.SubItems.Add(duration.ToString(@"mm\:ss\.ff"));

                    //形式
                    item.SubItems.Add(Path.GetExtension(f.Name).Replace(".", ""));

                    //フォルダ名
                    item.SubItems.Add(Path.GetDirectoryName(file));

                    //フルパス
                    item.SubItems.Add(f.FullName);

                    listView_FileList.Items.Add(item);
                    listView_FileList.Focus();

                    if (m_WMP != null)
                    {
                        m_WMP.controls.stop();
                    }
                }

            }

        }

        private void Form_SimpleSoundPlayer_FormClosing(object sender, FormClosingEventArgs e)
        {
            m_AppSetting.Settings.Path = textBox_FolderPath.Text;
            m_AppSetting.Exit();
        }

        private void comboBox_Filter1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox_Filter2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox_Filter3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox_Filter1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_Filter2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_Filter3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button_ClearFilter_Click(object sender, EventArgs e)
        {

        }
    }
}