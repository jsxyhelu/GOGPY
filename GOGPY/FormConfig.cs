using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DirectShowLib;
using System.Runtime.InteropServices;
namespace GOGPY
{
    public partial class FormConfig : Form
    {
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
        INIFileHelper inifilehelper = new INIFileHelper("./GOConfig");

        public FormMain fatherForm;
        public FormConfig()
        {
            InitializeComponent();
            foreach (DsDevice ds in DsDevice.GetDevicesOfCat(FilterCategory.VideoInputDevice))
            {
                comboBox1.Items.Add(ds.Name);
            }
            //读取数据库
            string strtmp = inifilehelper.IniReadValue("视频采集", "摄像头序号");
            int itmp = Convert.ToInt32(strtmp);
            if(itmp > comboBox1.Items.Count)
            {
                itmp = 0;
            }
            if (comboBox1.Items.Count > 0)
            {
                comboBox1.SelectedIndex = itmp;
            }
        }

        //选择不同视频采集设备
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Release COM objects
            if (theDevice != null)
            {
                Marshal.ReleaseComObject(theDevice);
                theDevice = null;
            }
            //Create the filter for the selected video input device
            string devicepath = comboBox1.SelectedItem.ToString();
            theDevice = CreateFilter(FilterCategory.VideoInputDevice, devicepath);
        }

        //视频设置
        private void btnVideoConfig_Click(object sender, EventArgs e)
        {
            DisplayPropertyPage(theDevice);
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

        //保存数据到数据持久层。这里的程序比较简单，就直接保存到ini中去
        private void btnSave_Click(object sender, EventArgs e)
        {
            int itmp = comboBox1.SelectedIndex;
            inifilehelper.IniWriteValue("视频采集", "摄像头序号", itmp.ToString());

            inifilehelper.IniWriteValue("图像参数", "摄像头序号", "empty");
            inifilehelper.IniWriteValue("分辨率", "摄像头序号", "empty");
            inifilehelper.IniWriteValue("图片格式", "摄像头序号", "empty");
            inifilehelper.IniWriteValue("图片压缩", "摄像头序号", "empty");

            inifilehelper.IniWriteValue("保存配置", "自定义文件名", "TRUE");
            inifilehelper.IniWriteValue("保存配置", "前缀", "empty");
            inifilehelper.IniWriteValue("保存配置", "后缀", "empty");

            MessageBox.Show("配置保存成功!");

            //强刷
            fatherForm.InitVideoDevice();
            this.Hide();
        }
    }
}
