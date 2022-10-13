using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product_Management_API.Infrastructure.Models
{
    public class ProductModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [ConcurrencyCheck]
        public bool Available { get; set; }

        [Required]
        public int Price { get; set; }
    }
}
