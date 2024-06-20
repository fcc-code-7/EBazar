using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBazarSols.Entities
{
    public class Product : BaseEntity
    {
        public decimal Price { get; set; }
        public int CategoryId { get; set; } 
        public Category category { get; set; }
    }
}
