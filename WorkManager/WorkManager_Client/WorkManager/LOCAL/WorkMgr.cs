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
        public string rootPath { private get; set; }
        private string[] today;

        public Local_WorkMgr()
        {
            workNodeList = new List<LocalWorkNode>();

            string date = DateTime.Now.ToString("yyyy-MM-dd");
            today = date.Split('-');

            /*temporary path.. it will be controlled by user*/
            //rootPath = @"C:\Users\user\Desktop\WorkManager";
            rootPath = @"..\";

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

                List<string> list_filesPath =  data[4].Split(',').ToList();

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

        private void RecordFiles(ref LocalWorkNode node)
        {
            string[] day = node.date.Split('-');

            /*file move*/
            string newPath = new string(@"..\");
            newPath = newPath + day[0];
            newPath = newPath + '\\' + day[1];
            newPath = newPath + '\\' + day[2];

            DirectoryInfo di = new DirectoryInfo(newPath);

            if (di.Exists == false)
            {
                di.Create();
            }

            List<string> filesPath = node.files;
            List<string> newFilesPath = new List<string>();

            foreach (var path in filesPath)
            {
                string newFilePath = newPath + '\\' + Path.GetFileName(path);
                newFilesPath.Add(newFilePath);

                if (path.Length != 0)
                {
                    System.IO.File.Move(path, newFilePath);
                }
            }
          
            node.files = newFilesPath;
        }
    }
}
