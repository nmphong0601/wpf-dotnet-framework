using MediaTinLanh.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediaTinLanh.Control;

namespace MediaTinLanh.UI.WPF.ViewModels
{
    public class MessageViewModel : INotifyPropertyChanged
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

        private string _message;
        public string Message
        {
            get
            {
                return _message;
            }

            set
            {
                if (value == _message)
                {
                    return;
                }
                _message = value;
                OnPropertyChanged("Message");
            }
        }

        private string _title;
        public string Title
        {
            get
            {
                return _title;
            }

            set
            {
                if (value == _title)
                {
                    return;
                }
                _title = value;
                OnPropertyChanged("Title");
            }
        }

        public MessageViewModel()
        {
        }
    }
}
