using System;
using System.Collections;
using System.Collections.Generic;
using ShoppingCart.Business;
using ShoppingCart.Business.Campaigns;
using ShoppingCart.Business.Carts;
using ShoppingCart.Business.Categories;
using ShoppingCart.Business.Coupons;
using ShoppingCart.Business.Products;
using Shouldly;
using Xunit;

namespace ShoppingCart.Tests.Carts
{
    class GetGetDeliveryCostTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            var category1 = new Category("Category 1");
            var category2 = new Category("Category 2");

            var product1 = new Product("Product 1", 10, category1);
            var product2 = new Product("Product 2", 100, category2);

            var testCart1 = new Cart();
            testCart1.AddItem(product1, 2);
            testCart1.AddItem(product1, 4);

            yield return new object[] { testCart1, 100 };

            testCart1.AddItem(product2, 4);
            yield return new object[] { testCart1, 200 };

            testCart1.AddItem(product2, 2);

            testCart1.ApplyCoupons(new Coupon(10, 10, DiscountType.Rate));
            testCart1.ApplyCoupons(new Coupon(100, 10, DiscountType.Rate));
            yield return new object[] { testCart1, 250 };


            var testCart2 = new Cart();
            testCart2.AddItem(product1, 1);

            yield return new object[] { testCart2, 20 };

            testCart2.AddItem(product2, 1);
            testCart2.ApplyCoupons(new Coupon(10, 10, DiscountType.Rate));
            testCart2.ApplyCoupons(new Coupon(100, 10, DiscountType.Rate));

            testCart2.ApplyDiscounts(new Campaign(category1, 10, 10, DiscountType.Rate));
            testCart2.ApplyDiscounts(new Campaign(category2, 10, 10, DiscountType.Rate));
            yield return new object[] { testCart2, 30 };

            testCart2.AddItem(product2, 2);
            yield return new object[] { testCart2, 50 };
            //... You can extend tests cases
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class Carts_GetDeliveryCost_Tests
    {
        [Theory]
        [ClassData(typeof(GetGetDeliveryCostTestData))]
        public void Theory(Cart cart, double expectedAmount)
        {
            throw new NotImplementedException(); //not implemented.Tests cases are not true, needs to be calculated

            //cart.GetDeliveryCost().ShouldBe(expectedAmount);
        }
    }
}
