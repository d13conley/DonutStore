using System;
using System.Collections.Generic;

namespace DonutStore.Data.Models
{
    public partial class Donuts
    {
        public int DonutId { get; set; }
        public string Flavor { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
    }
}
