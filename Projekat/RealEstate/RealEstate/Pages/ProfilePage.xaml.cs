namespace RealEstate.Pages;

public partial class ProfilePage : ContentPage
{
	public ProfilePage()
	{
		InitializeComponent();
		GetProfileDetails();
	}
	private void GetProfileDetails()
	{
		nameLbl.Text = LoginPage.user.name;
        emailLbl.Text = LoginPage.user.email;
		phoneLbl.Text = LoginPage.user.phone;
	}
    void ImgbackBtn_Clicked(System.Object sender, System.EventArgs e)
    {
        Navigation.PopModalAsync();
    }
}