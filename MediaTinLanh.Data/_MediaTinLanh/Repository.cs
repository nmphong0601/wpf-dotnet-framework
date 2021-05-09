using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaTinLanh.Data
{
    // MediaTinLanhDB. hosts all repositories

    public static class MediaTinLanhContext
    {
        //static MediaTinLanhContext db = new MediaTinLanhContext();
        static MediaTinLanhDb db = new MediaTinLanhDb();

        // entity specific repositories

        public static BanDichCaus BanDichCaus { get { return new BanDichCaus(); } }
        public static BanDichSachs BanDichSachs { get { return new BanDichSachs(); } }
        public static BanDichPhienBans BanDichPhienBans { get { return new BanDichPhienBans(); } }
        public static BoDes BoDes { get { return new BoDes(); } }
        public static CauDos CauDos { get { return new CauDos(); } }
        public static CauHois CauHois { get { return new CauHois(); } }
        public static DapAns DapAns { get { return new DapAns(); } }
        public static ChuDes ChuDes { get { return new ChuDes(); } }
        public static CauKinhThanhs CauKinhThanhs { get { return new CauKinhThanhs(); } }
        public static GopYPhanMems GopYPhanMems { get { return new GopYPhanMems(); } }
        public static LoaiBaiHats LoaiBaiHats { get { return new LoaiBaiHats(); } }
        public static ThanhCas ThanhCas { get { return new ThanhCas(); } }
        public static MediaTypes MediaTypes { get { return new MediaTypes(); } }
        public static Medias Medias { get { return new Medias(); } }
        public static MediaThanhCas MediaThanhCas { get { return new MediaThanhCas(); } }
        public static Templates Templates { get { return new Templates(); } }
        public static NgonNgus NgonNgus { get { return new NgonNgus(); } }
        public static PhienBans PhienBans { get { return new PhienBans(); } }
        public static Sachs Sachs { get { return new Sachs(); } }
        public static LoiBaiHats LoiBaiHats { get { return new LoiBaiHats(); } }

        // general purpose operations

        public static void Execute(string sql, params object[] parms) { db.Execute(sql, parms); }
        public static IEnumerable<dynamic> Query(string sql, params object[] parms) { return db.Query(sql, parms); }
        public static object Scalar(string sql, params object[] parms) { return db.Scalar(sql, parms); }

        public static DataSet GetDataSet(string sql, params object[] parms) { return db.GetDataSet(sql, parms); }
        public static DataTable GetDataTable(string sql, params object[] parms) { return db.GetDataTable(sql, parms); }
        public static DataRow GetDataRow(string sql, params object[] parms) { return db.GetDataRow(sql, parms); }
    }
}
