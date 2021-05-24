using System;
using System.Collections.Generic;
using System.Text;


namespace WorkManager
{
    public class LocalWorkNode
    {
        public ulong m_nSerialNum { get; private set; }
        public string m_strDate { get; private set; }
        public string m_strSubject { get; private set; }
        public string m_strDetailed { get; private set; }
        public List<string> m_files;

        public LocalWorkNode(ulong serialNum, string date, string subject, string detailed, List<string> files)
        {
            this.m_nSerialNum = serialNum;
            this.m_strDate = date;
            this.m_strSubject = subject;
            this.m_strDetailed = detailed;
            this.m_files = new List<string>();

            foreach(var filePath in files)
            {
                this.m_files.Add(filePath);
            }
        }

        public LocalWorkNode(LocalWorkNode node)
        {
            this.m_nSerialNum = node.m_nSerialNum;
            this.m_strDate = node.m_strDate;
            this.m_strSubject = node.m_strSubject;
            this.m_strDetailed = node.m_strDetailed;
            this.m_files = node.m_files;
        }

        public override string ToString()
        {
            return m_nSerialNum.ToString() + '|' + m_strDate + '|' + m_strSubject + '|' + m_strDetailed + '|' + GetFilesString();
        }

        public string GetFilesString()
        {
            string result = new string("");

            foreach(var filePath in m_files)
            {
                result += filePath + ",";
            }

            return result;
        }

        public override bool Equals(object obj)
        {
            LocalWorkNode other = obj as LocalWorkNode;

            return this.m_nSerialNum == other.m_nSerialNum && this.m_strSubject == other.m_strSubject && this.m_strDate == other.m_strDate;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public string GetDayOfWeek()
        {
            DateTime dt;
            dt = Convert.ToDateTime(this.m_strDate);

            string day;

            switch (dt.DayOfWeek)
            {
                case DayOfWeek.Monday:
                    day = new string("월요일");
                    break;
                case DayOfWeek.Tuesday:
                    day = new string("화요일");
                    break;
                case DayOfWeek.Wednesday:
                    day = new string("수요일");
                    break;
                case DayOfWeek.Thursday:
                    day = new string("목요일");
                    break;
                case DayOfWeek.Friday:
                    day = new string("금요일");
                    break;
                case DayOfWeek.Saturday:
                    day = new string("토요일");
                    break;
                case DayOfWeek.Sunday:
                    day = new string("일요일");
                    break;
                default:
                    day = new string("");
                    break;
            }
            return day;
        }

        

    }
}
