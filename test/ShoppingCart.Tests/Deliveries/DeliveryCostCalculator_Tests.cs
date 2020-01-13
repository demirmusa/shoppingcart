using System;
using System.Collections;
using System.Collections.Generic;
using ShoppingCart.Business.Carts;
using ShoppingCart.Business.Categories;
using ShoppingCart.Business.Deliveries;
using ShoppingCart.Business.Products;
using Shouldly;
using Xunit;

namespace ShoppingCart.Tests.Deliveries
{
    public class CalculatorTestData : IEnumerable<object[]>
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

            yield return new object[] { 8, 4, 2, testCart1, 100 };

            testCart1.AddItem(product2, 4);
            yield return new object[] { 8, 4, 2, testCart1, 200 };

            testCart1.AddItem(product2, 2);
            yield return new object[] { 8, 4, 2, testCart1, 250 };


            var testCart2 = new Cart();
            testCart2.AddItem(product1, 1);

            yield return new object[] { 8, 4, 2, testCart2, 20 };

            testCart2.AddItem(product2, 1);
            yield return new object[] { 8, 4, 2, testCart2, 30 };

            testCart2.AddItem(product2, 2);
            yield return new object[] { 8, 4, 2, testCart2, 50 };
            //... You can extend tests cases
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class DeliveryCostCalculator_Tests
    {
        [Theory]
        [ClassData(typeof(CalculatorTestData))]
        public void Test_Calculate_For(double costPerDelivery, double costPerProduct, double fixedCost, Cart cart, double expectedCalculatedCost)
        {
            var deliveryCostCalculator = new DeliveryCostCalculator(costPerDelivery, costPerProduct, fixedCost);

            var calculatedCost = deliveryCostCalculator.CalculateFor(cart);

            //calculatedCost.ShouldBe(expectedCalculatedCost);
            throw new NotImplementedException(); //not implemented.Tests cases are not true, needs to be calculated
        }
    }
}
