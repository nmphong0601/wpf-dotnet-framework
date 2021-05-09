using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaTinLanh.Model
{
    public class BanDichCauModel
    {
        public int? Id { get; set; }
        public int? CauId { get; set; }
        public string NoiDungDich { get; set; }
        public int? NgonNguId { get; set; }
    }
}
