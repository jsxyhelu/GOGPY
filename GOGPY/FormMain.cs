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
using System.Collections.Generic;

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
        FormShow formshow = new FormShow();

        INIFileHelper inifilehelper = new INIFileHelper("./GOConfig");
        bool b_take_picture;

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
            b_take_picture = false;
        }

        //选择视频设备
        public void InitVideoDevice()
        {
            try
            {
                //读取参数
                string strTmp = inifilehelper.IniReadValue("视频采集", "摄像头序号");
                int VIDEODEVICE = Convert.ToInt32(strTmp); // zero based index of video capture device to use
                const int VIDEOWIDTH = 1024; // 是用默认（最大）分辨率
                const int VIDEOHEIGHT = 768; // Depends on video device caps
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
            if (b_take_picture == false)
                b_take_picture = true;
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

            Bitmap bitmap2;
            if (b_take_picture == true)
            {
                bitmap2 = client.fetchresult(bytes);
                if (bitmap2 == null)
                {
                    MessageBox.Show("图像获取错误!请重新获取");
                }
                else
                {
                    //pictureBox1.Image = bitmap2;
                    //保存这个图像
                    bitmap2.Save(Application.StartupPath + "/" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                    b_take_picture = false;
                    MessageBox.Show("图像采集成功！");

                    UpdateFileList();
                }
            }
            //显示结果
            picPreview.Image = bitmap;
        }
        //打开设置界面
        private void btnConfig_Click(object sender, EventArgs e)
        {
            formconfig.Visible = true;
        }
        #endregion
      
        private void FormMain_Load(object sender, EventArgs e)
        {
            camtimer.Enabled = true;
        }

        //综合测试按钮
        private void button1_Click(object sender, EventArgs e)
        {

            

     
        }

        //更新filelist
        private void UpdateFileList()
        {
            System.IO.DirectoryInfo dir = new DirectoryInfo(Application.StartupPath);
            if (dir.Exists)
            {
                FileInfo[] fiList = dir.GetFiles();
                List<string> mList = new List<string>();
                foreach (var item in fiList)
                {
                    var FilePath = item.FullName; //路径
                    var FileName = Path.GetFileNameWithoutExtension(FilePath);
                    var ExtName = Path.GetExtension(FilePath);
                    if (ExtName.ToString() == ".jpg")
                    {
                        mList.Add(FileName.ToString());
                    }
                }
                mList.Sort();   //按时间降序排列
                mList.Reverse();
                //读取最多4个图片
                if (mList.Count > 1)
                {
                    //测试
                    pictureBox1.Image = Image.FromFile(Application.StartupPath + "/" + mList[0] + ".jpg");
                }

            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            formshow.showImage(pb.Image);
            formshow.Visible = true;
        }
    }
}
