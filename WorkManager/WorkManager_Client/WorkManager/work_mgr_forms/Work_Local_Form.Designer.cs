﻿
namespace WorkManager
{
    partial class Work_Local_Form
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.labelYear = new System.Windows.Forms.Label();
            this.comboYear = new System.Windows.Forms.ComboBox();
            this.comboMonth = new System.Windows.Forms.ComboBox();
            this.labelMonth = new System.Windows.Forms.Label();
            this.comboDay = new System.Windows.Forms.ComboBox();
            this.labelDay = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnCheck = new System.Windows.Forms.Button();
            this.Date = new System.Windows.Forms.ColumnHeader();
            this.Day = new System.Windows.Forms.ColumnHeader();
            this.Subject = new System.Windows.Forms.ColumnHeader();
            this.serialNumber = new System.Windows.Forms.ColumnHeader();
            this.linkedFile = new System.Windows.Forms.ColumnHeader();
            this.details = new System.Windows.Forms.ColumnHeader();
            this.listViewMain = new System.Windows.Forms.ListView();
            this.button_read_details = new System.Windows.Forms.Button();
            this.button_delete = new System.Windows.Forms.Button();
            this.listView_files = new System.Windows.Forms.ListView();
            this.col_filName = new System.Windows.Forms.ColumnHeader();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // labelYear
            // 
            this.labelYear.AutoSize = true;
            this.labelYear.Location = new System.Drawing.Point(96, 13);
            this.labelYear.Name = "labelYear";
            this.labelYear.Size = new System.Drawing.Size(19, 15);
            this.labelYear.TabIndex = 2;
            this.labelYear.Text = "년";
            // 
            // comboYear
            // 
            this.comboYear.FormattingEnabled = true;
            this.comboYear.Location = new System.Drawing.Point(12, 9);
            this.comboYear.Name = "comboYear";
            this.comboYear.Size = new System.Drawing.Size(78, 23);
            this.comboYear.TabIndex = 3;
            this.comboYear.SelectedIndexChanged += new System.EventHandler(this.comboYear_SelectedIndexChanged);
            // 
            // comboMonth
            // 
            this.comboMonth.FormattingEnabled = true;
            this.comboMonth.Location = new System.Drawing.Point(121, 9);
            this.comboMonth.Name = "comboMonth";
            this.comboMonth.Size = new System.Drawing.Size(78, 23);
            this.comboMonth.TabIndex = 5;
            this.comboMonth.SelectedIndexChanged += new System.EventHandler(this.comboMonth_SelectedIndexChanged);
            // 
            // labelMonth
            // 
            this.labelMonth.AutoSize = true;
            this.labelMonth.Location = new System.Drawing.Point(205, 13);
            this.labelMonth.Name = "labelMonth";
            this.labelMonth.Size = new System.Drawing.Size(19, 15);
            this.labelMonth.TabIndex = 4;
            this.labelMonth.Text = "월";
            // 
            // comboDay
            // 
            this.comboDay.FormattingEnabled = true;
            this.comboDay.Location = new System.Drawing.Point(230, 9);
            this.comboDay.Name = "comboDay";
            this.comboDay.Size = new System.Drawing.Size(78, 23);
            this.comboDay.TabIndex = 7;
            this.comboDay.SelectedIndexChanged += new System.EventHandler(this.comboDay_SelectedIndexChanged);
            // 
            // labelDay
            // 
            this.labelDay.AutoSize = true;
            this.labelDay.Location = new System.Drawing.Point(314, 13);
            this.labelDay.Name = "labelDay";
            this.labelDay.Size = new System.Drawing.Size(19, 15);
            this.labelDay.TabIndex = 6;
            this.labelDay.Text = "일";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(230, 323);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 9;
            this.btnAdd.Text = "추가";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.UseWaitCursor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnCheck
            // 
            this.btnCheck.Location = new System.Drawing.Point(473, 323);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(75, 23);
            this.btnCheck.TabIndex = 10;
            this.btnCheck.Text = "조회";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // Date
            // 
            this.Date.Text = "날짜";
            this.Date.Width = 200;
            // 
            // Day
            // 
            this.Day.Text = "요일";
            // 
            // Subject
            // 
            this.Subject.Text = "제목";
            this.Subject.Width = 300;
            // 
            // serialNumber
            // 
            this.serialNumber.Text = "";
            this.serialNumber.Width = 0;
            // 
            // linkedFile
            // 
            this.linkedFile.Text = "";
            this.linkedFile.Width = 0;
            // 
            // details
            // 
            this.details.Text = "";
            this.details.Width = 0;
            // 
            // listViewMain
            // 
            this.listViewMain.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Date,
            this.Day,
            this.Subject,
            this.serialNumber,
            this.linkedFile,
            this.details});
            this.listViewMain.GridLines = true;
            this.listViewMain.HideSelection = false;
            this.listViewMain.Location = new System.Drawing.Point(12, 39);
            this.listViewMain.Name = "listViewMain";
            this.listViewMain.Size = new System.Drawing.Size(536, 278);
            this.listViewMain.TabIndex = 8;
            this.listViewMain.UseCompatibleStateImageBehavior = false;
            this.listViewMain.View = System.Windows.Forms.View.Details;
            this.listViewMain.ColumnWidthChanging += new System.Windows.Forms.ColumnWidthChangingEventHandler(this.listViewMain_columnWidthChanging);
            this.listViewMain.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listViewMain_MouseClick);
            // 
            // button_read_details
            // 
            this.button_read_details.Location = new System.Drawing.Point(392, 323);
            this.button_read_details.Name = "button_read_details";
            this.button_read_details.Size = new System.Drawing.Size(75, 23);
            this.button_read_details.TabIndex = 29;
            this.button_read_details.Text = "상세보기";
            this.button_read_details.UseVisualStyleBackColor = true;
            this.button_read_details.UseWaitCursor = true;
            this.button_read_details.Click += new System.EventHandler(this.button_read_details_Click);
            // 
            // button_delete
            // 
            this.button_delete.Location = new System.Drawing.Point(311, 323);
            this.button_delete.Name = "button_delete";
            this.button_delete.Size = new System.Drawing.Size(75, 23);
            this.button_delete.TabIndex = 28;
            this.button_delete.Text = "삭제";
            this.button_delete.UseVisualStyleBackColor = true;
            this.button_delete.UseWaitCursor = true;
            this.button_delete.Click += new System.EventHandler(this.button_delete_Click);
            // 
            // listView_files
            // 
            this.listView_files.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.col_filName});
            this.listView_files.HideSelection = false;
            this.listView_files.Location = new System.Drawing.Point(564, 39);
            this.listView_files.Name = "listView_files";
            this.listView_files.Size = new System.Drawing.Size(229, 278);
            this.listView_files.TabIndex = 37;
            this.listView_files.UseCompatibleStateImageBehavior = false;
            this.listView_files.View = System.Windows.Forms.View.Details;
            // 
            // col_filName
            // 
            this.col_filName.Text = "파일이름";
            this.col_filName.Width = 300;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(564, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 15);
            this.label1.TabIndex = 36;
            this.label1.Text = "파일목록";
            // 
            // Work_Local_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(805, 374);
            this.Controls.Add(this.listView_files);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_read_details);
            this.Controls.Add(this.button_delete);
            this.Controls.Add(this.btnCheck);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.listViewMain);
            this.Controls.Add(this.comboDay);
            this.Controls.Add(this.labelDay);
            this.Controls.Add(this.comboMonth);
            this.Controls.Add(this.labelMonth);
            this.Controls.Add(this.comboYear);
            this.Controls.Add(this.labelYear);
            this.Name = "Work_Local_Form";
            this.Text = "Daily Work Manager";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Label labelYear;
        private System.Windows.Forms.ComboBox comboYear;
        private System.Windows.Forms.ComboBox comboMonth;
        private System.Windows.Forms.Label labelMonth;
        private System.Windows.Forms.ComboBox comboDay;
        private System.Windows.Forms.Label labelDay;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.ColumnHeader 상세;
        private System.Windows.Forms.ColumnHeader 요일;
        private System.Windows.Forms.ColumnHeader 날짜;
        private System.Windows.Forms.ColumnHeader Date;
        private System.Windows.Forms.ColumnHeader Day;
        private System.Windows.Forms.ColumnHeader Subject;
        private System.Windows.Forms.ColumnHeader serialNumber;
        private System.Windows.Forms.ColumnHeader linkedFile;
        private System.Windows.Forms.ColumnHeader details;
        private System.Windows.Forms.ListView listViewMain;
        private System.Windows.Forms.Button button_read_details;
        private System.Windows.Forms.Button button_delete;
        private System.Windows.Forms.ListView listView_files;
        private System.Windows.Forms.ColumnHeader col_filName;
        private System.Windows.Forms.Label label1;
    }
}

