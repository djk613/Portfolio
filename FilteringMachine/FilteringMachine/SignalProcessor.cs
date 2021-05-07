using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace FilteringMachine
{
    public static class FilterProcessor
    {
        public static float[] GetGaussianFilter1D(float sigma)
        {
            int nFilterCount = getGaussianFilterCount(ref sigma);
            int nFilterMid = (nFilterCount - 1) / 2;

            int[] listPosValues = new int[nFilterCount];
            float[] listFilterValues = new float[nFilterCount];

            for (int i = 0; i < nFilterCount; i++)
            { 
                listPosValues[i] = Math.Abs(i - nFilterMid);
            }

            for (int i = 0; i < nFilterCount; i++)
            {
                listFilterValues[i] = getGaussianFilterValue1D(sigma, listPosValues[i]);
            }

            return listFilterValues;
        }

        public static float[] Convolve1D(float[] signal, float[] filter)
        {
            float[] result = new float[signal.Length];
            
            int nMidFilter = (int)Math.Round((filter.Length - 1.0f) / 2.0f);

            for (int i = 0; i < signal.Length; i++)
            {
                float fValue = 0.0f;

                for (int j = 0; j < filter.Length; j++)
                {
                    int nIdx = i - j + nMidFilter;

                    if (0 <= nIdx && nIdx < signal.Length)
                    {
                        fValue += signal[nIdx] * filter[j];
                    }
                }
                result[i] = fValue;
            }

            return result;
        }

        public static float[,] GetGaussianFilter2D(float sigma)
        {
            int nFilterCount = getGaussianFilterCount(ref sigma);
            int nFilterMid = (nFilterCount - 1) / 2;

            Point[,] listPosValues = new Point[nFilterCount, nFilterCount];
            float[,] listFilterValues = new float[nFilterCount, nFilterCount];

            for (int x = 0; x < nFilterCount; x++)
            {
                for (int y = 0; y < nFilterCount; y++)
                {
                    listPosValues[x, y] = new Point(Math.Abs(x - nFilterMid), Math.Abs(y - nFilterMid));
                }
            }

            for (int x = 0; x < nFilterCount; x++)
            {
                for (int y = 0; y < nFilterCount; y++)
                {
                    listFilterValues[x, y] = getGaussianFilterValue2D(sigma, listPosValues[x, y]);
                }
            }

            return listFilterValues;
        }
        private static int getGaussianFilterCount(ref float sigma)
        {
            const float FGARRAYRATE = 6.0f;
            int nCount = (int)(Math.Ceiling(sigma * FGARRAYRATE));

            if (nCount % 2 == 0)
                nCount++;

            return nCount;
        }

        /*Fomula for yiedling gaussian mask*/
        private static float getGaussianFilterValue1D(double sigma, int nPosValue)
        {
            double Process1 = Math.Pow(sigma, 2.0);
            double Process2 = 2.0 * Process1;
            double Process3 = -Math.Pow(nPosValue, 2.0) / Process2;

            double Process4 = Math.Exp(Process3);
            double Process5 = 1.0 / (sigma * Math.Sqrt(2.0 * Math.PI));

            double Process6 = Process4 * Process5;

            return (float)Process6;
        }

        /*Fomula for yiedling gaussian mask*/
        private static float getGaussianFilterValue2D(double sigma, Point pos)
        {
            double process1 = -(Math.Pow(pos.X, 2.0) + Math.Pow(pos.Y, 2.0));
            double process2 = 2.0f * Math.Pow(sigma, 2.0);
            double process3 = Math.Exp(process1 / process2);

            double process4 = 1.0 / (2.0 * Math.PI * Math.Pow(sigma, 2.0));

            double process5 = process3 * process4;

            return (float)process5;
        }

        public static float[,] GetMeanFilter(uint filterMaskHeight, uint filterMaskWidth)
        {
            float maskArea = Convert.ToSingle(filterMaskHeight * filterMaskWidth); 

            float[,] listFilterValues = new float[filterMaskHeight, filterMaskWidth];

            for(int i = 0; i < filterMaskHeight; i++)
            {
                for(int j = 0; j < filterMaskWidth; j++)
                {
                    listFilterValues[i, j] = 1.0f / maskArea;
                }
            }

            return listFilterValues;
        }

        public static float[,] GetLaplacianFilter()
        {
            float[,] listFilterValues = new float[3, 3]
            {
                { 0.0f,   1.0f,   0.0f},
                { 1.0f,  -3.0f,   1.0f},
                { 0.0f,   1.0f,   0.0f}
            };

            return listFilterValues;
        }

        public static float[,] GetSharpFilter()
        {
            float[,] listFilterValues = new float[3, 3]
            {
                { 0.0f,   -1.0f,   0.0f},
                {-1.0f,    5.0f,  -1.0f},
                { 0.0f,   -1.0f,   0.0f}
            };

            return listFilterValues;
        }


        public static Bitmap ConvolveImage(Bitmap bitmap, float[,] filter)
        {
            Bitmap result = new Bitmap(bitmap);

            int nMidFilter = (int)Math.Round((Math.Sqrt(filter.Length) - 1.0f) / 2.0f);

            for (int x = 0; x < bitmap.Width; x++)
            {
                for (int y = 0; y < bitmap.Height; y++)
                {
                    float fRedResult = 0.0f;
                    float fGreenResult = 0.0f;
                    float fBlueResult = 0.0f;

                    for (int nFilter_X = 0; nFilter_X < filter.GetLength(0); nFilter_X++)
                    {
                        for (int nFilter_Y = 0; nFilter_Y < filter.GetLength(0); nFilter_Y++)
                        {
                            int nIndexX = x - nFilter_X + nMidFilter;
                            int nIndexY = y - nFilter_Y + nMidFilter;

                            if ((nIndexX < 0 || nIndexY < 0) || (nIndexX >= bitmap.Width || nIndexY >= bitmap.Height))
                                continue;

                            Color pixcelColor = bitmap.GetPixel(nIndexX, nIndexY);

                            int nRed = pixcelColor.R;
                            int nGreen = pixcelColor.G;
                            int nBlue = pixcelColor.B;

                            fRedResult += nRed * filter[nFilter_Y, nFilter_X];
                            fGreenResult += nGreen * filter[nFilter_Y, nFilter_X];
                            fBlueResult += nBlue * filter[nFilter_Y, nFilter_X];
                        }
                    }

                    fRedResult = Math.Clamp(fRedResult, 0.0f, 255.0f);
                    fGreenResult = Math.Clamp(fGreenResult, 0.0f, 255.0f);
                    fBlueResult = Math.Clamp(fBlueResult, 0.0f, 255.0f);

                    Color resultColor = Color.FromArgb((int)(fRedResult), (int)(fGreenResult), (int)(fBlueResult));
                    result.SetPixel(x, y, resultColor);

                }
            }

            return result;
        }

        
    }
}
