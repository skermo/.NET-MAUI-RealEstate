using RealEstate.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Data
{
    public class BookmarkRepository
    {
        public string StatusMessage { get; set; }

        private SQLiteConnection conn;
        private void Init()
        {
            if (conn != null)
                return;
            conn = new SQLiteConnection(Database.DatabasePath, Database.Flags);
            conn.CreateTable<Bookmark>();
        }
        public void AddNewBookmark(int userId, int propertyId)
        {
            int result = 0;
            Init();

            result = conn.Insert(new Bookmark
            {
                userId= userId,
                propertyId= propertyId,
            });

        }
        public List<Bookmark> GetAllBookmarks()
        {
            try
            {
                Init();
                return conn.Table<Bookmark>().ToList();
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Unable to read data from the database. {0}", ex.Message);
            }

            return new List<Bookmark>();
        }

        /*public void DeleteBookmark(Bookmark bookmark)
        {
            Init();
            conn.Delete(bookmark);
        }*/
    }
}
