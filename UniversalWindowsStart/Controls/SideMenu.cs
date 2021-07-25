using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;

namespace UniversalWindowsStart.Controls
{
    [TemplatePart(Name = PART_HamburgerMenuButton, Type = typeof(ButtonBase))]
    [TemplatePart(Name = PART_SplitView, Type = typeof(SplitView))]
    [TemplatePart(Name = PART_Frame, Type = typeof(Frame))]
    public class SideMenu : ListBox
    {
        private const string PART_HamburgerMenuButton = "PART_HamburgerMenuButton";
        private const string PART_SplitView = "PART_SplitView";
        private const string PART_Frame = "PART_Frame";
        private Button HamburgerMenuButton;
        private SplitView SplitView1;
        private Frame Frame1;

        public SideMenu()
        {
            DefaultStyleKey = typeof(SideMenu);
            SelectionChanged += SideMenu_SelectionChanged;
            Loaded += SideMenu_Loaded;
        }

        public Dictionary<string, Page> Pages
        {
            get => (Dictionary<string, Page>)GetValue(PagesProperty);
            set => SetValue(PagesProperty, value);
        }

        public static readonly DependencyProperty PagesProperty =
            DependencyProperty.Register(
                name: nameof(Pages),
                propertyType: typeof(Dictionary<string, Page>),
                ownerType: typeof(SideMenu),
                typeMetadata: new PropertyMetadata(
                defaultValue: new Dictionary<string, Page>()));

        private void SideMenu_Loaded(object sender, RoutedEventArgs e)
        {
            SelectPage(pageName: "HomePage");
        }

        private void SideMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                SideMenuItem item = (SideMenuItem)e.AddedItems[0];
                SelectPage(item.PageTypeName);
            }
        }

        private void HamburgerMenuButton_Click(object sender, RoutedEventArgs e)
        {
            SplitView1.IsPaneOpen = !SplitView1.IsPaneOpen;
        }

        private void SelectPage(string pageName)
        {
            if (string.IsNullOrEmpty(pageName) || Pages.Count == 0)
            {
                return;
            }
            Frame1.Content = Pages.ContainsKey(pageName) ? Pages[pageName] : (object)"Page not founded.";
        }

        protected override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            HamburgerMenuButton = GetTemplateChild<Button>(PART_HamburgerMenuButton);
            HamburgerMenuButton.Click += HamburgerMenuButton_Click;
            SplitView1 = GetTemplateChild<SplitView>(PART_SplitView);
            Frame1 = GetTemplateChild<Frame>(PART_Frame);
        }

        protected T GetTemplateChild<T>(string childName) where T : DependencyObject
        {
            return GetTemplateChild(childName) is T child ? child : throw new TemplatePartNotFounded(childName, typeof(T));
        }

        protected override DependencyObject GetContainerForItemOverride()
        {
            return new SideMenuItem();
        }

        protected override bool IsItemItsOwnContainerOverride(object item)
        {
            return item is SideMenuItem;
        }
    }
}
