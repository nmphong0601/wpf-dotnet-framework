using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace MediaTinLanh.UI.Controls
{
    public class SlideData
    {
        public string NoiDung { get; set; }
        public int ViTri { get; set; }
    }

    public class TaoTrinhChieuViewModel : INotifyPropertyChanged
    {
        private string _noiDungNhap;
        private List<SlideData> _slides;

        public TaoTrinhChieuViewModel()
        {
            _slides = new List<SlideData>();
        }

        public string NoiDungNhap
        {
            get { return _noiDungNhap; }
            set
            {
                _noiDungNhap = value;
                OnPropertyChanged(nameof(NoiDungNhap));
            }
        }

        public List<SlideData> Slides
        {
            get { return _slides; }
            set
            {
                _slides = value;
                OnPropertyChanged(nameof(Slides));
            }
        }

        public void NoiDungToSlide()
        {
            // clear old data
            _slides = new List<SlideData>();
            if (!String.IsNullOrWhiteSpace(_noiDungNhap))
            {
                string[] stringSlits = _noiDungNhap.Split(new[] { Environment.NewLine + Environment.NewLine }, System.StringSplitOptions.None);

                if (stringSlits.Count() == 0)
                {
                    stringSlits = new string[] { _noiDungNhap };
                }

                for (int i = 0; i < stringSlits.Length; i++)
                {
                    var viTri = _noiDungNhap.IndexOf(stringSlits[i]);

                    var slidedata = new SlideData
                    {
                        NoiDung = stringSlits[i],
                        ViTri = viTri
                    };
                    _slides.Add(slidedata);
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
