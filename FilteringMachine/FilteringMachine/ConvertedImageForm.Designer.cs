
namespace FilteringMachine
{
    partial class ConvertedImageForm
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
            this.pictureBoxConvertedImage = new System.Windows.Forms.PictureBox();
            this.buttonSaveImage = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxConvertedImage)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxConvertedImage
            // 
            this.pictureBoxConvertedImage.Location = new System.Drawing.Point(12, 12);
            this.pictureBoxConvertedImage.Name = "pictureBoxConvertedImage";
            this.pictureBoxConvertedImage.Size = new System.Drawing.Size(400, 400);
            this.pictureBoxConvertedImage.TabIndex = 0;
            this.pictureBoxConvertedImage.TabStop = false;
            // 
            // buttonSaveImage
            // 
            this.buttonSaveImage.Font = new System.Drawing.Font("맑은 고딕", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonSaveImage.Location = new System.Drawing.Point(206, 418);
            this.buttonSaveImage.Name = "buttonSaveImage";
            this.buttonSaveImage.Size = new System.Drawing.Size(100, 25);
            this.buttonSaveImage.TabIndex = 1;
            this.buttonSaveImage.Text = "이미지 저장";
            this.buttonSaveImage.UseVisualStyleBackColor = true;
            this.buttonSaveImage.Click += new System.EventHandler(this.buttonSaveImage_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Font = new System.Drawing.Font("맑은 고딕", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonCancel.Location = new System.Drawing.Point(312, 418);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(100, 25);
            this.buttonCancel.TabIndex = 2;
            this.buttonCancel.Text = "이미지 수정 취소";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // ConvertedImageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 452);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSaveImage);
            this.Controls.Add(this.pictureBoxConvertedImage);
            this.Name = "ConvertedImageForm";
            this.Text = "ConvertedImageForm";
            this.Load += new System.EventHandler(this.ConvertedImageForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxConvertedImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxConvertedImage;
        private System.Windows.Forms.Button buttonSaveImage;
        private System.Windows.Forms.Button buttonCancel;
    }
}