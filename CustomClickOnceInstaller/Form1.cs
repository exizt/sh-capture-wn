﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Deployment.Application;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomClickOnceInstaller
{
    public partial class Form1 : Form
    {
        CustomInstaller installer;
        public const string URL_APPLICATION = "http://imagecapture.asv.kr/Image_Capture.application";
        public Form1()
        {
            InitializeComponent();

            label1.Text = "정보를 조회중입니다...";
            //string s = ApplicationDeployment.CurrentDeployment.ActivationUri.ToString();
            string s = ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString();
            label1.Text = s;

            return;
            progressBar1.Step = 10;
            progressBar1.Style = ProgressBarStyle.Marquee;
            progressBar1.MarqueeAnimationSpeed = 30;
            button1.Visible = false;

            installer = new CustomInstaller(this);
            installer.PrepareApplication(URL_APPLICATION);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            installer.InstallApplication();
            //MessageBox.Show("설치를 완료하였습니다.");
        }
    }
}
