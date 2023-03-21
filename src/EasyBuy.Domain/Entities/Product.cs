using EasyBuy.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyBuy.Domain.Entities
{
    internal class Product
    {
        private Product()
        {

        }

        internal Product(ProductName name, string description, int amount, int? weight)
        {
            Id = new Guid();
            Name = name;
            Description = description;
            Amount = amount;
            Weight = weight;
            HasBeenPlacedInCart = false;
        }

        public Guid Id { get; }
        public ProductName Name { get; }
        public string? Description { get; }
        public bool HasBeenPlacedInCart { get; }
        public AmountOfProducts Amount { get; }
        public int? Weight { get; }
    }

    internal sealed record ProductName
    {
        private const int MinimalLengthOfProductName = 2;
        public string Value { get; }

        public ProductName(string? value)
        {
            if (value is null || value.Length is < MinimalLengthOfProductName)
            {
                throw new InvalidProductNameException(value ?? string.Empty);
            }

            Value = value;
        }

        public static implicit operator string(ProductName productName)
        => productName.Value;

        public static implicit operator ProductName(string value)
            => new(value);
    }

    internal sealed record AmountOfProducts
    {
        public int Value { get; }

        public AmountOfProducts(int value)
        {
            if (value == 0)
            {
                throw new IncorrectAmountOfProductsException(value);
            }

            Value = value;
        }

        public static implicit operator int(AmountOfProducts productName)
        => productName.Value;

        public static implicit operator AmountOfProducts(string value)
            => new(value);
    }
}
