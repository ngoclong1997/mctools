﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;
using ServerScan.Helper;

namespace ServerScan
{
    class ScanSettings
    {
        public int dpi = 200;
        public int color = 4; //4 is black-white, gray is 2, color is 1
        public bool adf = false;
        public bool tryFlatbed = false; //try flatbed if adf fails
    }

    class Scan
    {
        public static List<Image> StartScan()
        {
            List<Image> result = new List<Image>();
            if (Program.config.SavePath == "")
            {
                Program.ShowError("Vui lòng chọn thư mục lưu kết quả");
                return result;
            }

            if (!PathWritable(Program.config.SavePath))
            {
                Program.ShowError("Thư mục lưu kết quả không được quyền ghi dữ liệu");
                return result;
            }

            if (Program.config.ScannerID == "")
            {
                Program.ShowError("Vui lòng chọn máy quét!");
                return result;
            }

            //Load settings
            ScanSettings settings = new ScanSettings();
            settings.color = Program.config.ScanColor;
            settings.dpi = Program.config.ScanDpi;
            settings.adf = Program.config.ScanADF;
            settings.tryFlatbed = Program.config.ScanTryFlatbed;

            try
            {
                result = WIAScanner.Scan(Program.config.ScannerID, settings);
                //Call garbage collector
                GC.Collect();
            }
            catch (Exception ex)
            {
                Program.ShowError(ex);
            }
            return result;
        }

        private static Boolean PathWritable(String path)
        {
            try
            {
                System.Security.AccessControl.DirectorySecurity ds = Directory.GetAccessControl(path);
                return true;
            }
            catch (UnauthorizedAccessException)
            {
                return false;
            }
            catch (Exception)
            {
                Program.ShowError("Không thể truy cập vào đường dẫn lưu kết quả");
                return false;
            }
        }

        public static int SaveImages(List<Image> list)
        {
            if (!PathWritable(Program.config.SavePath))
            {
                Program.ShowError("Đường dẫn lưu kết quả không được phép ghi");
                return 0;
            }
            Logger.Log("Finished scanning " + list.Count + " files");
            DateTime now = DateTime.Now;
            ImageHelper.createTif(list, Program.config.SavePath + "\\" + now.ToString("yy_MM_dd-H_mm_ss") + ".tif");
            return 1;
        }


    }
}