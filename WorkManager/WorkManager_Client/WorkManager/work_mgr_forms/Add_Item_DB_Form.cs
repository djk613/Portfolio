using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using TCP_SOCKET_NETWORK;
using Protocol;

namespace WorkManager
{
    public partial class Add_Item_DB_Form : Form
    {
        public string user_id { get; set; }
        public DataGridView dataGridView_workList { get; set; }
        private List<string> filesSelected { get; set; }
        public Add_Item_DB_Form()
        {
            InitializeComponent();
        }

        private void Additem_DB_Form_Load(object sender, EventArgs e)
        {
            filesSelected = new List<string>();

            dataGridView_fileList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView_fileList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView_fileList.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
        }

        private void buttonFindFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openfileDlg = new OpenFileDialog();

            if(filesSelected != null)
            {
                filesSelected.Clear();
            }

            string OpenFilePath = System.Environment.CurrentDirectory;

            openfileDlg.InitialDirectory = OpenFilePath;
            openfileDlg.RestoreDirectory = true;
            openfileDlg.Title = "파일 선택";
            openfileDlg.DefaultExt = "*";
            openfileDlg.FileName = "";
            openfileDlg.Filter = "모든 파일 (*.*) | *.*";

            openfileDlg.Multiselect = true;                      
            openfileDlg.ReadOnlyChecked = true;                  
            openfileDlg.ShowReadOnly = true;                     

            DialogResult dr = openfileDlg.ShowDialog();

            DataTable table = new DataTable();
            table.Columns.Add("FILES", typeof(string));

            if (dr == DialogResult.OK)
            {
                foreach (String filepath in openfileDlg.FileNames)
                {
                    filesSelected.Add(filepath);
                    table.Rows.Add(Path.GetFileName(filepath));
                }
            }

            dataGridView_fileList.DataSource = table;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DB_workMgr db_work = new DB_workMgr(dataGridView_workList, user_id);
            db_work.Connect();

            db_work.InsertList(user_id, textBoxTitle.Text, textBoxContext.Text);

            int work_no;
            work_no = db_work.GetLastWorkNo();
            db_work.Disconnect();

            List<Tuple<int, string>> list = new List<Tuple<int, string>>();

            foreach(var fileName in filesSelected)
            {
                Tuple<int, string> data = new Tuple<int, string>(work_no, Path.GetFileName(fileName.ToString()));
                list.Add(data);
            }

            DB_fileMgr db_file = new DB_fileMgr();
            db_file.Connect();

            db_file.InsertFiles(list);
            db_file.Disconnect();

            /*network TCP socket process.*/
            Net_Client client = new Net_Client("127.0.0.1");

            foreach (var fileName in filesSelected)
            {
                client.Run(Protocol.CLIENT_REQ.SEND_FILE, fileName);
            }

            this.Close();
        }
    }
}
