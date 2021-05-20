using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace WorkManager
{
    public partial class Add_Item_Local_Form : Form
    {
        public delegate void ChildAddFormSendDataHandler(LocalWorkNode node);
        public event ChildAddFormSendDataHandler ChildAddFormEvent;

        private List<string> filesSelected { get; set; }

        public Add_Item_Local_Form()
        {
            InitializeComponent();

            filesSelected = new List<string>();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(textBoxTitle.Text.Length == 0)
            {
                MessageBox.Show("제목의 내용이 필요합니다.");
                return;
            }

            string subject = textBoxTitle.Text;
            string detail = textBoxContext.Text;

            string date = DateTime.Now.ToString("yyyy-MM-dd");

            /*it is possible to make overload... I don't know how much resources will be used for gethashcode func*/
            ulong serialNum = (ulong)subject.GetHashCode() + (ulong)detail.GetHashCode();

            LocalWorkNode node = new LocalWorkNode(serialNum, date, subject, detail, filesSelected);

            this.ChildAddFormEvent(node);

            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_files_Click(object sender, EventArgs e)
        {
            OpenFileDialog openfileDlg = new OpenFileDialog();

            if (filesSelected != null)
            {
                filesSelected.Clear();
            }

            string OpenFilePath = System.Environment.CurrentDirectory;

            openfileDlg.InitialDirectory = OpenFilePath;
            openfileDlg.RestoreDirectory = true;
            openfileDlg.Title = "파일 선택";
            openfileDlg.DefaultExt = "*";
            openfileDlg.FileName = "";
            openfileDlg.Filter = "모든 파일 (*.*) | *.*";

            openfileDlg.Multiselect = true;
            openfileDlg.ReadOnlyChecked = true;
            openfileDlg.ShowReadOnly = true;

            DialogResult dr = openfileDlg.ShowDialog();

            if (dr == DialogResult.OK)
            {
                foreach (String filepath in openfileDlg.FileNames)
                {
                    filesSelected.Add(filepath);
                }

                listView_fileList.Items.Clear();

                foreach (string fileName in filesSelected)
                {
                    ListViewItem lvi;
                    lvi = listView_fileList.Items.Add(Path.GetFileName(fileName));
                }
            }
        }
    }
}
