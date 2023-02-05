using RealEstate.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Data
{
    public class PropertyRepository
    {
        public string StatusMessage { get; set; }
        private SQLiteConnection conn;
        private void Init()
        {
            if (conn != null)
                return;
            conn = new SQLiteConnection(Database.DatabasePath, Database.Flags);
            conn.CreateTable<Property>();
        }

        public void AddNewProperty(int id, string name, string description, string address, string imageUrl, double price, bool isTrending, int categoryId, string phone, string city)
        {
            int result = 0;
                Init();

            result = conn.Insert(new Property
            {
                id = id,
                name= name,
                description= description,
                address= address,
                imageUrl= imageUrl,
                price= price,
                isTrending= isTrending,
                categoryId=categoryId, 
                phone = phone,
                city = city
            });
        }

        public List<Property> GetAllProperties()
        {
            try
            {
                Init();
                return conn.Table<Property>().ToList();
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Unable to read data from the database. {0}", ex.Message);
            }

            return new List<Property>();
        }
        public void deleteAllProperties()
        {
            Init();
            conn.DeleteAll<Property>();
        }
    }
}
