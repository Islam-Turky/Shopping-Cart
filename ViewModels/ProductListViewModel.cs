﻿using SampleApplication.Models;

namespace SampleApplication.ViewModels
{
    public class ProductListViewModel
    {
        public List<Product>? products;
        public Category? Category { get; set; }
        //public string? param { get; set; }
    }
}
