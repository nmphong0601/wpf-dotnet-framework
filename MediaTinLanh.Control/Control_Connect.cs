using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MediaTinLanh.Control
{
    public class Control_Connect
    {
        #region -- ConnectionString --
        public static string m_ConnectString;
        public static string ConnectionString()
        {
            try
            {
                
                if (m_ConnectString.Trim() == String.Empty)
                {
                    string servername = "";
                    string quyenhan = "";
                    string username = "";
                    string pasword = "";
                    string databasename = "";
                    Control_Xml xmlcontrol = new Control_Xml();
                    xmlcontrol.ReadFile("Connectionconfig.xml", ref servername, ref quyenhan, ref username, ref pasword, ref databasename);
                    Control_Security baomat = new Control_Security();
                    pasword = baomat.Giaima(pasword, "lnduc");
                    if (quyenhan == "Quyền Windows")
                        m_ConnectString = "Data Source=" + servername + ";Initial Catalog=" + databasename + ";Integrated Security=True;";
                    else
                        m_ConnectString = "Data Source=" + servername + ";Initial Catalog=" + databasename + ";User Id=" + username + ";Password=" + pasword + ";";
                    return m_ConnectString;
                }
                else
                    return m_ConnectString;
            }
            catch
            {
                MessageBox.Show("Lỗi kết nối đến cơ sở dữ liệu! Xin vui lòng thiết lập lại kết nối...", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        #endregion
    }
}
