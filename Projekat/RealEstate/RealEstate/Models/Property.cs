using SQLite;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Models
{
    [Table("properties")]
    public class Property
    {
        [PrimaryKey]
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string address { get; set; }
        public string imageUrl { get; set; }
        public double price { get; set; }
        public bool isTrending { get; set; }
        public int categoryId { get; set; }
        public string phone { get; set; }
        public string city { get; set; }

    }
}
