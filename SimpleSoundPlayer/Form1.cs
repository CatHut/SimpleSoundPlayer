using System.Diagnostics;
using WMPLib;
using CatHut;

namespace SimpleSoundPlayer
{
    public partial class Form_SimpleSoundPlayer : Form
    {
        WMPLib.WindowsMediaPlayer m_WMP = null;
        AppSetting m_AppSetting;

        // 全ファイルのリスト（フィルタ前）
        private List<ListViewItem> m_AllFileItems = new List<ListViewItem>();

        // フィルタ処理用のタスク
        private Task m_FilterTask = null;
        private CancellationTokenSource m_FilterCancellation = null;

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

            // フィルタ設定を復元
            textBox_Filter1.Text = m_AppSetting.Settings.Filter1Text;
            comboBox_Filter1.SelectedIndex = m_AppSetting.Settings.Filter1Mode;
            textBox_Filter2.Text = m_AppSetting.Settings.Filter2Text;
            comboBox_Filter2.SelectedIndex = m_AppSetting.Settings.Filter2Mode;
            textBox_Filter3.Text = m_AppSetting.Settings.Filter3Text;
            comboBox_Filter3.SelectedIndex = m_AppSetting.Settings.Filter3Mode;
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
            //�L�[�������ꂽ�����ׂ�
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
                m_AllFileItems.Clear();

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

                    m_AllFileItems.Add(item);

                    if (m_WMP != null)
                    {
                        m_WMP.controls.stop();
                    }
                }

                // フィルタを適用してリストビューを更新
                ApplyFilter();
            }

        }

        private void Form_SimpleSoundPlayer_FormClosing(object sender, FormClosingEventArgs e)
        {
            m_AppSetting.Settings.Path = textBox_FolderPath.Text;

            // フィルタ設定を保存
            m_AppSetting.Settings.Filter1Text = textBox_Filter1.Text;
            m_AppSetting.Settings.Filter1Mode = comboBox_Filter1.SelectedIndex;
            m_AppSetting.Settings.Filter2Text = textBox_Filter2.Text;
            m_AppSetting.Settings.Filter2Mode = comboBox_Filter2.SelectedIndex;
            m_AppSetting.Settings.Filter3Text = textBox_Filter3.Text;
            m_AppSetting.Settings.Filter3Mode = comboBox_Filter3.SelectedIndex;

            m_AppSetting.Exit();
        }

        private void comboBox_Filter1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private void comboBox_Filter2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private void comboBox_Filter3_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private void textBox_Filter1_TextChanged(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private void textBox_Filter2_TextChanged(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private void textBox_Filter3_TextChanged(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private void button_ClearFilter_Click(object sender, EventArgs e)
        {
            textBox_Filter1.Text = "";
            textBox_Filter2.Text = "";
            textBox_Filter3.Text = "";
            comboBox_Filter1.SelectedIndex = 0;
            comboBox_Filter2.SelectedIndex = 0;
            comboBox_Filter3.SelectedIndex = 0;
        }

        /// <summary>
        /// フィルタを適用してリストビューを更新
        /// </summary>
        private void ApplyFilter()
        {
            // 既存のフィルタタスクをキャンセル
            if (m_FilterCancellation != null)
            {
                m_FilterCancellation.Cancel();
            }

            m_FilterCancellation = new CancellationTokenSource();
            var token = m_FilterCancellation.Token;

            // フィルタ条件を取得
            var filter1Text = textBox_Filter1.Text.Trim();
            var filter1Mode = comboBox_Filter1.SelectedIndex; // 0:含む, 1:含まない
            var filter2Text = textBox_Filter2.Text.Trim();
            var filter2Mode = comboBox_Filter2.SelectedIndex;
            var filter3Text = textBox_Filter3.Text.Trim();
            var filter3Mode = comboBox_Filter3.SelectedIndex;

            // すべてのフィルタが空の場合は全件表示
            bool hasFilter = !string.IsNullOrEmpty(filter1Text) ||
                           !string.IsNullOrEmpty(filter2Text) ||
                           !string.IsNullOrEmpty(filter3Text);

            // バックグラウンドでフィルタ処理を実行
            m_FilterTask = Task.Run(() =>
            {
                // フィルタ処理
                var filteredItems = new List<ListViewItem>();

                foreach (var item in m_AllFileItems)
                {
                    if (token.IsCancellationRequested)
                        return filteredItems;

                    bool match = true;

                    // フィルタが1つも設定されていない場合は全件表示
                    if (hasFilter)
                    {
                        // フルパスの文字列を取得（ファイル名+フォルダパス）
                        var fullPath = item.SubItems[(int)COLUMNS.FULL_PATH].Text;
                        var fileName = item.SubItems[(int)COLUMNS.FILE_NAME].Text;
                        var folderPath = item.SubItems[(int)COLUMNS.FOLDER_PATH].Text;
                        var searchTarget = fileName + " " + folderPath;

                        // フィルタ1（TextBoxが空でない場合のみ処理）
                        if (!string.IsNullOrEmpty(filter1Text))
                        {
                            bool contains = searchTarget.IndexOf(filter1Text, StringComparison.OrdinalIgnoreCase) >= 0;
                            if (filter1Mode == 0 && !contains) match = false; // 含む
                            if (filter1Mode == 1 && contains) match = false;  // 含まない
                        }

                        // フィルタ2（TextBoxが空でない場合のみ処理）
                        if (match && !string.IsNullOrEmpty(filter2Text))
                        {
                            bool contains = searchTarget.IndexOf(filter2Text, StringComparison.OrdinalIgnoreCase) >= 0;
                            if (filter2Mode == 0 && !contains) match = false;
                            if (filter2Mode == 1 && contains) match = false;
                        }

                        // フィルタ3（TextBoxが空でない場合のみ処理）
                        if (match && !string.IsNullOrEmpty(filter3Text))
                        {
                            bool contains = searchTarget.IndexOf(filter3Text, StringComparison.OrdinalIgnoreCase) >= 0;
                            if (filter3Mode == 0 && !contains) match = false;
                            if (filter3Mode == 1 && contains) match = false;
                        }
                    }

                    if (match)
                    {
                        filteredItems.Add((ListViewItem)item.Clone());
                    }
                }

                return filteredItems;
            }, token).ContinueWith(task =>
            {
                // UIスレッドでリストビューを更新
                if (!token.IsCancellationRequested && task.IsCompletedSuccessfully)
                {
                    var filteredItems = task.Result;

                    listView_FileList.BeginUpdate();
                    listView_FileList.Items.Clear();

                    // No.を振り直す
                    for (int i = 0; i < filteredItems.Count; i++)
                    {
                        filteredItems[i].SubItems[(int)COLUMNS.NO].Text = (i + 1).ToString();
                        listView_FileList.Items.Add(filteredItems[i]);
                    }

                    listView_FileList.EndUpdate();
                }
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }
    }
}