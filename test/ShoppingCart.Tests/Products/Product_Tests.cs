using System;
using System.Collections.Generic;
using System.Text;
using ShoppingCart.Business.Categories;
using ShoppingCart.Business.Products;
using Shouldly;
using Xunit;

namespace ShoppingCart.Tests.Products
{
    public class Product_Tests
    {
        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] {null, 10, new Category("Test"), typeof(ArgumentNullException)},
                new object[] {"", 10, new Category("Test"), typeof(ArgumentNullException)},
                new object[] {" ", 10, new Category("Test"), typeof(ArgumentNullException)},
                new object[] {"Product", 0, new Category("Test"), typeof(ArgumentOutOfRangeException)},
                new object[] {"Product", -1, new Category("Test"), typeof(ArgumentOutOfRangeException)},
                new object[] {"Product", int.MinValue, new Category("Test"), typeof(ArgumentOutOfRangeException)},
                new object[] {"Product", 10, null, typeof(ArgumentNullException)},
                new object[] {"Product", 10, new Category("Test")},
            };

        [Theory]
        [MemberData(nameof(Data))]
        public void Constructor_Theory(string title, double price, Category category, Type typeOfException = null)
        {
            if (typeOfException != null)
            {
                Should.Throw(() =>
                {
                    new Product(title, price, category);
                }, typeOfException);
            }
            else
            {
                var product = new Product(title, price, category);
                product.Title.ShouldBe(title);
                product.Price.ShouldBe(price);
                product.Category.ShouldBe(category);
            }
        }
    }
}
