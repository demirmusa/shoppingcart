using System;
using ShoppingCart.Business;
using ShoppingCart.Business.Campaigns;
using ShoppingCart.Business.Carts;
using ShoppingCart.Business.Categories;
using ShoppingCart.Business.Coupons;
using ShoppingCart.Business.Products;

namespace ShoppingCart.ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Category food = new Category("Food");

            Product apple = new Product("Apple", 100.0, food);
            Product almond = new Product("Almonds", 150.0, food);

            Cart cart = new Cart();
            cart.AddItem(apple, 3);
            cart.AddItem(almond, 1);

            Campaign campaign1 = new Campaign(food, 20.0, 3, DiscountType.Rate);

            Campaign campaign2 = new Campaign(food, 50.0, 5, DiscountType.Rate);

            Campaign campaign3 = new Campaign(food, 5, 5, DiscountType.Amount);

            cart.ApplyDiscounts(campaign1, campaign2, campaign3);

            Coupon coupon = new Coupon(100, 10, DiscountType.Rate);

            cart.ApplyCoupon(coupon);
        }
    }
}
