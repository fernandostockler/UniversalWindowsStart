using System.Linq;
using UniversalWindowsStart.Controls;
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
            DesselectAllSideMenuItems();

            void DesselectAllSideMenuItems()
            {
                foreach (object item in sideMenu.Items)
                {
                    if (item is SideMenuItem sideMenuItem)
                    {
                        sideMenuItem.IsSelected = false;
                    }
                }
            }
        }
    }
}
