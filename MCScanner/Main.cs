﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ServerScan
{
    public partial class Main : Form
    {
        List<Image> images = new List<Image>();
        public Main()
        {
            InitializeComponent();
            LoadProps();

            if (Program.config.StartMinimized)
                WindowState = FormWindowState.Minimized;
        }

        public void LoadProps()
        {
            if (Program.config.ScannerID != "")
                lb_scanner.Text = Program.config.ScannerName;
            if (Program.config.SavePath != "")
                lb_path.Text = Program.config.SavePath;

            check_useAdf.Checked = Program.config.ScanADF;
            check_tryFlatbed.Checked = Program.config.ScanTryFlatbed;
            combo_dpi.SelectedItem = Program.config.ScanDpi.ToString();
            check_tryFlatbed.Enabled = check_useAdf.Checked;

            switch (Program.config.ScanColor)
            {
                case 4:
                    combo_color.SelectedItem = "Black & White";
                    break;
                case 2:
                    combo_color.SelectedItem = "Grayscale";
                    break;
                case 1:
                    combo_color.SelectedItem = "Color";
                    break;
            }
        }
        
        private void bt_selectScanner_Click(object sender, EventArgs e)
        {
            Form select = new SelectScanner();
            select.Show();
        }

        private void bt_startScan_Click(object sender, EventArgs e)
        {
            List<Image> scanResult = Scan.StartScan();
            images.AddRange(scanResult);
        }

        private void bt_path_Click(object sender, EventArgs e)
        {
            if (pathBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                Program.config.SavePath = pathBrowserDialog.SelectedPath;
                Program.config.Serialize();
                LoadProps();
            }
        }

        private void check_useAdf_Click(object sender, EventArgs e)
        {
            Program.config.ScanADF = check_useAdf.Checked;
            Program.config.Serialize();
        }

        private void check_tryFlatbed_Click(object sender, EventArgs e)
        {
            Program.config.ScanTryFlatbed = check_tryFlatbed.Checked;
            Program.config.Serialize();
        }

        private void combo_color_Leave(object sender, EventArgs e)
        {
            switch (combo_color.SelectedItem.ToString())
            {
                case "Black & White":
                    Program.config.ScanColor = 4;
                    break;
                case "Greyscale":
                    Program.config.ScanColor = 2;
                    break;
                case "Color":
                    Program.config.ScanColor = 1;
                    break;
            }

            Program.config.Serialize();
        }

        private void combo_dpi_Leave(object sender, EventArgs e)
        {
            Program.config.ScanDpi = Convert.ToInt32(combo_dpi.SelectedItem);
            Program.config.Serialize();
        }

        private void check_useAdf_CheckStateChanged(object sender, EventArgs e)
        {
            check_tryFlatbed.Enabled = check_useAdf.Checked;
        }

        private void Main_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == WindowState)
            {
                Hide();
                mainNotify.Visible = true;
            }
        }

        private void mainNotify_DoubleClick(object sender, EventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
            mainNotify.Visible = false;
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            List<Image> scanResult = Scan.StartScan();
            images.AddRange(scanResult);
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            Scan.SaveImages(images);   
        }

        private void ListBoxImageScanned_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            ListBoxImageScanned.Items.Clear();
            images.Clear();
            List<Image> scanResult = Scan.StartScan();
            images.AddRange(scanResult);
        }
    }
}