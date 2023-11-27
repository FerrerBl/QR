using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using QR.Models;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Xamarin.Forms;
namespace QR.Data
{
    public class SQLHelper
    {
        SQLiteAsyncConnection db;
        public SQLHelper(string dbPath)
        {
            db = new SQLiteAsyncConnection(dbPath);
            db.CreateTableAsync<Eventos>().Wait();
        }


        public Task<int> SaveEventoAsync(Eventos Even)
        {
            if (Even.IdEventos != 0)
                return db.UpdateAsync(Even);
            else
                return db.InsertAsync(Even);
         }

        public  Task <List<Eventos>> GetEventosAsync()
        {
            return db.Table<Eventos>().Where(x=> x.Estado ==true).ToListAsync();   
        }
        
        public Task <Eventos> GetEventosByIdAsync(int idEventos)
        {
            return db.Table<Eventos>().Where(a=>a.IdEventos ==idEventos).FirstOrDefaultAsync(); 
        }
    }

}