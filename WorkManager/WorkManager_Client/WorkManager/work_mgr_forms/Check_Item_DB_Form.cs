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
        public string title { get; set; }
        public string details { get; set; }

        public Check_Item_DB_Form()
        {
            InitializeComponent();
        }

        private void Check_Item_DB_Form_Load(object sender, EventArgs e)
        {
            textBoxTitle.Text = title;
            textBoxDetails.Text = details;
        }
    }
}
