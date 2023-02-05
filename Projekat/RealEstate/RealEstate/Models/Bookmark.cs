using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Models
{
    [Table("bookmarks")]
    public class Bookmark
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public int userId { get; set; }
        public int propertyId { get; set; }
    }
}
