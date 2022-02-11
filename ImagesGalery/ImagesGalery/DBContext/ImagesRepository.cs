using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace ImagesGalery.DBContext
{
     public class ImagesRepository
    {
        SQLiteConnection database;
        public ImagesRepository(string databasePath)
        {
            database = new SQLiteConnection(databasePath);
            database.CreateTable<Images>();
        }

        public IEnumerable<Images> GetItems()
        {
            return database.Table<Images>().ToList();
        }

        public Images GetItem(int id)
        {
            return database.Get<Images>(id);
        }
        public int DeleteItem(int id)
        {
            return database.Delete<Images>(id);
        }
        public int SaveItem(Images item)
        {
            if (item.Id != 0)
            {
                database.Update(item);
                return item.Id;
            }
            else
            {
                return database.Insert(item);
            }
        }
    }
}
