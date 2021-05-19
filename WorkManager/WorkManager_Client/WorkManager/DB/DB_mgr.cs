using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

namespace WorkManager
{
    public class DB_mgr : IDB_mgr
    {
        protected MySqlConnection connect;
        protected DB_mgr()
        {
            string myConnection = "Server=localhost;Port=3306;Database=work_mgr;Uid=root;Pwd=1234";
            connect = new MySqlConnection(myConnection);
        }

        virtual public void Connect()
        {
            connect.Open();
        }

        virtual public void Disconnect()
        {
            connect.Close();
        }
    }
}
