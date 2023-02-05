using RealEstate.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Data
{
    // Jedna klasa u kojoj se definira manipualcija sa podacima vezanim za klasu User
    public class UserRepository
    {
        public string StatusMessage { get; set; }

        // TODO: Add variable for the SQLite connection
        private SQLiteConnection conn;
        private void Init()
        {
            // TODO: Add code to initialize the repository
            if (conn != null)
                return;
            conn = new SQLiteConnection(Database.DatabasePath, Database.Flags);
            conn.CreateTable<User>();
        }
        public void AddNewUser(string name, string email, string password, string phone)
        {
            int result = 0;
            try
            {
                // TODO: Call Init()
                Init();

                // basic validation to ensure a name was entered
                if (string.IsNullOrEmpty(name))
                    throw new Exception("Please enter a valid name!");
                if (string.IsNullOrEmpty(email))
                    throw new Exception("Please enter a valid email!");
                if (string.IsNullOrEmpty(password))
                    throw new Exception("Please enter a valid password!");

                // TODO: Insert the new person into the database
                result = conn.Insert(new User
                {
                    name = name,
                    email = email,
                    password = password,
                    phone = phone
                });

                StatusMessage = string.Format("{0} record(s) added (User: {1})", result, name);
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Unable to add {0}. Error: {1}", name, ex.Message);
            }

        }
        public List<User> GetAllUsers()
        {
            // TODO: Init then retrieve a list of Person objects from the database into a list
            try
            {
                Init();
                return conn.Table<User>().ToList();
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Unable to read data from the database. {0}", ex.Message);
            }

            return new List<User>();
        }
    }
}
