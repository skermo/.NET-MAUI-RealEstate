using RealEstate.Data;
using RealEstate.Models;

namespace RealEstate.Pages;

public partial class Tab2 : ContentPage
{
	public Tab2()
	{
		InitializeComponent();
	}
    async void ImgBackBtn_Clicked(System.Object sender, System.EventArgs e)
    {
        await Shell.Current.GoToAsync("//Home//Tab1");
    }

    async void SbProperty_TextChanged(System.Object sender, Microsoft.Maui.Controls.TextChangedEventArgs e)
    {
        if (e.NewTextValue == null) return;
        List<Property> properties = new List<Property>();
        foreach (Property property in LoginPage.properties)
        {
            if (property.name.Contains(e.NewTextValue, System.StringComparison.CurrentCultureIgnoreCase) || property.address.Contains(e.NewTextValue, System.StringComparison.CurrentCultureIgnoreCase))
            {
                properties.Add(property);
            }
        }
        CvSearch.ItemsSource = properties;
    }

    void CvSearch_SelectionChanged(System.Object sender, Microsoft.Maui.Controls.SelectionChangedEventArgs e)
    {
        var currentSelection = e.CurrentSelection.FirstOrDefault() as Property;
        if (currentSelection == null) return;
        Navigation.PushModalAsync(new PropertyDetail(currentSelection.id));
        ((CollectionView)sender).SelectedItem = null;
    }
}