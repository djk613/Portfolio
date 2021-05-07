using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;

namespace FilteringMachine
{
    static public class Variables
    { 
        public enum FilterType
        {
            Mean = 0,
            Laplacian,
            Sharp,
            Gaussian
        }

        public enum ImageType
        {
            BMP = 0,
            JPEG,
            PNG
        }

        static public FilterType filterType = FilterType.Mean;
        static public ImageType imageType = ImageType.BMP;
        static public string strLoadingImageFile { get; set; } = new string("");
        static public Bitmap newImage { get; set; }
    }
}
