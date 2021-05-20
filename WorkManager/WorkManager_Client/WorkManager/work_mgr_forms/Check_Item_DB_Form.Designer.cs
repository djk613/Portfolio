
namespace WorkManager
{
    partial class Check_Item_DB_Form
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
            this.textBoxTitle = new System.Windows.Forms.TextBox();
            this.textBoxDetails = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnErase
            // 
            this.btnErase.Location = new System.Drawing.Point(403, 387);
            this.btnErase.Name = "btnErase";
            this.btnErase.Size = new System.Drawing.Size(89, 30);
            this.btnErase.TabIndex = 21;
            this.btnErase.Text = "확인";
            this.btnErase.UseVisualStyleBackColor = true;
            // 
            // labelContext
            // 
            this.labelContext.AutoSize = true;
            this.labelContext.Location = new System.Drawing.Point(12, 42);
            this.labelContext.Name = "labelContext";
            this.labelContext.Size = new System.Drawing.Size(31, 15);
            this.labelContext.TabIndex = 18;
            this.labelContext.Text = "내용";
            // 
            // textBoxTitle
            // 
            this.textBoxTitle.Location = new System.Drawing.Point(12, 13);
            this.textBoxTitle.Name = "textBoxTitle";
            this.textBoxTitle.Size = new System.Drawing.Size(480, 23);
            this.textBoxTitle.TabIndex = 17;
            // 
            // textBoxDetails
            // 
            this.textBoxDetails.Location = new System.Drawing.Point(12, 63);
            this.textBoxDetails.Multiline = true;
            this.textBoxDetails.Name = "textBoxDetails";
            this.textBoxDetails.Size = new System.Drawing.Size(480, 318);
            this.textBoxDetails.TabIndex = 16;
            // 
            // Check_Item_DB_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(503, 426);
            this.Controls.Add(this.btnErase);
            this.Controls.Add(this.labelContext);
            this.Controls.Add(this.textBoxTitle);
            this.Controls.Add(this.textBoxDetails);
            this.Name = "Check_Item_DB_Form";
            this.Text = "Check_Item_DB_Form";
            this.Load += new System.EventHandler(this.Check_Item_DB_Form_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnErase;
        private System.Windows.Forms.Label labelContext;
        private System.Windows.Forms.TextBox textBoxTitle;
        private System.Windows.Forms.TextBox textBoxDetails;
    }
}