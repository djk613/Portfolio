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
        private DataGridView m_grid_view { get; set; }
        private string str_user_id { get; set; }

        public DB_workMgr(DataGridView _gridView, string _user_id)
        {
            m_grid_view = _gridView;
            str_user_id = _user_id;
        }

       
        public bool SearchListByDate(int n_year = 0, int n_month = 0, int n_day = 0)
        { 
            try
            {
                string str_query;
                MySqlCommand command;
                MySqlDataAdapter dataAdapter;
                DataTable dataSet;
                BindingSource bindSource;

                if (n_year == 0)
                {
                    str_query = string.Format("SELECT * FROM work_mgr.work_tb WHERE user_id ='{0}'", str_user_id);

                }
                else if (n_month == 0)
                {
                    string startDate = string.Format("{0}-{1}-{2}", n_year, "01", "01");
                    string endDate = string.Format("{0}-{1}-{2}", n_year, "12", "31");

                    str_query = string.Format("SELECT * FROM work_mgr.work_tb WHERE user_id ='{0}' AND date BETWEEN '{1}' AND '{2}'", str_user_id, startDate, endDate);
                }
                else if (n_day == 0)
                {
                    string startDate = string.Format("{0}-{1}-{2}", n_year, n_month.ToString("D2"), "01");
                    string endDate = string.Format("{0}-{1}-{2}", n_year, n_month.ToString("D2"), "31");

                    str_query = string.Format("SELECT * FROM work_mgr.work_tb WHERE user_id ='{0}' AND date BETWEEN '{1}' AND '{2}'", str_user_id, startDate, endDate);
                }
                else
                {
                    string startDate = string.Format("{0}-{1}-{2}", n_year, n_month.ToString("D2"), n_day.ToString("D2"));
                    string endDate = string.Format("{0}-{1}-{2}", n_year, n_month.ToString("D2"), n_day.ToString("D2"));

                    str_query = string.Format("SELECT * FROM work_mgr.work_tb WHERE user_id ='{0}' AND date BETWEEN '{1}' AND '{2}'", str_user_id, startDate, endDate);
                }

                command = new MySqlCommand(str_query, connect);

                dataAdapter = new MySqlDataAdapter();
                dataAdapter.SelectCommand = command;

                dataSet = new DataTable();
                dataAdapter.Fill(dataSet);

                bindSource = new BindingSource();
                bindSource.DataSource = dataSet;
                m_grid_view.DataSource = bindSource;

                m_grid_view.Columns["user_id"].Visible = false;
                m_grid_view.Columns["work_no"].Visible = false;

                dataAdapter.Update(dataSet);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return true;
        }

        public bool SearchWorkByWorkNo(int n_work_no, ref DBWorkNode workNode)
        {
            try
            {
                string str_query;
                MySqlCommand command;
                MySqlDataReader reader;

                str_query = string.Format("SELECT * FROM work_mgr.work_tb WHERE work_no={0}", n_work_no);
                command = new MySqlCommand(str_query, connect);
                reader = command.ExecuteReader();

                while(reader.Read())
                {
                    workNode.m_nWork_no = reader.GetInt32(0);
                    workNode.m_strUser_id = reader.GetString(1);
                    workNode.m_date = reader.GetDateTime(2);
                    workNode.m_strTitle = reader.GetString(3);
                    workNode.m_strDetails = reader.GetString(4);
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return false;
        }

        public bool DeleteList(int n_work_no)
        {
            try
            {
                string str_query;
                MySqlCommand command;
                MySqlDataReader reader;

                str_query = string.Format("DELETE FROM work_mgr.work_tb WHERE work_no ={0}", n_work_no);
                command = new MySqlCommand(str_query, connect);
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

        public bool InsertList(string str_user_id, string str_work_title, string str_work_detail)
        {
            try
            {
                string str_query;
                MySqlCommand command;
                MySqlDataReader reader;

                string str_date = DateTime.Now.ToString("yyyy-MM-dd");

                str_query = string.Format("INSERT INTO work_mgr.work_tb(user_id,work_title,work_detail,date) VALUES ('{0}','{1}','{2}','{3}')", str_user_id, str_work_title, str_work_detail, str_date);
                command = new MySqlCommand(str_query, connect);
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

        public bool UpdateList(int n_work_no, string str_work_title, string str_work_detail)
        {
            try
            {
                string str_query;
                MySqlCommand command;
                MySqlDataReader reader;

                str_query = string.Format("UPDATE work_mgr.work_tb SET work_title = '{0}' AND work_detail = '{1}' WHERE work_no = {2}", str_work_title, str_work_detail, n_work_no);
                command = new MySqlCommand(str_query, connect);
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
            int n_work_no;
            string str_query;
            MySqlCommand command;
            MySqlDataReader reader;

            n_work_no = 0;

            try
            {
                str_query = string.Format("SELECT LAST_INSERT_ID()");
                command = new MySqlCommand(str_query, connect);
                reader = command.ExecuteReader();

                while(reader.Read())
                {
                    n_work_no = reader.GetInt32(0);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return n_work_no;
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
