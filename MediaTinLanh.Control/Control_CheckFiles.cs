using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaTinLanh.Control
{
    public class Control_CheckFiles
    {
        /// <summary>
        /// Thiết lập đường dẫn cho các mục
        /// </summary>
        public string _local_media { get; set; }
        public string _local_KinhThanh { get; set; }
        public string _local_ThanhCa { get; set; }

        public Control_CheckFiles()
        {
           
        }

        public Control_CheckFiles(string local_media, string local_KinhThanh, string local_ThanhCa)
        {
            _local_media = local_media;
            _local_KinhThanh = local_KinhThanh;
            _local_ThanhCa = local_ThanhCa;
        }
    }
}
