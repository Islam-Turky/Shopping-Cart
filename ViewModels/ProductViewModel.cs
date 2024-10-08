﻿using SampleApplication.Models;

namespace SampleApplication.ViewModels
{
    public class ProductViewModel
    {
        public Product? Product { get; set; }
        public IEnumerable<Category>? Category { get; set; }
    }
}
