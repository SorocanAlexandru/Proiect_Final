using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Proiect_Final.Rezervari
{
    public class Restaurantul
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string ShopName { get; set; }
        public string Adress { get; set; }
        public DateTime Data { get; set; }
        public string ShopDetails
        {
            get
            {
                return "Adresa: " + Adress + "\n" + "Data: " + Data;} }

        [OneToMany]
        public List<ListaRezervari> ListeRezervari { get; set; }
    }
}
