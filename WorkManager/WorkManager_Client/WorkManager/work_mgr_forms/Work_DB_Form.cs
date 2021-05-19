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
        public string user_id { get; set; }

        private int selected_workList_idx { get; set; }
        private int selected_fileList_idx { get; set; }

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

            DB_workMgr db_work = new DB_workMgr(dataGridView_work, user_id);
            db_work.Connect();

            bool b_search_success = db_work.SearchList();
            db_work.Disconnect();

            SetComboBox();
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            int year;
            int month;
            int day;

            if (comboYear.Text == "")
            {
                year = 0;
            }
            else
            {
                year = Convert.ToInt32(comboYear.Text);
            }

            if (comboMonth.Text == "")
            {
                month = 0;
            }
            else
            {
                month = Convert.ToInt32(comboMonth.Text);
            }

            if (comboDay.Text == "")
            {
                day = 0;
            }
            else
            {
                day = Convert.ToInt32(comboDay.Text);
            }

            RefreshWorkTable(year, month, day);
        }

        private void SetComboBox()
        {
            comboYear.Items.Clear();
            comboMonth.Items.Clear();
            comboYear.Items.Clear();

            List<string> year = new List<string>();
            List<string> month = new List<string>();
            List<string> day = new List<string>();

            for (int rows = 1; rows < dataGridView_work.Rows.Count - 1; rows++)
            {
                string value = dataGridView_work.Rows[rows].Cells[2].Value.ToString();

                DateTime dt = Convert.ToDateTime(dataGridView_work.Rows[rows].Cells[2].Value);

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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Additem_DB_Form item_db_form = new Additem_DB_Form();
            item_db_form.user_id = user_id;
            item_db_form.dataGridView_workList = dataGridView_work;

            item_db_form.ShowDialog();

            RefreshWorkTable();
        }

        private void dataGridView_work_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selected_workList_idx = e.RowIndex;

            if(selected_workList_idx >= (dataGridView_work.RowCount - 1))
            {
                return;
            }

            DataGridViewRow row = dataGridView_work.Rows[selected_workList_idx];
            string selected_work_no = row.Cells[0].Value.ToString();

            DB_fileMgr db_file = new DB_fileMgr(dataGridView_file);
            db_file.Connect();

            db_file.SearchFiles(Convert.ToInt32(selected_work_no));
            db_file.Disconnect();
        }

        private void dataGridView_file_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selected_fileList_idx = e.RowIndex;
        }

        private void button_delete_file_Click(object sender, EventArgs e)
        {
            if(selected_fileList_idx >= (dataGridView_file.RowCount - 1))
            {
                return;
            }

            DataGridViewRow row = dataGridView_file.Rows[selected_fileList_idx];

            string selected_work_no = row.Cells[1].Value.ToString();
            string selected_file_name = row.Cells[2].Value.ToString();

            DB_fileMgr db_file = new DB_fileMgr(dataGridView_file);
            db_file.Connect();

            db_file.DeleteFile(Convert.ToInt32(selected_work_no), selected_file_name);
            db_file.Disconnect();
        }


        private void button_delete_Click(object sender, EventArgs e)
        {
            bool b_pressOK = MessageBox.Show("선택된 항목을 삭제하시겠습니까?", "삭제여부", MessageBoxButtons.OKCancel) == DialogResult.OK;

            if(b_pressOK)
            {
                int selected_work_no = Convert.ToInt32(dataGridView_work.Rows[selected_workList_idx].Cells[0].Value.ToString());

                DB_fileMgr db_file = new DB_fileMgr(dataGridView_file);
                db_file.Connect();

                db_file.DeleteFiles(selected_work_no);
                db_file.Disconnect();

                DB_workMgr db_work = new DB_workMgr(dataGridView_work, user_id);
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

        private void RefreshWorkTable(int year = 0, int month = 0, int day = 0)
        {
            DB_workMgr db_work = new DB_workMgr(dataGridView_work, user_id);
            db_work.Connect();

            bool b_search_success = db_work.SearchList(year, month, day);
            db_work.Disconnect();

            SetComboBox();
        }

        private void button_read_details_Click(object sender, EventArgs e)
        {

        }

        private void button_download_file_Click(object sender, EventArgs e)
        {
            List<string> fileList; 

            DB_fileMgr db_file = new DB_fileMgr(dataGridView_file);
            db_file.Connect();

            int selected_work_no = Convert.ToInt32(dataGridView_work.Rows[selected_workList_idx].Cells[0].Value.ToString());
            fileList = db_file.GetFilesLinkedWithWork(selected_work_no);
            db_file.Disconnect();

            Net_Client client = new Net_Client("127.0.0.1");
            
            foreach(string fileName in fileList)
            {
                client.Run(Protocol.CLIENT_REQ.RECEIVE_FILE, fileName);
            }
        }
    }
}
