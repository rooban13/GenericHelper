using FluentValidation;
using GenericHelper.Demo.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenericHelper.Demo.Core.Validator
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(model => model.Name).NotEmpty().MaximumLength(100);
            RuleFor(model => model.Description).NotEmpty();
        }
    }
}
