namespace Proiect_Final;
using Proiect_Final.Rezervari;


public partial class ListaRestaurante : ContentPage
{
	public ListaRestaurante()
	{
		InitializeComponent();
	}

    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var slist = (ListaRezervari)BindingContext;
        slist.Date = DateTime.UtcNow;
        await AppShell.Database.SaveShopListAsync(slist);
        await Navigation.PopAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var slist = (ListaRezervari)BindingContext;
        await AppShell.Database.DeleteShopListAsync(slist);
        await Navigation.PopAsync();
    }
}