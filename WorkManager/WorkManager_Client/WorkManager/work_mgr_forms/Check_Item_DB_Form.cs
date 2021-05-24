using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WorkManager
{
    public partial class Check_Item_DB_Form : Form
    {
        public string m_strTitle { get; set; }
        public string m_strDetails { get; set; }

        public Check_Item_DB_Form()
        {
            InitializeComponent();
        }

        private void Check_Item_DB_Form_Load(object sender, EventArgs e)
        {
            textBoxTitle.Text = m_strTitle;
            textBoxDetails.Text = m_strDetails;
        }

        private void btnErase_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
