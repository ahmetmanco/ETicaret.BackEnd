using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using VMs.Product;

namespace _02_ETicaret.Application.Validations.Product
{
    public class CreateProductValidation : AbstractValidator<ProductCreateVM>
    {
        public CreateProductValidation()
        {
            RuleFor(x => x.Name).NotEmpty()
                .NotNull()
                .WithMessage("Ürün adı boş geçilemez")
                .MaximumLength(100)
                .MinimumLength(5)
                .WithMessage("Ürün adı 5 ile 100 karakter arasında olmalıdır");

            RuleFor(x => x.Stock)
                .NotEmpty()
                .NotNull()
                .WithMessage("Stok bilgisi boş geçilemez")
                .Must(x => x >= 0)
                .WithMessage("Stok bilgisi negatif değer olamaz");
            RuleFor(x => x.Price)
                .NotEmpty()
                .NotNull()
                .WithMessage("Fiyat bilgisi boş geçilemez")
                .Must(x => x >= 0)
                .WithMessage("Fiyat bilgisi negatif değer olamaz");
        }
    }
}
