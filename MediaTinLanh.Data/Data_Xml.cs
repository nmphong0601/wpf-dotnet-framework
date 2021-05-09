using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace MediaTinLanh.Data
{
    public class Data_Xml
    {
        public void WriteXMLFile(string filepath, string server, string port, string user, string pass, string databasename, 
            string fptserver, string ftpusername, string ftppassword)
        {
            XmlTextWriter xmltextwriter = new XmlTextWriter(filepath, System.Text.Encoding.Unicode);
            // mở file xml để ghi
            xmltextwriter.WriteStartDocument();

            //Ghi chú thích
            xmltextwriter.WriteComment(
                "\nKhông được tự thay đổi nội dung trong tập tin này!\n Các thông số cơ bản:\n\t " +
                "quyenhan= Quyền Windows.\n\t quyenhan=s: Quyền SQL.\n\t servername: tên server.\n\t " +
                "username: tên đăng nhập hệ thống.\n\t password: mật khẩu dùng đăng nhập hệ thống.\n\t " +
                "database: tên cơ sở dữ liệu của chương trình.");


            xmltextwriter.WriteStartElement("Config");
            xmltextwriter.WriteString("\n\t");

            xmltextwriter.WriteStartElement("servername");
            xmltextwriter.WriteString(server);
            xmltextwriter.WriteEndElement();
            xmltextwriter.WriteString("\n\t");

            xmltextwriter.WriteStartElement("port");
            xmltextwriter.WriteString(port);
            xmltextwriter.WriteEndElement();
            xmltextwriter.WriteString("\n\t");

            xmltextwriter.WriteStartElement("username");
            xmltextwriter.WriteString(user);
            xmltextwriter.WriteEndElement();
            xmltextwriter.WriteString("\n\t");

            xmltextwriter.WriteStartElement("password");
            xmltextwriter.WriteString(pass);
            xmltextwriter.WriteEndElement();
            xmltextwriter.WriteString("\n\t");

            xmltextwriter.WriteStartElement("database");
            xmltextwriter.WriteString(databasename);
            xmltextwriter.WriteEndElement();
            xmltextwriter.WriteString("\n");

            xmltextwriter.WriteStartElement("ftpserver");
            xmltextwriter.WriteString(databasename);
            xmltextwriter.WriteEndElement();
            xmltextwriter.WriteString("\n");

            xmltextwriter.WriteStartElement("ftpusername");
            xmltextwriter.WriteString(databasename);
            xmltextwriter.WriteEndElement();
            xmltextwriter.WriteString("\n");

            xmltextwriter.WriteStartElement("ftppassword");
            xmltextwriter.WriteString(databasename);
            xmltextwriter.WriteEndElement();
            xmltextwriter.WriteString("\n");

            xmltextwriter.WriteEndDocument();
            xmltextwriter.Close();
        }
        public string[] ReadXMLFile(string filepath)
        {
            XmlTextReader xmltextreader = new XmlTextReader(filepath);
            xmltextreader.Read();
            string kq = "";
            while (xmltextreader.Read())
            {
                if (xmltextreader.NodeType == XmlNodeType.Text)
                    kq += xmltextreader.ReadContentAsString() + ",";
            }
            kq = kq.Remove(kq.Length - 1);
            return kq.Split(new char[1] { ',' });
        }
    }
}
