﻿using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SampleApplication.Models
{
    public class Product
    {
        [Key]
        public string PId { get; set; } = string.Empty!;

        [Required]
        public string ProductName { get; set; } = string.Empty!;

        [Required]
        public int Amount { get; set; }
        public string ProductDescription { get; set; } = string.Empty;

        [Required]
        public Category? Category { get; set; }

        [Required]
        public string ProductPrice { get; set; } = string.Empty!;
        public string ProductImg { get; set; } = string.Empty;
    }
}
