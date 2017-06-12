using MyDictionary.Models;
using SQLite.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MyDictionary.Helper
{
    public class SQLiteManager
    {
        SQLiteConnection _sqlconnection;
        public SQLiteManager()
        {
            _sqlconnection = DependencyService.Get<ISQLiteConnection>().GetConnection();
            _sqlconnection.CreateTable<Dictionary>();
        }

        #region CRUD
        public int Insert(Dictionary d)
        {
            return _sqlconnection.Insert(d);
        }
        public int Update(Dictionary d)
        {
            return _sqlconnection.Update(d);
        }
        public int Delete(int Id)
        {
            return _sqlconnection.Delete<Dictionary>(Id);
        }
        public List<Dictionary> GetAll()
        {
            return _sqlconnection.Table<Dictionary>().ToList();
        }
        public Dictionary Get(int Id)
        {
            return _sqlconnection.Table<Dictionary>().FirstOrDefault(x => x.Id == Id);
        }

        public void Dispose()
        {
            _sqlconnection.Dispose();
        }
        #endregion
    }
}
