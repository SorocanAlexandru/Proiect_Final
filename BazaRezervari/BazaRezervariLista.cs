using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Proiect_Final.Rezervari;
using SQLiteNetExtensions;

namespace Proiect_Final.BazaRezervari
{
    public class BazaRezervariLista
    {
        readonly SQLiteAsyncConnection _database;
        public BazaRezervariLista(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<ListaRezervari>().Wait();
            _database.CreateTableAsync<Restaurantul>().Wait();
        }

        public Task<List<Restaurantul>> GetShopsAsync()
        {
            return _database.Table<Restaurantul>().ToListAsync();
        }
        public Task<int> SaveShopAsync(Restaurantul shop)
        {
            if (shop.ID != 0)
            {
                return _database.UpdateAsync(shop);
            }
            else
            {
                return _database.InsertAsync(shop);
            }
        }

        public Task<List<ListaRezervari>> GetShopListsAsync()
        {
            return _database.Table<ListaRezervari>().ToListAsync();
        }
        public Task<ListaRezervari> GetShopListAsync(int id)
        {
            return _database.Table<ListaRezervari>()
            .Where(i => i.ID == id)
           .FirstOrDefaultAsync();
        }
        public Task<int> SaveShopListAsync(ListaRezervari slist)
        {
            if (slist.ID != 0)
            {
                return _database.UpdateAsync(slist);
            }
            else
            {
                return _database.InsertAsync(slist);
            }
        }
        public Task<int> DeleteShopListAsync(ListaRezervari slist)
        {
            return _database.DeleteAsync(slist);
        }

        public Task<int> DeleteRestaurantListAsync(Restaurantul slist)
        {
            return _database.DeleteAsync(slist);
        }
    }
}