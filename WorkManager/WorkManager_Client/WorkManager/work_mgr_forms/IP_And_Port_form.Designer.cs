
namespace WorkManager
{
    partial class IP_And_Port_form
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
            this.button_OK = new System.Windows.Forms.Button();
            this.textBox_DB_port = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_DB_IP = new System.Windows.Forms.TextBox();
            this.checkBox_localhost = new System.Windows.Forms.CheckBox();
            this.button_cancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_File_IP = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_File_port = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_OK
            // 
            this.button_OK.Location = new System.Drawing.Point(206, 20);
            this.button_OK.Name = "button_OK";
            this.button_OK.Size = new System.Drawing.Size(75, 67);
            this.button_OK.TabIndex = 16;
            this.button_OK.Text = "접속";
            this.button_OK.UseVisualStyleBackColor = true;
            this.button_OK.Click += new System.EventHandler(this.button_OK_Click);
            // 
            // textBox_DB_port
            // 
            this.textBox_DB_port.Location = new System.Drawing.Point(62, 45);
            this.textBox_DB_port.Name = "textBox_DB_port";
            this.textBox_DB_port.Size = new System.Drawing.Size(109, 23);
            this.textBox_DB_port.TabIndex = 15;
            this.textBox_DB_port.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_port_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 15);
            this.label2.TabIndex = 14;
            this.label2.Text = "Port";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 15);
            this.label1.TabIndex = 13;
            this.label1.Text = "Server IP";
            // 
            // textBox_DB_IP
            // 
            this.textBox_DB_IP.Location = new System.Drawing.Point(62, 16);
            this.textBox_DB_IP.Name = "textBox_DB_IP";
            this.textBox_DB_IP.Size = new System.Drawing.Size(109, 23);
            this.textBox_DB_IP.TabIndex = 12;
            this.textBox_DB_IP.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_IP_KeyPress);
            // 
            // checkBox_localhost
            // 
            this.checkBox_localhost.AutoSize = true;
            this.checkBox_localhost.Location = new System.Drawing.Point(12, 169);
            this.checkBox_localhost.Name = "checkBox_localhost";
            this.checkBox_localhost.Size = new System.Drawing.Size(174, 19);
            this.checkBox_localhost.TabIndex = 17;
            this.checkBox_localhost.Text = "localhost 및 임의 포트 사용";
            this.checkBox_localhost.UseVisualStyleBackColor = true;
            this.checkBox_localhost.CheckedChanged += new System.EventHandler(this.checkBox_localhost_CheckedChanged);
            // 
            // button_cancel
            // 
            this.button_cancel.Location = new System.Drawing.Point(206, 99);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(75, 64);
            this.button_cancel.TabIndex = 18;
            this.button_cancel.Text = "Local 모드";
            this.button_cancel.UseVisualStyleBackColor = true;
            this.button_cancel.Click += new System.EventHandler(this.button_cancel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBox_DB_IP);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBox_DB_port);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(188, 75);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "DB_Server";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.textBox_File_IP);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.textBox_File_port);
            this.groupBox2.Location = new System.Drawing.Point(12, 88);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(188, 75);
            this.groupBox2.TabIndex = 25;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "DB_Server";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 15);
            this.label3.TabIndex = 13;
            this.label3.Text = "Server IP";
            // 
            // textBox_File_IP
            // 
            this.textBox_File_IP.Location = new System.Drawing.Point(62, 16);
            this.textBox_File_IP.Name = "textBox_File_IP";
            this.textBox_File_IP.Size = new System.Drawing.Size(109, 23);
            this.textBox_File_IP.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 49);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 15);
            this.label6.TabIndex = 14;
            this.label6.Text = "Port";
            // 
            // textBox_File_port
            // 
            this.textBox_File_port.Location = new System.Drawing.Point(62, 45);
            this.textBox_File_port.Name = "textBox_File_port";
            this.textBox_File_port.Size = new System.Drawing.Size(109, 23);
            this.textBox_File_port.TabIndex = 15;
            // 
            // IP_And_Port_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(290, 197);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button_cancel);
            this.Controls.Add(this.checkBox_localhost);
            this.Controls.Add(this.button_OK);
            this.Name = "IP_And_Port_form";
            this.Text = "IPAndPortForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_OK;
        private System.Windows.Forms.TextBox textBox_DB_port;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_DB_IP;
        private System.Windows.Forms.CheckBox checkBox_localhost;
        private System.Windows.Forms.Button button_cancel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_File_IP;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_File_port;
    }
}