using MediaTinLanh.Control;
using MediaTinLanh.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace MediaTinLanh.UI.Controls
{
    /// <summary>
    /// Interaction logic for ucTabTuTaoTrinhChieu.xaml
    /// </summary>
    public partial class ucTabTuTaoTrinhChieu : UserControl
    {
        private System.Windows.Data.ListCollectionView Context { get; }
        private ImageViewModel ImageDataContext { get; set; }
        private ObservableCollection<ImageSource> slideImageSources = new ObservableCollection<ImageSource>();
        
        TaoTrinhChieuViewModel viewModel = new TaoTrinhChieuViewModel();
        int currentSlideIndex = 0;

        private readonly Control_Presentation _controller;

        private Uri backgroundImagePath = new Uri("pack://application:,,,/Resources/images/trinh-chieu/bg.jpg");
        private Uri templateFilePath = new Uri("pack://application:,,,/Files/template.pptx");
        private string tempFilePath = string.Empty;
        private Stream backgroundImage;

        public ucTabTuTaoTrinhChieu()
        {
            InitializeComponent();
            this.DataContext = viewModel;

            ImageDataContext = (ImageViewModel)this.Resources["ImageContext"];

            ImageDataContext.Images.Add(new BitmapImage(new Uri("pack://application:,,,/Resources/images/main/Layer-169.png")));
            ImageDataContext.Images.Add(new BitmapImage(new Uri("pack://application:,,,/Resources/images/main/Layer-43.png")));
            ImageDataContext.Images.Add(new BitmapImage(new Uri("pack://application:,,,/Resources/images/main/Layer-30.png")));

            ImageDataContext.SelectedImage = ImageDataContext.Images[0];
            _controller = new Control_Presentation();

            tempFilePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\MediaTinLanh\\temp\\temp.pptx";
            backgroundImage = Application.GetResourceStream(backgroundImagePath).Stream;
            OpenTempFile(Application.GetResourceStream(templateFilePath).Stream);
            CurrentSlide.Source = slideImageSources[currentSlideIndex];
            SlidesListView.ItemsSource = slideImageSources;
        }

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);

            txtTieuDe.GotFocus += RemovePlaceholderTextBox;
            txtTieuDe.LostFocus += AddPlaceholderTextBox;

            txtMoTa.GotFocus += RemovePlaceholderTextBox;
            txtMoTa.LostFocus += AddPlaceholderTextBox;

            txtNoiDung.GotFocus += RemovePlaceholderTextBox;
            txtNoiDung.LostFocus += AddPlaceholderTextBox;


        }

        public void RemovePlaceholderTextBox(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;

            if (textBox.Text == textBox.Tag.ToString())
            {
                textBox.Text = "";
            }
        }

        public void AddPlaceholderTextBox(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;

            if (string.IsNullOrWhiteSpace(textBox.Text))
                textBox.Text = textBox.Tag.ToString();
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

        private void faRight_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            //listBoxTranlateTransform.X += listBoxImage.ActualWidth * 1.5;

            //double xTranslateRight = listBoxImage.ActualWidth * 1.2;
            //double xTranslateLeft = xTranslateRight - (2 * xTranslateRight);


            //if (listBoxTranlateTransform.X == 0)
            //{
            //    listBoxPrevScaleTranform.ScaleX = 1;

            //    var sbPrev = new Storyboard();
            //    var animationOpacityPrev = new DoubleAnimation(0, 1, new Duration(new TimeSpan(0, 0, 0, 0, 200)));
            //    Storyboard.SetTargetName(animationOpacityPrev, "listBoxPrevImage");
            //    Storyboard.SetTargetProperty(animationOpacityPrev, new PropertyPath(OpacityProperty));
            //    sbPrev.Children.Add(animationOpacityPrev);

            //    var animationTranslatePrev = new DoubleAnimation(xTranslateLeft, 0, new Duration(new TimeSpan(0, 0, 0, 0, 500)));
            //    Storyboard.SetTargetName(animationTranslatePrev, "listBoxPrevTranlateTransform");
            //    Storyboard.SetTargetProperty(animationTranslatePrev, new PropertyPath(TranslateTransform.XProperty));
            //    sbPrev.Children.Add(animationTranslatePrev);

            //    var sb = new Storyboard();
            //    var animationOpacity = new DoubleAnimation(1, 0, new Duration(new TimeSpan(0, 0, 0, 0, 200)));
            //    Storyboard.SetTargetName(animationOpacity, "listBoxImage");
            //    Storyboard.SetTargetProperty(animationOpacity, new PropertyPath(OpacityProperty));
            //    sb.Children.Add(animationOpacity);

            //    var animationTranslate = new DoubleAnimation(0, xTranslateRight, new Duration(new TimeSpan(0, 0, 0, 0, 500)));
            //    Storyboard.SetTargetName(animationTranslate, "listBoxTranlateTransform");
            //    Storyboard.SetTargetProperty(animationTranslate, new PropertyPath(TranslateTransform.XProperty));
            //    sb.Children.Add(animationTranslate);

            //    var sbNext = new Storyboard();
            //    listBoxNextScaleTranform.ScaleX = 0;
            //    var animationTranslateNext = new DoubleAnimation(xTranslateRight, xTranslateLeft, new Duration(new TimeSpan(0, 0, 0, 0, 100)));
            //    Storyboard.SetTargetName(animationTranslateNext, "listBoxNextTranlateTransform");
            //    Storyboard.SetTargetProperty(animationTranslateNext, new PropertyPath(TranslateTransform.XProperty));
            //    sbNext.Children.Add(animationTranslateNext);

            //    sb.Begin(listBoxImage);
            //    sbNext.Begin(listBoxNextImage);
            //    sbPrev.Begin(listBoxPrevImage);

            //}
            //else if (listBoxTranlateTransform.X == xTranslateRight)
            //{
            //    listBoxNextScaleTranform.ScaleX = 1;

            //    var sbPrev = new Storyboard();
            //    var animationOpacityPrev = new DoubleAnimation(1, 0, new Duration(new TimeSpan(0, 0, 0, 0, 100)));
            //    Storyboard.SetTargetName(animationOpacityPrev, "listBoxPrevImage");
            //    Storyboard.SetTargetProperty(animationOpacityPrev, new PropertyPath(OpacityProperty));
            //    sbPrev.Children.Add(animationOpacityPrev);

            //    var animationTranslatePrev = new DoubleAnimation(0, xTranslateRight, new Duration(new TimeSpan(0, 0, 0, 0, 500)));
            //    Storyboard.SetTargetName(animationTranslatePrev, "listBoxPrevTranlateTransform");
            //    Storyboard.SetTargetProperty(animationTranslatePrev, new PropertyPath(TranslateTransform.XProperty));
            //    sbPrev.Children.Add(animationTranslatePrev);

            //    var sb = new Storyboard();
            //    listBoxScaleTranform.ScaleX = 0;
            //    var animationTranslate = new DoubleAnimation(xTranslateRight, xTranslateLeft, new Duration(new TimeSpan(0, 0, 0, 0, 100)));
            //    Storyboard.SetTargetName(animationTranslate, "listBoxTranlateTransform");
            //    Storyboard.SetTargetProperty(animationTranslate, new PropertyPath(TranslateTransform.XProperty));
            //    sb.Children.Add(animationTranslate);

            //    var sbNext = new Storyboard();
            //    var animationOpacityNext = new DoubleAnimation(0, 1, new Duration(new TimeSpan(0, 0, 0, 0, 100)));
            //    Storyboard.SetTargetName(animationOpacityNext, "listBoxNextImage");
            //    Storyboard.SetTargetProperty(animationOpacityNext, new PropertyPath(OpacityProperty));
            //    sbPrev.Children.Add(animationOpacityNext);

            //    var animationTranslateNext = new DoubleAnimation(xTranslateLeft, 0, new Duration(new TimeSpan(0, 0, 0, 0, 500)));
            //    Storyboard.SetTargetName(animationTranslateNext, "listBoxNextTranlateTransform");
            //    Storyboard.SetTargetProperty(animationTranslateNext, new PropertyPath(TranslateTransform.XProperty));
            //    sbNext.Children.Add(animationTranslateNext);

            //    sb.Begin(listBoxImage);
            //    sbPrev.Begin(listBoxPrevImage);
            //    sbNext.Begin(listBoxNextImage);
            //}
            //else if (listBoxTranlateTransform.X == xTranslateLeft)
            //{
            //    listBoxScaleTranform.ScaleX = 1;

            //    var sbPrev = new Storyboard();
            //    listBoxPrevScaleTranform.ScaleX = 0;
            //    var animationTranslatePrev = new DoubleAnimation(xTranslateRight, xTranslateLeft, new Duration(new TimeSpan(0, 0, 0, 0, 100)));
            //    Storyboard.SetTargetName(animationTranslatePrev, "listBoxPrevTranlateTransform");
            //    Storyboard.SetTargetProperty(animationTranslatePrev, new PropertyPath(TranslateTransform.XProperty));
            //    sbPrev.Children.Add(animationTranslatePrev);

            //    var sb = new Storyboard();
            //    var animationOpacity = new DoubleAnimation(0, 1, new Duration(new TimeSpan(0, 0, 0, 0, 100)));
            //    Storyboard.SetTargetName(animationOpacity, "listBoxImage");
            //    Storyboard.SetTargetProperty(animationOpacity, new PropertyPath(OpacityProperty));
            //    sb.Children.Add(animationOpacity);

            //    var animationTranslate = new DoubleAnimation(xTranslateLeft, 0, new Duration(new TimeSpan(0, 0, 0, 0, 500)));
            //    Storyboard.SetTargetName(animationTranslate, "listBoxTranlateTransform");
            //    Storyboard.SetTargetProperty(animationTranslate, new PropertyPath(TranslateTransform.XProperty));
            //    sb.Children.Add(animationTranslate);

            //    var sbNext = new Storyboard();
            //    var animationOpacityNext = new DoubleAnimation(1, 0, new Duration(new TimeSpan(0, 0, 0, 0, 200)));
            //    Storyboard.SetTargetName(animationOpacityNext, "listBoxNextImage");
            //    Storyboard.SetTargetProperty(animationOpacityNext, new PropertyPath(OpacityProperty));
            //    sbPrev.Children.Add(animationOpacityNext);

            //    var animationTranslateNext = new DoubleAnimation(0, xTranslateRight, new Duration(new TimeSpan(0, 0, 0, 0, 500)));
            //    Storyboard.SetTargetName(animationTranslateNext, "listBoxNextTranlateTransform");
            //    Storyboard.SetTargetProperty(animationTranslateNext, new PropertyPath(TranslateTransform.XProperty));
            //    sbNext.Children.Add(animationTranslateNext);

            //    sbPrev.Begin(listBoxPrevImage);
            //    sbNext.Begin(listBoxNextImage);
            //    sb.Begin(listBoxImage);

            //}
        }

        private void faLeft_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            //listBoxTranlateTransform.X -= listBoxImage.ActualWidth * 1.5;

            //double xTranslateRight = listBoxImage.ActualWidth * 1.2;
            //double xTranslateLeft = xTranslateRight - (2 * xTranslateRight);


            //if (listBoxTranlateTransform.X == 0)
            //{
            //    listBoxNextScaleTranform.ScaleX = 1;

            //    var sbPrev = new Storyboard();
            //    listBoxPrevScaleTranform.ScaleX = 0;
            //    var animationTranslatePrev = new DoubleAnimation(xTranslateLeft, xTranslateRight, new Duration(new TimeSpan(0, 0, 0, 0, 100)));
            //    Storyboard.SetTargetName(animationTranslatePrev, "listBoxPrevTranlateTransform");
            //    Storyboard.SetTargetProperty(animationTranslatePrev, new PropertyPath(TranslateTransform.XProperty));
            //    sbPrev.Children.Add(animationTranslatePrev);

            //    var sb = new Storyboard();
            //    var animationOpacity = new DoubleAnimation(1, 0, new Duration(new TimeSpan(0, 0, 0, 0, 200)));
            //    Storyboard.SetTargetName(animationOpacity, "listBoxImage");
            //    Storyboard.SetTargetProperty(animationOpacity, new PropertyPath(OpacityProperty));
            //    sb.Children.Add(animationOpacity);

            //    var animationTranslate = new DoubleAnimation(0, xTranslateLeft, new Duration(new TimeSpan(0, 0, 0, 0, 500)));
            //    Storyboard.SetTargetName(animationTranslate, "listBoxTranlateTransform");
            //    Storyboard.SetTargetProperty(animationTranslate, new PropertyPath(TranslateTransform.XProperty));
            //    sb.Children.Add(animationTranslate);

            //    var sbNext = new Storyboard();
            //    var animationOpacityNext = new DoubleAnimation(0, 1, new Duration(new TimeSpan(0, 0, 0, 0, 100)));
            //    Storyboard.SetTargetName(animationOpacityNext, "listBoxNextImage");
            //    Storyboard.SetTargetProperty(animationOpacityNext, new PropertyPath(OpacityProperty));
            //    sbPrev.Children.Add(animationOpacityNext);

            //    var animationTranslateNext = new DoubleAnimation(xTranslateRight, 0, new Duration(new TimeSpan(0, 0, 0, 0, 500)));
            //    Storyboard.SetTargetName(animationTranslateNext, "listBoxNextTranlateTransform");
            //    Storyboard.SetTargetProperty(animationTranslateNext, new PropertyPath(TranslateTransform.XProperty));
            //    sbNext.Children.Add(animationTranslateNext);

            //    sbPrev.Begin(listBoxPrevImage);
            //    sb.Begin(listBoxImage);
            //    sbNext.Begin(listBoxNextImage);
            //}
            //else if (listBoxTranlateTransform.X == xTranslateRight)
            //{
            //    listBoxScaleTranform.ScaleX = 1;

            //    var sbPrev = new Storyboard();
            //    var animationOpacityPrev = new DoubleAnimation(1, 0, new Duration(new TimeSpan(0, 0, 0, 0, 200)));
            //    Storyboard.SetTargetName(animationOpacityPrev, "listBoxPrevImage");
            //    Storyboard.SetTargetProperty(animationOpacityPrev, new PropertyPath(OpacityProperty));
            //    sbPrev.Children.Add(animationOpacityPrev);

            //    var animationTranslatePrev = new DoubleAnimation(0, xTranslateLeft, new Duration(new TimeSpan(0, 0, 0, 0, 500)));
            //    Storyboard.SetTargetName(animationTranslatePrev, "listBoxPrevTranlateTransform");
            //    Storyboard.SetTargetProperty(animationTranslatePrev, new PropertyPath(TranslateTransform.XProperty));
            //    sbPrev.Children.Add(animationTranslatePrev);

            //    var sb = new Storyboard();
            //    var animationOpacity = new DoubleAnimation(0, 1, new Duration(new TimeSpan(0, 0, 0, 0, 100)));
            //    Storyboard.SetTargetName(animationOpacity, "listBoxImage");
            //    Storyboard.SetTargetProperty(animationOpacity, new PropertyPath(OpacityProperty));
            //    sb.Children.Add(animationOpacity);

            //    var animationTranslate = new DoubleAnimation(xTranslateRight, 0, new Duration(new TimeSpan(0, 0, 0, 0, 500)));
            //    Storyboard.SetTargetName(animationTranslate, "listBoxTranlateTransform");
            //    Storyboard.SetTargetProperty(animationTranslate, new PropertyPath(TranslateTransform.XProperty));
            //    sb.Children.Add(animationTranslate);

            //    var sbNext = new Storyboard();
            //    listBoxNextScaleTranform.ScaleX = 0;
            //    var animationTranslateNext = new DoubleAnimation(xTranslateLeft, xTranslateRight, new Duration(new TimeSpan(0, 0, 0, 0, 100)));
            //    Storyboard.SetTargetName(animationTranslateNext, "listBoxNextTranlateTransform");
            //    Storyboard.SetTargetProperty(animationTranslateNext, new PropertyPath(TranslateTransform.XProperty));
            //    sbNext.Children.Add(animationTranslateNext);

            //    sbNext.Begin(listBoxNextImage);
            //    sbPrev.Begin(listBoxPrevImage);
            //    sb.Begin(listBoxImage);
            //}
            //else if (listBoxTranlateTransform.X == xTranslateLeft)
            //{
            //    listBoxPrevScaleTranform.ScaleX = 1;

            //    var sbPrev = new Storyboard();
            //    var animationOpacityPrev = new DoubleAnimation(0, 1, new Duration(new TimeSpan(0, 0, 0, 0, 100)));
            //    Storyboard.SetTargetName(animationOpacityPrev, "listBoxPrevImage");
            //    Storyboard.SetTargetProperty(animationOpacityPrev, new PropertyPath(OpacityProperty));
            //    sbPrev.Children.Add(animationOpacityPrev);

            //    var animationTranslatePrev = new DoubleAnimation(xTranslateRight, 0, new Duration(new TimeSpan(0, 0, 0, 0, 500)));
            //    Storyboard.SetTargetName(animationTranslatePrev, "listBoxPrevTranlateTransform");
            //    Storyboard.SetTargetProperty(animationTranslatePrev, new PropertyPath(TranslateTransform.XProperty));
            //    sbPrev.Children.Add(animationTranslatePrev);

            //    var sb = new Storyboard();
            //    listBoxScaleTranform.ScaleX = 0;
            //    var animationTranslate = new DoubleAnimation(xTranslateLeft, xTranslateRight, new Duration(new TimeSpan(0, 0, 0, 0, 100)));
            //    Storyboard.SetTargetName(animationTranslate, "listBoxTranlateTransform");
            //    Storyboard.SetTargetProperty(animationTranslate, new PropertyPath(TranslateTransform.XProperty));
            //    sb.Children.Add(animationTranslate);

            //    var sbNext = new Storyboard();
            //    var animationTranslateNext = new DoubleAnimation(0, xTranslateLeft, new Duration(new TimeSpan(0, 0, 0, 0, 500)));
            //    Storyboard.SetTargetName(animationTranslateNext, "listBoxNextTranlateTransform");
            //    Storyboard.SetTargetProperty(animationTranslateNext, new PropertyPath(TranslateTransform.XProperty));
            //    sbNext.Children.Add(animationTranslateNext);

            //    sb.Begin(listBoxImage);
            //    sbPrev.Begin(listBoxPrevImage);
            //    sbNext.Begin(listBoxNextImage);
            //}
        }

        


        private ScrollBar _horizontalScrollBar;
        private RepeatButton _leftButton;
        private RepeatButton _rightButton;

        /// <summary>
        /// This method is calling when the horizontally scrolling ScrollViewer is loaded.
        /// </summary>
        /// <param name="sender">the scrollviewer</param>
        /// <param name="e">the Loaded event</param>
        private void HorizontalScrollViewer_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            ScrollViewer scrollViewer = sender as ScrollViewer;
            scrollViewer.ApplyTemplate();

            _horizontalScrollBar = scrollViewer.Template.FindName("PART_HorizontalScrollBar", scrollViewer) as ScrollBar;
            _horizontalScrollBar.ApplyTemplate();

            _leftButton = _horizontalScrollBar.Template.FindName("PART_LeftButton", _horizontalScrollBar) as RepeatButton;
            _rightButton = _horizontalScrollBar.Template.FindName("PART_RightButton", _horizontalScrollBar) as RepeatButton;

            UpdateHorizontalScrollBarButtons();
        }

        /// <summary>
        /// This method is called when the size of the horizontally scrolling ScrollViewer changes
        /// </summary>
        /// <param name="sender">the scrollviewer</param>
        /// <param name="e">the SizeChanged event</param>
        private void HorizontalScrollViewer_SizeChanged(object sender, System.Windows.SizeChangedEventArgs e)
        {
            UpdateHorizontalScrollBarButtons();
        }

        /// <summary>
        /// This method is called when the scroll bar position changes, due to
        /// calling LineLeft or LineRight.
        /// </summary>
        /// <param name="sender">the scrollviewer</param>
        /// <param name="e">the ScrollChanged event</param>
        private void HorizontalScrollViewer_ScrollChanged(object sender, System.Windows.Controls.ScrollChangedEventArgs e)
        {
            UpdateHorizontalScrollBarButtons();
        }

        /// <summary>
        /// This method is called when the user clicks on the Left arrow button.
        /// </summary>
        /// <param name="sender">the Left arrow button</param>
        /// <param name="e">the click event</param> 
        private void LeftButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            //HorizontalScroller.LineLeft();
            double availablePanelWidth = HorizontalScroller.ActualWidth;

            availablePanelWidth += LeftButton.ActualWidth;
            availablePanelWidth += RightButton.ActualWidth;

            HorizontalScroller.ScrollToHorizontalOffset(HorizontalScroller.HorizontalOffset - availablePanelWidth);
        }

        /// <summary>
        /// This method is called when the user clicks on the Right arrow button.
        /// </summary>
        /// <param name="sender">the Right arrow button</param>
        /// <param name="e">the click event</param>
        private void RightButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            //HorizontalScroller.LineRight();
            double availablePanelWidth = HorizontalScroller.ActualWidth;

            availablePanelWidth += LeftButton.ActualWidth;
            availablePanelWidth += RightButton.ActualWidth;

            HorizontalScroller.ScrollToHorizontalOffset(HorizontalScroller.HorizontalOffset + availablePanelWidth);
        }

        /// <summary>
        /// This method adjusts the visibility of the scroll bar buttons, depending  
        /// on the available space and the current scroll position. 
        /// </summary>
        /// <remarks>
        /// The scroll bar buttons will normally be visible if there is not 
        /// enough room to show all the content (the colored rectangles).
        /// However, if the user is currently scrolled all the way to the
        /// left, the Left scroll button will be hidden.
        /// Similarly, if the user is current scrolled all the way to the
        /// right, the Right scroll button will be hidden.
        /// </remarks>
        private void UpdateHorizontalScrollBarButtons()
        {
            // at startup, _horizontalScrollBar can be null
            if (_horizontalScrollBar == null)
                return;

            // HorizontalContentPanel is the panel containing the colored rectangles.
            // The desired width for the content panel is the amount of space that the
            // colored rectangles would take up if the window was large enough so that
            // they could all be displayed without scrolling.

            tStack.ApplyTemplate();
            tStack.UpdateLayout();

            double desiredPanelWidth = 0;

            foreach (var item in tStack.Items)
            {
                UIElement uiElement = (UIElement)tStack.ItemContainerGenerator.ContainerFromItem(item);

                if (uiElement is ContentPresenter)
                {
                    ContentPresenter contentPresenterElement = (ContentPresenter)uiElement;
                    desiredPanelWidth += contentPresenterElement.ActualWidth;
                }
                else if (uiElement is FrameworkElement)
                {
                    FrameworkElement wpfElement = (FrameworkElement)uiElement;
                    desiredPanelWidth += wpfElement.ActualWidth;
                }
            }

            // We need to figure out how much space is available for the content panel to
            // know if scroll buttons are needed.
            // VerticalScroller is the ScrollViewer which contains our content panel.
            // The VerticalScroller height is "*", so it will take up as much space as
            // possible.  We add the width for any visible scroll buttons to the left or right.

            double availablePanelWidth = HorizontalScroller.ActualWidth;

            if (LeftButton.Visibility == Visibility.Visible)
            {
                availablePanelWidth += LeftButton.ActualWidth;
            }  
            if (RightButton.Visibility == Visibility.Visible)
            {
                availablePanelWidth += RightButton.ActualWidth;
            } 

            // Decide whether to show the scroll bar buttons
            // by comparing the 2 values

            Visibility leftButtonVisibility;
            Visibility rightButtonVisibility;

            if (availablePanelWidth < desiredPanelWidth)
            {
                // By comparing availablePanelWidth and desiredPanelWidth,
                // we now know that scroll bar buttons are needed due to space
                // constraints.  However, we still might choose to hide a scroll bar
                // button based on the current scrollbar position.  If the position
                // is at the left, hide the Left button, and if the position is at the
                // right, hide the Right button.

                bool isAtTheFarLeft = false;
                bool isAtTheFarRight = false;

                if (_horizontalScrollBar != null)
                {
                    if (_horizontalScrollBar.Value == _horizontalScrollBar.Maximum)
                        isAtTheFarRight = true;
                    if (_horizontalScrollBar.Value == _horizontalScrollBar.Minimum)
                        isAtTheFarLeft = true;
                }

                if (isAtTheFarLeft)
                    leftButtonVisibility = Visibility.Collapsed;
                else
                    leftButtonVisibility = Visibility.Visible;

                if (isAtTheFarRight)
                    rightButtonVisibility = Visibility.Collapsed;
                else
                    rightButtonVisibility = Visibility.Visible;
            }
            else
            {
                // scroll bars are not needed

                leftButtonVisibility = Visibility.Collapsed;
                rightButtonVisibility = Visibility.Collapsed;
            }

            LeftButton.Visibility = leftButtonVisibility;
            RightButton.Visibility = rightButtonVisibility;
        }
    }
}
