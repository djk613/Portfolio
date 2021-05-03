using System;
using System.Collections.Generic;
using System.Text;


namespace WorkManager
{
    public class WorkNode
    {
        public WorkNode(ulong serialNum, string date, string subject, string detailed, string linkedFile = "")
        {
            this.serialNum = serialNum;
            this.date = date;
            this.subject = subject;
            this.detailed = detailed;
            this.linkedFile = linkedFile;
        }

        public WorkNode(WorkNode node)
        {
            this.serialNum = node.serialNum;
            this.date = node.date;
            this.subject = node.subject;
            this.detailed = node.detailed;
            this.linkedFile = node.linkedFile;
        }

        public override string ToString()
        {
            return serialNum.ToString() + '|' + date + '|' + subject + '|' + detailed + '|' + linkedFile;
        }

        public override bool Equals(object obj)
        {
            WorkNode other = obj as WorkNode;

            return this.serialNum == other.serialNum;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public string GetDayOfWeek()
        {
            DateTime dt;
            dt = Convert.ToDateTime(this.date);

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

        public ulong serialNum { get; private set; }
        public string date { get; private set; }
        public string subject { get; private set; }
        public string detailed { get; private set; }
        public string linkedFile { get; private set; }

    }
}
