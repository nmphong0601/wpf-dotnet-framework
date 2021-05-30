using Microsoft.Xaml.Behaviors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MediaTinLanh.UI.Resources
{
    partial class CustomResourceDictionary : ResourceDictionary
    {
        public CustomResourceDictionary()
        {
            InitializeComponent();
        }

        double offset = 0;
        private void Button_Left(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.Primitives.RepeatButton btn = sender as System.Windows.Controls.Primitives.RepeatButton;
            ScrollViewer scrollViewer = btn.Tag as ScrollViewer;
            scrollViewer.ApplyTemplate();

            var listBoxElement = scrollViewer.GetSelfAndAncestors().Where(x => x.DependencyObjectType.Name == "ListBox").FirstOrDefault() as ListBox;

            listBoxElement.ApplyTemplate();
            ListBoxItem item = listBoxElement.ItemContainerGenerator.ContainerFromIndex(0) as ListBoxItem;

            offset -= item.ActualWidth;
            if (offset < 0)
                offset = 0;
            scrollViewer.ScrollToHorizontalOffset(offset);
        }

        private void Button_Right(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.Primitives.RepeatButton btn = sender as System.Windows.Controls.Primitives.RepeatButton;
            ScrollViewer scrollViewer = btn.Tag as ScrollViewer;
            scrollViewer.ApplyTemplate();

            var listBoxElement = scrollViewer.GetSelfAndAncestors().Where(x => x.DependencyObjectType.Name == "ListBox").FirstOrDefault() as ListBox;

            listBoxElement.ApplyTemplate();
            ListBoxItem item = listBoxElement.ItemContainerGenerator.ContainerFromIndex(0) as ListBoxItem;

            offset += item.ActualWidth;
            if (offset > scrollViewer.ScrollableWidth)
                offset = scrollViewer.ScrollableWidth;
            scrollViewer.ScrollToHorizontalOffset(offset);
        }
    }
}
