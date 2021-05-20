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
    public partial class Check_Item_Local_Form : Form
    {
        public delegate void ChildCheckFormSendDataHandler(LocalWorkNode node);

        public LocalWorkNode checkingNode;

        public Check_Item_Local_Form()
        {
            InitializeComponent();
        }

        private void Check_Item_Local_Form_Load(object sender, EventArgs e)
        {
            this.textBoxTitle.Text = checkingNode.subject;
            this.textBoxContext.Text = checkingNode.detailed;
        }

        private void btnErase_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
