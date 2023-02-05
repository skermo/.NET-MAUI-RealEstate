using RealEstate.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Data
{
    public class CategoryRepository
    {
        public string StatusMessage { get; set; }
        private SQLiteConnection conn;
        private void Init()
        {
            if (conn != null)
                return;
            conn = new SQLiteConnection(Database.DatabasePath, Database.Flags);
            conn.CreateTable<Category>();
        }

        public void AddNewCategory(int id, string name, string imageUrl)
        {
            int result = 0;
            Init();

            result = conn.Insert(new Category
            {
                id = id,
                name = name,
                imageUrl = imageUrl
            });
        }

        public List<Category> GetAlCategories()
        {
            try
            {
                Init();
                return conn.Table<Category>().ToList();
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Unable to read data from the database. {0}", ex.Message);
            }

            return new List<Category>();
        }
        public void deleteAllCategories()
        {
            Init();
            conn.DeleteAll<Category>();
        }
    }
}
