using AutoMapper;
using MediaTinLanh.Data;
using MediaTinLanh.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace MediaTinLanh.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        static bool initialized = false;
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            if (!initialized)
            {
                Mapper.Initialize(cfg =>
                {
                    cfg.AddProfile<MappingProfile>();
                });

                initialized = true;
            }
        }
    }

    public class MappingProfile : AutoMapper.Profile
    {
        public MappingProfile()
        {
            CreateMap<ThanhCa, ThanhCaModel>().ForMember(dest => dest.LoaiThanhCa, conf => conf.MapFrom(src => src.LoaiThanhCa))
                                              .ForMember(dest => dest.LoiBaiHats, opt => opt.MapFrom(src => src.DanhSachLoiBaiHat));

            CreateMap<LoiBaiHat, LoiBaiHatModel>();
            CreateMap<PhienBan, PhienBanModel>();
            CreateMap<LoaiBaiHat, LoaiBaiHatModel>();

            CreateMap<PhienBanModel, PhienBan>();
            CreateMap<LoaiBaiHatModel, LoaiBaiHat>();
        }
    }
}
