using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _01_ETicaret.Domain.Base;

namespace _01_ETicaret.Domain_.Entities
{
    public class File : BaseEntity
    {
        public int Id { get; set; }
        [NotMapped] // veritabanında file tablosunda oluşmasına gerek yok
        public override DateTime? UpdateDate { get => base.UpdateDate; set => base.UpdateDate = value; }
        public string Storage { get; set; }
        public string FileName { get; set; }
        public string Path { get; set; }
    }
}
