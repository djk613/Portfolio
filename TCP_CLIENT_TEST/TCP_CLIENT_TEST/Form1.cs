using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FileSender;

namespace TCP_CLIENT_TEST
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox_type.Items.Add("SEND");
            comboBox_type.Items.Add("RECEIVE");
        }

        private void button_file_search_Click(object sender, EventArgs e)
        {
            OpenFileDialog pFileDlg = new OpenFileDialog();
            pFileDlg.Filter = "Text Files(*.txt)|*.txt|All Files(*.*)|*.*";
            pFileDlg.Title = "주소 파일을 선택해 주세요.";
            if (pFileDlg.ShowDialog() == DialogResult.OK)
            {
                textBox_file_path.Text = pFileDlg.FileName;
            }
        }

        private void button_TCP_Click(object sender, EventArgs e)
        {
            if(textBox_file_path.Text == "" || textBox_server_IP.Text == "")
            {
                return;
            }

            TCP tcp = new TCP();

            tcp.TCP_RUN(textBox_server_IP.Text, textBox_file_path.Text);
        }
    }
}
