using MediaTinLanh.UI.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MediaTinLanh.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            btnThanCa.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            Application.Current.Shutdown();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void btnMaximizeRestore_Click(object sender, RoutedEventArgs e)
        {
            if (btnMaximizeRestore.Content == FindResource("Restore"))
            {
                btnMaximizeRestore.Content = FindResource("Maximize");
                this.WindowState = WindowState.Normal;
            }
            else
            {
                btnMaximizeRestore.Content = FindResource("Restore");
                this.WindowState = WindowState.Maximized;
            }
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void btnThanhCa_Click(object sender, RoutedEventArgs e)
        {
            buttonStyle_Reset();
            currentContent_Close();

            Color darkGrayColor = (Color)Application.Current.Resources["MDTLDarkGray"];
            SolidColorBrush backgroundButton = new SolidColorBrush(darkGrayColor);

            Button btn = sender as Button;
            if (btn.Background != backgroundButton)
            {
                buttonStyle_Click(btn);

                mainThanhCa.Visibility = Visibility.Visible;
                //accountButtons.Visibility = Visibility.Visible;
            }
        }

        private void btnKinhThanh_Click(object sender, RoutedEventArgs e)
        {
            buttonStyle_Reset();
            currentContent_Close();

            Color darkGrayColor = (Color)Application.Current.Resources["MDTLDarkGray"];
            SolidColorBrush backgroundButton = new SolidColorBrush(darkGrayColor);

            Button btn = sender as Button;
            if (btn.Background != backgroundButton)
            {
                buttonStyle_Click(btn);
            }
        }

        private void buttonStyle_Click(Button btnInput)
        {
            Color grayColor = (Color)Application.Current.Resources["MDTLGray"];
            SolidColorBrush backgroundButton = new SolidColorBrush(grayColor);

            Color darkGrayColor = (Color)Application.Current.Resources["MDTLDarkGray"];
            SolidColorBrush backgroundDarkerButton = new SolidColorBrush(darkGrayColor);


            Button button = new Button();
            Style style = new Style(typeof(Button), btnInput.Style);

            //Background button normal
            Setter setterNormal = new Setter();
            setterNormal.Property = Button.BackgroundProperty;
            setterNormal.Value = backgroundDarkerButton;
            style.Setters.Add(setterNormal);

            //Template button
            Setter setterTemplate = new Setter();
            setterTemplate.Property = Button.TemplateProperty;

            ControlTemplate template = new ControlTemplate(typeof(Button));

            template.VisualTree = new FrameworkElementFactory(typeof(Border));

            template.VisualTree.SetValue(Border.BackgroundProperty, (SolidColorBrush)setterNormal.Value);
            template.VisualTree.SetValue(Border.BorderThicknessProperty, new Thickness(1, 0, 1, 0));
            template.VisualTree.SetValue(Border.BorderBrushProperty, backgroundDarkerButton);

            template.VisualTree.AppendChild(new FrameworkElementFactory(typeof(ContentPresenter)));

            template.VisualTree.FirstChild.SetValue(ContentPresenter.HorizontalAlignmentProperty, HorizontalAlignment.Center);
            template.VisualTree.FirstChild.SetValue(ContentPresenter.VerticalAlignmentProperty, VerticalAlignment.Center);

            setterTemplate.Value = template;
            style.Setters.Add(setterTemplate);

            button.Style = style;

            btnInput.Style = button.Style;
        }

        private void buttonStyle_Reset()
        {
            btnThanCa.Style = (Style)this.Resources["MenuButton"];
            btnKinhThanh.Style = (Style)this.Resources["MenuButton"];
            btnVideo.Style = (Style)this.Resources["MenuButton"];
            btnHinhAnh.Style = (Style)this.Resources["MenuButton"];
            btnDoKinhThanh.Style = (Style)this.Resources["MenuButton"];
            btnTruyenTranh.Style = (Style)this.Resources["MenuButton"];
            btnTranhToMau.Style = (Style)this.Resources["MenuButton"];
            btnThietKe.Style = (Style)this.Resources["MenuButton"];
        }

        private void currentContent_Close()
        {
            mainThanhCa.Visibility = Visibility.Hidden;
        }

        private void btnOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            btnCloseMenu.Visibility = Visibility.Visible;
            btnOpenMenu.Visibility = Visibility.Collapsed;
        }

        private void btnCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            btnOpenMenu.Visibility = Visibility.Visible;
            btnCloseMenu.Visibility = Visibility.Collapsed;
        }
    }

}
