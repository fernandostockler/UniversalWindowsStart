using Windows.UI.Xaml.Controls;
using UniversalWindowsStart.Samples.Views;

namespace UniversalWindowsStart.Samples
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void SettingsButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            sideMenu.SelectPage(nameof(SettingsPage));
            sideMenu.SelectedIndex = -1;
        }
    }
}
