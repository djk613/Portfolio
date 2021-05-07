using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FilteringMachine
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            radioButtonMean.Checked = true;
            radioButtonTypeBMP.Checked = true;
        }

        private void buttonFileOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog opdiag = new OpenFileDialog();
            opdiag.Title = "이미지파일 열기";
            opdiag.Filter = "Image (*.bmp, *.jpg, *.png) | *.bmp; *.jpg; *.png;";

            if(opdiag.ShowDialog() == DialogResult.OK)
            {
                ShowImage(opdiag.FileName);

            }
        }

        public void ShowImage(string imageFileName)
        {
            Image img = Image.FromFile(imageFileName);

            pictureBoxOriginal.BackColor = Color.DimGray;
            pictureBoxOriginal.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxOriginal.Image = img.GetThumbnailImage(2000, 2000, null, IntPtr.Zero);

            Variables.strLoadingImageFile = imageFileName;
        }

        private void buttonImageConvert_Click(object sender, EventArgs e)
        {
            /*If image is not loaded, conversion of the image is not going to be done..*/
            if (String.IsNullOrEmpty(Variables.strLoadingImageFile))
            {
                MessageBox.Show("우선 이미지파일을 먼저 등록하여 주세요.");
                return;
            }

            if(radioButtonMean.Checked)
            {
                Variables.filterType = Variables.FilterType.Mean;
            } 
            else if (radioButtonLaplacian.Checked)
            {
                Variables.filterType = Variables.FilterType.Laplacian;
            }
            else if (radioButtonSharp.Checked)
            {
                Variables.filterType = Variables.FilterType.Sharp;
            }
            else if (radioButtonGaussian.Checked)
            {
                Variables.filterType = Variables.FilterType.Gaussian;
            }

            if (radioButtonTypeBMP.Checked)
            {
                Variables.imageType = Variables.ImageType.BMP;
            }
            else if (radioButtonTypeJPG.Checked)
            {
                Variables.imageType = Variables.ImageType.JPEG;
            }
            else if (radioButtonTypePNG.Checked)
            {
                Variables.imageType = Variables.ImageType.PNG;
            }

            ConvertedImageForm convertedImageForm = new ConvertedImageForm();
            convertedImageForm.ShowDialog();

        }

    }
}
