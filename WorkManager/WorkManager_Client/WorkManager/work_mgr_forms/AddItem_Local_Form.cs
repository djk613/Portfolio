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
    public partial class AddItem_Local_Form : Form
    {
        public delegate void ChildAddFormSendDataHandler(WorkNode node);
        public event ChildAddFormSendDataHandler ChildAddFormEvent;

        public AddItem_Local_Form()
        {
            InitializeComponent();
        }

        private void buttonFindFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDiag = new OpenFileDialog();
            fileDiag.DefaultExt = "All";
            fileDiag.Filter = "모든 파일 (*.*)|*.*";
            fileDiag.Multiselect = false;

            fileDiag.ShowDialog();

            if(fileDiag.FileName.Length > 0)
            {
                textBoxFilePath.Text = fileDiag.FileName;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(textBoxTitle.Text.Length == 0)
            {
                return;
            }

            string subject = textBoxTitle.Text;
            string detail = textBoxContext.Text;
            string linkedFile = textBoxFilePath.Text;

            string date = DateTime.Now.ToString("yyyy-MM-dd");
            string[] day = date.Split('-');

            /*it is possible to make overload... I don't know how much resources will be used for gethashcode func*/
            ulong serialNum = (ulong)subject.GetHashCode() + (ulong)detail.GetHashCode();

            /*file move*/
            string path = linkedFile;
            string newPath = new string(@"..\");
            newPath = newPath + '\\' + day[0];
            newPath = newPath + '\\' + day[1];
            newPath = newPath + '\\' + day[2];

            DirectoryInfo di = new DirectoryInfo(newPath);
            if (di.Exists == false)
            {
                di.Create();
            }

            newPath = newPath + '\\' + Path.GetFileName(textBoxFilePath.Text);

            if(textBoxFilePath.Text.Length != 0)
            {
                System.IO.File.Move(path, newPath);
            }

            WorkNode node = new WorkNode(serialNum, date, subject, detail, newPath);

            this.ChildAddFormEvent(node);

            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
