# UniversalWindowsStart
Este é um projeto de uma biblioteca muito simples, sem dependências, que facilita o início de um aplicativo Universal Windows.
   
  
## Controles para navegação:
São 2 controles que trabalham juntos e que permite a navegação entre views.
  
SideMenu | SideMenuItem
--- | ---
Herda de ListBox | Herda de ListBoxItem
Use a propriedade `Pages` para registrar as instâncias das views disponíveis para navigação. | Use a propriedade `PageTypeName` para indicar qual o tipo de view a ser exibida.
  
  
### SideMenu e SideMenuItem exemplos de uso:
Exemplo MVVM:
</br>

```C#
1. Na ViewModel:

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
              { nameof(SettingsPage), new SettingPage() }
          };
      }
  }


  2. Na Página MainPage:

  <Page
      x:Class="MyProject.MainPage"
      xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
      xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
      xmlns:controls="using:UniversalWindowsStart.Controls"
      xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
      xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
      xmlns:vm="using:MyProject.ViewModels"
      Background="{ThemeResource ApplicationPageBackgroundThemeBrush}"
      mc:Ignorable="d">
      <Page.DataContext>
          <vm:MainPageViewModel />
      </Page.DataContext>
      <Grid>
          <controls:SideMenu x:Name="sidemenu" Pages="{Binding Pages, Mode=TwoWay}">
              <controls:SideMenuItem
                  Content="Home"
                  PageTypeName="HomePage"
                  Symbol="Home" />
              <controls:SideMenuItem
                  Content="Settings"
                  PageTypeName="SettingsPage"
                  Symbol="Setting" />
          </controls:SideMenu>
      </Grid>
  </Page>
  ```
Exemplo Code-Behinde:

```C#
1. Code behinde:

public sealed partial class MainPage : Page
{
  public MainPage()
  {
      InitializeComponent();
      Loaded += MainPage_Loaded;
  }

  private void MainPage_Loaded(object sender, RoutedEventArgs e)
  {
      sideMenu.Pages.Clear();
      sideMenu.Pages.Add(nameof(HomePage), new HomePage());
      sideMenu.Pages.Add(nameof(SettingsPage), new SettingsPage());
  }
}

2. Em MainPage.xaml

<Page
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
    xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
    xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
    xmlns:Custom="using:UniversalWindowsStart.Controls"
    x:Class="UniversalWindowsStart.Samples.MainPage"
    mc:Ignorable="d"
    Background="{ThemeResource ApplicationPageBackgroundThemeBrush}">
    <Grid>
        <Custom:SideMenu x:Name="sideMenu">
            <Custom:SideMenuItem Content="Home" Symbol="Home" PageTypeName="HomePage" IsSelected="True"/>
            <Custom:SideMenuItem Content="Settings" Symbol="Setting" PageTypeName="SettingsPage"/>
        </Custom:SideMenu>
    </Grid>
</Page>

```

### Resultado:

![Code sample](https://github.com/fernandostockler/UniversalWindowsStart/blob/development/Captura%20de%20tela%202021-07-25%20173547_MyProject_SideMenu.png)
    
