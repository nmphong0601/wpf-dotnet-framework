using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace MediaTinLanh.Control
{
    public class Control_FTP
    {
        private string[] GetFilesDetailList()
        {
            string[] downloadFiles;
            try
            {
                StringBuilder result = new StringBuilder();
                FtpWebRequest ftp;
                ftp = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://" + Control_Security.FTP_Server + "/"));
                ftp.Credentials = new NetworkCredential(Control_Security.FTP_Username, Control_Security.FTP_Password);
                ftp.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
                WebResponse response = ftp.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());
                string line = reader.ReadLine();
                while (line != null)
                {
                    result.Append(line);
                    result.Append("\n");
                    line = reader.ReadLine();
                }

                result.Remove(result.ToString().LastIndexOf("\n"), 1);
                reader.Close();
                response.Close();
                return result.ToString().Split('\n');
                //MessageBox.Show(result.ToString().Split('\n'));
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                downloadFiles = null;
                return downloadFiles;
            }
        }
        //Lấy dữ liệu từ FTP server
        public static List<string> ListFiles()
        {
            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(Control_Security.FTP_Server);
                request.Method = WebRequestMethods.Ftp.ListDirectory;

                request.Credentials = new NetworkCredential(Control_Security.FTP_Username, Control_Security.FTP_Password);
                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                Stream responseStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(responseStream);
                string names = reader.ReadToEnd();

                reader.Close();
                response.Close();

                return names.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static string[] GetFileList()
        {
            string[] downloadFiles;
            StringBuilder result = new StringBuilder();
            FtpWebRequest reqFTP;
            try
            {
                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://" + Control_Security.FTP_Server + "/TC_PP/"));
                reqFTP.UseBinary = true;
                reqFTP.Credentials = new NetworkCredential(Control_Security.FTP_Username, Control_Security.FTP_Password);
                reqFTP.Method = WebRequestMethods.Ftp.ListDirectory;
                WebResponse response = reqFTP.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());
                //MessageBox.Show(reader.ReadToEnd());
                string line = reader.ReadLine();
                while (line != null)
                {
                    result.Append(line);
                    result.Append("\n");
                    line = reader.ReadLine();
                }
                result.Remove(result.ToString().LastIndexOf('\n'), 1);
                reader.Close();
                response.Close();
                //MessageBox.Show(response.StatusDescription);
                return result.ToString().Split('\n');
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                downloadFiles = null;
                return downloadFiles;
            }
        }
        #region Upload file

        public static void upload_files(string localFile, string remotepath)
        {
            using (var client = new WebClient())
            {
                if (Control_Security.GET_FTP())
                {
                    Control_Security.GET_FTP();
                    client.Credentials = new NetworkCredential(Control_Security.FTP_Username, Control_Security.FTP_Password);
                    client.UploadFile(Control_Security.FTP_Server + remotepath, WebRequestMethods.Ftp.UploadFile, localFile);
                }
            }
        }

        #endregion
        
        #region Download files

        public static void Download_files(string inputfilepath, string FilePathOnRemote)
        {
            if(Control_Security.GET_FTP())
            {
                string ftpfullpath = "ftp://" + Control_Security.FTP_Server + "//" + FilePathOnRemote;

                using (WebClient request = new WebClient())
                {
                    request.Credentials = new NetworkCredential(Control_Security.FTP_Username, Control_Security.FTP_Password);
                    byte[] fileData = request.DownloadData(ftpfullpath);

                    FileInfo fileInfo = new FileInfo(inputfilepath);
                    fileInfo.Directory.Create();

                    using (FileStream file = File.Create(inputfilepath))
                    {
                        file.Write(fileData, 0, fileData.Length);
                        file.Close();
                    }
                }
            }
            else
            {

            }
            
        }

        #endregion
    }
}
