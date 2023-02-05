

using RealEstate.Models;

namespace RealEstate.Pages;

public partial class PropertyList : ContentPage
{
    public PropertyList(int categoryId, string categoryName)
    {
        InitializeComponent();
        Title = categoryName;
        GetPropertiesList(categoryId);
    }
    public PropertyList(string cityName)
    {
        InitializeComponent();
        //Title = categoryName;
        GetPropertiesList(cityName);
    }
    private async void GetPropertiesList(string cityName)
    {
        List<Property> propertiesByCity = new List<Property>();
        foreach (Property property in LoginPage.properties)
        {
            if (property.city == cityName)
            {
                propertiesByCity.Add(property);
            }
        }
        CvProperties.ItemsSource = propertiesByCity;
    }
    private async void GetPropertiesList(int categoryId)
    {
        List<Property> propertiesByCategory = new List<Property>();
        for(int i = 0; i < LoginPage.properties.Count; i++)
        {
            if (LoginPage.properties[i].categoryId == categoryId)
            {
                propertiesByCategory.Add(LoginPage.properties[i]);
            }
        }
        CvProperties.ItemsSource = propertiesByCategory;
    }

    void CvProperties_SelectionChanged(System.Object sender, Microsoft.Maui.Controls.SelectionChangedEventArgs e)
    {
        var currentSelection = e.CurrentSelection.FirstOrDefault() as Property;
        if (currentSelection == null) return;
        Navigation.PushModalAsync(new PropertyDetail(currentSelection.id));
        ((CollectionView)sender).SelectedItem = null;
    }
}