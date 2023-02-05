﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Models
{
    [Table("categories")]
    public class Category
    {
        [PrimaryKey]
        public int id { get; set; }
        public string name { get; set; }
        public string imageUrl { get; set; }
    }
}
