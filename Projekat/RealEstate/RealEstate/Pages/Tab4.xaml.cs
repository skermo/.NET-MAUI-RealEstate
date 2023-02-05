using RealEstate.Data;

namespace RealEstate.Pages;

public partial class Tab4 : ContentPage
{

	public Tab4()
	{
		InitializeComponent();
	}
    async void TapLogout_Tapped(object sender, System.EventArgs e)
    {
        //Preferences.Set("accesstoken", string.Empty);
        //Application.Current.MainPage = new LoginPage();
        //LoginPage.loadUser(-1, "", "", "");
        //await Shell.Current.GoToAsync("//LoginPage");
        //LoginPage.user = null;
        //Navigation.PushModalAsync(new WelcomePage());
        Application.Current.MainPage = new AppShell();
    }
    async void TapProfile_Tapped(object sender, System.EventArgs e)
    {
        Navigation.PushModalAsync(new ProfilePage());
    }
}