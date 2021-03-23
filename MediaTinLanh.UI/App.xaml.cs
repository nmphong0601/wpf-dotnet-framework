using ControlzEx.Theming;
using MahApps.Metro.Theming;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace MediaTinLanh.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            ThemeManager.Current.ThemeSyncMode = ThemeSyncMode.SyncWithAppMode;
            ThemeManager.Current.SyncTheme();

            Color gray = (Color)ColorConverter.ConvertFromString("#424242");
            SolidColorBrush grayBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#424242"));

            ThemeManager.Current.AddTheme(new Theme("CustomDarkGray", "CustomDarkGray", "Dark", "Gray", gray, grayBrush, true, false));
            ThemeManager.Current.AddTheme(new Theme("CustomLightGray", "CustomLightGray", "Light", "Gray", gray, grayBrush, true, false));

            ThemeManager.Current.AddTheme(RuntimeThemeGenerator.Current.GenerateRuntimeTheme("Dark", gray));
            ThemeManager.Current.AddTheme(RuntimeThemeGenerator.Current.GenerateRuntimeTheme("Light", gray));

            ThemeManager.Current.ChangeTheme(this, "Dark.Gray");
        }
    }
}
