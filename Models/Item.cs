﻿using System.ComponentModel.DataAnnotations;

namespace ElectronicsShop.Models
{
    public class Item
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
