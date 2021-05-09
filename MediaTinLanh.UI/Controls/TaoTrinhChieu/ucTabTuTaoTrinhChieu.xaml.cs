using MediaTinLanh.Control;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace MediaTinLanh.UI.Controls
{
    /// <summary>
    /// Interaction logic for ucTabTuTaoTrinhChieu.xaml
    /// </summary>
    public partial class ucTabTuTaoTrinhChieu : UserControl
    {
        TaoTrinhChieuViewModel viewModel = new TaoTrinhChieuViewModel();
        private ObservableCollection<ImageSource> slideImageSources = new ObservableCollection<ImageSource>();
        int currentSlideIndex = 0;

        //private string currentDirectoryPath = Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory()));
        //private string backgroundImagePath = string.Empty;
        //private string templateFilePath = string.Empty;
        //private string tempFilePath = string.Empty;
        //private FileStream backgroundImage;
        private readonly Control_Presentation _controller;
        //private DispatcherTimer timer = new DispatcherTimer();

        private Uri backgroundImagePath = new Uri("pack://application:,,,/Resources/images/trinh-chieu/bg.jpg");
        private Uri templateFilePath = new Uri("pack://application:,,,/Files/template.pptx");
        private string tempFilePath = string.Empty;
        private Stream backgroundImage;

        public ucTabTuTaoTrinhChieu()
        {
            InitializeComponent();
            this.DataContext = viewModel;
            _controller = new Control_Presentation();

            tempFilePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\MediaTinLanh\\temp\\temp.pptx";
            //backgroundImagePath = currentDirectoryPath + "\\Resources\\images\\trinh-chieu\\bg.jpg";
            //backgroundImage = new FileStream(backgroundImagePath, FileMode.Open);
            //OpenTempFile(templateFilePath);
            //CurrentSlide.Source = slideImageSources[currentSlideIndex];
            //SlidesListView.ItemsSource = slideImageSources;

            backgroundImage = Application.GetResourceStream(backgroundImagePath).Stream;
            OpenTempFile(Application.GetResourceStream(templateFilePath).Stream);
            CurrentSlide.Source = slideImageSources[currentSlideIndex];
            SlidesListView.ItemsSource = slideImageSources;
        }

        private void btnTaiPPTX_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            viewModel.NoiDungToSlide();
            if (viewModel.Slides.Count > 0)
            {
                System.Windows.Forms.SaveFileDialog saveFileDialog = new System.Windows.Forms.SaveFileDialog();
                saveFileDialog.Filter = "MS Powerpoint file (*.pptx)|*.pptx|Text file (*.txt)|*.txt";
                saveFileDialog.FileName = "Sample.pptx";
                saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\MediaTinLanh\\";
                if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    Control_Presentation.CreateFiles(
                        saveFileDialog.FileName,
                        viewModel.Slides.Select(slide => slide.NoiDung).ToArray(),
                        new string[] { "Arial", "70", "Bold" },
                        backgroundImage);
                }
            }

        }

        private void SaveTempFile()
        {
            if (viewModel.Slides.Count != 0)
            {
                var tempFolder = tempFilePath.Substring(0, tempFilePath.LastIndexOf("\\"));
                var exists = Directory.Exists(tempFolder);
                if (!exists)
                {
                    Directory.CreateDirectory(tempFolder);
                }

                Control_Presentation.CreateFiles(tempFilePath,
                    viewModel.Slides.Select(slide => slide.NoiDung).ToArray(), new string[] { "Arial", "70", "Bold" }, backgroundImage);
            }
        }

        private void OpenTempFile(string filePath)
        {
            slideImageSources.Clear();

            try
            {
                _controller.PptxFileToImages(filePath, slideImageSources);
                SlidesListView.Items.Refresh();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        private void OpenTempFile(Stream fileStream)
        {
            slideImageSources.Clear();

            try
            {
                _controller.PptxFileToImages(fileStream, slideImageSources);
                SlidesListView.Items.Refresh();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void Update()
        {
            viewModel.NoiDungToSlide();
            SaveTempFile();
            OpenTempFile(tempFilePath);
            if (currentSlideIndex < slideImageSources.Count)
            {
                CurrentSlide.Source = slideImageSources[currentSlideIndex];
            }
        }

        private void TextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            Update();
        }
    }
}
