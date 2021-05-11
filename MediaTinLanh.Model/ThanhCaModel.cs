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
        private string _ghiChu;
        private string _pptx;
        private string _pro;
        private string _txt;
        private string _pdf;
        private DateTime? _ngayCapNhat;

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
        public string GhiChu
        {
            get
            {
                return _ghiChu;
            }

            set
            {
                if (value == _ghiChu)
                {
                    return;
                }
                _ghiChu = value;
                OnPropertyChanged("GhiChu");
            }
        }
        public string PPTX
        {
            get
            {
                return _pptx;
            }

            set
            {
                if (value == _pptx)
                {
                    return;
                }
                _pptx = value;
                OnPropertyChanged("PPTX");
            }
        }
        public string PRO
        {
            get
            {
                return _pro;
            }

            set
            {
                if (value == _pro)
                {
                    return;
                }
                _pro = value;
                OnPropertyChanged("PRO");
            }
        }
        public string TXT
        {
            get
            {
                return _txt;
            }

            set
            {
                if (value == _txt)
                {
                    return;
                }
                _txt = value;
                OnPropertyChanged("TXT");
            }
        }
        public string PDF
        {
            get
            {
                return _pdf;
            }

            set
            {
                if (value == _pdf)
                {
                    return;
                }
                _pdf = value;
                OnPropertyChanged("PDF");
            }
        }
        public DateTime? NgayCapNhat
        {
            get
            {
                return _ngayCapNhat;
            }

            set
            {
                if (value == _ngayCapNhat)
                {
                    return;
                }
                _ngayCapNhat = value;
                OnPropertyChanged("NgayCapNhat");
            }
        }

        private LoaiBaiHatModel _loaiThanhCa;
        private ObservableCollection<LoiBaiHatModel> _loiBaiHats;

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
    }
}
