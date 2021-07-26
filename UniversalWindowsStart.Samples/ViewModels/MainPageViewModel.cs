using System.Collections.Generic;
using UniversalWindowsStart.MVVM;
using UniversalWindowsStart.Samples.Views;
using Windows.UI.Xaml.Controls;

namespace UniversalWindowsStart.Samples.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private Dictionary<string, Page> _pages;
        public Dictionary<string, Page> Pages
        {
            get => _pages;
            private set => _ = SetProperty(ref _pages, value);
        }
        public MainPageViewModel()
        {
            Pages = new Dictionary<string, Page>()
            {
                { nameof(HomePage), new HomePage() },
                { nameof(AboutPage), new AboutPage() }
            };
        }
    }
}
