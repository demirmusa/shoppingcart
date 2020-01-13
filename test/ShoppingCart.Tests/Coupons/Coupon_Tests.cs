using System;
using System.Collections.Generic;
using ShoppingCart.Business;
using ShoppingCart.Business.Categories;
using ShoppingCart.Business.Coupons;
using Shouldly;
using Xunit;

namespace ShoppingCart.Tests.Coupons
{
    public class Coupon_Tests
    {
        [Theory]
        [InlineData(0, 10, DiscountType.Rate, typeof(ArgumentOutOfRangeException))]
        [InlineData(0, 10, DiscountType.Amount, typeof(ArgumentOutOfRangeException))]
        [InlineData(int.MinValue, 10, DiscountType.Rate, typeof(ArgumentOutOfRangeException))]
        [InlineData(int.MinValue, 10, DiscountType.Amount, typeof(ArgumentOutOfRangeException))]
        [InlineData(10, 0, DiscountType.Rate, typeof(ArgumentOutOfRangeException))]
        [InlineData(10, 0, DiscountType.Amount, typeof(ArgumentOutOfRangeException))]
        [InlineData(10, int.MinValue, DiscountType.Rate, typeof(ArgumentOutOfRangeException))]
        [InlineData(10, int.MinValue, DiscountType.Amount, typeof(ArgumentOutOfRangeException))]
        [InlineData(10, 50.5, DiscountType.Rate)]
        [InlineData(10, 10.5, DiscountType.Amount)]
        public void Constructor_Tests(double minimumAmount, double discount, DiscountType discountType, Type typeOfException = null)
        {
            if (typeOfException != null)
            {
                Should.Throw(() =>
                {
                    new Coupon(minimumAmount, discount, discountType);
                }, typeOfException);
            }
            else
            {
                var coupon = new Coupon(minimumAmount, discount, discountType);
                coupon.MinimumAmount.ShouldBe(minimumAmount);
                coupon.Discount.ShouldBe(discount);
                coupon.DiscountType.ShouldBe(discountType);
            }
        }
    }
}
