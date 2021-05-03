using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace WorkManager
{
    public class WorkMgr
    {
        public WorkMgr()
        {
            workNodeList = new List<WorkNode>();

            string date = DateTime.Now.ToString("yyyy-MM-dd");
            today = date.Split('-');

            /*temporary path.. it will be controlled by user*/
            rootPath = @"C:\Users\user\Desktop\WorkManager";

            DirectoryInfo di = new DirectoryInfo(rootPath);

            if(di.Exists == false)
            {
                di.Create();
            }

            string fileName = new string("record.txt");
            string fileFullName = new string(rootPath + '\\' + fileName);

            if (File.Exists(fileFullName) == false)
            {
                File.Create(fileFullName).Close();
            }

            ReadRecord();
        }

        public void ReadRecord()
        {
            string[] recordInText = File.ReadAllLines(GetTempPath());

            foreach (string record in recordInText)
            {
                string[] data = record.Split('|');

                /*if the data is not correctly recorded, it won't be used*/
                if (data.Length != 5)
                {
                    continue;
                }

                WorkNode node = new WorkNode(ulong.Parse(data[0]), data[1], data[2], data[3], data[4]);

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
                foreach(WorkNode node in workNodeList)
                {
                    sw.WriteLine(node.ToString());
                }
            }
        }

        public List<WorkNode> GetWorkNodeList()
        {
            return workNodeList;
        }

        public string GetPathRoot()
        {
            return rootPath;
        }

        public string GetPathYear()
        {
            return GetPathRoot() + '\\' + today[0];
        }

        public string GetPathMonth()
        {
            return GetPathYear() + '\\' + today[1];
        }

        public string GetPathDay()
        {
            return GetPathMonth() + '\\' + today[2];
        }

        public string GetTempPath()
        {
            return GetPathRoot() + '\\' + "record.txt";
        }

        private List<WorkNode> workNodeList;
        public string rootPath { private get; set; }
        private string[] today;

    }
}
