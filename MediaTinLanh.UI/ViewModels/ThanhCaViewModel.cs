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

        private ObservableCollection<LoaiBaiHatModel> _selectedLoaiBaiHats;
        public ObservableCollection<LoaiBaiHatModel> SelectedLoaiBaiHats
        {
            get
            {
                return _selectedLoaiBaiHats;
            }

            set
            {
                if (value == _selectedLoaiBaiHats)
                {
                    return;
                }
                _selectedLoaiBaiHats = value;
                OnPropertyChanged("SelectedLoaiBaiHats");
            }
        }

        //private LoaiBaiHatModel _selectedLoaiBaiHat;
        //public LoaiBaiHatModel SelectedLoaiBaiHat
        //{
        //    get
        //    {
        //        return _selectedLoaiBaiHat;
        //    }

        //    set
        //    {
        //        if (value == _selectedLoaiBaiHat)
        //        {
        //            return;
        //        }
        //        _selectedLoaiBaiHat = value;
        //        OnPropertyChanged("SelectedLoaiBaiHat");
        //    }
        //}

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
            Items = new ObservableCollection<ThanhCaModel>();
            SelectedLoaiBaiHats = new ObservableCollection<LoaiBaiHatModel>();
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
