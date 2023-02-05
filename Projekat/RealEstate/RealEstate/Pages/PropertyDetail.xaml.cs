using RealEstate.Data;
using RealEstate.Models;

namespace RealEstate.Pages;

public partial class PropertyDetail : ContentPage
{
    private int propertyId;
    private string phoneNumber;
    private bool IsBookmarkEnabled;
    public PropertyDetail(int propertyId)
    {
        InitializeComponent();
        GetPropertyDetail(propertyId);
        this.propertyId = propertyId;
       // this.bookmarksRepository = repository;
    }

    private async void GetPropertyDetail(int propertyId)
    {
        Property property = new Property();
        for(int i = 0; i < LoginPage.properties.Count; i++)
        {
            if (LoginPage.properties[i].id == propertyId) {
                property = LoginPage.properties[i];
            }
        }
        LblPrice.Text = "$ " + property.price;
        LblDescription.Text = property.description;
        LblAddress.Text = property.address + ", " + property.city;
        ImgProperty.Source = property.imageUrl;
        LblPhone.Text = "+" + property.phone;

        phoneNumber = property.phone;

        List<Bookmark> bookmarks = LoginPage.getAllBookmarks();
        int br = 0;
        foreach (Bookmark bookmark in bookmarks)
        {
            if(bookmark.userId == LoginPage.user.id && bookmark.propertyId == propertyId)
            {
                ImgbookmarkBtn.Source = "bookmark_fill_icon";
                br++;
            }
        }
        if(br == 0)
        {
            ImgbookmarkBtn.Source = "bookmark_empty_icon";
            IsBookmarkEnabled = false;
        }

       /* if (property.Bookmark == null)
        {
            ImgbookmarkBtn.Source = "bookmark_empty_icon";
            IsBookmarkEnabled = false;
        }
        else
        {
            ImgbookmarkBtn.Source = property.Bookmark.Status ? "bookmark_fill_icon" : "bookmark_empty_icon";
            bookmarkId = property.Bookmark.Id;
            IsBookmarkEnabled = true;
        }*/

    }

    void ImgbackBtn_Clicked(System.Object sender, System.EventArgs e)
    {
        Navigation.PopModalAsync();
    }

    async void ImgbookmarkBtn_Clicked(System.Object sender, System.EventArgs e)
    {
        if (IsBookmarkEnabled == false)
        {
            // Add a bookmark
            var addBookmark = new Bookmark()
            {
                userId = LoginPage.user.id,
                propertyId = propertyId
            };
            LoginPage.addBookmark(addBookmark);
            ImgbookmarkBtn.Source = "bookmark_fill_icon";
            IsBookmarkEnabled = true;
        }
        else
        {
           /* Bookmark deleteBookmark = new Bookmark();
            // Delete a bookmark
            foreach(Bookmark bookmarks in LoginPage.getAllBookmarks())
            {
                if(bookmarks.userId == LoginPage.user.id && bookmarks.propertyId == propertyId)
                {
                    deleteBookmark = bookmarks;
                }
            }
            LoginPage.deleteBookmark(deleteBookmark);
            ImgbookmarkBtn.Source = "bookmark_empty_icon";
            IsBookmarkEnabled = false;*/
        }
    }
}