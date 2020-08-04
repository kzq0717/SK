using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace SK
{
    public class ImageHelper
    {
        /// <summary>
        /// 人体图像 图像宽度小于图像高度
        /// </summary>
        /// <param name="data">温度数据*100（36.55*100）</param>
        /// <param name="image_width">图像宽</param>
        /// <param name="image_height">图像高</param>
        public ImageHelper(short[] data, int image_width, int image_height)
        {
            if (data == null)
            {
                throw new Exception("温度数不能为空");
            }

            if (image_width <= 0 || image_height <= 0)
            {
                throw new Exception("请正确给出图像的高/宽的值.");
            }

            imageWidth = image_width;
            imageHeight = image_height;

            hightTemperature = (float)(data.Max() / 100.00);      //最大值
            lowTemperature = (float)(data.Min() / 100.00);//最小值
            GetAvrTemValue(data);//平均值
        }



        #region 方法
        /// <summary>
        /// 获取最高温
        /// </summary>
        /// <param name="data">温度图像数据</param>
        private void GetMaxTemValue(short[] data)
        {
            try
            {
                if (data == null) throw new Exception("数组不能为空.");
                int _maxValue = 0;
                bool hasValue = false;
                for (int i = 0; i < data.Length; i++)
                {
                    if (hasValue)
                    {
                        if (data[i] > _maxValue)
                        {
                            _maxValue = data[i];
                        }
                    }
                    else
                    {
                        _maxValue = data[i];
                        hasValue = true;
                    }
                }
                if (hasValue)
                {
                    hightTemperature = (float)(_maxValue / 100.00);
                }
                else
                {
                    hightTemperature = (float)(0.00);
                }

            }
            catch (Exception ex)
            {
                Log.WriteLog($"获取图像中最大值异常:{ex.Message}_{ex.StackTrace}");
                return;
            }

        }


        /// <summary>
        /// 获取最低温
        /// </summary>
        /// <param name="data">温度图像数据</param>
        private void GetMinTemValue(short[] data)
        {
            try
            {
                if (data == null) throw new Exception("数组不能为空.");
                int _mixValue = 0;
                bool hasValue = false;
                for (int i = 0; i < data.Length; i++)
                {
                    if (hasValue)
                    {
                        if (data[i] > _mixValue)
                        {
                            _mixValue = data[i];
                        }
                    }
                    else
                    {
                        _mixValue = data[i];
                        hasValue = true;
                    }
                }
                if (hasValue)
                {
                    lowTemperature = (float)(_mixValue / 100.00);
                }
                else
                {
                    lowTemperature = (float)(0.00);
                }
            }
            catch (Exception ex)
            {
                Log.WriteLog($"获取图像中最小值异常:{ex.Message}_{ex.StackTrace}");
                return;
            }

        }

        /// <summary>
        /// 获取平均温度
        /// </summary>
        /// <param name="data"></param>
        private void GetAvrTemValue(short[] data) {
            try
            {
                if (data == null) throw new Exception("数组不能为空.");
                int sum = 0;
                for (int i = 0; i < data.Length; i++)
                {
                    sum += data[i];
                }

                this.aveTemperature = (float)Math.Round(((decimal)sum/data.Length),2);

            }
            catch (Exception ex)
            {
                Log.WriteLog($"获取图像中最小值异常:{ex.Message}_{ex.StackTrace}");
                return;
            }

        }
        #endregion
        #region 属性
        /// <summary>256色
        /// </summary>
        private byte[,] rgbPalette_256;

        /// <summary>灰度
        /// </summary>
        private byte[,] greyPalette_256;

        #region ARGB值
        private int[] c = new int[256] {
        0,263172,526344,789516,1052688,1315860,1579032,1842204,
        2105376,2368548,2631720,2894892,3158064,3421236,3684408,
        3947580,4210752,4473924,4737096,5000268,5526612,5526612,
        5786700,6047816,6308932,6570048,6831164,7092280,7353396,
        7614512,7875628,8136744,8397860,8658976,8920092,9181208,
        9442324,9703440,9964556,10225672,10486788,11010048,11010048,
        11273220,11536392,11799564,12062736,12325908,12589080,
        12852252,13115424,13378596,13641768,13904940,14168112,
        14431284,14694456,14957628,15220800,15483972,15747144,
        16010316,16273488,16536660,16536660,16536656,16275532,
        16014408,16014408,15753284,15492160,15492160,15231036,
        14969912,14969912,14708788,14447664,14447664,14186540,
        13925416,13925416,13664292,13403168,13403168,13142044,
        12880920,12880920,12619796,12358672,12358672,12097548,
        11836424,11836424,11575300,11314176,11053056,11053056,
        11053056,11316228,11579400,11579400,11842572,12105744,
        12105744,12368916,12632088,12632088,12895260,13158432,
        13158432,13421604,13684776,13684776,13947948,14211120,
        14211120,14474292,14737464,14737464,15000636,15263808,
        15263808,15526980,15790152,15790152,16053324,16316496,
        16579668,16579668,15530064,14480460,13429828,12380224,
        11067448,10017844,8968240,7917608,6868004,5555228,4505624,
        3456020,2405388,1355784,43008,43008,306180,569352,1095696,
        1358868,1885212,2148384,2411556,2937900,3201072,3727416,
        3990588,4253760,4780104,5043276,5569620,5569620,5569628,
        5569640,5569652,5569664,5569676,5569684,5569696,5569708,
        5569720,5569732,5569740,5569752,5569764,5569776,5569788,
        5569788,5305592,5040372,4513004,4247784,3720416,3456220,
        3191000,2663632,2398412,1871044,1606848,1341628,814260,
        549040,21672,21672,1070252,2118832,3167416,4215996,5526724,
        6575304,7623884,8672468,9721048,11031776,12080356,13128936,
        14177520,15226100,16536828,16536828,16273656,16010484,
        15484140,15220968,14694624,14431452,14168280,13641936,
        13378764,12852420,12589248,12326076,11799732,11536560,
        11010216,11010216,10749100,10487984,9965752,9704636,
        9182404,8921288,8660172,8137940,7876824,7354592,7093476,
        6832360,6310128,6049012,5526780,5526780,5000444,4737276,
        4210940,3947772,3684604,3158268,2895100,2368764,2105596,
        1842428,1316092,1052924,526588,263420,16579836};

        //    //256级RGB值
        //    Color temp;
        //    rgbPalette_256 = new byte[256, 3];
        //        for (int i = 0; i< 256; i++)
        //        {
        //            temp = ColorTranslator.FromWin32(c[i]);

        //            rgbPalette_256[i, 0] = temp.B;
        //            rgbPalette_256[i, 1] = temp.G;
        //            rgbPalette_256[i, 2] = temp.R;
        //        }

        ////灰度值
        //GreyPalette = new byte[256, 3];
        //        for (short i = 0; i <= 255; i++)
        //        {

        //            GreyPalette[i, 0] = (byte) i;
        //GreyPalette[i, 1] = (byte) i;
        //GreyPalette[i, 2] = (byte) i;
        #endregion

        /// <summary>seriesID
        /// </summary>
        public string seriesID { get; set; }

        /// <summary>ImageID
        /// </summary>
        public string imageID { get; set; }

        /// <summary>图像数据
        /// </summary>
        public byte[] imageData { get; set; }

        /// <summary>二维图像数据
        /// </summary>
        public int[,] ImageData { get; set; }

        /// <summary>图像宽度(240)
        /// </summary>
        public int imageWidth { get; set; }

        /// <summary>图像高度(320)
        /// </summary>
        public int imageHeight { get; set; }

        /// <summary>
        /// 高温
        /// </summary>
        public float hightTemperature { get; set; }

        /// <summary>
        /// 低温
        /// </summary>
        public float lowTemperature { get; set; }

        /// <summary>
        /// 平均值
        /// </summary>
        public float aveTemperature { get; set; }

        /// <summary>图像数量
        /// </summary>
        public int imageCount { get; set; }


        /// <summary>
        /// 256彩色图像
        /// </summary>
        public Bitmap getCloreImage { get; set; }

        #endregion

        #region 方法
        /// <summary>构造函数
        /// </summary>
        public ImageHelper(byte[] data)
        {
            try
            {
                if (data.Length > 0)
                {
                    byte[] tempBytes = new byte[data.Length - 8]; //温度数据
                    short[] tempData = new short[tempBytes.Length / 2];
                    Buffer.BlockCopy(data, 8, tempData, 0, tempBytes.Length); //拷贝数据
                    this.imageWidth = BitConverter.ToInt32(data, 0);
                    this.imageHeight = BitConverter.ToInt32(data, 4);
                    this.ImageData = OneToTwo(tempData, imageWidth, imageHeight);//温度数矩阵
                    this.hightTemperature = tempData.Cast<short>().Max() / 100.0f;//高温
                    this.lowTemperature = tempData.Cast<short>().Min() / 100.0f;//低温
                }
                else
                {
                    throw new Exception("图像信息不能为空.");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        #region 获取图像属性(宽度，高度，图像矩阵数据，高温，低温)
        /// <summary>获取图像属性(宽度，高度，图像矩阵数据，高温，低温)
        /// </summary>
        /// <param name="bytes"></param>
        private List<ImageInfo> setImageMeta(List<ImageInfo> L_imageInfo)
        {
            try
            {
                List<ImageInfo> imageMetas = new List<ImageInfo>();
                foreach (ImageInfo imageInfo in L_imageInfo)
                {
                    byte[] bytes = imageInfo.imageData;
                    byte[] newbytes = new byte[bytes.Length - 8];//只存温度数据
                    short[] data = new short[newbytes.Length / 2];//short类型的温度数据
                    Buffer.BlockCopy(bytes, 8, data, 0, newbytes.Length);

                    imageInfo.imageWidth = BitConverter.ToInt32(bytes, 0); //图像的宽度（240）
                    imageInfo.imageHeight = BitConverter.ToInt32(bytes, 4);//图像的高度（320） 
                    imageInfo.ImageData = OneToTwo(data, imageInfo.imageWidth, imageInfo.imageHeight);//二维图像数据
                    imageInfo.hightTemperature = data.Cast<short>().Max() / 100.0f;//高温
                    imageInfo.lowTemperature = data.Cast<short>().Min() / 100.0f; //低温
                    imageMetas.Add(imageInfo);
                }
                return imageMetas;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message + ex.StackTrace);
                return null;
            }
        }

        #endregion

        #region 温度数据转成BitMap图像

        /// <summary>将byte[]数据转为bitmap
        /// </summary>
        /// <returns></returns>
        public Bitmap getBitmap()
        {
            try
            {
                int m_colorIndex; //颜色对应的索引
                byte[,] colorImageData = new byte[imageWidth, imageHeight];//温度数据对应颜色坐标
                init_RGB_256_Platte();
                for (int x = 0; x < imageWidth; x++)
                {
                    for (int y = 0; y < imageHeight; y++)
                    {
                        m_colorIndex = (int)(Math.Round(ImageData[x, y] - lowTemperature) * 256.0 / (hightTemperature - lowTemperature));//对应color
                        if (m_colorIndex > 255)
                        {
                            colorImageData[x, y] = 255;
                        }
                        else if (m_colorIndex <= 0)
                        {
                            colorImageData[x, y] = 0;
                        }
                        else
                        {
                            colorImageData[x, y] = (byte)m_colorIndex;
                        }
                    }
                }
                Bitmap bitmap = new Bitmap(imageWidth, imageHeight, PixelFormat.Format24bppRgb);
                Rectangle re = new Rectangle(0, 0, imageWidth, imageHeight);
                BitmapData bitmapData = bitmap.LockBits(re, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
                int dstStride = bitmapData.Stride;
                System.IntPtr dstScan0 = bitmapData.Scan0;
                unsafe
                {
                    try
                    {
                        byte* pDst = (byte*)(void*)dstScan0;
                        for (int x = 0; x < imageWidth; x++)
                        {
                            for (int y = 0; y < imageHeight; y++) //原始图像 
                            {
                                pDst[x * 3 + y * dstStride] = rgbPalette_256[colorImageData[x, y], 0];
                                pDst[x * 3 + y * dstStride + 1] = rgbPalette_256[colorImageData[x, y], 1];
                                pDst[x * 3 + y * dstStride + 2] = rgbPalette_256[colorImageData[x, y], 2];
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        System.Windows.Forms.MessageBox.Show(ex.Message + ex.StackTrace);
                    }

                }
                bitmap.UnlockBits(bitmapData);
                return bitmap;
            }
            catch (Exception ex)
            {
                throw new Exception("无法得到BitMap图像信息.", ex.InnerException);
            }

        }

        /// <summary>导出温度数据到文件中
        /// </summary>
        /// <param name="filePath">文件存储路径</param>
        /// <returns>成功：true  失败：false</returns>
        public bool outTemperatureDataToFile(string filePath)
        {
            try
            {
                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }

                string dataFileName = filePath + "\\" + Guid.NewGuid().ToString() + ".txt";
                if (!File.Exists(dataFileName))
                {
                    FileStream fs = File.Create(dataFileName);
                    fs.Close();
                }

                StreamWriter write = File.AppendText(dataFileName);

                int m_row = ImageData.GetUpperBound(0) + 1; //行数
                int m_col = ImageData.GetLength(1);//列数
                int i = 1;

                for (int y = 0; y < m_row; y++)
                {
                    for (int x = 0; x < m_col; x++)
                    {
                        if (x % m_col == 0 && x != 0)
                        {
                            write.Write("\n");
                        }
                        else
                        {
                            write.Write(ImageData[y, x] + ",");
                            i++;
                        }
                    }
                }
                write.Flush();
                write.Close();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        /// <summary>返回bitmap图像信息
        /// </summary>
        /// <param name="imageInfo">
        /// 图像宽度、图像高度、 低温、高温 、图像数据
        /// 
        /// </param>
        /// <returns></returns>
        public Bitmap getBitmap(ImageInfo imageInfo)
        {
            try
            {
                init_RGB_256_Platte();

                int m_imageWidth = imageInfo.imageWidth; //320
                int m_imageHight = imageInfo.imageHeight; // 240
                int m_colorIndex;
                byte[,] colorImageData = new byte[m_imageWidth, m_imageHight];//温度数据对应颜色坐标
                float m_imageLowTemperature = imageInfo.lowTemperature * 100.00f; //低温*100.00f
                float m_imageHightTemperature = imageInfo.hightTemperature * 100.00f;//高温*100.00f

                for (int x = 0; x < m_imageWidth; x++)
                {
                    for (int y = 0; y < m_imageHight; y++)
                    {
                        m_colorIndex = (int)(Math.Round(imageInfo.ImageData[x, y] - m_imageLowTemperature) * 256.0 / (m_imageHightTemperature - m_imageLowTemperature));//对应color
                        if (m_colorIndex > 255)
                        {
                            colorImageData[x, y] = 255;
                        }
                        else if (m_colorIndex <= 0)
                        {
                            colorImageData[x, y] = 0;
                        }
                        else
                        {
                            colorImageData[x, y] = (byte)m_colorIndex;
                        }
                    }
                }

                Bitmap bitmap = new Bitmap(m_imageWidth, m_imageHight, PixelFormat.Format24bppRgb);
                Rectangle re = new Rectangle(0, 0, m_imageWidth, m_imageHight);
                BitmapData bitmapData = bitmap.LockBits(re, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
                int dstStride = bitmapData.Stride;
                System.IntPtr dstScan0 = bitmapData.Scan0;
                unsafe
                {
                    try
                    {
                        byte* pDst = (byte*)(void*)dstScan0;
                        for (int x = 0; x < m_imageWidth; x++)
                        {
                            for (int y = 0; y < m_imageHight; y++) //原始图像 
                            {
                                pDst[x * 3 + y * dstStride] = rgbPalette_256[colorImageData[x, y], 0];
                                pDst[x * 3 + y * dstStride + 1] = rgbPalette_256[colorImageData[x, y], 1];
                                pDst[x * 3 + y * dstStride + 2] = rgbPalette_256[colorImageData[x, y], 2];
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        System.Windows.Forms.MessageBox.Show(ex.Message + ex.StackTrace);
                    }

                }
                bitmap.UnlockBits(bitmapData);
                return bitmap;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region 将bitmap转存储为PNG
        /// <summary>将bitmap转存储为PNG
        /// </summary>
        /// <param name="bitmap">bitmap图像</param>
        /// <param name="imageId">图像编号</param>
        public void setBitmapToPng(Bitmap bitmap, string imageId)
        {
            try
            {
                string filePath = System.Windows.Forms.Application.StartupPath + "\\Image";
                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }

                bitmap.Save(filePath + "\\" + imageId + ".png", System.Drawing.Imaging.ImageFormat.Png); ;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region 初始化8位色彩色模式
        /// <summary>初始化8位色彩色模式
        /// </summary>
        private void init_RGB_256_Platte()
        {
            Color temp;
            rgbPalette_256 = new byte[256, 3];
            for (int i = 0; i < 256; i++)
            {
                temp = ColorTranslator.FromWin32(c[i]);
                rgbPalette_256[i, 0] = temp.B;
                rgbPalette_256[i, 1] = temp.G;
                rgbPalette_256[i, 2] = temp.R;
            }
        }
        #endregion

        #region 初始化8位色灰度模式
        /// <summary>初始化8位色灰度模式
        /// </summary>
        private void init_Grey_256_Platte()
        {
            for (int i = 0; i < 256; i++)
            {
                greyPalette_256[i, 0] = (byte)i;
                greyPalette_256[i, 1] = (byte)i;
                greyPalette_256[i, 2] = (byte)i;
            }
        }
        #endregion

        #region 一维数组转二维数组
        /// <summary>一维数组转二维数组
        /// </summary>
        /// <param name="b">一维数组（温度数据）</param>
        /// <returns></returns>
        private int[,] OneToTwo(short[] b, int G_int_ImageWidth, int G_int_ImageHeight)
        {
            int[,] temp = new int[G_int_ImageWidth, G_int_ImageHeight];
            for (int x = 0; x < G_int_ImageWidth; x++)
            {
                for (int y = 0; y < G_int_ImageHeight; y++)
                {
                    temp[x, y] = b[G_int_ImageHeight * x + y];
                }
            }
            return temp;
        }
        #endregion

        /// <summary>二维转一维度数组
        /// </summary>
        /// <param name="b">二维数组</param>
        /// <param name="G_int_ImageWidth">图像的宽度</param>
        /// <param name="G_int_ImageHeight">图像的高度</param>
        /// <returns>一维数组</returns>
        private int[] TwoToOne(int[,] b, int G_int_ImageWidth, int G_int_ImageHeight)
        {
            int[] temp = new int[G_int_ImageHeight * G_int_ImageWidth + 1];
            int n = 0;
            for (int x = 0; x < G_int_ImageWidth; x++)
            {
                for (int y = 0; y < G_int_ImageHeight; y++)
                {
                    temp[n] = b[x, y];
                    n++;
                }
            }
            return temp;
        }


        #region 打开指定路径文件
        /// <summary>打开指定路径文件
        /// </summary>
        /// <param name="fileFullName">文件所在路径</param>
        private void OpenFolderAndSelectFile(string fileFullName)
        {
            System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo("Explorer.exe");
            psi.Arguments = "/e,/select," + fileFullName;
            System.Diagnostics.Process.Start(psi);
        }
        #endregion

        #region 生成缩略图
        /// <summary>生成缩略图
        /// </summary>
        /// <param name="originalBmp">要生成缩略图的Bitmap图像</param>
        /// <param name="desiredWidth">缩略图像宽度</param>
        /// <param name="desiredHeight">缩略图像高度</param>
        /// <returns>生成的缩略图</returns>
        public static Bitmap CreateThumbnail(Bitmap originalBmp, int desiredWidth, int desiredHeight)
        {
            //If the image is smaller than a thumbnail just return it
            if (originalBmp.Width <= desiredWidth && originalBmp.Height <= desiredHeight)
            {
                return originalBmp;
            }
            int newWidth, newHeight;

            //scale down the smaller dimentsion
            if (desiredWidth * originalBmp.Height < desiredHeight * originalBmp.Width)
            {
                newWidth = desiredWidth;
                newHeight = (int)Math.Round((decimal)originalBmp.Height * desiredHeight / originalBmp.Width);
            }
            else
            {
                newHeight = desiredHeight;
                newWidth = (int)Math.Round((decimal)originalBmp.Width * desiredWidth / originalBmp.Height);
            }

            //This code creates cleaner(though bigger) thumbnails and properly and handle GIF files better by generating
            // a white background for transparent images (as opposed to black)
            //This is preferred to calling Bitmap.GetThumbnailImage()
            Bitmap bitmap = new Bitmap(newWidth, newHeight);

            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                graphics.FillRectangle(Brushes.White, 0, 0, newWidth, newHeight);
                graphics.DrawImage(originalBmp, 0, 0, newWidth, newHeight);
            }
            return bitmap;
        }
        #endregion

        #endregion

        #region 图像处理类 
        /// <summary>图像类
        /// </summary>
        public class ImageInfo
        {
            /// <summary>seriesID
            /// </summary>
            public string seriesID { get; set; }

            /// <summary>ImageID
            /// </summary>
            public string imageID { get; set; }

            /// <summary>图像数据
            /// </summary>
            public byte[] imageData { get; set; }

            /// <summary>二维图像数据
            /// </summary>
            public int[,] ImageData { get; set; }

            /// <summary>图像宽度(240)
            /// </summary>
            public int imageWidth { get; set; }

            /// <summary>图像高度(320)
            /// </summary>
            public int imageHeight { get; set; }

            /// <summary>高温
            /// </summary>
            public float hightTemperature { get; set; }

            /// <summary>低温
            /// </summary>
            public float lowTemperature { get; set; }

            /// <summary>图像数量
            /// </summary>
            public int imageCount { get; set; }

            /// <summary>图像是否达标
            /// </summary>
            public string IsOK { get; set; }
        }
        #endregion

    }

    /// <summary>
    /// </summary>
    class UnsafeBitmap
    {
        Bitmap bitmap;
        int stride;
        BitmapData bitmapData = null;
        unsafe Byte* pBase = null;

        public UnsafeBitmap(Bitmap bitmap)
        {
            this.bitmap = new Bitmap(bitmap);
        }


        public UnsafeBitmap(int width, int height)
        {
            this.bitmap = new Bitmap(width, height, PixelFormat.Format24bppRgb);
        }

        public void Dispose()
        {
            bitmap.Dispose();
        }

        public Bitmap Bitmap
        {
            get { return (bitmap); }
        }


        public struct PixelData
        {
            public byte blue;
            public byte green;
            public byte red;
        };


        private Point PixeSize
        {
            get
            {
                GraphicsUnit graphicsUnit = GraphicsUnit.Pixel; //给定像素类型
                RectangleF bounds = bitmap.GetBounds(ref graphicsUnit);
                return new Point((int)bounds.Width, (int)bounds.Height);
            }
        }

        /// <summary>将bitmap所到内存中
        /// </summary>
        public void LockBitmap()
        {
            GraphicsUnit graphicsUnit = GraphicsUnit.Pixel;
            RectangleF rectangleF = bitmap.GetBounds(ref graphicsUnit);
            Rectangle rectangle = new Rectangle((int)rectangleF.X, (int)rectangleF.Y, (int)rectangleF.Width, (int)rectangleF.Height);
            bitmapData = bitmap.LockBits(rectangle, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            stride = bitmapData.Stride;
        }

        /// <summary>获取像素值
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        unsafe public PixelData GetPixel(int x, int y)
        {
            PixelData returnValue = *PixelAt(x, y);
            return returnValue;
        }

        /// <summary>设置像素值
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="colour"></param>
        unsafe public void SetPixel(int x, int y, PixelData colour)
        {

            PixelData* pixel = PixelAt(x, y);
            *pixel = colour;

        }

        /// <summary>将数据锁到内存中
        /// </summary>
        unsafe public void UnlockBitmap()
        {
            bitmap.UnlockBits(bitmapData);
            bitmapData = null;
            pBase = null;
        }

        /// <summary>设置指定位置
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        unsafe public PixelData* PixelAt(int x, int y)
        {
            return (PixelData*)(pBase + y * stride + x * sizeof(PixelData));
        }

    }

    /// <summary>测试类--查看循环读取，与内存读取的效率问题
    /// </summary>
    public class test
    {
        static void Main()
        {
            Bitmap bitmap = new Bitmap(@"1.jpg");
            UnsafeBitmap bitmap2 = new UnsafeBitmap(bitmap);
            System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
            stopwatch.Start();
            for (int i = 0; i < bitmap.Width; i++)
            {
                for (int j = 0; j < bitmap.Height; j++)
                {
                    Color c = bitmap.GetPixel(i, j);
                }
            }
            stopwatch.Stop();
            Console.WriteLine(stopwatch.ElapsedTicks);

            stopwatch.Reset();
            stopwatch.Start();
            bitmap2.LockBitmap();
            for (int i = 0; i < bitmap.Width; i++)
                for (int j = 0; j < bitmap.Height; j++)
                {
                    UnsafeBitmap.PixelData c = bitmap2.GetPixel(i, j);
                }
            bitmap2.UnlockBitmap();
            stopwatch.Stop();
            Console.WriteLine(stopwatch.ElapsedTicks);
        }
    }



}
