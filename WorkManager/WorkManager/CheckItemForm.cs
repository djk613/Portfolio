using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace WorkManager
{
    public partial class CheckItemForm : Form
    {
        public delegate void ChildCheckFormSendDataHandler(WorkNode node);
        public event ChildCheckFormSendDataHandler ChildEraseFormEvent;
        public CheckItemForm()
        {
            InitializeComponent();
        }

        public void SetDetailData()
        {
            this.textBoxTitle.Text = checkingNode.subject;
            this.textBoxContext.Text = checkingNode.detailed;
            this.textBoxFilePath.Text = checkingNode.linkedFile;
        }

        private void btnErase_Click(object sender, EventArgs e)
        {
            this.ChildEraseFormEvent(checkingNode);

            this.Close();
        }

        public WorkNode checkingNode;

        private void buttonOpenFolder_Click(object sender, EventArgs e)
        {
            Process.Start(checkingNode.linkedFile);
        }
    }
}
