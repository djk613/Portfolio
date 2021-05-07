using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace FilteringMachine
{
    public partial class ConvertedImageForm : Form
    {
        public ConvertedImageForm()
        {
            InitializeComponent();
            ConvertImage();
        }

        private void ConvertedImageForm_Load(object sender, EventArgs e)
        {
            
        }

        public void ConvertImage()
        {
            FileStream fs = File.OpenRead(Variables.strLoadingImageFile);
            Bitmap image = new Bitmap(fs);

            float[,] filter2D;

            if (Variables.filterType == Variables.FilterType.Mean)
            {
                filter2D = FilterProcessor.GetMeanFilter(3, 3);
            }
            else if (Variables.filterType == Variables.FilterType.Laplacian)
            {
                filter2D = FilterProcessor.GetLaplacianFilter();
            }
            else if (Variables.filterType == Variables.FilterType.Sharp)
            {
                filter2D = FilterProcessor.GetSharpFilter();
            }
            else if (Variables.filterType == Variables.FilterType.Gaussian)
            {
                filter2D = FilterProcessor.GetGaussianFilter2D(0.6f);
            }
            else
            {
                return;
            }

            Variables.newImage = FilterProcessor.ConvolveImage(image, filter2D);
            
            pictureBoxConvertedImage.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxConvertedImage.BackColor = Color.DimGray;
            pictureBoxConvertedImage.Image = Variables.newImage.GetThumbnailImage(2000, 2000, null, IntPtr.Zero);
            
        }

        private void buttonSaveImage_Click(object sender, EventArgs e)
        {
            ImageFormat extensionType;

            if (Variables.imageType == Variables.ImageType.BMP)
            {
                extensionType = ImageFormat.Bmp;
            }
            else if (Variables.imageType == Variables.ImageType.JPEG)
            {
                extensionType = ImageFormat.Jpeg;
            }
            else if (Variables.imageType == Variables.ImageType.PNG)
            {
                extensionType = ImageFormat.Png;
            }
            else
            {
                return;
            }

            Variables.newImage.Save($"{Path.GetFileNameWithoutExtension(Variables.strLoadingImageFile)}_gaussian.bmp", extensionType);
            Variables.newImage.Dispose();

            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
