using Microsoft.Maui.ApplicationModel.Communication;
using Microsoft.Maui.Controls;
using RealEstate.Data;
using RealEstate.Models;
using System;

namespace RealEstate.Pages;

public partial class LoginPage : ContentPage
{
    /*    private async void Button_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//Home/Tab1");
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//Home/Tab1");
        }*/
    UserRepository repository;
    PropertyRepository property;
    CategoryRepository category;
    public static BookmarkRepository bookmarkRepository;
    public static User user = new User();
    public static List<Property> properties = new List<Property>();
    public static List<Category> categories = new List<Category>();
    public static List<Bookmark> bookmarks = new List<Bookmark>();
    public static List<City> cities = new List<City>();
    public LoginPage(UserRepository userRepository, PropertyRepository propertyRepository, CategoryRepository categoryRepository, BookmarkRepository bookmarkRepository)
    {
        InitializeComponent();
        repository = userRepository;
        this.property = propertyRepository;
        this.category = categoryRepository;
        LoginPage.bookmarkRepository = bookmarkRepository;
    }


    async void BtnLogin_Clicked(System.Object sender, System.EventArgs e)
    {
        List<User> users = repository.GetAllUsers();
        string email = EntEmail.Text;
        string password = EntPassword.Text;
        int br = 0;
        for (int i = 0; i < users.Count; i++)
        {
            if (users[i].email.Equals(email) && users[i].password.Equals(password))
            {
                loadUser(users[i].id, users[i].name, users[i].email, users[i].phone);
                bookmarks = getAllBookmarks();
                 /*user.id = users[i].id;
                 user.email = users[i].email;
                 user.name = users[i].name;
                 user.phone = users[i].phone;*/
                await Shell.Current.GoToAsync("//Home/Tab1");
                EntEmail.Text = "";
                EntPassword.Text = "";
                email = "";
                password = "";
                br++;
                 property.deleteAllProperties();
                 category.deleteAllCategories();
                 napraviSve();
                properties = property.GetAllProperties();
                categories = category.GetAlCategories();
                List<string> pom = getCities().Distinct().ToList();
                foreach (string c in pom)
                {
                    cities.Add(new City(c));
                }

                /*cities.add(28, "Dubai", "");
                cities.Add("Abu Dhabi");*/
                //cities.Add(new City("Dubai"));
                //cities.Add(new City("Abu Dhabi"));
            }
        }
        if (br == 0)
        {
            DisplayAlert("", "Oops something went wrong.", "Cancel");
        }
        /*var response = await ApiService.Login(EntEmail.Text, EntPassword.Text);
        if (response)
        {
            Application.Current.MainPage = new CustomTabbedPage();
        }
        else
        {
            await DisplayAlert("", "Oops something went wrong.", "Cancel");
        }*/
    }

    async void TapJoinNow_Tapped(object sender, System.EventArgs e)
    {
        await Shell.Current.GoToAsync("//RegisterPage");
    }

    public static List<Bookmark> getAllBookmarks()
    {
        List<Bookmark> allBookmarks = bookmarkRepository.GetAllBookmarks();
        return allBookmarks;
    }

    public static void addBookmark(Bookmark bookmark)
    {
        bookmarkRepository.AddNewBookmark(bookmark.userId, bookmark.propertyId);
    }

    /*public static void deleteBookmark(Bookmark bookmark)
    {
        bookmarkRepository.DeleteBookmark(bookmark);
    }*/

