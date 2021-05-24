using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using TCP_SOCKET_NETWORK;
using Protocol;

namespace WorkManager
{
    public partial class Work_DB_Form : Form
    {
        public string str_user_id { get; set; }

        private int m_nSelected_workList_idx { get; set; }
        private int m_nSelected_fileList_idx { get; set; }

        public Work_DB_Form()
        {
            InitializeComponent();
        }

        private void Work_DB_Form_Load(object sender, EventArgs e)
        {
            dataGridView_work.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView_work.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView_work.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;

            dataGridView_file.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView_file.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView_file.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;

            DB_workMgr db_work = new DB_workMgr(dataGridView_work, str_user_id);
            db_work.Connect();

            bool b_search_success = db_work.SearchListByDate();
            db_work.Disconnect();

            SetComboBox();
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            RefreshWorkTableWithComboBox();
        }

        private void SetComboBox()
        {
            comboYear.Items.Clear();
            comboMonth.Items.Clear();
            comboDay.Items.Clear();

            List<string> yearList = new List<string>();
            List<string> monthList = new List<string>();
            List<string> dayList = new List<string>();

            for (int rows = 0; rows < dataGridView_work.Rows.Count - 1; rows++)
            {
                string value = dataGridView_work.Rows[rows].Cells[2].Value.ToString();

                DateTime dt = Convert.ToDateTime(dataGridView_work.Rows[rows].Cells[2].Value);

                yearList.Add(dt.Year.ToString());
                monthList.Add(dt.Month.ToString());
                dayList.Add(dt.Day.ToString());
            }

            yearList = yearList.Distinct().ToList();
            monthList = monthList.Distinct().ToList();
            dayList = dayList.Distinct().ToList();

            comboYear.Items.AddRange(yearList.ToArray());
            comboMonth.Items.AddRange(monthList.ToArray());
            comboDay.Items.AddRange(dayList.ToArray());
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Add_Item_DB_Form item_db_form = new Add_Item_DB_Form();
            item_db_form.m_strUser_id = str_user_id;
            item_db_form.m_dataGridView_workList = dataGridView_work;

            item_db_form.ShowDialog();

            RefreshWorkTable();
        }

        private void dataGridView_work_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            m_nSelected_workList_idx = e.RowIndex;

            if(m_nSelected_workList_idx >= (dataGridView_work.RowCount - 1))
            {
                return;
            }

            if(m_nSelected_workList_idx == -1)
            {
                return;
            }

            DataGridViewRow row = dataGridView_work.Rows[m_nSelected_workList_idx];
            string selected_work_no = row.Cells[0].Value.ToString();

            DB_fileMgr db_file = new DB_fileMgr(dataGridView_file);
            db_file.Connect();

            db_file.SearchFiles(Convert.ToInt32(selected_work_no));
            db_file.Disconnect();
        }

        private void dataGridView_file_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            m_nSelected_fileList_idx = e.RowIndex;
        }

        private void button_delete_file_Click(object sender, EventArgs e)
        {
            if(m_nSelected_fileList_idx >= (dataGridView_file.RowCount - 1))
            {
                return;
            }

            DataGridViewRow row = dataGridView_file.Rows[m_nSelected_fileList_idx];

            string str_selected_work_no = row.Cells[1].Value.ToString();
            string str_selected_file_name = row.Cells[2].Value.ToString();

            DB_fileMgr db_file = new DB_fileMgr(dataGridView_file);
            db_file.Connect();

            db_file.DeleteFile(Convert.ToInt32(str_selected_work_no), str_selected_file_name);
            db_file.Disconnect();
        }


        private void button_delete_Click(object sender, EventArgs e)
        {
            if(dataGridView_work.RowCount == 1)
            {
                MessageBox.Show("삭제할 수 있는 항목이 더 이상 없습니다.");
                return;
            }

            bool b_pressOK = MessageBox.Show("선택된 항목을 삭제하시겠습니까?", "삭제여부", MessageBoxButtons.OKCancel) == DialogResult.OK;

            if(b_pressOK)
            {
                int selected_work_no = Convert.ToInt32(dataGridView_work.Rows[m_nSelected_workList_idx].Cells[0].Value.ToString());

                DB_fileMgr db_file = new DB_fileMgr(dataGridView_file);
                db_file.Connect();

                db_file.DeleteFiles(selected_work_no);
                db_file.Disconnect();

                DB_workMgr db_work = new DB_workMgr(dataGridView_work, str_user_id);
                db_work.Connect();

                db_work.DeleteList(selected_work_no);
                db_work.Disconnect();

                RefreshWorkTable();
            }
            else
            {
                MessageBox.Show("취소되었습니다.");
            }
        }

        private void RefreshWorkTable(int n_year = 0, int n_month = 0, int n_day = 0)
        {
            DB_workMgr db_work = new DB_workMgr(dataGridView_work, str_user_id);
            db_work.Connect();

            bool b_search_success = db_work.SearchListByDate(n_year, n_month, n_day);
            db_work.Disconnect();

            SetComboBox();
        }

        private void button_read_details_Click(object sender, EventArgs e)
        {
            int n_selected_work_no = Convert.ToInt32(dataGridView_work.Rows[m_nSelected_workList_idx].Cells[0].Value.ToString());

            DB_workMgr db_work = new DB_workMgr(dataGridView_work, str_user_id);
            db_work.Connect();

            DBWorkNode workNode = new DBWorkNode();
            db_work.SearchWorkByWorkNo(n_selected_work_no, ref workNode);
            
            Check_Item_DB_Form check_DB_form = new Check_Item_DB_Form();
            check_DB_form.m_strTitle = workNode.m_strTitle;
            check_DB_form.m_strDetails = workNode.m_strDetails;

            check_DB_form.ShowDialog();
        }

        private void button_download_file_Click(object sender, EventArgs e)
        {
            List<string> fileList; 

            DB_fileMgr db_file = new DB_fileMgr(dataGridView_file);
            db_file.Connect();

            int n_selected_work_no = Convert.ToInt32(dataGridView_work.Rows[m_nSelected_workList_idx].Cells[0].Value.ToString());
            fileList = db_file.GetFilesLinkedWithWork(n_selected_work_no);
            db_file.Disconnect();

            Net_Client client = new Net_Client(Globals.m_strFile_IP, Globals.m_nFile_port);
            
            foreach(string fileName in fileList)
            {
                client.Run(Protocol.CLIENT_REQ.RECEIVE_FILE, fileName);
            }
        }

        private void comboYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshWorkTableWithComboBox();
        }

        private void comboMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshWorkTableWithComboBox();
        }

        private void comboDay_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshWorkTableWithComboBox();
        }

        private void RefreshWorkTableWithComboBox()
        {
            int n_year;
            int n_month;
            int n_day;

            if (comboYear.Text == "")
            {
                n_year = 0;
            }
            else
            {
                n_year = Convert.ToInt32(comboYear.Text);
            }

            if (comboMonth.Text == "")
            {
                n_month = 0;
            }
            else
            {
                n_month = Convert.ToInt32(comboMonth.Text);
            }

            if (comboDay.Text == "")
            {
                n_day = 0;
            }
            else
            {
                n_day = Convert.ToInt32(comboDay.Text);
            }

            RefreshWorkTable(n_year, n_month, n_day);
        }
    }
}
