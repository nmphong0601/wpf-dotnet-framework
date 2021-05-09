using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaTinLanh.Data
{
    //MediaTinLanh DB
    //public partial class MediaTinLanhContext : DbContext
    //{
    //    public MediaTinLanhContext() : base("DB.MediaTinLanh") { }

    //    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    //    {
    //        Database.SetInitializer<MediaTinLanhContext>(null);
    //    }

    //    public DbSet<BanDichCau> BanDichCaus { get; set; }
    //    public DbSet<BanDichSach> BanDichSachs { get; set; }
    //    public DbSet<BanDichPhienBan> BanDichPhienBans { get; set; }
    //    public DbSet<BoDe> BoDes { get; set; }
    //    public DbSet<CauDo> CauDos { get; set; }
    //    public DbSet<CauHoi> CauHois { get; set; }
    //    public DbSet<DapAn> DapAns { get; set; }
    //    public DbSet<ChuDe> ChuDes { get; set; }
    //    public DbSet<CauKinhThanh> CauKinhThanhs { get; set; }
    //    public DbSet<GopYPhanMem> GopYPhanMems { get; set; }
    //    public DbSet<LoaiThanhCa> LoaiThanhCas { get; set; }
    //    public DbSet<ThanhCa> ThanhCas { get; set; }
    //    public DbSet<MediaType> MediaTypes { get; set; }
    //    public DbSet<Media> Medias { get; set; }
    //    public DbSet<MediaThanhCa> MediaThanhCas { get; set; }
    //    public DbSet<Template> Templates { get; set; }
    //    public DbSet<NgonNgu> NgonNgus { get; set; }
    //    public DbSet<PhienBan> PhienBans { get; set; }
    //    public DbSet<Sach> Sachs { get; set; }
    //    public DbSet<LoiBaiHat> LoiBaiHats { get; set; }
    //}

    public partial class MediaTinLanhDb : Db
    {
        public MediaTinLanhDb() : base("DB.MediaTinLanh") { }

    }
}
