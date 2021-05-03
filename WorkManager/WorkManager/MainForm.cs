using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WorkManager
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            /*instancing manager class*/
            this.mgr = new WorkMgr();
        }

        private void listViewMain_columnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            e.Cancel = true;
            e.NewWidth = listViewMain.Columns[e.ColumnIndex].Width;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddItemForm addForm = new AddItemForm();

            addForm.ChildAddFormEvent += AddEventMethod;

            addForm.ShowDialog();
        }

        public void AddEventMethod(WorkNode node)
        {
            List<WorkNode> workList = mgr.GetWorkNodeList();

            workList.Add(node);

            listViewMain.Items.Clear();
            SetListViewData();
            SetComboBox();
            mgr.WriteRecord();
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            CheckItemForm checkForm = new CheckItemForm();

            if(listViewMain.SelectedItems.Count == 1)
            {
                int selectRow = listViewMain.SelectedItems[0].Index;
                string serialNum = listViewMain.Items[selectRow].SubItems[3].Text;

                List<WorkNode> list = mgr.GetWorkNodeList();
                WorkNode node = list.Find(node => node.serialNum == Convert.ToUInt64(serialNum));

                WorkNode newNode = new WorkNode(node);

                checkForm.checkingNode = node;

                checkForm.ChildEraseFormEvent += EraseEventMethod;

                checkForm.SetDetailData();

                checkForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("목록은 하나만 선택");
            }
            
        }

        public void EraseEventMethod(WorkNode checkingNode)
        {
            List<WorkNode> list = mgr.GetWorkNodeList();
            WorkNode node = list.Find(listNode => listNode.serialNum == checkingNode.serialNum);
            list.Remove(node);

            listViewMain.Items.Clear();
            SetListViewData();
            SetComboBox();
            mgr.WriteRecord();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            SetComboBox();
            SetListViewData();
        }

        private void SetListViewData()
        {
            List<WorkNode> workList = mgr.GetWorkNodeList();

            foreach (WorkNode node in workList)
            {
                ListViewItem lvi;
                lvi = listViewMain.Items.Add(node.date);
                lvi.SubItems.Add(node.GetDayOfWeek());
                lvi.SubItems.Add(node.subject);
                lvi.SubItems.Add(node.serialNum.ToString());
            }
        }

        private void SetLivstViewDataWithFilter()
        {
            string year;
            string month; 
            string day;

            if(comboYear.SelectedItem != null)
            {
                year = comboYear.SelectedItem.ToString();
            }
            else
            {
                year = new string("");
            }

            if (comboMonth.SelectedItem != null)
            {
                month = comboMonth.SelectedItem.ToString();
            }
            else
            {
                month = new string("");
            }

            if (comboDay.SelectedItem != null)
            {
                day = comboDay.SelectedItem.ToString();
            }
            else
            {
                day = new string("");
            }

            List<WorkNode> workList = mgr.GetWorkNodeList();
            listViewMain.Items.Clear();

            foreach (WorkNode node in workList)
            {
                DateTime dt;
                dt = DateTime.ParseExact(node.date, "yyyy-MM-dd", null);

                if((year == dt.Year.ToString() || String.IsNullOrEmpty(year) == true) 
                    && (month == dt.Month.ToString() || String.IsNullOrEmpty(month) == true)
                    && (day == dt.Day.ToString() || String.IsNullOrEmpty(day)))
                {
                    ListViewItem lvi;
                    lvi = listViewMain.Items.Add(node.date);
                    lvi.SubItems.Add(node.GetDayOfWeek());
                    lvi.SubItems.Add(node.subject);
                    lvi.SubItems.Add(node.serialNum.ToString());
                }
            }
        }

        private void SetComboBox()
        {
            List<WorkNode> list = mgr.GetWorkNodeList();

            List<string> year = new List<string>();
            List<string> month = new List<string>();
            List<string> day = new List<string>();

            foreach (WorkNode node in list)
            {
                DateTime dt;
                dt = DateTime.ParseExact(node.date, "yyyy-MM-dd", null);

                year.Add(dt.Year.ToString());
                month.Add(dt.Month.ToString());
                day.Add(dt.Day.ToString());
            }

            year = year.Distinct().ToList();
            month = month.Distinct().ToList();
            day = day.Distinct().ToList();

            comboYear.Items.AddRange(year.ToArray());
            comboMonth.Items.AddRange(month.ToArray());
            comboDay.Items.AddRange(day.ToArray());
        }

        private WorkMgr mgr;

        private void comboYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetLivstViewDataWithFilter();
        }

        private void comboMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetLivstViewDataWithFilter();
        }

        private void comboDay_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetLivstViewDataWithFilter();
        }
    }
}
