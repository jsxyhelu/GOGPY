using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Runtime.InteropServices;
using System.IO;
using System.Diagnostics;
using System.Threading;
using GOClrDll;
using DirectShowLib;

namespace GOGPY
{
    public partial class FormMain : Form
    {
        #region 公共变量
        private Capture cam;
        string strPath = "";
        int iparam = 32;
        IntPtr m_ip = IntPtr.Zero;
        Image srcImage;
    
        GOCsharpHelper gocsharphelper = new GOCsharpHelper();
        FormConfig formconfig = new FormConfig();
       
        INIFileHelper inifilehelper = new INIFileHelper("./GOConfig");
        #endregion
      
        #region 事件驱动
        public FormMain()
        {
            InitializeComponent();
            //选择视频设备
            InitVideoDevice();
            //传值
            formconfig.fatherForm = this;
        }

        //选择视频设备
        public void InitVideoDevice()
        {
            try
            {
                //读取参数
                string strTmp = inifilehelper.IniReadValue("视频采集", "摄像头序号");
                int VIDEODEVICE = Convert.ToInt32(strTmp); // zero based index of video capture device to use
                const int VIDEOWIDTH = 640; // Depends on video device caps
                const int VIDEOHEIGHT = 480; // Depends on video device caps
                const int VIDEOBITSPERPIXEL = 24; // BitsPerPixel values determined by device
                cam = new Capture(VIDEODEVICE, VIDEOWIDTH, VIDEOHEIGHT, VIDEOBITSPERPIXEL, picMain);
            }
            catch
            {
                MessageBox.Show("摄像头打开错误，请首先确保摄像头连接并设置正确！");
                formconfig.Visible = true;
            }
        }
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);

            if (m_ip != IntPtr.Zero)
            {
                Marshal.FreeCoTaskMem(m_ip);
                m_ip = IntPtr.Zero;
            }
        }
        private void btnCapture_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            // Release any previous buffer
            if (m_ip != IntPtr.Zero)
            {
                Marshal.FreeCoTaskMem(m_ip);
                m_ip = IntPtr.Zero;
            }

            // capture image
            m_ip = cam.Click();//click就是采集吗？
            Bitmap b = new Bitmap(cam.Width, cam.Height, cam.Stride, PixelFormat.Format24bppRgb, m_ip);

            // If the image is upsidedown
            b.RotateFlip(RotateFlipType.RotateNoneFlipY);
            pictureBox1.Image = b;
            //处理测试 3 8 7
            srcImage = b;
            if (pictureBox3.Image != null)
                pictureBox3.Image.Dispose();
            if (pictureBox8.Image != null)
                pictureBox8.Image.Dispose();
            if (pictureBox7.Image != null)
                pictureBox7.Image.Dispose();

            Image image0 = gocsharphelper.ImageProcess0(srcImage, iparam);
            pictureBox3.Image = image0;
            Image image1 = gocsharphelper.ImageProcess1(srcImage, iparam);
            pictureBox8.Image = image1;
            Image image2 = gocsharphelper.ImageProcess2(srcImage, iparam);
            pictureBox7.Image = image2;

            Cursor.Current = Cursors.Default;
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            cam.Dispose();

            if (m_ip != IntPtr.Zero)
            {
                Marshal.FreeCoTaskMem(m_ip);
                m_ip = IntPtr.Zero;
            }

            //ReloadAllUnits();
            gocsharphelper.Clear();
        }
        

        //尝试使用timer，解决实时显示问题
        private void timer_Tick(object sender, EventArgs e)
        {
            // Cursor.Current = Cursors.WaitCursor;

            // Release any previous buffer
            if (m_ip != IntPtr.Zero)
            {
                Marshal.FreeCoTaskMem(m_ip);
                m_ip = IntPtr.Zero;
            }

            // capture image
            m_ip = cam.Click();//click就是采集吗？
            Bitmap b = new Bitmap(cam.Width, cam.Height, cam.Stride, PixelFormat.Format24bppRgb, m_ip);

            // If the image is upsidedown
            b.RotateFlip(RotateFlipType.RotateNoneFlipY);
            srcImage = b;
            if (picPreview.Image != null)
                picPreview.Image.Dispose();
           
            Image image0 = gocsharphelper.ImageProcess0(srcImage, iparam);
            picPreview.Image = image0;

        }
        //打开设置界面
        private void btnConfig_Click(object sender, EventArgs e)
        {
            formconfig.Visible = true;
        }
        #endregion
      

        #region 图像处理wraper
        class GOCsharpHelper
        {
            GOClrClass client = new GOClrClass();
            string strResult1 = null;
            string strResult2 = null;
            string strResult0 = null;
            //输入参数是string或bitmap
            public Bitmap ImageProcess0(string ImagePath, int iparam)
            {
                Image ImageTemp = Bitmap.FromFile(ImagePath);
                return ImageProcess0(ImageTemp, iparam);
            }
            //输出结果是bitmap
            public Bitmap ImageProcess0(Image image, int iparam)
            {
                MemoryStream ms = new MemoryStream();
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] bytes = ms.GetBuffer();
                strResult0 = client.ConvetAndSplit0(bytes, iparam);
                Image ImageResult = Bitmap.FromFile(strResult0);
                return (Bitmap)ImageResult;
            }

            //输入参数是string或bitmap
            public Bitmap ImageProcess1(string ImagePath, int iparam)
            {
                Image ImageTemp = Bitmap.FromFile(ImagePath);
                return ImageProcess1(ImageTemp, iparam);
            }
            //输出结果是bitmap
            public Bitmap ImageProcess1(Image image, int iparam)
            {
                MemoryStream ms = new MemoryStream();
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] bytes = ms.GetBuffer();
                strResult1 = client.ConvetAndSplit1(bytes, iparam);
                Image ImageResult = Bitmap.FromFile(strResult1);
                return (Bitmap)ImageResult;
            }

            //输入参数是string或bitmap
            public Bitmap ImageProcess2(string ImagePath, int iparam)
            {
                Image ImageTemp = Bitmap.FromFile(ImagePath);
                return ImageProcess2(ImageTemp, iparam);
            }
            //输出结果是bitmap
            public Bitmap ImageProcess2(Image image, int iparam)
            {
                MemoryStream ms = new MemoryStream();
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] bytes = ms.GetBuffer();
                strResult2 = client.ConvetAndSplit2(bytes, iparam);
                Image ImageResult = Bitmap.FromFile(strResult2);
                return (Bitmap)ImageResult;
            }

            public void Clear()
            {
                if (File.Exists(strResult1))
                    File.Delete(strResult1);
                if (File.Exists(strResult2))
                    File.Delete(strResult2);
            }
        }
        #endregion

    }
}
