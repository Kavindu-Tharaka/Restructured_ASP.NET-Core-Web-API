﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ancon.Domain.Models
{
    public class ProductCategoryAddModel
    {
        [Required]
        [MaxLength(100)]
        [MinLength(1)]
        public string CategoryName { get; set; }
    }
}