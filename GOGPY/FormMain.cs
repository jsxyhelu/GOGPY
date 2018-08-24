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
        #region 公共变量和类库引用
        //A (modified) definition of OleCreatePropertyFrame found here: http://groups.google.no/group/microsoft.public.dotnet.languages.csharp/browse_thread/thread/db794e9779144a46/55dbed2bab4cd772?lnk=st&q=[DllImport(%22olepro32.dll%22)]&rnum=1&hl=no#55dbed2bab4cd772
        [DllImport("oleaut32.dll", CharSet = CharSet.Unicode, ExactSpelling = true)]
        public static extern int OleCreatePropertyFrame(
            IntPtr hwndOwner,
            int x,
            int y,
            [MarshalAs(UnmanagedType.LPWStr)] string lpszCaption,
            int cObjects,
            [MarshalAs(UnmanagedType.Interface, ArraySubType = UnmanagedType.IUnknown)] 
            ref object ppUnk,
            int cPages,
            IntPtr lpPageClsID,
            int lcid,
            int dwReserved,
            IntPtr lpvReserved);

        IBaseFilter theDevice = null;

        private Capture cam;
        List<PictureBox> listPictureBox; //控件集合
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
          
            //传值
            formconfig.fatherForm = this;
            b_take_picture = false;
            //构造摄像头数据
            foreach (DsDevice ds in DsDevice.GetDevicesOfCat(FilterCategory.VideoInputDevice))
            {
                comboBox1.Items.Add(ds.Name);
            }
            //读取数据库
            string strtmp = inifilehelper.IniReadValue("视频采集", "摄像头序号");
            int itmp = Convert.ToInt32(strtmp);
            if (itmp > comboBox1.Items.Count)
            {
                itmp = 0;
            }
            if (comboBox1.Items.Count > 0)
            {
                comboBox1.SelectedIndex = itmp;
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

        private void FormMain_Load(object sender, EventArgs e)
        {
            camtimer.Enabled = true;
            string strSavePath = null;
          

            //设置图片保存位置
            try
            {
                strSavePath = inifilehelper.IniReadValue("保存配置", "图片存放目录");
                if (Directory.Exists(strSavePath))
                {
                    tbResultPath.Text = strSavePath;
                }
                else
                {
                    MessageBox.Show("配置目录错误，采用当前程序目录");
                    tbResultPath.Text = Application.StartupPath;
                }
            }
            catch
            {
                MessageBox.Show("配置程序错误，请联系操作人员！");
            }
            //设置矫正不矫正
            string  strAdjust = inifilehelper.IniReadValue("矫正方式", "矫正");
            if (strAdjust == "true")
            {
                AutoAdjust.Checked = true;
                NoAdjust.Checked = false;
            }
            else
            {
                AutoAdjust.Checked = false;
                NoAdjust.Checked = true;
            }
            //设定采集模式
            string strColor = inifilehelper.IniReadValue("拍摄类型", "拍摄类型");
            if (strColor == "彩色")
            {
                radioColor.Checked = true;
                radioGray.Checked = false;
                radioBin.Checked = false;
            }
            else if (strColor == "灰度")
            {
                radioColor.Checked = false;
                radioGray.Checked = true;
                radioBin.Checked = false;
            }
            else
            {
                radioColor.Checked = false;
                radioGray.Checked = false;
                radioBin.Checked = true;
            }
            //设定控件组，这个操作在所有控件读取后进行
            listPictureBox = new List<PictureBox>();
            listPictureBox.Add(pictureBox1);
            listPictureBox.Add(pictureBox2);
            listPictureBox.Add(pictureBox3);
            listPictureBox.Add(pictureBox4);
            listPictureBox.Add(pictureBox5);

            //读取现有图片
            UpdateFileList();
        }

        //综合测试按钮
        private void button1_Click(object sender, EventArgs e)
        {

        }

        //点击显示图片按牛牛
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            formshow.showImage(pb.Image);
            formshow.Visible = true;
        }

        //关闭并打开摄像头
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int itmp = comboBox1.SelectedIndex;
            inifilehelper.IniWriteValue("视频采集", "摄像头序号", itmp.ToString());
            camtimer.Enabled = false;
            //选择视频设备
            InitVideoDevice();
            //生成配套的视频控制界面
            if (theDevice != null)
            {
                Marshal.ReleaseComObject(theDevice);
                theDevice = null;
            }
            //Create the filter for the selected video input device
            string devicepath = comboBox1.SelectedItem.ToString();
            theDevice = CreateFilter(FilterCategory.VideoInputDevice, devicepath);
            camtimer.Enabled = true;
        }

        //视频设置
        private void btnVideoConfig_Click(object sender, EventArgs e)
        {
            DisplayPropertyPage(theDevice);
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
                bool bifAjust = true;
                int imethod = 0;
                if (NoAdjust.Checked)
                    bifAjust = false;
                if (radioGray.Checked)
                    imethod = 1;
                if (radioBin.Checked)
                    imethod = 2;
                bitmap2 = client.fetchresult(bytes, bifAjust, imethod);
                if (bitmap2 == null)
                {
                    MessageBox.Show("图像获取错误!请重新获取");
                }
                else
                {
                    string strPath;
                    if (Directory.Exists(tbResultPath.Text))
                    {
                        strPath = tbResultPath.Text;
                    }
                    else
                    {
                        strPath = Application.StartupPath;
                    }
                    //保存这个图像
                    bitmap2.Save(strPath + "/" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                    b_take_picture = false;
                   // MessageBox.Show("图像采集成功！");
                    //更新左下方文件目录
                    UpdateFileList();
                }
            }
            //显示结果
            picPreview.Image = bitmap;
        }
        //打开设置界面
        private void btnConfig_Click(object sender, EventArgs e)
        {
            MessageBox.Show("摄像头设置功能稍后提供……");
            //formconfig.Visible = true;
        }
        #endregion
      
        #region helper函数

        //更新左下方文件目录
        private void UpdateFileList()
        {
            string strPath;
            if (Directory.Exists(tbResultPath.Text)) 
            {
                strPath = tbResultPath.Text;
            }
            else 
            {
                strPath = Application.StartupPath;
            }
            System.IO.DirectoryInfo dir = new DirectoryInfo(strPath);
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
                //clear现有图片
                for (int i = 0; i < 5; i++)
                {
                    listPictureBox[i].Image = null;
                }
                //读取最多5个图片
                if (mList.Count > 5)
                {
                    for(int i = 0;i<5;i++)
                    {
                       listPictureBox[i].Image = Image.FromFile(strPath+"/"+mList[i]+".jpg");
                    }
                }
                else 
                {
                    for (int i = 0; i < mList.Count; i++)
                    {
                       listPictureBox[i].Image = Image.FromFile(strPath + "/" + mList[i] + ".jpg");
                    }
                }

            }
        }

        /// <summary>
        /// Enumerates all filters of the selected category and returns the IBaseFilter for the 
        /// filter described in friendlyname
        /// </summary>
        /// <param name="category">Category of the filter</param>
        /// <param name="friendlyname">Friendly name of the filter</param>
        /// <returns>IBaseFilter for the device</returns>
        private IBaseFilter CreateFilter(Guid category, string friendlyname)
        {
            object source = null;
            Guid iid = typeof(IBaseFilter).GUID;
            foreach (DsDevice device in DsDevice.GetDevicesOfCat(category))
            {
                if (device.Name.CompareTo(friendlyname) == 0)
                {
                    device.Mon.BindToObject(null, null, ref iid, out source);
                    break;
                }
            }

            return (IBaseFilter)source;
        }

        /// <summary>
        /// Displays a property page for a filter
        /// </summary>
        /// <param name="dev">The filter for which to display a property page</param>
        private void DisplayPropertyPage(IBaseFilter dev)
        {
            //Get the ISpecifyPropertyPages for the filter
            ISpecifyPropertyPages pProp = dev as ISpecifyPropertyPages;
            int hr = 0;

            if (pProp == null)
            {
                //If the filter doesn't implement ISpecifyPropertyPages, try displaying IAMVfwCompressDialogs instead!
                IAMVfwCompressDialogs compressDialog = dev as IAMVfwCompressDialogs;
                if (compressDialog != null)
                {

                    hr = compressDialog.ShowDialog(VfwCompressDialogs.Config, IntPtr.Zero);
                    DsError.ThrowExceptionForHR(hr);
                }
                else
                {
                    MessageBox.Show("Item has no property page", "No Property Page", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                return;
            }

            //Get the name of the filter from the FilterInfo struct
            FilterInfo filterInfo;
            hr = dev.QueryFilterInfo(out filterInfo);
            DsError.ThrowExceptionForHR(hr);

            // Get the propertypages from the property bag
            DsCAUUID caGUID;
            hr = pProp.GetPages(out caGUID);
            DsError.ThrowExceptionForHR(hr);

            //Create and display the OlePropertyFrame
            object oDevice = (object)dev;
            hr = OleCreatePropertyFrame(this.Handle, 0, 0, filterInfo.achName, 1, ref oDevice, caGUID.cElems, caGUID.pElems, 0, 0, IntPtr.Zero);
            DsError.ThrowExceptionForHR(hr);

            Marshal.ReleaseComObject(oDevice);

            if (filterInfo.pGraph != null)
            {
                Marshal.ReleaseComObject(filterInfo.pGraph);
            }

            // Release COM objects
            Marshal.FreeCoTaskMem(caGUID.pElems);
        }


        //选择视频设备
        public void InitVideoDevice()
        {
            try
            {
                if (cam != null)
                    cam.Dispose();
                //读取参数
                string strTmp = inifilehelper.IniReadValue("视频采集", "摄像头序号");
                int VIDEODEVICE = Convert.ToInt32(strTmp); // zero based index of video capture device to use
                const int VIDEOWIDTH = 1024;// 是用默认（最大）分辨率
                const int VIDEOHEIGHT = 768; // Depends on video device caps
                const int VIDEOBITSPERPIXEL = 24; // BitsPerPixel values determined by device
                cam = new Capture(VIDEODEVICE, VIDEOWIDTH, VIDEOHEIGHT, VIDEOBITSPERPIXEL, picMain);
            }
            catch
            {
                MessageBox.Show("摄像头打开错误，请首先确保摄像头连接并至少支持1024*768分辨率！");
            }
        }
        #endregion

        //打开并设置目录
        private void btnSetting_Click(object sender, EventArgs e)
        {

            try
            {
                inifilehelper.IniWriteValue("保存配置", "图片存放目录", tbResultPath.Text);
                MessageBox.Show("图片存放目录保存成功！");
                //读取现有图片
                UpdateFileList();
            }
            catch 
            {
                MessageBox.Show("图片存放目录保存失败！");
            }
           


        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            string strPath = folderBrowserDialog1.SelectedPath;
            tbResultPath.Text = strPath;
        }

        //打开图像
        private void btnWatch_Click(object sender, EventArgs e)
        {
            //打开目录
            if (Directory.Exists(tbResultPath.Text))
            {
                System.Diagnostics.Process proc = new System.Diagnostics.Process();
                proc.StartInfo.FileName = tbResultPath.Text;
                proc.StartInfo.UseShellExecute = true;
                proc.Start();  
            }
        }

        //设定矫正
        private void AutoAdjust_CheckedChanged(object sender, EventArgs e)
        {
            if (AutoAdjust.Checked == true)
            {
                inifilehelper.IniWriteValue("矫正方式", "矫正","true");

            }
            else 
            {
                inifilehelper.IniWriteValue("矫正方式", "矫正", "false");
            }
        }

        //设定颜色
        private void radioColor_CheckedChanged(object sender, EventArgs e)
        {
            if (radioColor.Checked == true)
            {
                inifilehelper.IniWriteValue("拍摄类型", "拍摄类型", "彩色");
            }
            else if (radioGray.Checked == true)
            {
                inifilehelper.IniWriteValue("拍摄类型", "拍摄类型", "灰度");
            }
            else 
            {
                inifilehelper.IniWriteValue("拍摄类型", "拍摄类型", "二值");
            }
        }

       
    }
}
