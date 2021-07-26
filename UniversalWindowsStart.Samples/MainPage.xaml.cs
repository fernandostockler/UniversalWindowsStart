using Windows.UI.Xaml.Controls;

namespace UniversalWindowsStart.Samples
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void SettingsSideMenuItem_Tapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            sideMenu.SelectPage(SettingsSideMenuItem.PageTypeName);
        }
    }
}
