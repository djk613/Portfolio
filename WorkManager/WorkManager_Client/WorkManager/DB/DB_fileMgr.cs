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
        private DataGridView gridView;

        public DB_fileMgr(DataGridView _gridView = null)
        {
            gridView = _gridView;
        }

        public bool SearchFiles(int work_no)
        {
            if(gridView == null)
            {
                return false;
            }

            try
            {
                string query;
                MySqlCommand command;
                MySqlDataAdapter dataAdapter;
                DataTable dataSet;
                BindingSource bindSource;

                query = string.Format("SELECT * FROM work_mgr.file_tb WHERE work_no = {0}", work_no);
                command = new MySqlCommand(query, connect);

                dataAdapter = new MySqlDataAdapter();
                dataAdapter.SelectCommand = command;

                dataSet = new DataTable();
                dataAdapter.Fill(dataSet);

                bindSource = new BindingSource();
                bindSource.DataSource = dataSet;
                gridView.DataSource = bindSource;

                gridView.Columns["file_no"].Visible = false;
                gridView.Columns["work_no"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return true;
        }

        public List<string> GetFilesLinkedWithWork(int work_no)
        {
            List<string> list = new List<string>();
            
            try
            {
                string query;
                MySqlCommand command;
                MySqlDataReader reader;

                query = string.Format("SELECT * FROM work_mgr.file_tb WHERE work_no = {0}", work_no);
                command = new MySqlCommand(query, connect);
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

        public bool DeleteFiles(int work_no)
        {
            List<string> fileNames = new List<string>();
            string query;
            MySqlCommand command;
            MySqlDataReader reader;

            try
            {
                query = string.Format("SELECT * FROM work_mgr.file_tb WHERE work_no ={0}", work_no);
                command = new MySqlCommand(query, connect);
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
                query = string.Format("DELETE FROM work_mgr.file_tb WHERE (work_no,file_name) IN (");
                
                for(int i = 0; i <fileNames.Count; i++)
                {
                    query += string.Format("({0},'{1}')", work_no, fileNames[i]);

                    if(i == (fileNames.Count - 1))
                    {
                        query += ")";
                    }
                    else
                    {
                        query += ",";
                    }
                }

                command = new MySqlCommand(query, connect);
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

        public bool DeleteFile(int work_no, string fileName)
        {
            try
            {
                string query;
                MySqlCommand command;
                MySqlDataReader reader;

                query = string.Format("DELETE FROM work_mgr.file_tb WHERE work_no ={0} AND file_name='{1}'", work_no, fileName);
                command = new MySqlCommand(query, connect);
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
                string query;
                MySqlCommand command;
                MySqlDataReader reader;

                query = string.Format("INSERT INTO work_mgr.file_tb(work_no,file_name) VALUES ");

                for(int i = 0; i < files.Count; i++)
                {
                    string temp = string.Format("({0}, '{1}')", files[i].Item1, files[i].Item2);
                    query += temp;

                    if (i == (files.Count - 1))
                    {
                        query += "";
                    }
                    else
                    {
                        query += ",";
                    }
                }

                command = new MySqlCommand(query, connect);
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
