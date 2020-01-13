using System;
using System.Collections.Generic;
using System.Text;
using ShoppingCart.Business;
using ShoppingCart.Business.Campaigns;
using ShoppingCart.Business.Categories;
using Shouldly;
using Xunit;

namespace ShoppingCart.Tests.Campaigns
{
    public class Campaign_Tests
    {
        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] {null, 10, 10, DiscountType.Rate, typeof(ArgumentNullException)},

                new object[] {new Category("Category 1"), 0, 10, DiscountType.Rate, typeof(ArgumentOutOfRangeException)},
                new object[] {new Category("Category 1"), int.MinValue, 10, DiscountType.Rate, typeof(ArgumentOutOfRangeException)},

                new object[] {new Category("Category 1"), 10, 0, DiscountType.Rate, typeof(ArgumentOutOfRangeException)},
                new object[] {new Category("Category 1"), 10, int.MinValue, DiscountType.Rate, typeof(ArgumentOutOfRangeException)},


                new object[] {null, 10, 10, DiscountType.Amount, typeof(ArgumentNullException)},

                new object[] {new Category("Category 1"), 0, 10, DiscountType.Amount, typeof(ArgumentOutOfRangeException)},
                new object[] {new Category("Category 1"), int.MinValue, 10, DiscountType.Amount, typeof(ArgumentOutOfRangeException)},

                new object[] {new Category("Category 1"), 10, 0, DiscountType.Amount, typeof(ArgumentOutOfRangeException)},
                new object[] {new Category("Category 1"), 10, int.MinValue, DiscountType.Amount, typeof(ArgumentOutOfRangeException)},

                new object[] {new Category("Category 1"), 10, 10, DiscountType.Amount},
                new object[] {new Category("Category 1"), 10, 10, DiscountType.Rate}
            };

        [Theory]
        [MemberData(nameof(Data))]
        public void Constructor_Tests(Category category, double discount, int minimumNumberOfItems, DiscountType discountType, Type typeOfException = null)
        {
            if (typeOfException != null)
            {
                Should.Throw(() =>
                {
                    new Campaign(category, discount, minimumNumberOfItems, discountType);
                }, typeOfException);
            }
            else
            {
                var campaign = new Campaign(category, discount, minimumNumberOfItems, discountType);
                campaign.Category.ShouldBe(category);
                campaign.Discount.ShouldBe(discount);
                campaign.MinimumNumberOfItems.ShouldBe(minimumNumberOfItems);
                campaign.DiscountType.ShouldBe(discountType);
            }
        }
    }
}
