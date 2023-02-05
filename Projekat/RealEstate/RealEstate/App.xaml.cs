namespace RealEstate;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

        //MainPage = new NavigationPage();
        MainPage = new AppShell();
        //MainPage = new Microsoft.Maui.Controls.NavigationPage(new AppShell());
    }
}
