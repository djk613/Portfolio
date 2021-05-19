
namespace WorkManager
{
    partial class Login
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
            this.button_login = new System.Windows.Forms.Button();
            this.textBox_PW = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_ID = new System.Windows.Forms.TextBox();
            this.button_create_ID = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.button_change_PW = new System.Windows.Forms.Button();
            this.comboBox_mode = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button_login
            // 
            this.button_login.Location = new System.Drawing.Point(183, 11);
            this.button_login.Name = "button_login";
            this.button_login.Size = new System.Drawing.Size(75, 53);
            this.button_login.TabIndex = 11;
            this.button_login.Text = "로그인";
            this.button_login.UseVisualStyleBackColor = true;
            this.button_login.Click += new System.EventHandler(this.button_login_Click);
            // 
            // textBox_PW
            // 
            this.textBox_PW.Location = new System.Drawing.Point(68, 41);
            this.textBox_PW.Name = "textBox_PW";
            this.textBox_PW.PasswordChar = '*';
            this.textBox_PW.Size = new System.Drawing.Size(109, 23);
            this.textBox_PW.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 15);
            this.label2.TabIndex = 9;
            this.label2.Text = "비밀번호";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 15);
            this.label1.TabIndex = 8;
            this.label1.Text = "아이디";
            // 
            // textBox_ID
            // 
            this.textBox_ID.Location = new System.Drawing.Point(68, 12);
            this.textBox_ID.Name = "textBox_ID";
            this.textBox_ID.Size = new System.Drawing.Size(109, 23);
            this.textBox_ID.TabIndex = 7;
            // 
            // button_create_ID
            // 
            this.button_create_ID.Location = new System.Drawing.Point(183, 99);
            this.button_create_ID.Name = "button_create_ID";
            this.button_create_ID.Size = new System.Drawing.Size(75, 23);
            this.button_create_ID.TabIndex = 12;
            this.button_create_ID.Text = "계정생성";
            this.button_create_ID.UseVisualStyleBackColor = true;
            this.button_create_ID.Click += new System.EventHandler(this.button_create_ID_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Buxton Sketch", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(21, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(146, 29);
            this.label3.TabIndex = 13;
            this.label3.Text = "Work Manager";
            // 
            // button_change_PW
            // 
            this.button_change_PW.Location = new System.Drawing.Point(183, 70);
            this.button_change_PW.Name = "button_change_PW";
            this.button_change_PW.Size = new System.Drawing.Size(75, 23);
            this.button_change_PW.TabIndex = 14;
            this.button_change_PW.Text = "암호변경";
            this.button_change_PW.UseVisualStyleBackColor = true;
            this.button_change_PW.Click += new System.EventHandler(this.button_change_PW_Click);
            // 
            // comboBox_mode
            // 
            this.comboBox_mode.FormattingEnabled = true;
            this.comboBox_mode.Location = new System.Drawing.Point(68, 71);
            this.comboBox_mode.Name = "comboBox_mode";
            this.comboBox_mode.Size = new System.Drawing.Size(109, 23);
            this.comboBox_mode.TabIndex = 15;
            this.comboBox_mode.SelectedIndexChanged += new System.EventHandler(this.comboBox_mode_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 15);
            this.label4.TabIndex = 16;
            this.label4.Text = "모드";
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(272, 134);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBox_mode);
            this.Controls.Add(this.button_change_PW);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button_create_ID);
            this.Controls.Add(this.button_login);
            this.Controls.Add(this.textBox_PW);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_ID);
            this.Name = "Login";
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Login_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_login;
        private System.Windows.Forms.TextBox textBox_PW;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_ID;
        private System.Windows.Forms.Button button_create_ID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button_change_PW;
        private System.Windows.Forms.ComboBox comboBox_mode;
        private System.Windows.Forms.Label label4;
    }
}