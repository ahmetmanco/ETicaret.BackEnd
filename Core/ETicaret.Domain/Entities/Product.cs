using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _01_ETicaret.Domain.Base;
using _01_ETicaret.Domain_.Entities;

namespace _01_ETicaret.Domain.Entities
{
    public class Product : BaseEntity
    {
        public int Id { get; set; }
        public int Stock { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public List<string>? ProductImage { get; set; }
        public ICollection<Order>? Orders { get; set; }
        public ICollection<ProductImageFile> productImageFiles { get; set; }
    }
}
