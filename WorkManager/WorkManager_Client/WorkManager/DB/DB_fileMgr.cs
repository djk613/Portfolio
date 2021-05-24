using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Data;
using MySql.Data.MySqlClient;

namespace WorkManager
{
    public class DB_fileMgr : DB_mgr
    {
        private DataGridView m_grid_view;

        public DB_fileMgr(DataGridView _gridView = null)
        {
            m_grid_view = _gridView;
        }

        public bool SearchFiles(int n_work_no)
        {
            if(m_grid_view == null)
            {
                return false;
            }

            try
            {
                string str_query;
                MySqlCommand command;
                MySqlDataAdapter dataAdapter;
                DataTable dataSet;
                BindingSource bindSource;

                str_query = string.Format("SELECT * FROM work_mgr.file_tb WHERE work_no = {0}", n_work_no);
                command = new MySqlCommand(str_query, connect);

                dataAdapter = new MySqlDataAdapter();
                dataAdapter.SelectCommand = command;

                dataSet = new DataTable();
                dataAdapter.Fill(dataSet);

                bindSource = new BindingSource();
                bindSource.DataSource = dataSet;
                m_grid_view.DataSource = bindSource;

                m_grid_view.Columns["file_no"].Visible = false;
                m_grid_view.Columns["work_no"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return true;
        }

        public List<string> GetFilesLinkedWithWork(int n_work_no)
        {
            List<string> list = new List<string>();
            
            try
            {
                string str_query;
                MySqlCommand command;
                MySqlDataReader reader;

                str_query = string.Format("SELECT * FROM work_mgr.file_tb WHERE work_no = {0}", n_work_no);
                command = new MySqlCommand(str_query, connect);
                reader = command.ExecuteReader();

                while(reader.Read())
                {
                    list.Add(reader.GetValue(2).ToString());
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return list;
        }

        public bool DeleteFiles(int n_work_no)
        {
            List<string> fileNames = new List<string>();
            string str_query;
            MySqlCommand command;
            MySqlDataReader reader;

            try
            {
                str_query = string.Format("SELECT * FROM work_mgr.file_tb WHERE work_no ={0}", n_work_no);
                command = new MySqlCommand(str_query, connect);
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    fileNames.Add(reader.GetValue(2).ToString());
                }

                reader.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            if(fileNames.Count == 0)
            {
                return true;
            }

            try
            {
                str_query = string.Format("DELETE FROM work_mgr.file_tb WHERE (work_no,file_name) IN (");
                
                for(int i = 0; i <fileNames.Count; i++)
                {
                    str_query += string.Format("({0},'{1}')", n_work_no, fileNames[i]);

                    if(i == (fileNames.Count - 1))
                    {
                        str_query += ")";
                    }
                    else
                    {
                        str_query += ",";
                    }
                }

                command = new MySqlCommand(str_query, connect);
                reader = command.ExecuteReader();

                while (reader.Read())
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

        public bool DeleteFile(int n_work_no, string str_file_name)
        {
            try
            {
                string str_query;
                MySqlCommand command;
                MySqlDataReader reader;

                str_query = string.Format("DELETE FROM work_mgr.file_tb WHERE work_no ={0} AND file_name='{1}'", n_work_no, str_file_name);
                command = new MySqlCommand(str_query, connect);
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return true;
        }

        public bool InsertFiles(List<Tuple<int, string>> files)
        {
            if(files.Count == 0)
            {
                return false;
            }

            try
            {
                string str_query;
                MySqlCommand command;
                MySqlDataReader reader;

                str_query = string.Format("INSERT INTO work_mgr.file_tb(work_no,file_name) VALUES ");

                for(int i = 0; i < files.Count; i++)
                {
                    string str_temp = string.Format("({0}, '{1}')", files[i].Item1, files[i].Item2);
                    str_query += str_temp;

                    if (i == (files.Count - 1))
                    {
                        str_query += "";
                    }
                    else
                    {
                        str_query += ",";
                    }
                }

                command = new MySqlCommand(str_query, connect);
                reader = command.ExecuteReader();

                while(reader.Read())
                {
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return true;
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
