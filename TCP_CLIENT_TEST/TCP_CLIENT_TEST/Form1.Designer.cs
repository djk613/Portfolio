
namespace TCP_CLIENT_TEST
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_server_IP = new System.Windows.Forms.TextBox();
            this.comboBox_type = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_file_path = new System.Windows.Forms.TextBox();
            this.button_file_search = new System.Windows.Forms.Button();
            this.button_TCP = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "ServerIP";
            // 
            // textBox_server_IP
            // 
            this.textBox_server_IP.Location = new System.Drawing.Point(69, 10);
            this.textBox_server_IP.Name = "textBox_server_IP";
            this.textBox_server_IP.Size = new System.Drawing.Size(121, 23);
            this.textBox_server_IP.TabIndex = 1;
            // 
            // comboBox_type
            // 
            this.comboBox_type.FormattingEnabled = true;
            this.comboBox_type.Location = new System.Drawing.Point(69, 48);
            this.comboBox_type.Name = "comboBox_type";
            this.comboBox_type.Size = new System.Drawing.Size(121, 23);
            this.comboBox_type.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "type";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "file";
            // 
            // textBox_file_path
            // 
            this.textBox_file_path.Location = new System.Drawing.Point(69, 85);
            this.textBox_file_path.Name = "textBox_file_path";
            this.textBox_file_path.Size = new System.Drawing.Size(121, 23);
            this.textBox_file_path.TabIndex = 5;
            // 
            // button_file_search
            // 
            this.button_file_search.Location = new System.Drawing.Point(212, 4);
            this.button_file_search.Name = "button_file_search";
            this.button_file_search.Size = new System.Drawing.Size(75, 62);
            this.button_file_search.TabIndex = 6;
            this.button_file_search.Text = "파일찾기";
            this.button_file_search.UseVisualStyleBackColor = true;
            this.button_file_search.Click += new System.EventHandler(this.button_file_search_Click);
            // 
            // button_TCP
            // 
            this.button_TCP.Location = new System.Drawing.Point(212, 72);
            this.button_TCP.Name = "button_TCP";
            this.button_TCP.Size = new System.Drawing.Size(75, 36);
            this.button_TCP.TabIndex = 7;
            this.button_TCP.Text = "TCP_TEST";
            this.button_TCP.UseVisualStyleBackColor = true;
            this.button_TCP.Click += new System.EventHandler(this.button_TCP_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(306, 118);
            this.Controls.Add(this.button_TCP);
            this.Controls.Add(this.button_file_search);
            this.Controls.Add(this.textBox_file_path);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox_type);
            this.Controls.Add(this.textBox_server_IP);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_server_IP;
        private System.Windows.Forms.ComboBox comboBox_type;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_file_path;
        private System.Windows.Forms.Button button_file_search;
        private System.Windows.Forms.Button button_TCP;
    }
}

