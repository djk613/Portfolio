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

        public Add_Item_Local_Form()
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
                MessageBox.Show("제목의 내용이 필요합니다.");
                return;
            }

            string subject = textBoxTitle.Text;
            string detail = textBoxContext.Text;
            string linkedFile = textBoxFilePath.Text;

            string date = DateTime.Now.ToString("yyyy-MM-dd");
            string[] day = date.Split('-');

            /*it is possible to make overload... I don't know how much resources will be used for gethashcode func*/
            ulong serialNum = (ulong)subject.GetHashCode() + (ulong)detail.GetHashCode();

            LocalWorkNode node = new LocalWorkNode(serialNum, date, subject, detail, linkedFile);

            this.ChildAddFormEvent(node);

            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
