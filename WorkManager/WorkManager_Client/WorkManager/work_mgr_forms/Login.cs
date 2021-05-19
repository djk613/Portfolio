using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace WorkManager
{
    public partial class Login : Form
    {
        private string login_mode { get; set; }

        public Login()
        {
            InitializeComponent();
        }

        private void button_login_Click(object sender, EventArgs e)
        {
            if(login_mode == "LOCAL")
            {
                Work_Local_Form local_form = new Work_Local_Form();

                this.Visible = false;

                local_form.ShowDialog();

                this.Close();
            }

            DB_userMgr db_user = new DB_userMgr();
            db_user.Connect();

            string password = HashForPassword.SHA256Hash(textBox_PW.Text);

            bool b_login_success = db_user.LoginID(textBox_ID.Text, password);
            db_user.Disconnect();

            if (b_login_success)
            {
                MessageBox.Show("로그인 되었습니다.");

                this.Visible = false;

                Work_DB_Form work_db = new Work_DB_Form();
                work_db.user_id = textBox_ID.Text;

                work_db.ShowDialog();

                this.Close();
            }
            else
            {
                MessageBox.Show("아이디, 비밀번호가 일치하지 않습니다.");
            }
        }

        private void button_create_ID_Click(object sender, EventArgs e)
        {
            CreateID_form createID = new CreateID_form();

            this.Visible = false;

            createID.ShowDialog();

            this.Visible = true;
        }

        private void button_change_PW_Click(object sender, EventArgs e)
        {
            ChangePWForm changePW = new ChangePWForm();

            this.Visible = false;

            changePW.ShowDialog();

            this.Visible = true;
        }

        private void Login_Load(object sender, EventArgs e)
        {
            comboBox_mode.Items.Add("DB");
            comboBox_mode.Items.Add("LOCAL");

            comboBox_mode.Text = "DB";
        }

        private void comboBox_mode_SelectedIndexChanged(object sender, EventArgs e)
        {
            login_mode = (string)comboBox_mode.SelectedItem;

            if(login_mode == "DB")
            {
                textBox_ID.Enabled = true;
                textBox_PW.Enabled = true;
            }
            else if(login_mode == "LOCAL")
            {
                textBox_ID.Enabled = false;
                textBox_PW.Enabled = false;
            }
        }
    }
}
