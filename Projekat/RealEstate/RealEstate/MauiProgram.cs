using RealEstate.Data;
using RealEstate.Pages;

namespace RealEstate;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});
        // TODO: Dependency injection - Dodavanje instance kako bi bila dostupna i mogla se koristiti kroz cijelu aplikaciju
        builder.Services.AddTransient<RegisterPage>();
        builder.Services.AddTransient<LoginPage>();
        builder.Services.AddTransient<Tab2>();
        builder.Services.AddTransient<Tab1>();
        builder.Services.AddTransient<PropertyList>();
        builder.Services.AddTransient<Tab3>();
        builder.Services.AddTransient<ProfilePage>();
        builder.Services.AddTransient<Tab4>();

        builder.Services.AddSingleton<UserRepository>();
        builder.Services.AddSingleton<CategoryRepository>();
        builder.Services.AddSingleton<PropertyRepository>();
        builder.Services.AddTransient<BookmarkRepository>();

        return builder.Build();
	}
}
