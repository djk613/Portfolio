using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Data;
using MySql.Data.MySqlClient;

namespace WorkManager
{
    /*this DB class has been designed for databinding with one grid view*/
    public class DB_workMgr : DB_mgr
    {
        private DataGridView gridView { get; set; }
        private string user_id { get; set; }

        public DB_workMgr(DataGridView _gridView, string _user_id)
        {
            gridView = _gridView;
            user_id = _user_id;
        }

       
        public bool SearchList(int year = 0, int month = 0, int day = 0)
        { 
            try
            {
                string query;
                MySqlCommand command;
                MySqlDataAdapter dataAdapter;
                DataTable dataSet;
                BindingSource bindSource;

                if (year == 0)
                {
                    query = string.Format("SELECT * FROM work_mgr.work_tb WHERE user_id ='{0}'", user_id);

                }
                else if (month == 0)
                {
                    string startDate = string.Format("{0}-{1}-{2}", year, "01", "01");
                    string endDate = string.Format("{0}-{1}-{2}", year, "12", "31");

                    query = string.Format("SELECT * FROM work_mgr.work_tb WHERE user_id ='{0}' AND date BETWEEN '{1}' AND '{2}'", user_id, startDate, endDate);
                }
                else if (day == 0)
                {
                    string startDate = string.Format("{0}-{1}-{2}", year, month.ToString("D2"), "01");
                    string endDate = string.Format("{0}-{1}-{2}", year, month.ToString("D2"), "31");

                    query = string.Format("SELECT * FROM work_mgr.work_tb WHERE user_id ='{0}' AND date BETWEEN '{1}' AND '{2}'", user_id, startDate, endDate);
                }
                else
                {
                    string startDate = string.Format("{0}-{1}-{2}", year, month.ToString("D2"), day.ToString("D2"));
                    string endDate = string.Format("{0}-{1}-{2}", year, month.ToString("D2"), day.ToString("D2"));

                    query = string.Format("SELECT * FROM work_mgr.work_tb WHERE user_id ='{0}' AND date BETWEEN '{1}' AND '{2}'", user_id, startDate, endDate);
                }

                command = new MySqlCommand(query, connect);

                dataAdapter = new MySqlDataAdapter();
                dataAdapter.SelectCommand = command;

                dataSet = new DataTable();
                dataAdapter.Fill(dataSet);

                bindSource = new BindingSource();
                bindSource.DataSource = dataSet;
                gridView.DataSource = bindSource;

                gridView.Columns["user_id"].Visible = false;
                gridView.Columns["work_no"].Visible = false;

                dataAdapter.Update(dataSet);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return true;
        }

        public bool DeleteList(int work_no)
        {
            try
            {
                string query;
                MySqlCommand command;
                MySqlDataReader reader;

                query = string.Format("DELETE FROM work_mgr.work_tb WHERE work_no ={0}", work_no);
                command = new MySqlCommand(query, connect);
                reader = command.ExecuteReader();
                
                while(reader.Read())
                {
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return false;
        }

        public bool InsertList(string user_id, string work_title, string work_detail)
        {
            try
            {
                string query;
                MySqlCommand command;
                MySqlDataReader reader;

                string date = DateTime.Now.ToString("yyyy-MM-dd");

                query = string.Format("INSERT INTO work_mgr.work_tb(user_id,work_title,work_detail,date) VALUES ('{0}','{1}','{2}','{3}')", user_id, work_title, work_detail,date);
                command = new MySqlCommand(query, connect);
                reader = command.ExecuteReader();

                while(reader.Read())
                {
                }

                reader.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return true;
        }

        public bool UpdateList(int work_no, string work_title, string work_detail)
        {
            try
            {
                string query;
                MySqlCommand command;
                MySqlDataReader reader;

                query = string.Format("UPDATE work_mgr.work_tb SET work_title = '{0}' AND work_detail = '{1}' WHERE work_no = {2}", work_title, work_detail, work_no);
                command = new MySqlCommand(query, connect);
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return true;
        }

        public int GetLastWorkNo()
        {
            int work_no;
            string query;
            MySqlCommand command;
            MySqlDataReader reader;

            work_no = 0;

            try
            {
                query = string.Format("SELECT LAST_INSERT_ID()");
                command = new MySqlCommand(query, connect);
                reader = command.ExecuteReader();

                while(reader.Read())
                {
                    work_no = reader.GetInt32(0);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return work_no;
        }

        public override void Connect()
        {
            base.Connect();
        }

        public override void Disconnect()
        {
            base.Disconnect();
        }
    }
}
