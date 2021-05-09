using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaTinLanh.Model
{
    public class BanDichSachModel
    {
        public int? Id { get; set; }
        public int? SachId { get; set; }
        public string NoiDungDich { get; set; }
        public int? NgonNguId { get; set; }
    }
}
