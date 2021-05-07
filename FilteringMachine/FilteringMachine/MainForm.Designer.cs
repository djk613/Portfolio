
namespace FilteringMachine
{
    partial class MainForm
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
            this.pictureBoxOriginal = new System.Windows.Forms.PictureBox();
            this.groupBoxFilterType = new System.Windows.Forms.GroupBox();
            this.radioButtonGaussian = new System.Windows.Forms.RadioButton();
            this.radioButtonSharp = new System.Windows.Forms.RadioButton();
            this.radioButtonLaplacian = new System.Windows.Forms.RadioButton();
            this.radioButtonMean = new System.Windows.Forms.RadioButton();
            this.groupBoxExtensionType = new System.Windows.Forms.GroupBox();
            this.radioButtonTypePNG = new System.Windows.Forms.RadioButton();
            this.radioButtonTypeJPG = new System.Windows.Forms.RadioButton();
            this.radioButtonTypeBMP = new System.Windows.Forms.RadioButton();
            this.buttonFileOpen = new System.Windows.Forms.Button();
            this.buttonImageConvert = new System.Windows.Forms.Button();
            this.progressBarImageProcessing = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOriginal)).BeginInit();
            this.groupBoxFilterType.SuspendLayout();
            this.groupBoxExtensionType.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBoxOriginal
            // 
            this.pictureBoxOriginal.Location = new System.Drawing.Point(12, 12);
            this.pictureBoxOriginal.Name = "pictureBoxOriginal";
            this.pictureBoxOriginal.Size = new System.Drawing.Size(400, 400);
            this.pictureBoxOriginal.TabIndex = 2;
            this.pictureBoxOriginal.TabStop = false;
            // 
            // groupBoxFilterType
            // 
            this.groupBoxFilterType.Controls.Add(this.radioButtonGaussian);
            this.groupBoxFilterType.Controls.Add(this.radioButtonSharp);
            this.groupBoxFilterType.Controls.Add(this.radioButtonLaplacian);
            this.groupBoxFilterType.Controls.Add(this.radioButtonMean);
            this.groupBoxFilterType.Location = new System.Drawing.Point(423, 5);
            this.groupBoxFilterType.Name = "groupBoxFilterType";
            this.groupBoxFilterType.Size = new System.Drawing.Size(133, 123);
            this.groupBoxFilterType.TabIndex = 3;
            this.groupBoxFilterType.TabStop = false;
            this.groupBoxFilterType.Text = "필터종류";
            // 
            // radioButtonGaussian
            // 
            this.radioButtonGaussian.AutoSize = true;
            this.radioButtonGaussian.Location = new System.Drawing.Point(7, 94);
            this.radioButtonGaussian.Name = "radioButtonGaussian";
            this.radioButtonGaussian.Size = new System.Drawing.Size(73, 19);
            this.radioButtonGaussian.TabIndex = 7;
            this.radioButtonGaussian.TabStop = true;
            this.radioButtonGaussian.Text = "가우시안";
            this.radioButtonGaussian.UseVisualStyleBackColor = true;
            // 
            // radioButtonSharp
            // 
            this.radioButtonSharp.AutoSize = true;
            this.radioButtonSharp.Location = new System.Drawing.Point(7, 68);
            this.radioButtonSharp.Name = "radioButtonSharp";
            this.radioButtonSharp.Size = new System.Drawing.Size(49, 19);
            this.radioButtonSharp.TabIndex = 6;
            this.radioButtonSharp.TabStop = true;
            this.radioButtonSharp.Text = "샤프";
            this.radioButtonSharp.UseVisualStyleBackColor = true;
            // 
            // radioButtonLaplacian
            // 
            this.radioButtonLaplacian.AutoSize = true;
            this.radioButtonLaplacian.Location = new System.Drawing.Point(7, 42);
            this.radioButtonLaplacian.Name = "radioButtonLaplacian";
            this.radioButtonLaplacian.Size = new System.Drawing.Size(85, 19);
            this.radioButtonLaplacian.TabIndex = 5;
            this.radioButtonLaplacian.TabStop = true;
            this.radioButtonLaplacian.Text = "라플라시안";
            this.radioButtonLaplacian.UseVisualStyleBackColor = true;
            // 
            // radioButtonMean
            // 
            this.radioButtonMean.AutoSize = true;
            this.radioButtonMean.Location = new System.Drawing.Point(7, 18);
            this.radioButtonMean.Name = "radioButtonMean";
            this.radioButtonMean.Size = new System.Drawing.Size(61, 19);
            this.radioButtonMean.TabIndex = 1;
            this.radioButtonMean.TabStop = true;
            this.radioButtonMean.Text = "평균값";
            this.radioButtonMean.UseVisualStyleBackColor = true;
            // 
            // groupBoxExtensionType
            // 
            this.groupBoxExtensionType.Controls.Add(this.radioButtonTypePNG);
            this.groupBoxExtensionType.Controls.Add(this.radioButtonTypeJPG);
            this.groupBoxExtensionType.Controls.Add(this.radioButtonTypeBMP);
            this.groupBoxExtensionType.Location = new System.Drawing.Point(423, 134);
            this.groupBoxExtensionType.Name = "groupBoxExtensionType";
            this.groupBoxExtensionType.Size = new System.Drawing.Size(133, 103);
            this.groupBoxExtensionType.TabIndex = 4;
            this.groupBoxExtensionType.TabStop = false;
            this.groupBoxExtensionType.Text = "이미지 확장자";
            // 
            // radioButtonTypePNG
            // 
            this.radioButtonTypePNG.AutoSize = true;
            this.radioButtonTypePNG.Location = new System.Drawing.Point(7, 75);
            this.radioButtonTypePNG.Name = "radioButtonTypePNG";
            this.radioButtonTypePNG.Size = new System.Drawing.Size(49, 19);
            this.radioButtonTypePNG.TabIndex = 2;
            this.radioButtonTypePNG.Text = "PNG";
            this.radioButtonTypePNG.UseVisualStyleBackColor = true;
            // 
            // radioButtonTypeJPG
            // 
            this.radioButtonTypeJPG.AutoSize = true;
            this.radioButtonTypeJPG.Location = new System.Drawing.Point(7, 49);
            this.radioButtonTypeJPG.Name = "radioButtonTypeJPG";
            this.radioButtonTypeJPG.Size = new System.Drawing.Size(50, 19);
            this.radioButtonTypeJPG.TabIndex = 1;
            this.radioButtonTypeJPG.Text = "JPEG";
            this.radioButtonTypeJPG.UseVisualStyleBackColor = true;
            // 
            // radioButtonTypeBMP
            // 
            this.radioButtonTypeBMP.AutoSize = true;
            this.radioButtonTypeBMP.Location = new System.Drawing.Point(7, 23);
            this.radioButtonTypeBMP.Name = "radioButtonTypeBMP";
            this.radioButtonTypeBMP.Size = new System.Drawing.Size(50, 19);
            this.radioButtonTypeBMP.TabIndex = 0;
            this.radioButtonTypeBMP.Text = "BMP";
            this.radioButtonTypeBMP.UseVisualStyleBackColor = true;
            // 
            // buttonFileOpen
            // 
            this.buttonFileOpen.Location = new System.Drawing.Point(423, 313);
            this.buttonFileOpen.Name = "buttonFileOpen";
            this.buttonFileOpen.Size = new System.Drawing.Size(133, 31);
            this.buttonFileOpen.TabIndex = 5;
            this.buttonFileOpen.Text = "파일열기";
            this.buttonFileOpen.UseVisualStyleBackColor = true;
            this.buttonFileOpen.Click += new System.EventHandler(this.buttonFileOpen_Click);
            // 
            // buttonImageConvert
            // 
            this.buttonImageConvert.Location = new System.Drawing.Point(423, 350);
            this.buttonImageConvert.Name = "buttonImageConvert";
            this.buttonImageConvert.Size = new System.Drawing.Size(133, 31);
            this.buttonImageConvert.TabIndex = 6;
            this.buttonImageConvert.Text = "이미지변환";
            this.buttonImageConvert.UseVisualStyleBackColor = true;
            this.buttonImageConvert.Click += new System.EventHandler(this.buttonImageConvert_Click);
            // 
            // progressBarImageProcessing
            // 
            this.progressBarImageProcessing.Location = new System.Drawing.Point(423, 390);
            this.progressBarImageProcessing.Name = "progressBarImageProcessing";
            this.progressBarImageProcessing.Size = new System.Drawing.Size(133, 22);
            this.progressBarImageProcessing.TabIndex = 7;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 423);
            this.Controls.Add(this.progressBarImageProcessing);
            this.Controls.Add(this.buttonImageConvert);
            this.Controls.Add(this.buttonFileOpen);
            this.Controls.Add(this.groupBoxExtensionType);
            this.Controls.Add(this.groupBoxFilterType);
            this.Controls.Add(this.pictureBoxOriginal);
            this.Name = "MainForm";
            this.Text = "이미지 필터링";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOriginal)).EndInit();
            this.groupBoxFilterType.ResumeLayout(false);
            this.groupBoxFilterType.PerformLayout();
            this.groupBoxExtensionType.ResumeLayout(false);
            this.groupBoxExtensionType.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxOriginal;
        private System.Windows.Forms.GroupBox groupBoxFilterType;
        private System.Windows.Forms.RadioButton radioButtonSharp;
        private System.Windows.Forms.RadioButton radioButtonLaplacian;
        private System.Windows.Forms.RadioButton radioButtonMean;
        private System.Windows.Forms.GroupBox groupBoxExtensionType;
        private System.Windows.Forms.RadioButton radioButtonTypePNG;
        private System.Windows.Forms.RadioButton radioButtonTypeJPG;
        private System.Windows.Forms.RadioButton radioButtonTypeBMP;
        private System.Windows.Forms.Button buttonFileOpen;
        private System.Windows.Forms.Button buttonImageConvert;
        private System.Windows.Forms.RadioButton radioButtonGaussian;
        private System.Windows.Forms.ProgressBar progressBarImageProcessing;
    }
}

