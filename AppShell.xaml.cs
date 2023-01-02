namespace Proiect_Final;
using System;
using Proiect_Final.BazaRezervari;
using System.IO;
public partial class AppShell : Shell
{
    static BazaRezervariLista database;
    public static BazaRezervariLista Database
    {
        get
        {
            if (database == null)
            {
                database = new
               BazaRezervariLista(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.
               LocalApplicationData), "ShoppingList.db3"));
            }
            return database;
        }
    }
    public AppShell()
	{
		InitializeComponent();
	}
}
