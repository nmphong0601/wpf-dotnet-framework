using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaTinLanh.Model
{
    public class SachModel
    {
        public int? Id { get; set; }
        public int? STT { get; set; }
        public string Ten { get; set; }
        public int? TongSoChuong { get; set; }
        public int? PhienBanId { get; set; }
    }
}
