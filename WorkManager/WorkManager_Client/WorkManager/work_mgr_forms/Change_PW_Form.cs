using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WorkManager
{
    public partial class ChangePWForm : Form
    {
        public ChangePWForm()
        {
            InitializeComponent();
        }

        private void button_login_Click(object sender, EventArgs e)
        {
            DB_userMgr db_user = new DB_userMgr();
            db_user.Connect();

            bool b_pw_change_success = db_user.ChangePassword(textBox_ID.Text,
                HashForPassword.SHA256Hash(textBox_PW.Text),
                HashForPassword.SHA256Hash(textBox_changed_PW.Text));

            db_user.Disconnect();

            if (b_pw_change_success)
            {
                MessageBox.Show("비밀번호가 변경되었습니다.");
            }
            else
            {
                MessageBox.Show("아이디가 없거나, 기존의 비밀번호가 일치하지 않습니다.");
            }

            this.Close();
        }
    }
}
