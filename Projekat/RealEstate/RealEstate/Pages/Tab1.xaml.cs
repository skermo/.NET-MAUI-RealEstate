using Microsoft.Win32;
using RealEstate.Data;
using RealEstate.Models;
using System.Windows.Input;

namespace RealEstate.Pages;

public partial class Tab1 : ContentPage
{
	public Tab1()
    {
        InitializeComponent();
        LblUserName.Text = "Hi " + LoginPage.user.name;
        GetCategories();
        GetCities();
        GetTrendingProperties();
        GetRecomendedProperties();
    }

    private async void GetTrendingProperties()
    {
        List<Property> trendingProperties = new List<Property>();
        for(int i = 0; i < LoginPage.properties.Count; i++)
        {
            if (LoginPage.properties[i].isTrending)
            {
                trendingProperties.Add(LoginPage.properties[i]);
            }
        }
        CvTopPicks.ItemsSource = trendingProperties;
    }

    private async void GetRecomendedProperties()
    {
        List<Bookmark> bookmarks = LoginPage.bookmarks;
        List<Property> recommendedProperties = new List<Property>();
        List<int> ints= new List<int>();
        foreach(Category category in LoginPage.categories)
        {
            ints.Add(0);
        }
        for(int i = 0; i < bookmarks.Count(); i++)
        {
            if (bookmarks[i].userId == LoginPage.user.id)
                ints[LoginPage.properties[bookmarks[i].propertyId-1].categoryId-1] += 1;
        }
        for(int i = 0; i < ints.Count; i++)
        {
            if (ints[i] >= 2)
            {
                foreach(Property property in LoginPage.properties)
                {
                    if(property.categoryId == i + 1)
                    {
                        recommendedProperties.Add(property);
                    }
                }
            }
        }
        if(recommendedProperties.Count() == 0)
        {
            recommendedProperties.Add(LoginPage.properties[5]);
            recommendedProperties.Add(LoginPage.properties[9]);
            recommendedProperties.Add(LoginPage.properties[2]);
            recommendedProperties.Add(LoginPage.properties[11]);
        }

        CvRecommended.ItemsSource = recommendedProperties;
    }

    private async void GetCities()
    {
        CvCities.ItemsSource = LoginPage.cities;
    }
    private async void GetCategories()
    {
        CvCategories.ItemsSource = LoginPage.categories;
    }

    public async void CvCategories_SelectionChanged(System.Object sender, Microsoft.Maui.Controls.SelectionChangedEventArgs e)
    {
        var currentSelection = e.CurrentSelection.FirstOrDefault() as Category;
        if (currentSelection == null)
            return;
        await Navigation.PushModalAsync(new PropertyList(currentSelection.id, currentSelection.name));
        ((CollectionView)sender).SelectedItem = null;
    }
    public async void CvCities_SelectionChanged(System.Object sender, Microsoft.Maui.Controls.SelectionChangedEventArgs e)
    {
        var currentSelection = e.CurrentSelection.FirstOrDefault() as City;
        if (currentSelection == null)
            return;
        await Navigation.PushModalAsync(new PropertyList(currentSelection.name));
        ((CollectionView)sender).SelectedItem = null;
    }

    void CvTopPicks_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var currentSelection = e.CurrentSelection.FirstOrDefault() as Property;
        if (currentSelection == null) return;
        Navigation.PushModalAsync(new PropertyDetail(currentSelection.id));
        ((CollectionView)sender).SelectedItem = null;
    }
    void CvRecommended_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var currentSelection = e.CurrentSelection.FirstOrDefault() as Property;
        if (currentSelection == null) return;
        Navigation.PushModalAsync(new PropertyDetail(currentSelection.id));
        ((CollectionView)sender).SelectedItem = null;
    }

    void TapSearch_Tapped(object sender, System.EventArgs e)
    {
        Navigation.PushModalAsync(new Tab2());
    }
#region Commands
    public ICommand SelectedItemCommand => new Command<Category>(async (currentCategory) =>
    {
        await DisplayAlert("Selected Category", "Selected Category Name is " + currentCategory.name, "OK");
    });
#endregion
}