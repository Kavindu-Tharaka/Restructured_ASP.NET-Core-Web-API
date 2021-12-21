using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ancon.Domain.Models
{
    public class ProductQueryModel
    {
        public int Id { get; set; }

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
    }
}
