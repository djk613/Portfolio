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
        public bool m_bHas_IP_port_info { get; set; }

        private string m_strLogin_mode { get; set; }

        public Login()
        {
            InitializeComponent();
        }

        private void button_login_Click(object sender, EventArgs e)
        {
            if(m_strLogin_mode == "LOCAL")
            {
                /*if using simple local mode without connecting to server
                 this application will not use TCP network socket functions,
                 and files will be stored at user's PC, not server*/
                Work_Local_Form local_form = new Work_Local_Form();

                this.Visible = false;

                local_form.ShowDialog();

                this.Close();
            }
            else
            {
                /*ID and password check*/
                DB_userMgr db_user = new DB_userMgr();
                db_user.Connect();

                string str_password = HashForPassword.SHA256Hash(textBox_PW.Text);

                bool b_login_success = db_user.LoginID(textBox_ID.Text, str_password);
                db_user.Disconnect();

                if (b_login_success)
                {
                    MessageBox.Show("로그인 되었습니다.");

                    this.Visible = false;

                    Work_DB_Form work_db = new Work_DB_Form();
                    work_db.str_user_id = textBox_ID.Text;

                    work_db.ShowDialog();

                    this.Close();
                }
                else
                {
                    MessageBox.Show("아이디, 비밀번호가 일치하지 않습니다.");
                }
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
            m_strLogin_mode = (string)comboBox_mode.SelectedItem;

            if(m_strLogin_mode == "DB")
            {
                textBox_ID.Enabled = true;
                textBox_PW.Enabled = true;
            }
            else if(m_strLogin_mode == "LOCAL")
            {
                textBox_ID.Enabled = false;
                textBox_PW.Enabled = false;
            }
        }
    }
}
