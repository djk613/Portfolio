
namespace TCP_SERVER
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
            this.button_server_run = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBox_test = new System.Windows.Forms.CheckBox();
            this.textBox_IP = new System.Windows.Forms.TextBox();
            this.textBox_port = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button_server_run
            // 
            this.button_server_run.Location = new System.Drawing.Point(166, 4);
            this.button_server_run.Name = "button_server_run";
            this.button_server_run.Size = new System.Drawing.Size(98, 76);
            this.button_server_run.TabIndex = 0;
            this.button_server_run.Text = "서버가동";
            this.button_server_run.UseVisualStyleBackColor = true;
            this.button_server_run.Click += new System.EventHandler(this.button_server_run_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "IPv4";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "PORT";
            // 
            // checkBox_test
            // 
            this.checkBox_test.AutoSize = true;
            this.checkBox_test.Location = new System.Drawing.Point(12, 64);
            this.checkBox_test.Name = "checkBox_test";
            this.checkBox_test.Size = new System.Drawing.Size(47, 19);
            this.checkBox_test.TabIndex = 3;
            this.checkBox_test.Text = "Test";
            this.checkBox_test.UseVisualStyleBackColor = true;
            // 
            // textBox_IP
            // 
            this.textBox_IP.Location = new System.Drawing.Point(48, 6);
            this.textBox_IP.Name = "textBox_IP";
            this.textBox_IP.Size = new System.Drawing.Size(100, 23);
            this.textBox_IP.TabIndex = 4;
            // 
            // textBox_port
            // 
            this.textBox_port.Location = new System.Drawing.Point(48, 35);
            this.textBox_port.Name = "textBox_port";
            this.textBox_port.Size = new System.Drawing.Size(100, 23);
            this.textBox_port.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(276, 92);
            this.Controls.Add(this.textBox_port);
            this.Controls.Add(this.textBox_IP);
            this.Controls.Add(this.checkBox_test);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_server_run);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_server_run;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBox_test;
        private System.Windows.Forms.TextBox textBox_IP;
        private System.Windows.Forms.TextBox textBox_port;
    }
}

