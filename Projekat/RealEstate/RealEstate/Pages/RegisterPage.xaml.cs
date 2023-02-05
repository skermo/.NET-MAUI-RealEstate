using RealEstate.Data;

namespace RealEstate.Pages;

/*public partial class RegisterPage : ContentPage
{
    private async void Button_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//Login");
    }

}*/
public partial class RegisterPage : ContentPage
{
    UserRepository repository;
    public RegisterPage(UserRepository userRepository)
    {
        InitializeComponent();
        repository = userRepository;
    }

    async void BtnRegister_Clicked(object sender, EventArgs args)
    {
        statusMessage.Text = "";

        try
        {
            repository.AddNewUser(EntFullName.Text, EntEmail.Text, EntPassword.Text, EntPhone.Text);
            statusMessage.Text = repository.StatusMessage;
            EntFullName.Text = null;
            EntEmail.Text = null;
            EntPassword.Text = null;
            EntPhone.Text = null;
            await DisplayAlert("", "Your account has been created", "Alright");
        }
        catch (Exception)
        {
            await DisplayAlert("", "Oops something went wrong", "Cancel");
        }
        await Shell.Current.GoToAsync("//LoginPage");
    }

    async void TapLogin_Tapped(object sender, System.EventArgs e)
    {
        //await Navigation.PushModalAsync(new LoginPage(repository));
        await Shell.Current.GoToAsync("//LoginPage");
    }
}