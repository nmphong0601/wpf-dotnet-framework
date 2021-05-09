using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaTinLanh.Model
{
    public class MediaModel : INotifyPropertyChanged
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

        public MediaModel()
        {
            TrangThai = false;
        }

        public string _ten;
        public string _mota;
        public string _link;
        public string _locallink;
        public int? _chudeid;
        public int? _loai;
        public int? _thanhcaid;
        public int? _luotxem;
        public int? _luottai;
        public bool? _trangthai = false;

        public int? Id { get; set; }
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
        public string MoTa {
            get
            {
                return _mota;
            }

            set
            {
                if (value == _mota)
                {
                    return;
                }
                _mota = value;
                OnPropertyChanged("MoTa");
            }
        }
        public string Link {
            get
            {
                return _link;
            }

            set
            {
                if (value == _link)
                {
                    return;
                }
                _link = value;
                OnPropertyChanged("Link");
            }
        }
        public string LocalLink
        {
            get
            {
                return _locallink;
            }

            set
            {
                if (value == _locallink)
                {
                    return;
                }
                _locallink = value;
                OnPropertyChanged("LocalLink");
            }
        }
        public int? ChuDeId {
            get
            {
                return _chudeid;
            }

            set
            {
                if (value == _chudeid)
                {
                    return;
                }
                _chudeid = value;
                OnPropertyChanged("ChuDeId");
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

        public int? ThanhCaId
        {
            get
            {
                return _thanhcaid;
            }

            set
            {
                if (value == _thanhcaid)
                {
                    return;
                }
                _thanhcaid = value;
                OnPropertyChanged("ThanhCaId");
            }
        }
        public int? LuotXem {
            get
            {
                return _luotxem;
            }

            set
            {
                if (value == _luotxem)
                {
                    return;
                }
                _luotxem = value;
                OnPropertyChanged("LuotXem");
            }
        }
        public int? LuotTai {
            get
            {
                return _luottai;
            }

            set
            {
                if (value == _luottai)
                {
                    return;
                }
                _luottai = value;
                OnPropertyChanged("LuotTai");
            }
        }
        public bool? TrangThai {
            get
            {
                return _trangthai;
            }

            set
            {
                if (value == _trangthai)
                {
                    return;
                }
                _trangthai = value;
                OnPropertyChanged("TrangThai");
            }
        }
    }
}
