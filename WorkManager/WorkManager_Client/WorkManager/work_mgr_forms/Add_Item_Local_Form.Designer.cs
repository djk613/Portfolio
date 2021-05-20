
namespace WorkManager
{
    partial class Add_Item_Local_Form
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
            this.textBoxContext = new System.Windows.Forms.TextBox();
            this.textBoxTitle = new System.Windows.Forms.TextBox();
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelContext = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button_files = new System.Windows.Forms.Button();
            this.listView_fileList = new System.Windows.Forms.ListView();
            this.col_filName = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // textBoxContext
            // 
            this.textBoxContext.Location = new System.Drawing.Point(12, 82);
            this.textBoxContext.Multiline = true;
            this.textBoxContext.Name = "textBoxContext";
            this.textBoxContext.Size = new System.Drawing.Size(480, 318);
            this.textBoxContext.TabIndex = 0;
            // 
            // textBoxTitle
            // 
            this.textBoxTitle.Location = new System.Drawing.Point(12, 32);
            this.textBoxTitle.Name = "textBoxTitle";
            this.textBoxTitle.Size = new System.Drawing.Size(480, 23);
            this.textBoxTitle.TabIndex = 1;
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Location = new System.Drawing.Point(12, 13);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(31, 15);
            this.labelTitle.TabIndex = 2;
            this.labelTitle.Text = "제목";
            // 
            // labelContext
            // 
            this.labelContext.AutoSize = true;
            this.labelContext.Location = new System.Drawing.Point(12, 61);
            this.labelContext.Name = "labelContext";
            this.labelContext.Size = new System.Drawing.Size(31, 15);
            this.labelContext.TabIndex = 3;
            this.labelContext.Text = "내용";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(308, 406);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(89, 30);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "저장";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(403, 406);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(89, 30);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "취소";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(521, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 15);
            this.label1.TabIndex = 34;
            this.label1.Text = "파일목록";
            // 
            // button_files
            // 
            this.button_files.Location = new System.Drawing.Point(661, 406);
            this.button_files.Name = "button_files";
            this.button_files.Size = new System.Drawing.Size(89, 30);
            this.button_files.TabIndex = 33;
            this.button_files.Text = "파일등록";
            this.button_files.UseVisualStyleBackColor = true;
            this.button_files.Click += new System.EventHandler(this.button_files_Click);
            // 
            // listView_fileList
            // 
            this.listView_fileList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.col_filName});
            this.listView_fileList.HideSelection = false;
            this.listView_fileList.Location = new System.Drawing.Point(521, 82);
            this.listView_fileList.Name = "listView_fileList";
            this.listView_fileList.Size = new System.Drawing.Size(229, 318);
            this.listView_fileList.TabIndex = 35;
            this.listView_fileList.UseCompatibleStateImageBehavior = false;
            this.listView_fileList.View = System.Windows.Forms.View.Details;
            // 
            // col_filName
            // 
            this.col_filName.Text = "파일이름";
            this.col_filName.Width = 300;
            // 
            // Add_Item_Local_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(762, 444);
            this.Controls.Add(this.listView_fileList);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_files);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.labelContext);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.textBoxTitle);
            this.Controls.Add(this.textBoxContext);
            this.Name = "Add_Item_Local_Form";
            this.Text = "작업내용저장";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxContext;
        private System.Windows.Forms.TextBox textBoxTitle;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelContext;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_files;
        private System.Windows.Forms.ListView listView_fileList;
        private System.Windows.Forms.ColumnHeader col_filName;
    }
}