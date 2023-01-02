using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using System.Threading.Tasks;
using Proiect_Final.Rezervari;

namespace Proiect_Final.BazaRezervari
{
    public class BazaRezervariLista
    {
        readonly SQLiteAsyncConnection _database;
        public BazaRezervariLista(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<ListaRezervari>().Wait();
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
    }
}