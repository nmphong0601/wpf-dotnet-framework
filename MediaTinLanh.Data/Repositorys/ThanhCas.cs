using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dbMediaTinLanh = MediaTinLanh.Data.MediaTinLanhContext;

namespace MediaTinLanh.Data
{
    public partial class ThanhCas : Repository<ThanhCa>
    {
        public override IEnumerable<ThanhCa> All(string where = null, string orderBy = null, int top = 0, params object[] parms)
        {

            var thanhCas = base.All(where, orderBy, top, parms).ToList();
            if (thanhCas.Count() != 0)
            {
                for (int i = 0; i <= thanhCas.Count() - 1; i++)
                {
                    var tc = dbMediaTinLanh.ThanhCas.Single(thanhCas[i].ID);
                    thanhCas[i].LoaiThanhCa = tc.LoaiThanhCa;
                    thanhCas[i].DanhSachLoiBaiHat = tc.DanhSachLoiBaiHat;
                    //thanhCas[i].DanhSachMedia = tc.DanhSachMedia;
                }
            }

            return thanhCas;
        }
        public override ThanhCa Single(int? id)
        {

            var thanhCa = base.Single(id);
            if (thanhCa != null)
            {
                thanhCa.LoaiThanhCa = dbMediaTinLanh.LoaiBaiHats.All(where: "ID = @0", parms: new object[] { thanhCa.Loai }).FirstOrDefault();
                thanhCa.DanhSachLoiBaiHat = dbMediaTinLanh.LoiBaiHats.All(where: "ID_ThanhCa = @0", parms: new object[] { thanhCa.ID }).ToList();
                //var medias = dbMediaTinLanh.Query("Select md.Id, md.Ten, md.MoTa, md.Link, md.LocalLink, md.ChuDeId, md.Loai, md.LuotXem, md.LuotTai from Medias md join MediaThanhCas mdt on md.Id = mdt.MediaId where mdt.ThanhCaId = @0", parms: new object[] { thanhCa.Id }).ToList();
                //List<Media> listMedia = new List<Media>();
                //var medias = dbMediaTinLanh.Medias.All(where: "ThanhCaId = @0", parms: new object[]{ thanhCa.ID }).ToList();
                
                //if(medias.Count() != 0)
                //{
                //    foreach (var item in medias)
                //    {
                //        item.LuotXem = item.LuotXem != null ? (int)item.LuotXem : 0;
                //        item.LuotTai = item.LuotTai != null ? (int)item.LuotTai : 0;
                //    }
                //}
                //else
                //{
                //    var temp = new Media();

                //    medias.Add(temp);
                //}

                //thanhCa.DanhSachMedia = medias;
            }

            return thanhCa;
        }
    }
}
