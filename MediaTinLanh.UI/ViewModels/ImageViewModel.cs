using MediaTinLanh.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediaTinLanh.Control;
using System.Windows.Media.Imaging;

namespace MediaTinLanh.UI.ViewModels
{

    public class ImageViewModel : INotifyPropertyChanged
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

        private BitmapImage _selectedImage;
        public BitmapImage SelectedImage
        {
            get
            {
                return _selectedImage;
            }

            set
            {
                if (value == _selectedImage)
                {
                    return;
                }
                _selectedImage = value;
                OnPropertyChanged("SelectedImage");
            }
        }

        private ObservableCollection<BitmapImage> _images;
        public ObservableCollection<BitmapImage> Images
        {
            get
            {
                return _images;
            }

            set
            {
                if (value == _images)
                {
                    return;
                }
                _images = value;
                OnPropertyChanged("Images");
            }
        }

        public ImageViewModel()
        {
            Images = new ObservableCollection<BitmapImage>();
        }
    }
}
