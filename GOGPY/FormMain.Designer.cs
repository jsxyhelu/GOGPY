namespace GOGPY
{
    partial class FormMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
     

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.picPreview = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbExposure = new System.Windows.Forms.TrackBar();
            this.cbExposure = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnWatch = new System.Windows.Forms.Button();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.btnSetting = new System.Windows.Forms.Button();
            this.tbResultPath = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.NoAdjust = new System.Windows.Forms.RadioButton();
            this.AutoAdjust = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.radioBin = new System.Windows.Forms.RadioButton();
            this.radioGray = new System.Windows.Forms.RadioButton();
            this.radioColor = new System.Windows.Forms.RadioButton();
            this.btnCapture = new System.Windows.Forms.Button();
            this.btnConfig = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.camtimer = new System.Windows.Forms.Timer(this.components);
            this.picMain = new System.Windows.Forms.PictureBox();
            this.btnVideoConfig = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbExposure)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.SuspendLayout();
            // 
            // picPreview
            // 
            this.picPreview.BackColor = System.Drawing.SystemColors.ControlDark;
            this.picPreview.Image = ((System.Drawing.Image)(resources.GetObject("picPreview.Image")));
            this.picPreview.Location = new System.Drawing.Point(12, 12);
            this.picPreview.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picPreview.Name = "picPreview";
            this.picPreview.Size = new System.Drawing.Size(1203, 802);
            this.picPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picPreview.TabIndex = 0;
            this.picPreview.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(1233, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 27);
            this.label1.TabIndex = 1;
            this.label1.Text = "摄像头选择：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(1154, 887);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 27);
            this.label2.TabIndex = 1;
            this.label2.Text = "曝光度：";
            this.label2.Visible = false;
            // 
            // tbExposure
            // 
            this.tbExposure.Enabled = false;
            this.tbExposure.Location = new System.Drawing.Point(1238, 891);
            this.tbExposure.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbExposure.Name = "tbExposure";
            this.tbExposure.Size = new System.Drawing.Size(192, 56);
            this.tbExposure.TabIndex = 2;
            this.tbExposure.Visible = false;
            // 
            // cbExposure
            // 
            this.cbExposure.AutoSize = true;
            this.cbExposure.Enabled = false;
            this.cbExposure.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbExposure.Location = new System.Drawing.Point(1436, 890);
            this.cbExposure.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbExposure.Name = "cbExposure";
            this.cbExposure.Size = new System.Drawing.Size(74, 31);
            this.cbExposure.TabIndex = 3;
            this.cbExposure.Text = "自动";
            this.cbExposure.UseVisualStyleBackColor = true;
            this.cbExposure.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnWatch);
            this.groupBox1.Controls.Add(this.btnBrowse);
            this.groupBox1.Controls.Add(this.btnSetting);
            this.groupBox1.Controls.Add(this.tbResultPath);
            this.groupBox1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(1227, 92);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(371, 162);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "图像存放位置";
            // 
            // btnWatch
            // 
            this.btnWatch.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnWatch.Location = new System.Drawing.Point(55, 101);
            this.btnWatch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnWatch.Name = "btnWatch";
            this.btnWatch.Size = new System.Drawing.Size(123, 32);
            this.btnWatch.TabIndex = 1;
            this.btnWatch.Text = "浏览图像";
            this.btnWatch.UseVisualStyleBackColor = true;
            this.btnWatch.Click += new System.EventHandler(this.btnWatch_Click);
            // 
            // btnBrowse
            // 
            this.btnBrowse.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnBrowse.Location = new System.Drawing.Point(299, 42);
            this.btnBrowse.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(63, 32);
            this.btnBrowse.TabIndex = 1;
            this.btnBrowse.Text = "……";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // btnSetting
            // 
            this.btnSetting.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSetting.Location = new System.Drawing.Point(224, 101);
            this.btnSetting.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSetting.Name = "btnSetting";
            this.btnSetting.Size = new System.Drawing.Size(123, 32);
            this.btnSetting.TabIndex = 1;
            this.btnSetting.Text = "存储设置";
            this.btnSetting.UseVisualStyleBackColor = true;
            this.btnSetting.Click += new System.EventHandler(this.btnSetting_Click);
            // 
            // tbResultPath
            // 
            this.tbResultPath.Location = new System.Drawing.Point(19, 41);
            this.tbResultPath.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbResultPath.Name = "tbResultPath";
            this.tbResultPath.Size = new System.Drawing.Size(278, 34);
            this.tbResultPath.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.NoAdjust);
            this.groupBox2.Controls.Add(this.AutoAdjust);
            this.groupBox2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.Location = new System.Drawing.Point(1227, 261);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(371, 159);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "矫正方式";
            // 
            // NoAdjust
            // 
            this.NoAdjust.AutoSize = true;
            this.NoAdjust.Location = new System.Drawing.Point(204, 74);
            this.NoAdjust.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.NoAdjust.Name = "NoAdjust";
            this.NoAdjust.Size = new System.Drawing.Size(93, 31);
            this.NoAdjust.TabIndex = 0;
            this.NoAdjust.TabStop = true;
            this.NoAdjust.Text = "不矫正";
            this.NoAdjust.UseVisualStyleBackColor = true;
            this.NoAdjust.CheckedChanged += new System.EventHandler(this.AutoAdjust_CheckedChanged);
            // 
            // AutoAdjust
            // 
            this.AutoAdjust.AutoSize = true;
            this.AutoAdjust.Location = new System.Drawing.Point(55, 74);
            this.AutoAdjust.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.AutoAdjust.Name = "AutoAdjust";
            this.AutoAdjust.Size = new System.Drawing.Size(113, 31);
            this.AutoAdjust.TabIndex = 0;
            this.AutoAdjust.TabStop = true;
            this.AutoAdjust.Text = "自动矫正";
            this.AutoAdjust.UseVisualStyleBackColor = true;
            this.AutoAdjust.CheckedChanged += new System.EventHandler(this.AutoAdjust_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Controls.Add(this.radioBin);
            this.groupBox3.Controls.Add(this.radioGray);
            this.groupBox3.Controls.Add(this.radioColor);
            this.groupBox3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox3.Location = new System.Drawing.Point(1227, 438);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Size = new System.Drawing.Size(371, 162);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "拍摄类型";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(5, 120);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(357, 42);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // radioBin
            // 
            this.radioBin.AutoSize = true;
            this.radioBin.Location = new System.Drawing.Point(224, 58);
            this.radioBin.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioBin.Name = "radioBin";
            this.radioBin.Size = new System.Drawing.Size(73, 31);
            this.radioBin.TabIndex = 0;
            this.radioBin.TabStop = true;
            this.radioBin.Text = "黑白";
            this.radioBin.UseVisualStyleBackColor = true;
            this.radioBin.CheckedChanged += new System.EventHandler(this.radioColor_CheckedChanged);
            // 
            // radioGray
            // 
            this.radioGray.AutoSize = true;
            this.radioGray.Location = new System.Drawing.Point(127, 58);
            this.radioGray.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioGray.Name = "radioGray";
            this.radioGray.Size = new System.Drawing.Size(73, 31);
            this.radioGray.TabIndex = 0;
            this.radioGray.TabStop = true;
            this.radioGray.Text = "灰度";
            this.radioGray.UseVisualStyleBackColor = true;
            this.radioGray.CheckedChanged += new System.EventHandler(this.radioColor_CheckedChanged);
            // 
            // radioColor
            // 
            this.radioColor.AutoSize = true;
            this.radioColor.Location = new System.Drawing.Point(31, 58);
            this.radioColor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioColor.Name = "radioColor";
            this.radioColor.Size = new System.Drawing.Size(73, 31);
            this.radioColor.TabIndex = 0;
            this.radioColor.TabStop = true;
            this.radioColor.Text = "彩色";
            this.radioColor.UseVisualStyleBackColor = true;
            this.radioColor.CheckedChanged += new System.EventHandler(this.radioColor_CheckedChanged);
            // 
            // btnCapture
            // 
            this.btnCapture.AutoSize = true;
            this.btnCapture.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCapture.Image = ((System.Drawing.Image)(resources.GetObject("btnCapture.Image")));
            this.btnCapture.Location = new System.Drawing.Point(1420, 618);
            this.btnCapture.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCapture.Name = "btnCapture";
            this.btnCapture.Size = new System.Drawing.Size(179, 198);
            this.btnCapture.TabIndex = 1;
            this.btnCapture.Text = "拍摄";
            this.btnCapture.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCapture.UseVisualStyleBackColor = false;
            this.btnCapture.Click += new System.EventHandler(this.btnCapture_Click);
            // 
            // btnConfig
            // 
            this.btnConfig.AutoSize = true;
            this.btnConfig.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnConfig.Image = ((System.Drawing.Image)(resources.GetObject("btnConfig.Image")));
            this.btnConfig.Location = new System.Drawing.Point(1227, 618);
            this.btnConfig.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnConfig.Name = "btnConfig";
            this.btnConfig.Size = new System.Drawing.Size(184, 198);
            this.btnConfig.TabIndex = 1;
            this.btnConfig.Text = "设置";
            this.btnConfig.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnConfig.UseVisualStyleBackColor = false;
            this.btnConfig.Click += new System.EventHandler(this.btnConfig_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 820);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(139, 159);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // camtimer
            // 
            this.camtimer.Interval = 50;
            this.camtimer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // picMain
            // 
            this.picMain.Image = ((System.Drawing.Image)(resources.GetObject("picMain.Image")));
            this.picMain.Location = new System.Drawing.Point(800, 12);
            this.picMain.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picMain.Name = "picMain";
            this.picMain.Size = new System.Drawing.Size(413, 376);
            this.picMain.TabIndex = 5;
            this.picMain.TabStop = false;
            this.picMain.Visible = false;
            // 
            // btnVideoConfig
            // 
            this.btnVideoConfig.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnVideoConfig.Location = new System.Drawing.Point(1451, 45);
            this.btnVideoConfig.Name = "btnVideoConfig";
            this.btnVideoConfig.Size = new System.Drawing.Size(134, 33);
            this.btnVideoConfig.TabIndex = 11;
            this.btnVideoConfig.Text = "视频设置";
            this.btnVideoConfig.UseVisualStyleBackColor = true;
            this.btnVideoConfig.Click += new System.EventHandler(this.btnVideoConfig_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(1246, 52);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(180, 23);
            this.comboBox1.TabIndex = 12;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(169, 819);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(139, 159);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 13;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(326, 819);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(139, 159);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 14;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(484, 818);
            this.pictureBox4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(139, 159);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 15;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox5.Image")));
            this.pictureBox5.Location = new System.Drawing.Point(641, 818);
            this.pictureBox5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(139, 159);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 16;
            this.pictureBox5.TabStop = false;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1607, 990);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.btnVideoConfig);
            this.Controls.Add(this.picMain);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnConfig);
            this.Controls.Add(this.btnCapture);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cbExposure);
            this.Controls.Add(this.tbExposure);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.picPreview);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GOGPY(2018年8月11日 jsxyhelu.cnblogs.com）";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbExposure)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picPreview;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TrackBar tbExposure;
        private System.Windows.Forms.CheckBox cbExposure;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSetting;
        private System.Windows.Forms.TextBox tbResultPath;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton NoAdjust;
        private System.Windows.Forms.RadioButton AutoAdjust;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton radioBin;
        private System.Windows.Forms.RadioButton radioGray;
        private System.Windows.Forms.RadioButton radioColor;
        private System.Windows.Forms.Button btnCapture;
        private System.Windows.Forms.Button btnConfig;
        private System.Windows.Forms.Button btnWatch;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer camtimer;
        private System.Windows.Forms.PictureBox picMain;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnVideoConfig;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox5;
    }
}

