using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaTinLanh.Data
{
    //Domain objects
    public partial class LoaiBaiHat: Entity<LoaiBaiHat>
    {
        public LoaiBaiHat() { }
        public LoaiBaiHat(bool defaults) : base(defaults) { }

        public int? ID { get; set; }
        public string TenLoai { get; set; }
        public string VietTat { get; set; }
    }

    public partial class LoiBaiHat: Entity<LoiBaiHat>
    {
        public LoiBaiHat() { }
        public LoiBaiHat(bool defaults) : base(defaults) { }

        public int? ID { get; set; }
        public int? ID_ThanhCa { get; set; }
        public string Cau { get; set; }
        public string NoiDung { get; set; }
    }

    public partial class TaiNguyen: Entity<TaiNguyen>
    {
        public TaiNguyen() { }
        public TaiNguyen(bool defaults) : base(defaults) { }

        public int? ID { get; set; }
        public string TenTaiNguyen { get; set; }
        public string DiaChi { get; set; }
        public float KichThuoc { get; set; }
        public DateTime? NgayTaiLen { get; set; }
        public string NguoiTaiLen { get; set; }
        public string DinhDang { get; set; }
        public float LuotXem { get; set; }
    }

    public partial class PhienBan: Entity<PhienBan>
    {
        public PhienBan() { }
        public PhienBan(bool defaults) : base(defaults) { }

        public int? ID { get; set; }
        public string TenPhienBan { get; set; }
        public string SoHieuPhienBan { get; set; }
        public DateTime? NgayPhatHanh { get; set; }
        public int? Nam { get; set; }
        public string TrangThai { get; set; }
        public string MoTa { get; set; }
    }

    public partial class ThanhCa: Entity<ThanhCa>
    {
        public ThanhCa() {
            TrangThai = "Active";
        }
        public ThanhCa(bool defaults) : base(defaults) { }

        public int? ID { get; set; }
        public int? STT { get; set; }
        public string Ten { get; set; }
        public int? SoCau { get; set; }
        public int? Loai { get; set; }
        public string TrangThai { get; set; }
        public string GhiChu { get; set; }
        public string PPTX { get; set; }
        public string PRO { get; set; }
        public string TXT { get; set; }
        public string PDF { get; set; }
        public DateTime? NgayCapNhat { get; set; }
    }
}
