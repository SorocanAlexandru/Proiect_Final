using Proiect_Final.Rezervari;

namespace Proiect_Final;

public partial class RestaurantEntryPage : ContentPage
{
	public RestaurantEntryPage()
	{
		InitializeComponent();
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await AppShell.Database.GetShopsAsync();
    }
    async void OnShopAddedClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new RestaurantPage
        {
            BindingContext = new Restaurantul()
        });
    }
    async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            await Navigation.PushAsync(new RestaurantPage
            {
                BindingContext = e.SelectedItem as Restaurantul
            });
        }
    }
}

