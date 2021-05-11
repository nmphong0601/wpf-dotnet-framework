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

        public static LoaiBaiHats LoaiBaiHats { get { return new LoaiBaiHats(); } }
        public static ThanhCas ThanhCas { get { return new ThanhCas(); } }
        public static TaiNguyens TaiNguyens { get { return new TaiNguyens(); } }
        public static PhienBans PhienBans { get { return new PhienBans(); } }
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
