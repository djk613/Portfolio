
namespace WorkManager
{
    partial class Check_Item_Local_Form
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
            this.btnErase = new System.Windows.Forms.Button();
            this.labelContext = new System.Windows.Forms.Label();
            this.labelTitle = new System.Windows.Forms.Label();
            this.textBoxTitle = new System.Windows.Forms.TextBox();
            this.textBoxContext = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnErase
            // 
            this.btnErase.Location = new System.Drawing.Point(399, 384);
            this.btnErase.Name = "btnErase";
            this.btnErase.Size = new System.Drawing.Size(89, 30);
            this.btnErase.TabIndex = 15;
            this.btnErase.Text = "확인";
            this.btnErase.UseVisualStyleBackColor = true;
            this.btnErase.Click += new System.EventHandler(this.btnErase_Click);
            // 
            // labelContext
            // 
            this.labelContext.AutoSize = true;
            this.labelContext.Location = new System.Drawing.Point(8, 39);
            this.labelContext.Name = "labelContext";
            this.labelContext.Size = new System.Drawing.Size(31, 15);
            this.labelContext.TabIndex = 11;
            this.labelContext.Text = "내용";
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Location = new System.Drawing.Point(2, -14);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(31, 15);
            this.labelTitle.TabIndex = 10;
            this.labelTitle.Text = "제목";
            // 
            // textBoxTitle
            // 
            this.textBoxTitle.Location = new System.Drawing.Point(8, 10);
            this.textBoxTitle.Name = "textBoxTitle";
            this.textBoxTitle.Size = new System.Drawing.Size(480, 23);
            this.textBoxTitle.TabIndex = 9;
            // 
            // textBoxContext
            // 
            this.textBoxContext.Location = new System.Drawing.Point(8, 60);
            this.textBoxContext.Multiline = true;
            this.textBoxContext.Name = "textBoxContext";
            this.textBoxContext.Size = new System.Drawing.Size(480, 318);
            this.textBoxContext.TabIndex = 8;
            // 
            // Check_Item_Local_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(497, 423);
            this.Controls.Add(this.btnErase);
            this.Controls.Add(this.labelContext);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.textBoxTitle);
            this.Controls.Add(this.textBoxContext);
            this.Name = "Check_Item_Local_Form";
            this.Text = "CheckItemForm";
            this.Load += new System.EventHandler(this.Check_Item_Local_Form_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnErase;
        private System.Windows.Forms.Label labelContext;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.TextBox textBoxTitle;
        private System.Windows.Forms.TextBox textBoxContext;
    }
}