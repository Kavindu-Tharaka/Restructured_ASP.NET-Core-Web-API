﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ancon.Domain.Models
{
    public class ProductAddModel
    {
        [Required]
        [MaxLength(100)]
        [MinLength(1)]
        public string Name { get; set; }

        [Required]
        [Range(0, 99999)]
        public double Price { get; set; }

        [Required]
        [Range(0, 9999)]
        public int UnitsInStock { get; set; }

        // mewa onada? *OW*
        //product eka GET karaddi includes gahala Resturant ekai ProductCategory ekai ganna nam me entity references ona wenawa
        //public ResturantModel Resturant { get; set; }
        //public ProductCategoryModel ProductCategory { get; set; }

        // mewa onada?
        public int ResturantId { get; set; }
        public int ProductCategoryId { get; set; }
    }
}
