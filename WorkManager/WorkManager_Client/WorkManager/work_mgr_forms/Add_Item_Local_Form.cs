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

        private List<string> m_filesSelected { get; set; }

        public Add_Item_Local_Form()
        {
            InitializeComponent();

            m_filesSelected = new List<string>();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(textBoxTitle.Text.Length == 0)
            {
                MessageBox.Show("제목의 내용이 필요합니다.");
                return;
            }

            string str_subject = textBoxTitle.Text;
            string str_detail = textBoxContext.Text;

            string date = DateTime.Now.ToString("yyyy-MM-dd");

            /*it is possible to make overload... I don't know how much resources will be used for gethashcode func*/
            ulong serialNum = (ulong)str_subject.GetHashCode() + (ulong)str_detail.GetHashCode();

            LocalWorkNode node = new LocalWorkNode(serialNum, date, str_subject, str_detail, m_filesSelected);

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

            if (m_filesSelected != null)
            {
                m_filesSelected.Clear();
            }

            string str_openFilePath = System.Environment.CurrentDirectory;

            openfileDlg.InitialDirectory = str_openFilePath;
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
                    m_filesSelected.Add(filepath);
                }

                listView_fileList.Items.Clear();

                foreach (string fileName in m_filesSelected)
                {
                    ListViewItem lvi;
                    lvi = listView_fileList.Items.Add(Path.GetFileName(fileName));
                }
            }
        }
    }
}
