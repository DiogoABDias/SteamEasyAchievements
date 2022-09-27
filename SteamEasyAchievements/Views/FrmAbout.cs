﻿using System.Diagnostics;

namespace SteamDlcShopping.Views
{
    public partial class FrmAbout : Form
    {
        public FrmAbout()
        {
            InitializeComponent();
        }

        private void lnkAbout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process process = new()
            {
                StartInfo = new()
                {
                    CreateNoWindow = true,
                    UseShellExecute = false,
                    FileName = "cmd.exe",
                    Arguments = "/c start https://github.com/DiogoABDias/SteamDlcShopping"
                }
            };

            process.Start();
        }
    }
}