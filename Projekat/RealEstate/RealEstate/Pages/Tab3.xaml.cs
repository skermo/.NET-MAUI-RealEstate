using RealEstate.Data;
using RealEstate.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace RealEstate.Pages;

public partial class Tab3 : ContentPage
{
    public Tab3()
    {
        InitializeComponent();
        GetPropertiesList();
    }

    public async void GetPropertiesList()
    {
        List<Property> properties = new List<Property>();
        List<Bookmark> bookmarks = LoginPage.getAllBookmarks();
        for(int i = 0; i < bookmarks.Count; i++)
        {
            if (bookmarks[i].userId == LoginPage.user.id)
            {
                for(int j = 0; j < LoginPage.properties.Count; j++)
                {
                    if (LoginPage.properties[j].id == bookmarks[i].propertyId)
                    {
                        properties.Add(LoginPage.properties[j]);
                    }
                }
            }
        }
        CvProperties.ItemsSource = properties;
        
    }

    void CvProperties_SelectionChanged(System.Object sender, Microsoft.Maui.Controls.SelectionChangedEventArgs e)
    {
        var currentSelection = e.CurrentSelection.FirstOrDefault() as Property;
        if (currentSelection == null) return;
        Navigation.PushModalAsync(new PropertyDetail(currentSelection.id));
        ((CollectionView)sender).SelectedItem = null;
    }

}