using MediaTinLanh.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaTinLanh.Control
{
    public class Control_Xml
    {
        Data_Xml m_Xml_Data = new Data_Xml();

        public void ReadFile(string xmlfilepath, ref string servername, ref string port, ref string username,
            ref string password, ref string databasename)
        {
            string[] ConnectionInfo = m_Xml_Data.ReadXMLFile(xmlfilepath);
            servername = ConnectionInfo[0];
            port = ConnectionInfo[1];
            username = ConnectionInfo[2];
            password = ConnectionInfo[3];
            databasename = ConnectionInfo[4];
        }

        public void GetFtpAccount(string xmlfilepath, ref string server, ref string username, ref string password)
        {
            string[] FTPInfo = m_Xml_Data.ReadXMLFile(xmlfilepath);
            server = FTPInfo[5];
            username = FTPInfo[6];
            password = FTPInfo[7];
        }
        
        public void CheckVersion(string xmlfilepath, ref string nowversion, ref string newversion, ref string dateupdate,
            ref string datenewversion)
        {
            string[] ConnectionInfo = m_Xml_Data.ReadXMLFile(xmlfilepath);
            string content;
            using (var wc = new System.Net.WebClient())
                content = wc.DownloadString("https://updater.jhteam.net/jhsales/last/version.txt");
            datenewversion = content.Substring(content.IndexOf("-") + 1);
            newversion = content.Substring(0, content.Length - content.IndexOf("-"));
            nowversion = ConnectionInfo[3];
            dateupdate = ConnectionInfo[4];

        }
        public void SaveFile(string xmlfilepath, string servername, string port, string username, string password, string databasename,
            string fptserver, string ftpusername, string ftppassword)
        {
            //mã hóa password
            Control_Security baomatdata = new Control_Security();
            password = baomatdata.Mahoa(password, "lnduc");
            m_Xml_Data.WriteXMLFile(xmlfilepath, servername, port, username, password, databasename, fptserver,
                ftpusername, ftppassword);
        }
        public string LayTenSCDL(string xmlfilepath)
        {
            return m_Xml_Data.ReadXMLFile(xmlfilepath)[4].ToString();
        }
    }
}
