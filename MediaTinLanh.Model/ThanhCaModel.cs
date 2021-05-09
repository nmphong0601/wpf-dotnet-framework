using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaTinLanh.Model
{
    public class ThanhCaModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        private int? _stt;
        private string _ten;
        private int? _soCau;
        private int? _loai;
        private string _trangThai;
        private string _tenTep;
        private string _duongDan;

        public int? ID { get; set; }
        public int? STT {
            get
            {
                return _stt;
            }

            set
            {
                if (value == _stt)
                {
                    return;
                }
                _stt = value;
                OnPropertyChanged("STT");
            }
        }
        public string Ten {
            get
            {
                return _ten;
            }

            set
            {
                if (value == _ten)
                {
                    return;
                }
                _ten = value;
                OnPropertyChanged("Ten");
            }
        }
        public int? SoCau {
            get
            {
                return _soCau;
            }

            set
            {
                if (value == _soCau)
                {
                    return;
                }
                _soCau = value;
                OnPropertyChanged("SoCau");
            }
        }
        public int? Loai {
            get
            {
                return _loai;
            }

            set
            {
                if (value == _loai)
                {
                    return;
                }
                _loai = value;
                OnPropertyChanged("Loai");
            }
        }
        public string TrangThai
        {
            get
            {
                return _trangThai;
            }

            set
            {
                if (value == _trangThai)
                {
                    return;
                }
                _trangThai = value;
                OnPropertyChanged("TrangThai");
            }
        }
        public string TenTep
        {
            get
            {
                return _tenTep;
            }

            set
            {
                if (value == _tenTep)
                {
                    return;
                }
                _tenTep = value;
                OnPropertyChanged("TenTep");
            }
        }
        public string DuongDan
        {
            get
            {
                return _duongDan;
            }

            set
            {
                if (value == _duongDan)
                {
                    return;
                }
                _duongDan = value;
                OnPropertyChanged("DuongDan");
            }
        }

        private LoaiBaiHatModel _loaiThanhCa;

        private ObservableCollection<LoiBaiHatModel> _loiBaiHats;
        private ObservableCollection<MediaModel> _medias;

        public LoaiBaiHatModel LoaiThanhCa
        {
            get
            {
                return _loaiThanhCa;
            }

            set
            {
                if (value == _loaiThanhCa)
                {
                    return;
                }
                _loaiThanhCa = value;
                OnPropertyChanged("LoaiThanhCa");
            }
        }
        public ObservableCollection<LoiBaiHatModel> LoiBaiHats
        {
            get
            {
                return _loiBaiHats;
            }

            set
            {
                if (value == _loiBaiHats)
                {
                    return;
                }
                _loiBaiHats = value;
                OnPropertyChanged("LoiBaiHats");
            }
        }

        public ObservableCollection<MediaModel> Medias
        {
            get
            {
                return _medias;
            }

            set
            {
                if (value == _medias)
                {
                    return;
                }
                _medias = value;
                OnPropertyChanged("Medias");
            }
        }
    }
}
