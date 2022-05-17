using Application.ViewModels.Products;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ValidationRules.Products
{
    public class CreateProductValidator : AbstractValidator<CreateProduct>
    {
        public CreateProductValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Ürün adı boş olamaz.")
                .MaximumLength(150)
                .MinimumLength(2)
                    .WithMessage("Ürün adı 2 ile 150 karakter aralığında olmaıdır.");

            RuleFor(p => p.UnitInStock)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Stok bilgisi boş geçilemez.")
                .Must(s => s >= 0)
                    .WithMessage("Stok adedi 0'a eşit veya 0'dan büyük olmalıdır.");

            RuleFor(p => p.Price)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Fiyat bilgisi boş geçilemez.")
                 .Must(x => x >= 0)
                    .WithMessage("Fiyat bilgisi 0'a eşit veya 0'dan büyük olmalıdır.");

        }
    }
}
