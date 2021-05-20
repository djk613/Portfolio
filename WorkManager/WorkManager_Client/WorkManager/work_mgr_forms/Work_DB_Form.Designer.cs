
namespace WorkManager
{
    partial class Work_DB_Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnCheck = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.comboDay = new System.Windows.Forms.ComboBox();
            this.labelDay = new System.Windows.Forms.Label();
            this.comboMonth = new System.Windows.Forms.ComboBox();
            this.labelMonth = new System.Windows.Forms.Label();
            this.labelYear = new System.Windows.Forms.Label();
            this.comboYear = new System.Windows.Forms.ComboBox();
            this.dataGridView_work = new System.Windows.Forms.DataGridView();
            this.dataGridView_file = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.button_delete_file = new System.Windows.Forms.Button();
            this.button_delete = new System.Windows.Forms.Button();
            this.button_download_file = new System.Windows.Forms.Button();
            this.button_read_details = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_work)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_file)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCheck
            // 
            this.btnCheck.Location = new System.Drawing.Point(408, 325);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(75, 23);
            this.btnCheck.TabIndex = 19;
            this.btnCheck.Text = "조회";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(165, 325);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 18;
            this.btnAdd.Text = "추가";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.UseWaitCursor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // comboDay
            // 
            this.comboDay.FormattingEnabled = true;
            this.comboDay.Location = new System.Drawing.Point(230, 11);
            this.comboDay.Name = "comboDay";
            this.comboDay.Size = new System.Drawing.Size(78, 23);
            this.comboDay.TabIndex = 16;
            // 
            // labelDay
            // 
            this.labelDay.AutoSize = true;
            this.labelDay.Location = new System.Drawing.Point(314, 15);
            this.labelDay.Name = "labelDay";
            this.labelDay.Size = new System.Drawing.Size(19, 15);
            this.labelDay.TabIndex = 15;
            this.labelDay.Text = "일";
            // 
            // comboMonth
            // 
            this.comboMonth.FormattingEnabled = true;
            this.comboMonth.Location = new System.Drawing.Point(121, 11);
            this.comboMonth.Name = "comboMonth";
            this.comboMonth.Size = new System.Drawing.Size(78, 23);
            this.comboMonth.TabIndex = 14;
            // 
            // labelMonth
            // 
            this.labelMonth.AutoSize = true;
            this.labelMonth.Location = new System.Drawing.Point(205, 15);
            this.labelMonth.Name = "labelMonth";
            this.labelMonth.Size = new System.Drawing.Size(19, 15);
            this.labelMonth.TabIndex = 13;
            this.labelMonth.Text = "월";
            // 
            // labelYear
            // 
            this.labelYear.AutoSize = true;
            this.labelYear.Location = new System.Drawing.Point(96, 15);
            this.labelYear.Name = "labelYear";
            this.labelYear.Size = new System.Drawing.Size(19, 15);
            this.labelYear.TabIndex = 11;
            this.labelYear.Text = "년";
            // 
            // comboYear
            // 
            this.comboYear.FormattingEnabled = true;
            this.comboYear.Location = new System.Drawing.Point(12, 11);
            this.comboYear.Name = "comboYear";
            this.comboYear.Size = new System.Drawing.Size(78, 23);
            this.comboYear.TabIndex = 12;
            // 
            // dataGridView_work
            // 
            this.dataGridView_work.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_work.Location = new System.Drawing.Point(12, 41);
            this.dataGridView_work.Name = "dataGridView_work";
            this.dataGridView_work.RowTemplate.Height = 25;
            this.dataGridView_work.Size = new System.Drawing.Size(471, 278);
            this.dataGridView_work.TabIndex = 21;
            this.dataGridView_work.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_work_CellClick);
            // 
            // dataGridView_file
            // 
            this.dataGridView_file.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_file.Location = new System.Drawing.Point(504, 41);
            this.dataGridView_file.Name = "dataGridView_file";
            this.dataGridView_file.RowTemplate.Height = 25;
            this.dataGridView_file.Size = new System.Drawing.Size(252, 278);
            this.dataGridView_file.TabIndex = 22;
            this.dataGridView_file.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_file_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(504, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 15);
            this.label1.TabIndex = 23;
            this.label1.Text = "파일";
            // 
            // button_delete_file
            // 
            this.button_delete_file.Location = new System.Drawing.Point(681, 325);
            this.button_delete_file.Name = "button_delete_file";
            this.button_delete_file.Size = new System.Drawing.Size(75, 23);
            this.button_delete_file.TabIndex = 24;
            this.button_delete_file.Text = "파일삭제";
            this.button_delete_file.UseVisualStyleBackColor = true;
            this.button_delete_file.UseWaitCursor = true;
            this.button_delete_file.Click += new System.EventHandler(this.button_delete_file_Click);
            // 
            // button_delete
            // 
            this.button_delete.Location = new System.Drawing.Point(246, 325);
            this.button_delete.Name = "button_delete";
            this.button_delete.Size = new System.Drawing.Size(75, 23);
            this.button_delete.TabIndex = 25;
            this.button_delete.Text = "삭제";
            this.button_delete.UseVisualStyleBackColor = true;
            this.button_delete.UseWaitCursor = true;
            this.button_delete.Click += new System.EventHandler(this.button_delete_Click);
            // 
            // button_download_file
            // 
            this.button_download_file.Location = new System.Drawing.Point(600, 325);
            this.button_download_file.Name = "button_download_file";
            this.button_download_file.Size = new System.Drawing.Size(75, 23);
            this.button_download_file.TabIndex = 26;
            this.button_download_file.Text = "파일받기";
            this.button_download_file.UseVisualStyleBackColor = true;
            this.button_download_file.UseWaitCursor = true;
            this.button_download_file.Click += new System.EventHandler(this.button_download_file_Click);
            // 
            // button_read_details
            // 
            this.button_read_details.Location = new System.Drawing.Point(327, 325);
            this.button_read_details.Name = "button_read_details";
            this.button_read_details.Size = new System.Drawing.Size(75, 23);
            this.button_read_details.TabIndex = 27;
            this.button_read_details.Text = "상세보기";
            this.button_read_details.UseVisualStyleBackColor = true;
            this.button_read_details.UseWaitCursor = true;
            this.button_read_details.Click += new System.EventHandler(this.button_read_details_Click);
            // 
            // Work_DB_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(768, 357);
            this.Controls.Add(this.button_read_details);
            this.Controls.Add(this.button_download_file);
            this.Controls.Add(this.button_delete);
            this.Controls.Add(this.button_delete_file);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView_file);
            this.Controls.Add(this.dataGridView_work);
            this.Controls.Add(this.btnCheck);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.comboDay);
            this.Controls.Add(this.labelDay);
            this.Controls.Add(this.comboMonth);
            this.Controls.Add(this.labelMonth);
            this.Controls.Add(this.comboYear);
            this.Controls.Add(this.labelYear);
            this.Name = "Work_DB_Form";
            this.Text = "Work_DB_Form";
            this.Load += new System.EventHandler(this.Work_DB_Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_work)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_file)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ComboBox comboDay;
        private System.Windows.Forms.Label labelDay;
        private System.Windows.Forms.ComboBox comboMonth;
        private System.Windows.Forms.Label labelMonth;
        private System.Windows.Forms.Label labelYear;
        private System.Windows.Forms.ComboBox comboYear;
        private System.Windows.Forms.DataGridView dataGridView_work;
        private System.Windows.Forms.DataGridView dataGridView_file;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_delete_file;
        private System.Windows.Forms.Button button_delete;
        private System.Windows.Forms.Button button_download_file;
        private System.Windows.Forms.Button button_read_details;
    }
}