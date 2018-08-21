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
        FormConfig formconfig = new FormConfig();
        INIFileHelper inifilehelper = new INIFileHelper("./GOConfig");

        GOClrClass client = new GOClrClass();
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

        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            cam.Dispose();

            if (m_ip != IntPtr.Zero)
            {
                Marshal.FreeCoTaskMem(m_ip);
                m_ip = IntPtr.Zero;
            }

        
        }
        

        //尝试使用timer，解决实时显示问题
        private void timer_Tick(object sender, EventArgs e)
        {
            
            // Release any previous buffer
            if (m_ip != IntPtr.Zero)
            {
                Marshal.FreeCoTaskMem(m_ip);
                m_ip = IntPtr.Zero;
            }

            // capture image
            try
            {
                m_ip = cam.Click();
            }
            catch
            {
                //do nothing,允许丢帧 TODO：是否改成继承上一帧更好
            }
            
            Bitmap b = new Bitmap(cam.Width, cam.Height, cam.Stride, PixelFormat.Format24bppRgb, m_ip);

            // If the image is upsidedown
            b.RotateFlip(RotateFlipType.RotateNoneFlipY);
            srcImage = b;
            if (picPreview.Image != null)
                picPreview.Image.Dispose();

            //调用clr+opencv图像处理模块
            MemoryStream ms = new MemoryStream();
            b.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            byte[] bytes = ms.GetBuffer();
            Bitmap bitmap = client.testMethod(bytes);

            //显示结果
            picPreview.Image = bitmap;
        }
        //打开设置界面
        private void btnConfig_Click(object sender, EventArgs e)
        {
            formconfig.Visible = true;
        }
        #endregion
      

   

        private void button1_Click(object sender, EventArgs e)
        {
            camtimer.Enabled = true;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            camtimer.Enabled = true;
        }

    }
}
