namespace Proiect_Final;
using Proiect_Final.BazaRezervari;
using Proiect_Final.Rezervari;

public partial class ListaEntryRestaurante : ContentPage
{
	public ListaEntryRestaurante()
	{
		InitializeComponent();
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await AppShell.Database.GetShopListsAsync();
    }
    async void OnShopListAddedClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ListaRestaurante
        {
            BindingContext = new ListaRezervari()
        });
    }
    async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            await Navigation.PushAsync(new ListaRestaurante
            {
                BindingContext = e.SelectedItem as ListaRezervari
            });
        }
    }
}