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
    public class SideMenu : ListBox
    {
        private TextBlock PageNotFounded = new TextBlock() { Text = "Page not founded!", HorizontalAlignment = HorizontalAlignment.Center, VerticalAlignment = VerticalAlignment.Center, FontSize = 42.0 };
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

        private void SideMenu_Loaded(object sender, RoutedEventArgs e)
        {
            SelectPage("HomePage");
        }

        private void SideMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SideMenuItem item = (SideMenuItem)e.AddedItems[0];
            SelectPage(item.PageTypeName);
        }

        private void SelectPage(string pageName)
        {
            if (IsLoaded)
            {
                Frame1.Content = string.IsNullOrEmpty(pageName) || Pages.Count == 0
                    ? PageNotFounded
                    : (object)Pages[pageName];
            }
        }

        protected override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            HamburgerMenuButton = GetTemplateChild<Button>(PART_HamburgerMenuButton, true);
            HamburgerMenuButton.Click += HamburgerMenuButton_Click;
            SplitView1 = GetTemplateChild<SplitView>(PART_SplitView, true);
            Frame1 = GetTemplateChild<Frame>(PART_Frame, true);
        }

        private void HamburgerMenuButton_Click(object sender, RoutedEventArgs e)
        {
            SplitView1.IsPaneOpen = !SplitView1.IsPaneOpen;
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
