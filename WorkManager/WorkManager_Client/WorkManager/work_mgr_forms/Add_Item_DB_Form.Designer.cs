
namespace WorkManager
{
    partial class Add_Item_DB_Form
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
            this.label3 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.labelContext = new System.Windows.Forms.Label();
            this.labelTitle = new System.Windows.Forms.Label();
            this.textBoxTitle = new System.Windows.Forms.TextBox();
            this.textBoxContext = new System.Windows.Forms.TextBox();
            this.buttonFindFile = new System.Windows.Forms.Button();
            this.dataGridView_fileList = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_fileList)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Buxton Sketch", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(527, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(192, 39);
            this.label3.TabIndex = 30;
            this.label3.Text = "Work Manager";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(404, 401);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(89, 30);
            this.btnCancel.TabIndex = 29;
            this.btnCancel.Text = "취소";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(309, 401);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(89, 30);
            this.btnSave.TabIndex = 28;
            this.btnSave.Text = "저장";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // labelContext
            // 
            this.labelContext.AutoSize = true;
            this.labelContext.Location = new System.Drawing.Point(12, 56);
            this.labelContext.Name = "labelContext";
            this.labelContext.Size = new System.Drawing.Size(31, 15);
            this.labelContext.TabIndex = 25;
            this.labelContext.Text = "내용";
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Location = new System.Drawing.Point(12, 11);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(31, 15);
            this.labelTitle.TabIndex = 24;
            this.labelTitle.Text = "제목";
            // 
            // textBoxTitle
            // 
            this.textBoxTitle.Location = new System.Drawing.Point(12, 30);
            this.textBoxTitle.Name = "textBoxTitle";
            this.textBoxTitle.Size = new System.Drawing.Size(480, 23);
            this.textBoxTitle.TabIndex = 23;
            // 
            // textBoxContext
            // 
            this.textBoxContext.Location = new System.Drawing.Point(12, 77);
            this.textBoxContext.Multiline = true;
            this.textBoxContext.Name = "textBoxContext";
            this.textBoxContext.Size = new System.Drawing.Size(480, 318);
            this.textBoxContext.TabIndex = 22;
            // 
            // buttonFindFile
            // 
            this.buttonFindFile.Location = new System.Drawing.Point(630, 398);
            this.buttonFindFile.Name = "buttonFindFile";
            this.buttonFindFile.Size = new System.Drawing.Size(89, 30);
            this.buttonFindFile.TabIndex = 27;
            this.buttonFindFile.Text = "파일등록";
            this.buttonFindFile.UseVisualStyleBackColor = true;
            this.buttonFindFile.Click += new System.EventHandler(this.buttonFindFile_Click);
            // 
            // dataGridView_fileList
            // 
            this.dataGridView_fileList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_fileList.Location = new System.Drawing.Point(510, 77);
            this.dataGridView_fileList.Name = "dataGridView_fileList";
            this.dataGridView_fileList.RowTemplate.Height = 25;
            this.dataGridView_fileList.Size = new System.Drawing.Size(209, 318);
            this.dataGridView_fileList.TabIndex = 31;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(510, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 15);
            this.label1.TabIndex = 32;
            this.label1.Text = "파일목록";
            // 
            // Add_Item_DB_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(731, 440);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView_fileList);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.buttonFindFile);
            this.Controls.Add(this.labelContext);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.textBoxTitle);
            this.Controls.Add(this.textBoxContext);
            this.Name = "Add_Item_DB_Form";
            this.Text = "Additem_DB_Form";
            this.Load += new System.EventHandler(this.Additem_DB_Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_fileList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label labelContext;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.TextBox textBoxTitle;
        private System.Windows.Forms.TextBox textBoxContext;
        private System.Windows.Forms.Button buttonFindFile;
        private System.Windows.Forms.DataGridView dataGridView_fileList;
        private System.Windows.Forms.Label label1;
    }
}