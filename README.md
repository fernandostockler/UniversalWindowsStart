# UniversalWindowsStart
Este é um projeto de uma biblioteca muito simples, sem dependências, que facilita o início de um aplicativo Universal Windows.


## Controles para navegação:
São 2 controles que trabalham juntos e que permite a navegação entre views.


SideMenu | SideMenuItem
--- | ---
Herda de ListBox | Herda de ListBoxItem
Use a propriedade **Pages** para registrar as instâncias das views disponíveis para navigação. | Use a propriedade **PageTypeName** para indicar qual o tipo de view a ser exibida.


### SideMenu e SideMenuItem exemplos de uso:

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

### 3. Resultado:
![Code sample](/Images/Captura de tela 2021-07-25 173547_MyProject_SideMenu.png)
    
