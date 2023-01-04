
using Plugin.LocalNotification;
using Proiect_Final.Rezervari;
namespace Proiect_Final;


public partial class RestaurantPage : ContentPage
{
	public RestaurantPage()
	{
		InitializeComponent();
	}
    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var shop = (Restaurantul)BindingContext;
        await AppShell.Database.SaveShopAsync(shop);
        await Navigation.PopAsync();
        var detalii = shop.ShopDetails;
        var nume = shop.ShopName;
        
            var request = new NotificationRequest
            {
                Title = "Ai rezervare la restaurantul " + nume,
                Description = detalii,
                Schedule = new NotificationRequestSchedule
                {
                    NotifyTime = DateTime.Now.AddSeconds(1)
                }
            };
            LocalNotificationCenter.Current.Show(request);
        
    }

    async void OnShowMapButtonClicked(object sender, EventArgs e)
    {
        var shop = (Restaurantul)BindingContext;
        var address = shop.Adress;
        var locations = await Geocoding.GetLocationsAsync(address);

        var options = new MapLaunchOptions
        {
            Name = "Magazinul meu preferat"
        };
        var location = locations?.FirstOrDefault();
        // var myLocation = await Geolocation.GetLocationAsync();

        await Map.OpenAsync(location, options);
    }

    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var slist = (Restaurantul)BindingContext;
        await AppShell.Database.DeleteRestaurantListAsync(slist);
        await Navigation.PopAsync();
    }

}