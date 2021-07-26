using Windows.UI.Xaml.Controls;


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
            sideMenu.SelectPage("SettingsPage");
            sideMenu.SelectedIndex = -1;
        }
    }
}
