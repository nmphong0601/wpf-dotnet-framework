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
using System.Windows.Shapes;
using System.Windows.Threading;

namespace MediaTinLanh.UI.Controls
{
    /// <summary>
    /// Interaction logic for IntroWindow.xaml
    /// </summary>
    public partial class IntroWindow
    {
        public IntroWindow()
        {
            InitializeComponent();
            StartCloseTimer();
        }

        private void StartCloseTimer()
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(3d);
            timer.Tick += TimerTick;
            timer.Start();
        }

        private void TimerTick(object sender, EventArgs e)
        {
            try
            {
                DispatcherTimer timer = (DispatcherTimer)sender;
                if (timer.Interval == TimeSpan.Zero)
                {
                    timer.Stop();
                    MainWindow main = new MainWindow();
                    main.Owner = this;
                    this.Hide(); // not required if using the child events below
                    main.ShowDialog();
                }

                timer.Interval = timer.Interval.Add(TimeSpan.FromSeconds(-1));
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
