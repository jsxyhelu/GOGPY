namespace GOGPY
{
    partial class FormConfig
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormConfig));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbModel = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbResolution = new System.Windows.Forms.ComboBox();
            this.radioJPG = new System.Windows.Forms.RadioButton();
            this.radioBMP = new System.Windows.Forms.RadioButton();
            this.radioPNG = new System.Windows.Forms.RadioButton();
            this.tbCompress = new System.Windows.Forms.TrackBar();
            this.labelCompress = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioTimeAsFileName = new System.Windows.Forms.RadioButton();
            this.radioAutoFilename = new System.Windows.Forms.RadioButton();
            this.label9 = new System.Windows.Forms.Label();
            this.editPre1 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.editPre2 = new System.Windows.Forms.TextBox();
            this.btnDefault = new System.Windows.Forms.Button();
            this.btnVideoConfig = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbCompress)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbCompress);
            this.groupBox1.Controls.Add(this.radioPNG);
            this.groupBox1.Controls.Add(this.radioBMP);
            this.groupBox1.Controls.Add(this.radioJPG);
            this.groupBox1.Controls.Add(this.cbResolution);
            this.groupBox1.Controls.Add(this.cbModel);
            this.groupBox1.Controls.Add(this.labelCompress);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(606, 239);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "图片参数";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "渲染模式：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(49, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 25);
            this.label2.TabIndex = 0;
            this.label2.Text = "图片格式：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(49, 170);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 25);
            this.label3.TabIndex = 0;
            this.label3.Text = "图片压缩：";
            // 
            // cbModel
            // 
            this.cbModel.FormattingEnabled = true;
            this.cbModel.Location = new System.Drawing.Point(162, 36);
            this.cbModel.Name = "cbModel";
            this.cbModel.Size = new System.Drawing.Size(121, 32);
            this.cbModel.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(302, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 25);
            this.label4.TabIndex = 0;
            this.label4.Text = "分辨率：";
            // 
            // cbResolution
            // 
            this.cbResolution.FormattingEnabled = true;
            this.cbResolution.Location = new System.Drawing.Point(396, 36);
            this.cbResolution.Name = "cbResolution";
            this.cbResolution.Size = new System.Drawing.Size(154, 32);
            this.cbResolution.TabIndex = 1;
            // 
            // radioJPG
            // 
            this.radioJPG.AutoSize = true;
            this.radioJPG.Location = new System.Drawing.Point(163, 103);
            this.radioJPG.Name = "radioJPG";
            this.radioJPG.Size = new System.Drawing.Size(81, 29);
            this.radioJPG.TabIndex = 2;
            this.radioJPG.TabStop = true;
            this.radioJPG.Text = "*.JPG";
            this.radioJPG.UseVisualStyleBackColor = true;
            // 
            // radioBMP
            // 
            this.radioBMP.AutoSize = true;
            this.radioBMP.Location = new System.Drawing.Point(283, 103);
            this.radioBMP.Name = "radioBMP";
            this.radioBMP.Size = new System.Drawing.Size(90, 29);
            this.radioBMP.TabIndex = 2;
            this.radioBMP.TabStop = true;
            this.radioBMP.Text = "*.BMP";
            this.radioBMP.UseVisualStyleBackColor = true;
            // 
            // radioPNG
            // 
            this.radioPNG.AutoSize = true;
            this.radioPNG.Location = new System.Drawing.Point(410, 103);
            this.radioPNG.Name = "radioPNG";
            this.radioPNG.Size = new System.Drawing.Size(88, 29);
            this.radioPNG.TabIndex = 2;
            this.radioPNG.TabStop = true;
            this.radioPNG.Text = "*.PNG";
            this.radioPNG.UseVisualStyleBackColor = true;
            // 
            // tbCompress
            // 
            this.tbCompress.Location = new System.Drawing.Point(163, 170);
            this.tbCompress.Name = "tbCompress";
            this.tbCompress.Size = new System.Drawing.Size(335, 56);
            this.tbCompress.TabIndex = 3;
            // 
            // labelCompress
            // 
            this.labelCompress.AutoSize = true;
            this.labelCompress.Location = new System.Drawing.Point(509, 170);
            this.labelCompress.Name = "labelCompress";
            this.labelCompress.Size = new System.Drawing.Size(51, 25);
            this.labelCompress.TabIndex = 0;
            this.labelCompress.Text = "80%";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.editPre2);
            this.groupBox2.Controls.Add(this.editPre1);
            this.groupBox2.Controls.Add(this.radioTimeAsFileName);
            this.groupBox2.Controls.Add(this.radioAutoFilename);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.Location = new System.Drawing.Point(12, 257);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(606, 188);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "保存配置";
            // 
            // radioTimeAsFileName
            // 
            this.radioTimeAsFileName.AutoSize = true;
            this.radioTimeAsFileName.Location = new System.Drawing.Point(54, 122);
            this.radioTimeAsFileName.Name = "radioTimeAsFileName";
            this.radioTimeAsFileName.Size = new System.Drawing.Size(185, 29);
            this.radioTimeAsFileName.TabIndex = 2;
            this.radioTimeAsFileName.TabStop = true;
            this.radioTimeAsFileName.Text = "拍摄时间为文件名";
            this.radioTimeAsFileName.UseVisualStyleBackColor = true;
            // 
            // radioAutoFilename
            // 
            this.radioAutoFilename.AutoSize = true;
            this.radioAutoFilename.Location = new System.Drawing.Point(54, 52);
            this.radioAutoFilename.Name = "radioAutoFilename";
            this.radioAutoFilename.Size = new System.Drawing.Size(147, 29);
            this.radioAutoFilename.TabIndex = 2;
            this.radioAutoFilename.TabStop = true;
            this.radioAutoFilename.Text = "自定义文件名";
            this.radioAutoFilename.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(246, 56);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(69, 25);
            this.label9.TabIndex = 0;
            this.label9.Text = "前缀：";
            // 
            // editPre1
            // 
            this.editPre1.Location = new System.Drawing.Point(321, 53);
            this.editPre1.Name = "editPre1";
            this.editPre1.Size = new System.Drawing.Size(99, 31);
            this.editPre1.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(429, 58);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(26, 25);
            this.label6.TabIndex = 0;
            this.label6.Text = "+";
            // 
            // editPre2
            // 
            this.editPre2.Location = new System.Drawing.Point(461, 53);
            this.editPre2.Name = "editPre2";
            this.editPre2.Size = new System.Drawing.Size(99, 31);
            this.editPre2.TabIndex = 3;
            // 
            // btnDefault
            // 
            this.btnDefault.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDefault.Location = new System.Drawing.Point(56, 484);
            this.btnDefault.Name = "btnDefault";
            this.btnDefault.Size = new System.Drawing.Size(98, 33);
            this.btnDefault.TabIndex = 2;
            this.btnDefault.Text = "默认设置";
            this.btnDefault.UseVisualStyleBackColor = true;
            // 
            // btnVideoConfig
            // 
            this.btnVideoConfig.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnVideoConfig.Location = new System.Drawing.Point(369, 485);
            this.btnVideoConfig.Name = "btnVideoConfig";
            this.btnVideoConfig.Size = new System.Drawing.Size(98, 33);
            this.btnVideoConfig.TabIndex = 2;
            this.btnVideoConfig.Text = "视频设置";
            this.btnVideoConfig.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSave.Location = new System.Drawing.Point(473, 485);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(98, 33);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // FormConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(630, 567);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnVideoConfig);
            this.Controls.Add(this.btnDefault);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormConfig";
            this.Text = "系统设置";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbCompress)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbResolution;
        private System.Windows.Forms.ComboBox cbModel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton radioPNG;
        private System.Windows.Forms.RadioButton radioBMP;
        private System.Windows.Forms.RadioButton radioJPG;
        private System.Windows.Forms.TrackBar tbCompress;
        private System.Windows.Forms.Label labelCompress;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radioTimeAsFileName;
        private System.Windows.Forms.RadioButton radioAutoFilename;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox editPre2;
        private System.Windows.Forms.TextBox editPre1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnDefault;
        private System.Windows.Forms.Button btnVideoConfig;
        private System.Windows.Forms.Button btnSave;
    }
}