    public void napraviSve()
    {
        property.AddNewProperty(1, "Jumeirah Metro City", "Allsopp Real Estate are pleased to offer this stunning one bedroom apartment in Emaar's 5242, Dubai Marina.Amazing full marina views, from all rooms, this one bedroom apartment is offered vacant and spread over 696 sq. ft. Perfect for short term holiday lets or as a first home.", "Ciel Tower, Dubai Marina", "imagep1.jpg", 800000, false, 1, "38762098767", "Dubai");
        property.AddNewProperty(2, "Stuning Marina", "Sky golobal Real Estate is pleased to offer this stunning house in Emaar's 5242, Abu Dhabi Marina.Amazing full marina views, from all rooms, this one bedroom apartment is offered vacant and spread over 696 sq. ft. Perfect for short term holiday lets or as a first home.", "Dorrabay, Abu Dhabi Marina", "imagep2.jpg", 700000, true, 1, "38762569075", "Abu Dhabi");
        property.AddNewProperty(3, "Distress Deal", "Allsopp Real Estate are pleased to offer this stunning one bedroom apartment in Emaar's 5242, Abu Dhabi Marina.Amazing full marina views, from all rooms, this one bedroom apartment is offered vacant and spread over 696 sq. ft. Perfect for short term holiday lets or as a first home.", "Dorrabay, Abu Dhabi Marina", "imagep3.jpg", 200000, false, 1, "38761500869", "Abu Dhabi");
        property.AddNewProperty(4, "Panoramic Views", "Jumeirah Real Estate is pleased to offer this stunning one bedroom apartment in Emaar's 5242, Dubai Marina.Amazing full marina views, from all rooms, this one bedroom apartment is offered vacant and spread over 696 sq. ft. Perfect for short term holiday lets or as a first home.", "TFG Marina , Dubai Marina", "imagep4.jpg", 900000, false, 2, "3876378609", "Dubai");
        property.AddNewProperty(5, "Palm View", "Allsopp Real Estate are pleased to offer this stunning one bedroom apartment in Emaar's 5242, Abu Dhabi Marina.Amazing full marina views, from all rooms, this one bedroom apartment is offered vacant and spread over 696 sq. ft. Perfect for short term holiday lets or as a first home.", "The Palm Tower, Palm Jumeirah", "imagep5.jpg", 750000, true, 2, "38761521169", "Abu Dhabi");
        property.AddNewProperty(6, "Full Marina View", "Allsopp Real Estate are pleased to offer this stunning one bedroom apartment in Emaar's 5242, Dubai Marina.Amazing full marina views, from all rooms, this one bedroom apartment is offered vacant and spread over 696 sq. ft. Perfect for short term holiday lets or as a first home.", "Dorrabay, Dubai Marina", "imagep6.jpg", 200000, false, 3, "38750009128", "Dubai");
        property.AddNewProperty(7, "Avant Tower", "We are pleased to offer this stunning two bed apartment in Emaar's 5243, Dubai.Amazing full marina views, from all rooms, this two bedroom apartment is offered vacant and spread over 850 sq. ft. Perfect for short term holiday lets or as a first home.", "Attessa, Marina Promenade, Dubai Marina", "imagep7.jpg", 300000, true, 3, "38760999716", "Dubai");
        property.AddNewProperty(8, "Distress Deal", "Eithad Real Estate is pleased to offer this stunning one bedroom apartment in Emaar's 5242, Abu Dhabi Marina.Amazing full marina views, from all rooms, this one bedroom apartment is offered vacant and spread over 696 sq. ft. Perfect for short term holiday lets or as a first home.", "Tower B1, Vida Hotel, The Hills", "imagep8.jpg", 400000, false, 3, "3876678901", "Abu Dhabi");
        property.AddNewProperty(9, "Sea View", "Kernizia Real Estate is pleased to offer this stunning one bedroom apartment in Emaar's 5242, Abu Dhabi Marina.Amazing full marina views, from all rooms, this one bedroom apartment is offered vacant and spread over 696 sq. ft. Perfect for short term holiday lets or as a first home.", "Vida Residence 2, Vida Residence", "imagep9.jpg", 880000, false, 3, "38761907739", "Abu Dhabi");
        property.AddNewProperty(10, "Jenkins Height", "Astro Properties are delighted to present this Excellent investment opportunity to own a hotel room in the heart of Dubai Marina! Wyndham Dubai Marina is an upscale 4* hotel with breathtaking views of the Arabian Sea and Dubai Marina. The hotel is very popular through the guests and visitors and keeps high ranking on booking. com and similar booking portals through all time.", "Artesia C, Artesia, DAMAC Hills", "imagep10.jpg", 5500000, false, 4, "38761222254", "Dubai");
        property.AddNewProperty(11, "Takishi Penhouse", "Allsopp Real Estate are pleased to offer this stunning one bedroom apartment in Emaar's 5242, Dubai Marina.Amazing full marina views, from all rooms, this one bedroom apartment is offered vacant and spread over 696 sq. ft. Perfect for short term holiday lets or as a first home.", "Damac Maison The Distinction, Downtown Dubai", "imagep11.jpg", 800000, false, 4, "38762980013", "Dubai");
        property.AddNewProperty(12, "Blue World", "Elan Real Estate delighted to present Ciel Tower that means Sky in French, is in Abu Dhabi Marina one of the magnificent height of 360 meters and is a breathtaking building that will set a new global milestone as the world's tallest hotel upon completion. The architectural marvel is the newest landmark added to the world-famous skyline of the Marina. Designed by the award-winning London-based architect NORR, Ciel Tower features a stunning exterior, futuristic interiors and a spectacular glass observation deck that provides incredible 360-degree views of Abu Dhabi Marina, Palm Jumeirah and the Arab Gulf. ", "Dorrabay, Abu Dhabi Marina", "imagep12.jpg", 650000, true, 4, "38763517986", "Abu Dhabi");

        category.AddNewCategory(1, "House", "house.png");
        category.AddNewCategory(2, "Hotel", "hotel.png");
        category.AddNewCategory(3, "Apartment", "appartment.png");
        category.AddNewCategory(4, "Penthouse", "penthouse.png");
    }
    public List<string> getCities()
    {
        List<string> propertyCities = new List<string>();
        foreach (Property property in properties)
        {
            propertyCities.Add(property.city);
        }
        return propertyCities;
    }
    public static void loadUser(int id, string name, string email, string phone){
        user.id = id;
        user.name = name;
        user.email = email;
        user.phone = phone;
}
}