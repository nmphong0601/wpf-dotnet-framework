using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaTinLanh.Model
{
    public class PhienBanModel
    {
        public int? ID { get; set; }
        public string TenPhienBan { get; set; }
        public string SoHieuPhienBan { get; set; }
        public DateTime? NgayPhatHanh { get; set; }
        public int? Nam { get; set; }
        public string TrangThai { get; set; }
        public string MoTa { get; set; }
    }
}
