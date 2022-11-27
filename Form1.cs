using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace обработка_изображений_1
{
    public partial class Form1 : Form
    {
        Bitmap image;
        Bitmap prevImage;
        Bitmap firstImage;
        public Form1()
        {
            InitializeComponent();
        }

        public int Clamp(int value, int min, int max)
        {
            if (value < min)
                return min;
            if (value > max)
                return max;
            return value;
        }

        private Color GlobalThresholdcalculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color sourceColor = sourceImage.GetPixel(x, y);
            Color resultColor;
            if (sourceColor.R > 127)
                resultColor = Color.FromArgb(255, 255, 255);
            else
                resultColor = Color.FromArgb(0, 0, 0);
            return resultColor;
        }

        public static int[] HistogrammcalculateNewPixelColor(Bitmap sourceImage)
        {
            int[] result = new int[256];

            for (int i = 0; i < sourceImage.Height; i++)
                for (int j = 0; j < sourceImage.Width; j++)
                {
                    Color color = sourceImage.GetPixel(j, i);
                    result[color.R]++;
                }

            return result;
        }


        private void globalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap sourceImage = image;
            Bitmap resultImage = new Bitmap(sourceImage.Width, sourceImage.Height);

            //Вычислить гистограмму.
            int[] hist= HistogrammcalculateNewPixelColor(sourceImage);

            // Отсечь 5% от мин и макс пикселей.

            int sumHist = hist.Sum();
            int cut = (int)(sumHist * 0.05); // 5% 

            for (int i = 0; i < 255; i++)
            {
                if (hist[i] < cut)
                {
                    cut -= hist[i];
                    hist[i] = 0;
                }
                else
                {
                    hist[i] -= cut;
                }
                if (cut == 0) break;

            }

            cut = (int)(sumHist * 0.05);

            for (int i = 255; i < 0; i--)
            {
                if (hist[i] < cut)
                {
                    cut -= hist[i];
                    hist[i] = 0;
                }
                else
                {
                    hist[i] -= cut;
                }
                if (cut == 0) break;

            }

            // Найти взвешенное среднее
            int t = 0;

            int weight = 0;
            for (int i = 0; i < 255; i++)
            {
                if (hist[i] == 0) continue;

                weight += hist[i] * i;
            }

            // Вычисление порога
            t = (int)(weight / hist.Sum());

            for (int y = 0; y < sourceImage.Height; y++)
                for (int x = 0; x < sourceImage.Width; x++)
                {
                    Color color = sourceImage.GetPixel(x, y);
                    if (color.R >= t) resultImage.SetPixel(x, y, Color.White);
                    else resultImage.SetPixel(x, y, Color.Black);

                }
            pictureBox1.Image = resultImage;
            pictureBox1.Refresh();
        }

        private Color NiblackcalculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            double avgSum = 0;
            double standardDev = 0;
            double avgStandardDev = 0;
            double k = -0.2;
            int sum = 0;
            int threshold = 0;
            int w = 5;
            int sqCount = (int)Math.Pow(w * 2 + 1, 2);

            for (int l = -w; l <= w; l++)
            {
                for (int m = -w; m <= w; m++)
                {

                    int idX = Clamp(x + m, 0, sourceImage.Width - 1);
                    int idY = Clamp(y + l, 0, sourceImage.Height - 1);
                    Color neighborColor = sourceImage.GetPixel(idX, idY);
                    sum += neighborColor.R;
                }
            }
            avgSum = sum / sqCount;
            for (int l = -w; l <= w; l++)
            {
                for (int m = -w; m <= w; m++)
                {
                    int idX = Clamp(x + m, 0, sourceImage.Width - 1);
                    int idY = Clamp(y + l, 0, sourceImage.Height - 1);
                    Color neighborColor = sourceImage.GetPixel(idX, idY);
                    standardDev += Math.Pow(neighborColor.R - avgSum, 2);
                }
            }
            avgStandardDev = Math.Sqrt(standardDev / sqCount);
            threshold = (int)(avgStandardDev * k + avgSum);
            if (sourceImage.GetPixel(x, y).R > threshold)
                return Color.FromArgb(255, 255, 255);
            else
                return Color.FromArgb(0, 0, 0);
        }

        private void globalThresholdToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Bitmap sourceImage = image;
            Bitmap resultImage = new Bitmap(sourceImage.Width, sourceImage.Height);
            for (int i = 0; i < sourceImage.Width; i++)
            {

                for (int j = 0; j < sourceImage.Height; j++)
                {
                    resultImage.SetPixel(i, j, GlobalThresholdcalculateNewPixelColor(sourceImage, i, j));
                }
            }

            pictureBox1.Image = resultImage;
            pictureBox1.Refresh();
        }

        private void niblackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap sourceImage = image;
            Bitmap resultImage = new Bitmap(sourceImage.Width, sourceImage.Height);
            for (int i = 0; i < sourceImage.Width; i++)
            {

                for (int j = 0; j < sourceImage.Height; j++)
                {
                    resultImage.SetPixel(i, j, NiblackcalculateNewPixelColor(sourceImage, i, j));
                }
            }

            pictureBox1.Image = resultImage;
            pictureBox1.Refresh();
        }


        private void загрузитьФайлToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image files | *.png; *.jpg; *.bmp | All Files (*.*) | *.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                image = new Bitmap(dialog.FileName);
                pictureBox1.Image = image;
                pictureBox1.Refresh();
                pictureBox2.Image = image;
                pictureBox2.Refresh();
            }
        }
        private void сохранитьФайлToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null) //если в pictureBox есть изображение
            {
                //создание диалогового окна "Сохранить как..", для сохранения изображения
                SaveFileDialog savedialog = new SaveFileDialog();
                savedialog.Title = "Сохранить как...";
                //отображать ли предупреждение, если пользователь указывает имя уже существующего файла
                savedialog.OverwritePrompt = true;
                //отображать ли предупреждение, если пользователь указывает несуществующий путь
                savedialog.CheckPathExists = true;
                //список форматов файла, отображаемый в поле "Тип файла"
                savedialog.Filter = "Image Files(*.BMP)|*.BMP|Image Files(*.JPG)|*.JPG|Image Files(*.GIF)|*.GIF|Image Files(*.PNG)|*.PNG|All files (*.*)|*.*";
                //отображается ли кнопка "Справка" в диалоговом окне
                savedialog.ShowHelp = true;
                if (savedialog.ShowDialog() == DialogResult.OK) //если в диалоговом окне нажата кнопка "ОК"
                {
                    try
                    {
                        pictureBox1.Image.Save(savedialog.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                    }
                    catch
                    {
                        MessageBox.Show("Невозможно сохранить изображение", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = pictureBox2.Image;
        }

        private void среднееГеометрическоеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            image = new Bitmap(pictureBox1.Image);
            Bitmap sourceImage = image;
            Bitmap resultImage = new Bitmap(sourceImage.Width, sourceImage.Height);
            for (int i = 0; i < sourceImage.Width; i++)
            {

                for (int j = 0; j < sourceImage.Height; j++)
                {
                    resultImage.SetPixel(i, j, GeomcalculateNewPixelColor(sourceImage, i, j));
                }
            }

            pictureBox1.Image = resultImage;
            pictureBox1.Refresh();
        }
        private Color GeomcalculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int radius = 1; // радиус матрицы
            int matrixSize = (1 + 2 * radius) * (1 + 2 * radius);

            float summBright = 1f; // сумма яркостей


            for (int i = -radius; i <= radius; i++)
                for (int j = -radius; j <= radius; j++)
                {
                    int idX = Clamp(x + j, 0, sourceImage.Width - 1);
                    int idY = Clamp(y + i, 0, sourceImage.Height - 1);
                    Color neighborColor = sourceImage.GetPixel(idX, idY);
                    summBright *= (byte)(.299 * neighborColor.R + .587 * neighborColor.G + .114 * neighborColor.B);
                }

            var result = (byte)Math.Pow(summBright, 1 / (float)matrixSize);
            return Color.FromArgb(result, result, result);
        }

        private void pSNRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            image = new Bitmap(pictureBox2.Image);
            Bitmap sourceImage = new Bitmap(pictureBox1.Image);
            Bitmap resultImage = new Bitmap(sourceImage.Width, sourceImage.Height);
            if (resultImage.Size != image.Size) MessageBox.Show("Error size"); ;
            float mse = PSNRcalculateNewPixelColor(resultImage, image);
            float psnr = (float)(20 * Math.Log10(255f / Math.Sqrt(mse)));
            //return psnr;
            MessageBox.Show(psnr.ToString());
        }

        private static float PSNRcalculateNewPixelColor(Bitmap resultImage, Bitmap sourceImage)
        {

            float sum = 0f;
            for (int i = 0; i < resultImage.Height; i++)
                for (int j = 0; j < resultImage.Width; j++)
                {
                    sum += (float)Math.Pow((resultImage.GetPixel(j, i).R - sourceImage.GetPixel(j, i).R), 2f);
                    sum += (float)Math.Pow((resultImage.GetPixel(j, i).G - sourceImage.GetPixel(j, i).G), 2f);
                    sum += (float)Math.Pow((resultImage.GetPixel(j, i).B - sourceImage.GetPixel(j, i).B), 2f);
                }
            return (sum / (float)(resultImage.Width * resultImage.Height * 3));
           
        }

        private void sSIMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            image = new Bitmap(pictureBox2.Image);
            Bitmap sourceImage = new Bitmap(pictureBox1.Image);
            Bitmap resultImage = new Bitmap(sourceImage.Width, sourceImage.Height);
            float L = (float)(Math.Pow(2, 8) - 1f);
            float k1 = 0.01f;
            float k2 = 0.03f;

            float c1 = (float)Math.Pow(L * k1, 2);
            float c2 = (float)Math.Pow(L * k2, 2);
            float ssim, dssim;

            float meanX = ComputeMean(image), meanY = ComputeMean(sourceImage);
            float disX = ComputeDis(image, meanX), disY = ComputeDis(sourceImage, meanY);
            float covXY = ComputeCov(image, meanX, sourceImage, meanY);

            ssim = (2 * meanX * meanY + c1) * (2 * covXY + c2) /
                    (float)((Math.Pow(meanX, 2) + Math.Pow(meanY, 2) + c1) *
                    (Math.Pow(disX, 2) + Math.Pow(disY, 2) + c2));

            dssim = (1 - ssim) / 2;
            MessageBox.Show(ssim.ToString());
            //// float comM = ComputeMean(resultImage);

            //float sum = 0f;
            //for (int i = 0; i < resultImage.Height; i++)
            //    for (int j = 0; j < resultImage.Width; j++)
            //    {
            //        Color color = resultImage.GetPixel(j, i);
            //        sum += ((byte)(.299 * color.R + .587 * color.G + .114 * color.B));
            //    }
            //float comM = sum / (resultImage.Width * resultImage.Height);



            ////float perfM = ComputeMean(image);

            //sum = 0f;
            //for (int i = 0; i < image.Height; i++)
            //    for (int j = 0; j < image.Width; j++)
            //    {
            //        Color color = image.GetPixel(j, i);
            //        sum += (byte)(.299 * color.R + .587 * color.G + .114 * color.B);
            //    }
            //float perfM = sum / (image.Width * image.Height);




            ////float comVar = ComputeVariance(resultImage, comM);

            //sum = 0f;
            //for (int i = 0; i < resultImage.Height; i++)
            //    for (int j = 0; j < resultImage.Width; j++)
            //    {
            //        Color color = resultImage.GetPixel(j, i);
            //        sum += (float)Math.Pow(((byte)(.299 * color.R + .587 * color.G + .114 * color.B) - comM), 2);
            //    }
            //float comVar = (float)Math.Sqrt(sum / ((image.Width * image.Height - 1)));






            //// float perfVar = ComputeVariance(image, perfM);

            //sum = 0f;
            //for (int i = 0; i < image.Height; i++)
            //    for (int j = 0; j < image.Width; j++)
            //    {
            //        Color color = image.GetPixel(j, i);
            //        sum += (float)Math.Pow(((byte)(.299 * color.R + .587 * color.G + .114 * color.B) - perfM), 2);
            //    }
            //float perfVar = (float)Math.Sqrt(sum / ((image.Width * image.Height - 1)));





            ////float covar = ComputeCovariance(resultImage, image, comM, perfM);
            //sum = 0f;
            //for (int i = 0; i < resultImage.Height; i++)
            //    for (int j = 0; j < resultImage.Width; j++)
            //    {
            //        Color color1 = resultImage.GetPixel(j, i);
            //        Color color2 = image.GetPixel(j, i);
            //        sum += ((byte)(.299 * color1.R + .587 * color1.G + .114 * color1.B) - comM) * ((byte)(.299 * color2.R + .587 * color2.G + .114 * color2.B)) - perfM;
            //    }
            //float covar = sum / ((resultImage.Width * resultImage.Height - 1));

            //float up = (2 * comM * perfM + c1) * (2 * covar + c2);
            //float down = (comM * comM + perfM * perfM + c1) *
            //        (comVar * comVar + perfVar * perfVar + c2);

            //float ssim = up / down;

            //MessageBox.Show(ssim.ToString());
        }

        private static float ComputeMean(Bitmap image)
        {
            float sum = 0f;
            for (int i = 0; i < image.Height; i++)
                for (int j = 0; j < image.Width; j++)
                {
                    sum += image.GetPixel(j, i).R;
                    sum += image.GetPixel(j, i).G;
                    sum += image.GetPixel(j, i).B;
                }
            return (sum / (float)(image.Height * image.Width * 3));
        }

        private static float ComputeDis(Bitmap image, float mean)
        {
            float sum = 0f;
            for (int i = 0; i < image.Height; i++)
                for (int j = 0; j < image.Width; j++)
                {
                    sum += (float)Math.Pow(image.GetPixel(j, i).R - mean, 2);
                    sum += (float)Math.Pow(image.GetPixel(j, i).G - mean, 2);
                    sum += (float)Math.Pow(image.GetPixel(j, i).B - mean, 2);
                }
            return (float)Math.Sqrt(sum / ((float)(image.Height * image.Width) - 1f) * 3);
        }

        private static float ComputeCov(Bitmap im1, float m1, Bitmap im2, float m2)
        {
            float sum = 0f;
            for (int i = 0; i < im1.Height; i++)
                for (int j = 0; j < im1.Width; j++)
                {
                    sum += (im1.GetPixel(j, i).R - m1) * (im2.GetPixel(j, i).R - m2);
                    sum += (im1.GetPixel(j, i).G - m1) * (im2.GetPixel(j, i).G - m2);
                    sum += (im1.GetPixel(j, i).B - m1) * (im2.GetPixel(j, i).B - m2);
                }
            return (sum / ((float)(im1.Height * im1.Width) - 1f) * 3);
        }

        private void билатариальныйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //image = new Bitmap(pictureBox1.Image);
            //Bitmap sourceImage = image;
            //Bitmap resultImage = new Bitmap(sourceImage.Width, sourceImage.Height);

            //for (int i = 0; i < sourceImage.Width; i++)
            //{
            //    for (int j = 0; j < sourceImage.Height; j++)
            //    {
            //        resultImage.SetPixel(i, j, BilatarialcalculateNewPixelColor(sourceImage, i, j));
            //    }
            //}
            //pictureBox1.Image = resultImage;
            //pictureBox1.Refresh();

        }

        public Color BilatarialcalculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            double sigma = 40;
            int radius = 1;
            int count = (int)Math.Pow(radius * 2 + 1, 2);
            double sum = 0;
            double sumGaus = 0;
            double gaussian1 = 0;
            double gaussian2 = 0;

            for (int l = -radius; l <= radius; l++)
            {
                for (int k = -radius; k <= radius; k++)
                {
                    int idX = Clamp(x + k, 0, sourceImage.Width - 1);
                    int idY = Clamp(y + l, 0, sourceImage.Height - 1);
                    Color neighborColor = sourceImage.GetPixel(idX, idY);

                    gaussian1 = 1 / (2 * Math.PI * Math.Pow(sigma, 2)) * Math.Exp(-(Math.Pow(l, 2) + Math.Pow(k, 2)) / (2 * Math.Pow(sigma, 2)));
                    gaussian2 = 1 / (Math.Sqrt(2 * Math.PI) * sigma) * Math.Exp(-(Math.Pow((double)neighborColor.R / 255 - (double)sourceImage.GetPixel(x, y).R / 255, 2)) / (2 * Math.Pow(sigma, 2)));
                    sumGaus += gaussian1 * gaussian2;
                    sum += gaussian1 * gaussian2 * (double)neighborColor.R / 255;

                }
            }
            return Color.FromArgb(Clamp((int)(sum / sumGaus * 255), 0, 255),
            Clamp((int)(sum / sumGaus * 255), 0, 255),
            Clamp((int)(sum / sumGaus * 255), 0, 255));
        }
        public Bitmap WhitecalculateNewPixelColor(Bitmap sourceImage)
        {
            Random random = new Random();
            Bitmap resultImage = new Bitmap(sourceImage);
            int count = (int)((sourceImage.Width * sourceImage.Height) / 10);
     
                for (int j = 0; j < count; j++)
                {
                    int x = random.Next(0,sourceImage.Width);
                    int y = random.Next(0, sourceImage.Height);
                    resultImage.SetPixel(x,y,Color.White);
                }

            return resultImage;
        }

        private void райлиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            image = new Bitmap(pictureBox1.Image);
            Bitmap sourceImage = image;
            Bitmap resultImage = new Bitmap(sourceImage.Width, sourceImage.Height);

            double a = 0;
            double b = 0.4;
            var rayleigh = new float[256];
            float sum = 0f;
            int size = sourceImage.Width * sourceImage.Height;

            for (int i = 0; i < 256; i++)
            {
                double step = (float)i * 0.01;
                if (step >= a)
                {
                    rayleigh[i] = (float)((2 / b) * (step - a) * Math.Exp(-Math.Pow(step - a, 2) / b));
                }
                else
                {
                    rayleigh[i] = 0;
                }
                sum += rayleigh[i];
            }

            for (int i = 0; i < 256; i++)
            {
                rayleigh[i] /= sum;
                rayleigh[i] *= size;
                rayleigh[i] = (int)Math.Floor(rayleigh[i]);
            }


            resultImage = RailycalculateNewPixelColor(sourceImage,rayleigh);

            pictureBox1.Image = resultImage;
            pictureBox1.Refresh();
        }
        public Bitmap RailycalculateNewPixelColor(Bitmap sourceImage, float[] uniform)
        {
            int size = sourceImage.Width * sourceImage.Height;
            float[] uni = new float[uniform.Length];
            for (int i = 0; i < uniform.Length; i++) uni[i] = uniform[i];
     
            Random random = new Random();
            int count = 0;
            var noise = new byte[size];
            for (int i = 0; i < 256; i++)
            {
                for (int j = 0; j < (int)uniform[i]; j++)
                {
                    noise[j + count] = (byte)i;
                }
                count += (int)uniform[i];
            }

            for (int i = 0; i < size - count; i++)
            {
                noise[count + i] = 0;
            }

            noise = noise.OrderBy(x => random.Next()).ToArray();
            var resultImage = new Bitmap(sourceImage);

            for (int i = 0; i < sourceImage.Height; i++)
                for (int j = 0; j < sourceImage.Width; j++)
                {
                    Color color = sourceImage.GetPixel(j, i);

                    resultImage.SetPixel(j, i, Color.FromArgb(Clamp(color.R + noise[sourceImage.Width * i + j], 0, 255),
                        Clamp(color.G + noise[sourceImage.Width * i + j], 0, 255),
                        Clamp(color.B + noise[sourceImage.Width * i + j], 0, 255)));

                }

            return resultImage;
        }

        private void серыйToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Bitmap sourceImage = image;
            Bitmap resultImage = new Bitmap(sourceImage.Width, sourceImage.Height);
            for (int i = 0; i < sourceImage.Width; i++)
            {

                for (int j = 0; j < sourceImage.Height; j++)
                {
                    resultImage.SetPixel(i, j, GRAYcalculateNewPixelColor(sourceImage, i, j));
                }
            }
            pictureBox1.Image = resultImage;
            pictureBox1.Refresh();
        }
        private Color GRAYcalculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color sourceColor = sourceImage.GetPixel(x, y);
            int r = Convert.ToInt32(sourceColor.R);
            int g = Convert.ToInt32(sourceColor.G);
            int b = Convert.ToInt32(sourceColor.B);
            int gray;
            gray = Convert.ToInt32(0.299 * r + 0.587 * g + 0.114 * b);
            Color resultColor = Color.FromArgb(255, gray, gray, gray);
            // intensity = 0.299 * R+0.587*G+0.114*B
            return resultColor;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void белыйToolStripMenuItem_Click(object sender, EventArgs e)
        {

            image = new Bitmap(pictureBox1.Image);
            Bitmap sourceImage = image;
            Bitmap resultImage = new Bitmap(sourceImage.Width, sourceImage.Height);

            for (int i = 0; i < sourceImage.Width; i++)
            {
                for (int j = 0; j < sourceImage.Height; j++)
                {
                    resultImage.SetPixel(i, j, BilatarialcalculateNewPixelColor(sourceImage, i, j));
                }
            }
            pictureBox1.Image = resultImage;
            pictureBox1.Refresh();
        }

        private void билатериальныйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //image = new Bitmap(pictureBox1.Image);
            //Bitmap sourceImage = image;
            //Bitmap resultImage = new Bitmap(sourceImage.Width, sourceImage.Height);

            //for (int i = 0; i < sourceImage.Width; i++)
            //{
            //    for (int j = 0; j < sourceImage.Height; j++)
            //    {
            //        resultImage.SetPixel(i, j, BilatarialcalculateNewPixelColor(sourceImage, i, j));
            //    }
            //}
            //pictureBox1.Image = resultImage;
            //pictureBox1.Refresh();
        }

        private void билатариальныйToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            image = new Bitmap(pictureBox1.Image);
            Bitmap sourceImage = image;
            Bitmap resultImage = new Bitmap(sourceImage.Width, sourceImage.Height);

            for (int i = 0; i < sourceImage.Width; i++)
            {
                for (int j = 0; j < sourceImage.Height; j++)
                {
                    resultImage.SetPixel(i, j, BilatarialcalculateNewPixelColor(sourceImage, i, j));
                }
            }
            pictureBox1.Image = resultImage;
            pictureBox1.Refresh();
        }
    }

}
