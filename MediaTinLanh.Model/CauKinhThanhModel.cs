using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaTinLanh.Model
{
    public class CauKinhThanhModel
    {
        public int? Id { get; set; }
        public int? SachId { get; set; }
        public int? Chuong { get; set; }
        public int? STT { get; set; }
        public string NoiDung { get; set; }
        public int? TemplateId { get; set; }
    }
}
