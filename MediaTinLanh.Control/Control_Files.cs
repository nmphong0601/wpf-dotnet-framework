using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;
using System.Net;

namespace MediaTinLanh.Control
{
    public class Control_Files
    {
        //Lấy toàn bộ dữ liệu từ thư mục
        public static string[] files(string path)
        {
            string[] files = Directory.GetFiles(path);
            return files;
        }

        //Lấy toàn bộ dữ liệu từ thư mục theo định dạng
        public static string[] files(string path, string etx)
        {
            string[] files = new string[]{};
            DirectoryInfo d = new DirectoryInfo(path);//Assuming Test is your Folder
            FileInfo[] Files = d.GetFiles(etx); //Getting Text files
            int i = 0;
            foreach (FileInfo file in Files)
            {
                files[i] = file.Name;
                i++;
            }
            return files;
        }

        //Lấy MD5
        public static string GetMD5(string filename)
        {
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(filename))
                {
                    var hash = md5.ComputeHash(stream);
                    return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                }
            }
        }

        //Kiểm tra tồn tại
        public static bool CheckExit(string filename)
        {
            return File.Exists(filename);
        }
    }
}
