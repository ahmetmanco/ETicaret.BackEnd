using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_ETicaret.Domain_.Entities
{
    public class InvoiceFile : File
    {
        public decimal Price { get; set; }
    }
}
