using System;
using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;

namespace UniversalWindowsStart.Controls
{
    [TemplatePart(Name = PART_HamburgerMenuButton, Type = typeof(ButtonBase))]
    [TemplatePart(Name = PART_SplitView, Type = typeof(SplitView))]
    [TemplatePart(Name = PART_Frame, Type = typeof(Frame))]
    [TemplatePart(Name = PART_FooterArea, Type = typeof(FrameworkElement))]
    public class SideMenu : ListBox
    {
        private TextBlock PageNotFounded = new TextBlock() { Text = "Page not founded!", HorizontalAlignment = HorizontalAlignment.Center, VerticalAlignment = VerticalAlignment.Center, FontSize = 42.0 };
        private const string PART_HamburgerMenuButton = "PART_HamburgerMenuButton";
        private const string PART_SplitView = "PART_SplitView";
        private const string PART_Frame = "PART_Frame";
        private const string PART_FooterArea = "PART_FooterArea";
        private Button HamburgerMenuButton;
        private SplitView SplitView1;
        private Frame Frame1;
        private FrameworkElement FooterArea;

        public SideMenu()
        {
            DefaultStyleKey = typeof(SideMenu);
            Loaded += SideMenu_Loaded;
            SelectionChanged += SideMenu_SelectionChanged;
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
                typeMetadata: new PropertyMetadata(new Dictionary<string, Page>()));


        private void SideMenu_Loaded(object sender, RoutedEventArgs e)
        {
            DisplayFirstOrSelected();
        }
        private void HamburgerMenuButton_Click(object sender, RoutedEventArgs e)
        {
            SplitView1.IsPaneOpen = !SplitView1.IsPaneOpen;
        }

        private void SideMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SideMenuItem item = (SideMenuItem)e.AddedItems[0];
            SelectPage(item.PageTypeName);
        }

        public void SelectPage(string pageName)
        {
            if (IsLoaded)
            {
                Frame1.Content = string.IsNullOrEmpty(pageName) || Pages.Count == 0
                    ? PageNotFounded
                    : (object)Pages[pageName];
            }
        }

        private void DisplayFirstOrSelected()
        {
            SelectPage(PageWithIsSelectedOrFirstPage());

            string PageWithIsSelectedOrFirstPage()
            {
                SideMenuItem firstItem = null;
                foreach (object item in Items)
                {
                    if (item is SideMenuItem sideMenuItem)
                    {
                        if (firstItem == null)
                        {
                            firstItem = sideMenuItem;
                        }
                        if (sideMenuItem.IsSelected)
                        {
                            return sideMenuItem.PageTypeName;
                        }
                    }
                }
                return firstItem is null ? string.Empty : firstItem.PageTypeName;
            }
        }

        protected override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            HamburgerMenuButton = GetTemplateChild<Button>(PART_HamburgerMenuButton, true);
            HamburgerMenuButton.Click += HamburgerMenuButton_Click;
            SplitView1 = GetTemplateChild<SplitView>(PART_SplitView, true);
            Frame1 = GetTemplateChild<Frame>(PART_Frame, true);
            FooterArea = GetTemplateChild<FrameworkElement>(PART_FooterArea, true);
        }

        /// <summary>
        /// Retrieves the named element in the instantiated ControlTemplate visual tree.
        /// </summary>
        /// <param name="childName">The name of the element to find.</param>
        /// <param name="isRequired">Whether the element is required and will throw an exception if missing.</param>
        /// <returns>The template child matching the given name and type.</returns>
        protected T GetTemplateChild<T>(string childName, bool isRequired = false) where T : DependencyObject
        {
            T child = GetTemplateChild(childName) as T;
            return (child == null) && isRequired ? throw new ArgumentNullException(childName) : child;
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
