using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WorkManager
{
    public partial class CreateID_form : Form
    {
        public CreateID_form()
        {
            InitializeComponent();
        }

        private void button_create_ID_Click(object sender, EventArgs e)
        {
            DB_userMgr db_user = new DB_userMgr();
            db_user.Connect();

            string password = HashForPassword.SHA256Hash(textBox_PW.Text);

            bool b_create_ID_success = db_user.CreateID(textBox_ID.Text, password);
            db_user.Disconnect();

            if (b_create_ID_success)
            {
                MessageBox.Show("새로운 계정이 생성되었습니다.");
                
                this.Close();
            }
            else
            {
                MessageBox.Show("해당 아이디는 이미 존재합니다.");
            }

        }
    }
}
