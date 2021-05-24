using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace WorkManager
{
    public class Local_WorkMgr
    {
        private List<LocalWorkNode> workNodeList;
        public string m_root_path { private get; set; }
        private string[] m_today;

        public Local_WorkMgr()
        {
            workNodeList = new List<LocalWorkNode>();

            string str_date = DateTime.Now.ToString("yyyy-MM-dd");
            m_today = str_date.Split('-');

            /*temporary path.. it will be controlled by user*/
            //rootPath = @"C:\Users\user\Desktop\WorkManager";
            m_root_path = @"..\";

            DirectoryInfo di = new DirectoryInfo(m_root_path);

            if(di.Exists == false)
            {
                di.Create();
            }

            string str_file_name = new string("record.txt");
            string str_file_full_name = new string(m_root_path + '\\' + str_file_name);

            if (File.Exists(str_file_full_name) == false)
            {
                File.Create(str_file_full_name).Close();
            }

            ReadRecord();
        }

        public void ReadRecord()
        {
            string[] str_record_in_text_array = File.ReadAllLines(GetTempPath());

            foreach (string record in str_record_in_text_array)
            {
                string[] data = record.Split('|');

                /*if the data is not correctly recorded, it won't be used*/
                if (data.Length != 5)
                {
                    continue;
                }

                List<string> list_filesPath = data[4].Split(',').ToList();

                LocalWorkNode node = new LocalWorkNode(ulong.Parse(data[0]), data[1], data[2], data[3], list_filesPath);

                workNodeList.Add(node);
            }
        }

        public void WriteRecord()
        {
            /*if folder is not existed? make new one*/
            DirectoryInfo di = new DirectoryInfo(GetPathRoot());

            if(di.Exists == false)
            {
                di.Create();
            }

            /*Write date on a txt file*/
            using (StreamWriter sw = new StreamWriter(GetTempPath()))
            {
                foreach(LocalWorkNode node in workNodeList)
                {
                    sw.WriteLine(node.ToString());
                }
            }
        }

        public List<LocalWorkNode> GetWorkNodeList()
        {
            return workNodeList;
        }

        public void AddNodeToList(LocalWorkNode node)
        {
            RecordFiles(ref node);
            workNodeList.Add(node);
        }

        public void DeleteNodeInList(LocalWorkNode node)
        {
            workNodeList.Remove(node);
        }

        public string GetPathRoot()
        {
            return m_root_path;
        }

        public string GetPathYear()
        {
            return GetPathRoot() + '\\' + m_today[0];
        }

        public string GetPathMonth()
        {
            return GetPathYear() + '\\' + m_today[1];
        }

        public string GetPathDay()
        {
            return GetPathMonth() + '\\' + m_today[2];
        }

        public string GetTempPath()
        {
            return GetPathRoot() + '\\' + "record.txt";
        }

        private void RecordFiles(ref LocalWorkNode node)
        {
            string[] str_day = node.m_strDate.Split('-');

            /*file move*/
            string str_new_path = new string(@"..\");
            str_new_path = str_new_path + str_day[0];
            str_new_path = str_new_path + '\\' + str_day[1];
            str_new_path = str_new_path + '\\' + str_day[2];

            DirectoryInfo di = new DirectoryInfo(str_new_path);

            if (di.Exists == false)
            {
                di.Create();
            }

            List<string> files_path_list = node.m_files;
            List<string> new_files_path_list = new List<string>();

            foreach (var path in files_path_list)
            {
                string str_new_file_path = str_new_path + '\\' + Path.GetFileName(path);
                new_files_path_list.Add(str_new_file_path);

                if (path.Length != 0)
                {
                    System.IO.File.Move(path, str_new_file_path);
                }
            }
          
            node.m_files = new_files_path_list;
        }
    }
}
