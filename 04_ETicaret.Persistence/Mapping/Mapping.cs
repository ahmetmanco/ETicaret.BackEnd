using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _01_ETicaret.Domain.Entities;
using _02_ETicaret.Application.VMs.Product;
using AutoMapper;
using VMs.Product;

namespace _04_ETicaret.Persistence_.Mapping
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Product, ProductCreateVM>().ReverseMap();
            CreateMap<Product, ProductUpdateVM>().ReverseMap();
        }
    }
}
