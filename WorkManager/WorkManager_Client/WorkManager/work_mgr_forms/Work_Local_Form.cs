using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace WorkManager
{
    public partial class Work_Local_Form : Form
    {
        private Local_WorkMgr m_local_mgr;

        public Work_Local_Form()
        {
            InitializeComponent();

            /*instancing manager class*/
            this.m_local_mgr = new Local_WorkMgr();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            listViewMain.FullRowSelect = true;

            SetComboBox();
            SetListViewData();
        }

        private void listViewMain_columnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            e.Cancel = true;
            e.NewWidth = listViewMain.Columns[e.ColumnIndex].Width;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Add_Item_Local_Form addForm = new Add_Item_Local_Form();

            addForm.ChildAddFormEvent += AddEventMethod;

            addForm.ShowDialog();

            SetLivstViewDataWithFilter();
        }

        public void AddEventMethod(LocalWorkNode node)
        {
            List<LocalWorkNode> workList = m_local_mgr.GetWorkNodeList();

            m_local_mgr.AddNodeToList(node);

            RefreshViewList();
        }

        private void RefreshViewList()
        {
            listViewMain.Items.Clear();
            SetListViewData();
            SetComboBox();
            m_local_mgr.WriteRecord();
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            SetLivstViewDataWithFilter();
        }

        private void SetListViewData()
        {
            List<LocalWorkNode> workList = m_local_mgr.GetWorkNodeList();

            foreach (LocalWorkNode node in workList)
            {
                ListViewItem lvi;
                lvi = listViewMain.Items.Add(node.m_strDate);
                lvi.SubItems.Add(node.GetDayOfWeek());
                lvi.SubItems.Add(node.m_strSubject);
                lvi.SubItems.Add(node.m_nSerialNum.ToString());
            }
        }

        private void SetLivstViewDataWithFilter()
        {
            string str_year;
            string str_month; 
            string str_day;

            if(comboYear.SelectedItem != null)
            {
                str_year = comboYear.SelectedItem.ToString();
            }
            else
            {
                str_year = new string("");
            }

            if (comboMonth.SelectedItem != null)
            {
                str_month = comboMonth.SelectedItem.ToString();
            }
            else
            {
                str_month = new string("");
            }

            if (comboDay.SelectedItem != null)
            {
                str_day = comboDay.SelectedItem.ToString();
            }
            else
            {
                str_day = new string("");
            }

            List<LocalWorkNode> workList = m_local_mgr.GetWorkNodeList();
            listViewMain.Items.Clear();

            foreach (LocalWorkNode node in workList)
            {
                DateTime dt;
                dt = DateTime.ParseExact(node.m_strDate, "yyyy-MM-dd", null);

                if((str_year == dt.Year.ToString() || String.IsNullOrEmpty(str_year) == true) 
                    && (str_month == dt.Month.ToString() || String.IsNullOrEmpty(str_month) == true)
                    && (str_day == dt.Day.ToString() || String.IsNullOrEmpty(str_day)))
                {
                    ListViewItem lvi;
                    lvi = listViewMain.Items.Add(node.m_strDate);
                    lvi.SubItems.Add(node.GetDayOfWeek());
                    lvi.SubItems.Add(node.m_strSubject);
                    lvi.SubItems.Add(node.m_nSerialNum.ToString());
                }
            }
        }

        private void SetComboBox()
        {
            List<LocalWorkNode> list = m_local_mgr.GetWorkNodeList();

            List<string> year = new List<string>();
            List<string> month = new List<string>();
            List<string> day = new List<string>();

            foreach (LocalWorkNode node in list)
            {
                DateTime dt;
                dt = DateTime.ParseExact(node.m_strDate, "yyyy-MM-dd", null);

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

        private void button_read_details_Click(object sender, EventArgs e)
        {
            int selectedIndex;

            if (listViewMain.SelectedItems.Count > 0)
            {
                selectedIndex = listViewMain.Items.IndexOf(listViewMain.SelectedItems[0]);
            
                List<LocalWorkNode> workList = m_local_mgr.GetWorkNodeList();
                LocalWorkNode node = workList[selectedIndex];

                Check_Item_Local_Form check_local_form = new Check_Item_Local_Form();
                check_local_form.checkingNode = node;

                check_local_form.ShowDialog();
            }
        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            int selectedIndex;

            if (listViewMain.SelectedItems.Count > 0)
            {
                selectedIndex = listViewMain.Items.IndexOf(listViewMain.SelectedItems[0]);

                List<LocalWorkNode> workList = m_local_mgr.GetWorkNodeList();
                LocalWorkNode node = workList[selectedIndex];

                m_local_mgr.DeleteNodeInList(node);

                RefreshViewList();
            }
        }

        private void listViewMain_MouseClick(object sender, MouseEventArgs e)
        { 
            if(listViewMain.SelectedIndices.Count > 0)
            {
                listView_files.Items.Clear();

                int selectedIdx = listViewMain.SelectedItems[0].Index;

                List<LocalWorkNode> fileList = m_local_mgr.GetWorkNodeList();
                LocalWorkNode node = fileList[selectedIdx];

                foreach (string fileName in node.m_files)
                {
                    ListViewItem lvi;
                    lvi = listView_files.Items.Add(Path.GetFileName(fileName));
                }
            }
        }
    }
}
