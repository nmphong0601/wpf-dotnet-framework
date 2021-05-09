using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaTinLanh.Model
{
    public class MediaTypeModel
    {
        public int? Id { get; set; }
        public string Ten { get; set; }
        public string MoTa { get; set; }
        public int? DungLuongUploadToiDa { get; set; }
        public int? DungLuongDownloadToiDa { get; set; }
        public string DinhDang { get; set; }
    }
}
