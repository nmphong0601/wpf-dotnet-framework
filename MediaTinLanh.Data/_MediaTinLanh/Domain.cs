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

    public partial class BanDichCau: Entity<BanDichCau>
    {
        public BanDichCau() { }
        public BanDichCau(bool defaults) : base(defaults) { }

        public int? Id { get; set; }
        public int? CauId { get; set; }
        public string NoiDungDich { get; set; }
        public int? NgonNguId { get; set; }
    }

    public partial class BanDichPhienBan: Entity<BanDichPhienBan>
    {
        public BanDichPhienBan() { }
        public BanDichPhienBan(bool defaults) : base(defaults) { }

        public int? Id { get; set; }
        public int? PhienBanId { get; set; }
        public string NoiDungDich { get; set; }
        public int? NgonNguId { get; set; }
    }

    public partial class BanDichSach: Entity<BanDichSach>
    {
        public BanDichSach() { }
        public BanDichSach(bool defaults) : base(defaults) { }

        public int? Id { get; set; }
        public int? SachId { get; set; }
        public string NoiDungDich { get; set; }
        public int? NgonNguId { get; set; }
    }

    public partial class BoDe: Entity<BoDe>
    {
        public BoDe() { }
        public BoDe(bool defaults) : base(defaults) { }

        public int? Id { get; set; }
        public string Ten { get; set; }
        public int? ChuDeId { get; set; }
    }

    public partial class CauDo: Entity<CauDo>
    {
        public CauDo() { }
        public CauDo(bool defaults) : base(defaults) { }

        public int? Id { get; set; }
        public int? BoDeId { get; set; }
        public int? CauHoiId { get; set; }
        public int? DapAnId { get; set; }
        public string GoiY { get; set; }
    }

    public partial class CauHoi: Entity<CauHoi>
    {
        public CauHoi() { }
        public CauHoi(bool defaults) : base(defaults) { }

        public int? Id { get; set; }
        public string NoiDung { get; set; }
        public int? MediaId { get; set; }
    }

    public partial class CauKinhThanh: Entity<CauKinhThanh>
    {
        public CauKinhThanh() { }
        public CauKinhThanh(bool defaults) : base(defaults) { }

        public int? Id { get; set; }
        public int? SachId { get; set; }
        public int? Chuong { get; set; }
        public int? STT { get; set; }
        public string NoiDung { get; set; }
        public int? TemplateId { get; set; }
    }

    public partial class ChuDe: Entity<ChuDe>
    {
        public ChuDe() { }
        public ChuDe(bool defaults) : base(defaults) { }

        public int? Id { get; set; }
        public string Ten { get; set; }
        public string NoiDung { get; set; }
        public DateTime? ThoiGian { get; set; }
    }

    public partial class DapAn: Entity<DapAn>
    {
        public DapAn() { }
        public DapAn(bool defaults) : base(defaults) { }

        public int? Id { get; set; }
        public string NoiDung { get; set; }
        public int? CauKinhThanhId { get; set; }
    }

    public partial class GopYPhanMem: Entity<GopYPhanMem>
    {
        public GopYPhanMem() { }
        public GopYPhanMem(bool defaults) : base(defaults) { }

        public int? Id { get; set; }
        public string TieuDe { get; set; }
        public string NoiDung { get; set; }
    }

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

    public partial class Media: Entity<Media>
    {
        public Media() { }
        public Media(bool defaults) : base(defaults) { }

        public int? Id { get; set; }
        public string Ten { get; set; }
        public string MoTa { get; set; }
        public string Link { get; set; }
        public string LocalLink { get; set; }
        public int? ChuDeId { get; set; }
        public int? Loai { get; set; }
        public int? ThanhCaId { get; set; }
        public int? LuotXem { get; set; }
        public int? LuotTai { get; set; }
    }

    public partial class MediaThanhCa: Entity<MediaThanhCa>
    {
        public MediaThanhCa() { }
        public MediaThanhCa(bool defaults) : base(defaults) { }

        public int? Id { get; set; }
        public int? MediaId { get; set; }
        public int? ThanhCaId { get; set; }
    }

    public partial class MediaType: Entity<MediaType>
    {
        public MediaType() { }
        public MediaType(bool defaults) : base(defaults) { }

        public int? Id { get; set; }
        public string Ten { get; set; }
        public string MoTa { get; set; }
        public int? DungLuongUploadToiDa { get; set; }
        public int? DungLuongDownloadToiDa { get; set; }
        public string DinhDang { get; set; }
    }

    public partial class NgonNgu: Entity<NgonNgu>
    {
        public NgonNgu() { }
        public NgonNgu(bool defaults) : base(defaults) { }

        public int? Id { get; set; }
        public string Ten { get; set; }
        public string MoTa { get; set; }
    }

    public partial class PhienBan: Entity<PhienBan>
    {
        public PhienBan() { }
        public PhienBan(bool defaults) : base(defaults) { }

        public int? Id { get; set; }
        public string Ten { get; set; }
        public int? Nam { get; set; }
    }

    public partial class Sach: Entity<Sach>
    {
        public Sach() { }
        public Sach(bool defaults) : base(defaults) { }

        public int? Id { get; set; }
        public int? STT { get; set; }
        public string Ten { get; set; }
        public int? TongSoChuong { get; set; }
        public int? PhienBanId { get; set; }
    }

    public partial class Template: Entity<Template>
    {
        public Template() { }
        public Template(bool defaults) : base(defaults) { }

        public int? Id { get; set; }
        public int? MediaId { get; set; }
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
        public string TenTep { get; set; }
        public string DiongDan { get; set; }
    }
}
