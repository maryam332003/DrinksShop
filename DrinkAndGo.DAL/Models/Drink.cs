﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinkAndGo.DAL.Models
{
    public class Drink
    {
        public int DrinkId { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public Decimal Price{ get; set; }
        public string ImageUrl { get; set; }
        public string ImageThumbnailUrl { get; set; }
        public bool InStock { get; set; }
        public bool IsPreferredDrink { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }


    }
}
