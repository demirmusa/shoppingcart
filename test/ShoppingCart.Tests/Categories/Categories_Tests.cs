using System;
using System.Collections.Generic;
using System.Text;
using ShoppingCart.Business;
using ShoppingCart.Business.Categories;
using ShoppingCart.Business.Coupons;
using Shouldly;
using Xunit;

namespace ShoppingCart.Tests.Categories
{
    public class Categories_Tests
    {
        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] {null, null, typeof(ArgumentNullException)},
                new object[] {"", null, typeof(ArgumentNullException)},
                new object[] {" ", null, typeof(ArgumentNullException)},

                new object[] {null, new Category("Category 1"), typeof(ArgumentNullException)},
                new object[] {"", new Category("Category 1"), typeof(ArgumentNullException)},
                new object[] {" ", new Category("Category 1"), typeof(ArgumentNullException)},

                new object[] {"Product 1", new Category("Category 1")},
                new object[] {"Product 1", null}
            };

        [Theory]
        [MemberData(nameof(Data))]
        public void Constructor_Theory(string title, Category parentCategory, Type typeOfException = null)
        {
            if (typeOfException != null)
            {
                Should.Throw(() =>
                {
                    new Category(title, parentCategory);
                }, typeOfException);
            }
            else
            {
                var category = new Category(title, parentCategory);
                category.Title.ShouldBe(title);
                category.ParentCategory.ShouldBe(parentCategory);
            }
        }
    }
}
