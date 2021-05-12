using Microsoft.Office.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MediaTinLanh.Control
{
    public class Control_Security
    {
        public static string FTP_Server = "";
        public static string FTP_Username = "";
        public static string FTP_Password = "";

        public static String DatabaseName = "";
        public const String Key = "JHT@MDTL!12723WWXDE";
        private const string passPhrase = "1.ppYmr5*9736GQ";
        private const Int32 KEY_SIZE = 256;
       
        //Get username, password and serer
        public static bool GET_FTP()
        {
            try
            {
                if (FTP_Server.Length == 0 && FTP_Server.Length == 0 && FTP_Password.Length == 0)
                {
                    Control_Security control_Security = new Control_Security();
                    Control_Xml xml = new Control_Xml();
                    string ftp_server = "";
                    string ftp_username = "";
                    string ftp_password = "";
                    xml.GetFtpAccount("config.xml", ref ftp_server, ref ftp_username, ref ftp_password);
                    if (ftp_server != String.Empty && ftp_username != String.Empty && ftp_password != String.Empty)
                    {
                        FTP_Server = control_Security.Decrypt(ftp_server);
                        FTP_Username = control_Security.Decrypt(ftp_username);
                        FTP_Password = control_Security.Decrypt(ftp_password);
                        return true;
                    }
                    else
                        return false;
                }
                else
                    return true;

                
            }
            catch (Exception)
            {
                return false;
            }

        }
        public String Decrypt(String plainText)
        {
            bool useHashing = true;
            byte[] keyArray;
            byte[] toEncryptArray = Convert.FromBase64String(plainText);

            if (useHashing)
            {
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(Key));
            }
            else
                keyArray = UTF8Encoding.UTF8.GetBytes(Key);

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

            return UTF8Encoding.UTF8.GetString(resultArray);
        }

        public String Encrypt (String cipherText)
        {
            bool useHashing = true;
            byte[] keyArray;
            byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(cipherText);

            if (useHashing)
            {
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(Key));
            }
            else
                keyArray = UTF8Encoding.UTF8.GetBytes(Key);

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }

        #region Bảng chữ cái
        private string[] Kytu ={
                                   "a","á","à","ả","ã","ạ",
                                   "ă","ắ","ằ","ẳ","ẵ","ặ",
                                   "â","ấ","ầ","ẩ","ẫ","ậ",
                                   "b",
                                   "c",
                                   "d",
                                   "đ",
                                   "e","é","è","ẻ","ẽ","ẹ",
                                   "ê","ế","ề","ể","ễ","ệ",
                                   "f",
                                   "g",
                                   "h",
                                   "i","í","ì","ỉ","ĩ","ị",
                                   "j",
                                   "k",
                                   "l",
                                   "m",
                                   "n",
                                   "o","ó","ò","ỏ","õ","ọ",
                                   "ô","ố","ồ","ổ","ỗ","ộ",
                                   "ơ","ớ","ờ","ở","ỡ","ợ",
                                   "p",
                                   "q",
                                   "r",
                                   "s",
                                   "t",
                                   "u","ú","ù","ủ","ũ","ụ",
                                   "ư","ứ","ừ","ử","ữ","ự",
                                   "v",
                                   "w",
                                   "x",
                                   "y","ý","ỳ","ỷ","ỹ","ỵ",
                                   "z",
                                   " "
                               };
        #endregion

        #region Bảng chữ số
        private int[] So ={
                                2110,2111,2112,2113,2114,2115,//a
                                2120,2121,2122,2123,2124,2125,//ă
                                2130,2131,2132,2133,2134,2135,//â
                                2210,                         //b
                                2310,                         //c
                                3110,                         //d
                                3120,                         //đ
                                3210,3211,3212,3213,3214,3215,//e
                                3220,3221,3222,3223,3224,3225,//ê
                                3310,                         //f
                                4110,                         //g
                                4210,                         //h
                                4310,4311,4312,4313,4314,4315,//i
                                5110,                         //j
                                5210,                         //k
                                5310,                         //l
                                6110,                         //m
                                6210,                         //n
                                6310,6311,6312,6313,6314,6315,//o
                                6320,6321,6322,6323,6324,6325,//ô
                                6330,6331,6332,6333,6334,6335,//ơ
                                7110,                         //p
                                7210,                         //q
                                7310,                         //r
                                7410,                         //s
                                8110,                         //t
                                8210,8211,8212,8213,8214,8215,//u
                                8220,8221,8222,8223,8224,8225,//ư
                                8310,                         //v
                                9110,                         //w
                                9210,                         //x
                                9310,9311,9312,9313,9314,9315,//y
                                9410,                          //x
                                1000                           // " " dấu cách
                           };//kết thúc mảng So[] 
        #endregion

        #region Các Hàm
        public int[] Tim(string kytu)
        {
            int vitri = -1;
            int kieu = -1;
            int[] ketqua = new int[2];
            for (int i = 0; i <= Kytu.Length - 1; i++)
            {
                if (kytu == Kytu[i])
                {
                    vitri = i;
                    kieu = 9;
                    break;
                }
                if (kytu == Kytu[i].ToUpper())
                {
                    vitri = i;
                    kieu = 8;
                    break;
                }
            }
            ketqua[0] = vitri;
            ketqua[1] = kieu;
            return ketqua;
        }
        public int Tim(int so)
        {
            int vitri = -1;
            for (int i = 0; i < So.Length - 1; i++)
            {
                if (so == So[i])
                {
                    vitri = i;
                    break;
                }
            }
            return vitri;
        }
        /// <summary>
        /// Mã hóa 1 chuỗi.
        /// </summary>
        /// <param name="inputstring">Chuỗi cần mã hóa</param>
        /// <param name="keyvalue">Key</param>
        /// <returns>Chuỗi được mã hóa</returns>
        public string Mahoa(string inputstring, string keyvalue)
        {
            string result = "";

            int key = Math.Abs(keyvalue.GetHashCode());
            int go = key % keyvalue.Length;
            int add = key % 500;
            foreach (char kytu in inputstring)
            {
                int[] ketquatim = Tim(kytu.ToString());
                if (ketquatim[0] >= 0) //tìm thấy là chữ
                {
                    int vitri = (ketquatim[0] + go) % So.Length;
                    int phanmahoachu = So[vitri] + add;
                    string phanhoathuong = ketquatim[1].ToString();
                    result += phanhoathuong + phanmahoachu.ToString();
                }
                else //không phải là chữ
                    result += "0" + kytu + kytu + kytu + kytu;
            }
            return result;
        }
        /// <summary>
        /// Giải mã chuỗi đã mã hóa
        /// </summary>
        /// <param name="inputstring">Chuỗi đã mã hóa</param>
        /// <param name="keyvalue">Key lúc mã hóa</param>
        /// <returns>Chuỗi được giải mã</returns>
        public string Giaima(string inputstring, string keyvalue)
        {
            string result = "";
            if (inputstring.Length % 5 == 0)
            {
                int key = Math.Abs(keyvalue.GetHashCode());
                int go = key % keyvalue.Length;
                int minus = key % 500;
                int index = 0; // vị trí ký tự đang xử lý trong inputstring
                int solandoc = 0;
                while (index <= inputstring.Length)
                {
                    string day5kytu = "";
                    solandoc++;
                    for (int i = index; i <= solandoc * 5 - 1; i++)//lấy 5 ký tự
                    {
                        day5kytu += inputstring[i].ToString();
                    }
                    int kytudau = int.Parse(day5kytu[0].ToString());



                    if (kytudau == 0) //nếu không thuộc bảng ký tự
                    {
                        result += day5kytu[1].ToString();
                    }
                    else
                    {
                        int _4kytutieptheo = int.Parse(day5kytu.Substring(1, 4));
                        int vitrithucsu = ((Tim(_4kytutieptheo - minus) - go) + So.Length) % So.Length;
                        if (kytudau % 2 == 0)// chữ hoa
                        {
                            result += Kytu[vitrithucsu].ToString().ToUpper();
                        }
                        else //chữ thường
                        {
                            result += Kytu[vitrithucsu].ToString();
                        }
                    }

                    index = solandoc * 5;
                    if (index >= inputstring.Length)
                        break;
                }
            }
            return result;
        }
        #endregion
    }
}
