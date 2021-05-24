using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace WorkManager
{
    public class DB_mgr : IDB_mgr
    {
        protected MySqlConnection connect;
        protected DB_mgr()
        {

            string myConnection = string.Format("Server='{0}';Port={1};Database=work_mgr;Uid=root;Pwd=1234", Globals.m_strDB_IP, Globals.m_nDB_port);
            connect = new MySqlConnection(myConnection);    
        }

        virtual public void Connect()
        {
            try
            {
                connect.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("DB서버의 ServerIP 또는 Port정보가 틀립니다.");
                MessageBox.Show(ex.Message);

                /*kill all processes, end of application*/
                System.Diagnostics.Process[] mProcess = System.Diagnostics.Process.GetProcessesByName(Application.ProductName);
                foreach (System.Diagnostics.Process p in mProcess)
                {
                    p.Kill();
                }  
            }
        }

        virtual public void Disconnect()
        {
            connect.Close();
        }
    }

    public class DBWorkNode
    {
        public int m_nWork_no { get; set; }
        public string m_strUser_id { get; set; }
        public DateTime m_date { get; set; }
        public string m_strTitle { get; set; }//idx-3
        public string m_strDetails { get; set; }
    }
}
