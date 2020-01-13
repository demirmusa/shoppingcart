using System;
using ShoppingCart.Business.Categories;

namespace ShoppingCart.Business.Products
{
    public class Product
    {
        public string Title { get; set; }

        public double Price { get; set; }

        public Category Category { get; set; }

        public Product(string title, double price, Category category)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentNullException(nameof(title));
            }

            if (category == null)
            {
                throw new ArgumentNullException(nameof(category));
            }

            if (price <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(price), $"{nameof(price)} should be more than 0 (zero)");
            }

            Title = title;
            Price = price;
            Category = category;
        }
    }
}
