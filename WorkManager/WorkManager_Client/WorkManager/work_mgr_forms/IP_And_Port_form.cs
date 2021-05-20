using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WorkManager
{
    public partial class IP_And_Port_form : Form
    {
        public IP_And_Port_form()
        {
            InitializeComponent();
        }

        private void checkBox_localhost_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_localhost.Checked == true)
            {
                textBox_DB_IP.Text = "127.0.0.1";
                textBox_DB_port.Text = "10386";
                textBox_File_IP.Text = "127.0.0.1";
                textBox_File_port.Text = "10387";
            }
            else
            {
                textBox_DB_IP.Text = "";
                textBox_DB_port.Text = "";
                textBox_File_IP.Text = "";
                textBox_File_port.Text = "";
            }
        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            if (textBox_DB_IP.Text == "" || textBox_DB_port.Text == "" || textBox_File_IP.Text == "" || textBox_File_port.Text == "")
            {
                MessageBox.Show("IP나 Port 누락되었습니다.");
                return;
            }

            Login login = new Login();
            login.hasIPAndPortInfo = true;
            Globals.DB_IP = textBox_DB_IP.Text;
            Globals.DB_port = Convert.ToInt32(textBox_DB_port.Text);
            Globals.file_IP = textBox_File_IP.Text;
            Globals.file_port = Convert.ToInt32(textBox_File_port.Text);

            this.Visible = false;
            login.ShowDialog();

            this.Close();
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            DialogResult dlgReault =  MessageBox.Show("서버IP와 Port정보 없이, DB모드와 몇몇 기능 사용이 제한됩니다. 진행 하시겠습니까?", "확인", MessageBoxButtons.OKCancel);

            if(dlgReault == DialogResult.OK)
            {
                MessageBox.Show("Local모드로 진행합니다.");

                Work_Local_Form local = new Work_Local_Form();

                this.Visible = false;

                local.ShowDialog();

                this.Close();
            }
            else
            {
                return;
            }
        }

        private void textBox_IP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void textBox_port_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }


    }
}
