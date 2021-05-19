using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TCP_SOCKET_NETWORK;

namespace TCP_SERVER
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button_server_run_Click(object sender, EventArgs e)
        {
            Net_Server server;

            if (checkBox_test.Checked == true)
            {
                server = new Net_Server(Net_Server.test_server_ip, Convert.ToInt32(textBox_port.Text));
            }
            else
            {
                server = new Net_Server(textBox_IP.Text, Convert.ToInt32(textBox_port.Text));
            }

           
            server.Run();
        }
    }
}
