using MediaTinLanh.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediaTinLanh.Control;

namespace MediaTinLanh.UI.ViewModels
{
    public class ThanhCaViewModel : INotifyPropertyChanged
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

        private int _page;
        public int Page
        {
            get
            {
                return _page;
            }

            set
            {
                if (value == _page)
                {
                    return;
                }
                _page = value;
                OnPropertyChanged("Page");
            }
        }

        private int _pageSize;
        public int PageSize
        {
            get
            {
                return _pageSize;
            }

            set
            {
                if (value == _pageSize)
                {
                    return;
                }
                _pageSize = value;
                OnPropertyChanged("PageSize");
            }
        }

        private int _totalItem;
        public int TotalItem
        {
            get
            {
                return _totalItem;
            }

            set
            {
                if (value == _totalItem)
                {
                    return;
                }
                _totalItem = value;
                OnPropertyChanged("TotalItem");
            }
        }

        private LoaiBaiHatModel _selectedLoaiBaiHat;
        public LoaiBaiHatModel SelectedLoaiBaiHat
        {
            get
            {
                return _selectedLoaiBaiHat;
            }

            set
            {
                if (value == _selectedLoaiBaiHat)
                {
                    return;
                }
                _selectedLoaiBaiHat = value;
                OnPropertyChanged("SelectedLoaiBaiHat");
            }
        }

        private ObservableCollection<LoaiBaiHatModel> _loaiBaiHats;
        public ObservableCollection<LoaiBaiHatModel> LoaiBaiHats
        {
            get
            {
                return _loaiBaiHats;
            }

            set
            {
                if (value == _loaiBaiHats)
                {
                    return;
                }
                _loaiBaiHats = value;
                OnPropertyChanged("LoaiBaiHats");
            }
        }

        private ThanhCaModel _selectedIitem;
        public ThanhCaModel SelectedItem
        {
            get
            {
                return _selectedIitem;
            }

            set
            {
                if (value == _selectedIitem)
                {
                    return;
                }
                _selectedIitem = value;
                OnPropertyChanged("SelectedItem");
            }
        }

        private ObservableCollection<ThanhCaModel> _items;
        public ObservableCollection<ThanhCaModel> Items
        {
            get
            {
                return _items;
            }

            set
            {
                if (value == _items)
                {
                    return;
                }
                _items = value;
                OnPropertyChanged("Items");
            }
        }

        public ThanhCaViewModel()
        {
            _page = 1;
            _pageSize = 20;
            _totalItem = 0;
            _items = new ObservableCollection<ThanhCaModel>();
            _loaiBaiHats = new ObservableCollection<LoaiBaiHatModel>();
        }

        public ThanhCaModel FindItem(int thanhCaId)
        {
            var currentThanhCa = Items.Where(i => i.ID == thanhCaId).FirstOrDefault();
            if (currentThanhCa != null)
            {
                return currentThanhCa;
            }

            return new ThanhCaModel();
        }

        public void AddItem(int thanhCaId, ThanhCaModel thanhCa)
        {
            var currentThanhCa = Items.Where(i => i.ID == thanhCaId).FirstOrDefault();
            if (currentThanhCa == null)
            {
                currentThanhCa = thanhCa;
                Items.Add(currentThanhCa);
            }
        }
        //nút xóa
        public void Remove(int thanhCaId)
        {

            var currentThanhCa = Items.Where(i => i.ID == thanhCaId).FirstOrDefault();
            if (currentThanhCa != null)
            {
                Items.Remove(currentThanhCa);
            }
        }
        //nút cập nhật
        public void Update(int thanhCaId, ThanhCaModel thanhCa)
        {
            var currentThanhCa = Items.Where(i => i.ID == thanhCaId).FirstOrDefault();
            if (currentThanhCa != null)
            {
                currentThanhCa = thanhCa;
            }
        }
    }
}
