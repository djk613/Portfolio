using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace WorkManager
{
    public class DB_userMgr : DB_mgr
    {
        public DB_userMgr()
        {
        }

        public bool CreateID(string str_user_id, string str_password_hash)
        {
            string str_query;
            MySqlCommand command;
            MySqlDataReader reader;

            /*check same id before creating new id*/
            try
            {
                str_query = string.Format("SELECT * FROM work_mgr.user_tb WHERE user_id='{0}'", str_user_id);

                command = new MySqlCommand(str_query, connect);

                reader = command.ExecuteReader();

                int count = 0;

                while (reader.Read())
                {
                    count += 1;
                }

                if (count > 0)
                {
                    return false;
                }

                reader.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            /*creating new id*/
            try
            {
                str_query = string.Format("INSERT INTO work_mgr.user_tb (user_id,password) VALUE ('{0}','{1}' )", str_user_id, str_password_hash);

                command = new MySqlCommand(str_query, connect);
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                }

                reader.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return true;
        }

        public bool LoginID(string str_user_id, string str_password_hash)
        {
            string str_query = string.Format("SELECT * FROM work_mgr.user_tb WHERE user_id='{0}' AND password='{1}'", str_user_id, str_password_hash);
            MySqlCommand command = new MySqlCommand(str_query, connect);
            MySqlDataReader reader;

            reader = command.ExecuteReader();

            int n_count = 0;

            while (reader.Read())
            {
                n_count += 1;
            }

            if (n_count == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ChangePassword(string str_user_id, string str_password_hash, string str_new_password_hash)
        {
            string str_query;
            MySqlCommand command;
            MySqlDataReader reader;

            /*check id and password*/
            try
            {
                str_query = string.Format("SELECT * FROM work_mgr.user_tb WHERE user_id='{0}' AND password='{1}'", str_user_id, str_password_hash);

                command = new MySqlCommand(str_query, connect);

                reader = command.ExecuteReader();

                int n_count = 0;

                while (reader.Read())
                {
                    n_count += 1;
                }

                reader.Close();

                if (n_count != 1)
                {
                    return false;
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            /*delete id*/
            try
            {
                str_query = string.Format("UPDATE work_mgr.user_tb set user_id = '{0}', password = '{1}' where user_id = '{0}'", str_user_id, str_new_password_hash);
                command = new MySqlCommand(str_query, connect);
                reader = command.ExecuteReader();

                while(reader.Read())
                {
                }

                reader.Close();

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return true;
        }

        public bool DeleteID(string str_user_id, string str_password_hash)
        {
            string str_query;
            MySqlCommand command;
            MySqlDataReader reader;

            /*check id and password*/
            try
            {
                str_query = string.Format("SELECT * FROM work_mgr.user_tb WHERE user_id='{0}' AND password={1}", str_user_id, str_password_hash);
                command = new MySqlCommand(str_query, connect);
                reader = command.ExecuteReader();

                int n_count = 0;

                while (reader.Read())
                {
                    n_count += 1;
                }

                if (n_count != 1)
                {
                    MessageBox.Show("아이디가 없거나, 기존의 비밀번호가 일치하지 않습니다.");
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            try
            {
                str_query = string.Format("DELETE FROM work_mgr.user_tb WHERE user_id = '{0}'", str_user_id);
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
